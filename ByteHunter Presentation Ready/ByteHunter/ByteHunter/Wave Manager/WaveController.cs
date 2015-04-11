using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using ByteHunter.Entity;
using Microsoft.Xna.Framework.Graphics;

namespace ByteHunter.Wave_Manager
{
    public class WaveController
    {
        enum Path
        {
            enterBottomLeftExitCurveRight,
            enterBottomRightExitCurveLeft,
            enterTopLeftExitCurveRight,
            enterTopRightExitCurveLeft,
        }
        Player Player;

        Path currentPath;
        Random random;

        float timeBetweenWaves;
        float dtWaves;

        float timeBetweenSpawns;
        float dtSpawns;

        int numEnemies;
        int currentEnemies;
        int totalTypes;
        Queue<Vector2> waypoints;

        List<Enemy> enemies;

        Texture2D enemyTexture1;
        Texture2D enemyTexture2;
        Texture2D enemyTexture3;
        Texture2D enemyTexture4;
        Texture2D enemyTexture5;
        Texture2D enemyBulletTexture;

        Vector2 enemyStartPosition;
        float enemyVelocity;
        float enemyHealth;

        Viewport Viewport;

        public WaveController(Player Player, Texture2D EnemyTexture1, Texture2D EnemyTexture2, Texture2D EnemyTexture3,
            Texture2D EnemyTexture4, Texture2D EnemyTexture5,
            Texture2D EnemyBulletTexture, Viewport Viewport, int Seed)
        {
            this.Player = Player;
            enemyTexture1 = EnemyTexture1;
            enemyTexture2 = EnemyTexture2;
            enemyTexture3 = EnemyTexture3;
            enemyTexture4 = EnemyTexture4;
            enemyTexture5 = EnemyTexture5;
            enemyBulletTexture = EnemyBulletTexture;
            this.Viewport = Viewport;
            timeBetweenWaves = 6000;
            dtWaves = timeBetweenWaves;
            timeBetweenSpawns = 00500;
            dtSpawns = timeBetweenSpawns;
            numEnemies = 0;
            currentEnemies = 0;
            random = new Random(Seed);
            enemies = new List<Enemy>();
            enemyStartPosition = Vector2.Zero;
            enemyVelocity = .4f;
            enemyHealth = 10f;
            waypoints = new Queue<Vector2>();
            totalTypes = 4;
            numEnemies = 10;
        }

        public void Update(GameTime gameTime)
        {
            dtWaves += gameTime.ElapsedGameTime.Milliseconds;
            dtSpawns += gameTime.ElapsedGameTime.Milliseconds;

            if (dtWaves > timeBetweenWaves)
            {
                //enemies = null;
                //enemies = new List<Enemy>();
                //waypoints = null;
                //waypoints = new Queue<Vector2>();
                currentEnemies = 0;
                switch (random.Next(totalTypes))
                {
                    case 0:
                        currentPath = Path.enterBottomLeftExitCurveRight;
                        break;
                    case 1:
                        currentPath = Path.enterBottomRightExitCurveLeft;
                        break;
                    case 2:
                        currentPath = Path.enterTopLeftExitCurveRight;
                        break;
                    case 3:
                        currentPath = Path.enterTopRightExitCurveLeft;
                        break;
                }

                switch (currentPath)
                {
                    case Path.enterBottomLeftExitCurveRight:
                        enemyStartPosition = percentHelper(20, 110);
                        waypoints.Enqueue(percentHelper(20, 100));
                        waypoints.Enqueue(percentHelper(20, 59));
                        waypoints.Enqueue(percentHelper(25, 45));
                        waypoints.Enqueue(percentHelper(31.5f, 32));
                        waypoints.Enqueue(percentHelper(45, 24));
                        waypoints.Enqueue(percentHelper(110, 24));
                        break;
                    case Path.enterBottomRightExitCurveLeft:
                        enemyStartPosition = percentHelper(80, 110);
                        waypoints.Enqueue(percentHelper(80, 100));
                        waypoints.Enqueue(percentHelper(80, 59));
                        waypoints.Enqueue(percentHelper(75, 45));
                        waypoints.Enqueue(percentHelper(69.5f, 32));
                        waypoints.Enqueue(percentHelper(55, 24));
                        waypoints.Enqueue(percentHelper(-10, 24));
                        break;
                    case Path.enterTopLeftExitCurveRight:
                        enemyStartPosition = percentHelper(20, -10);
                        waypoints.Enqueue(percentHelper(20, 0));
                        waypoints.Enqueue(percentHelper(20, 41));
                        waypoints.Enqueue(percentHelper(25, 55));
                        waypoints.Enqueue(percentHelper(31.5f, 68));
                        waypoints.Enqueue(percentHelper(45, 76));
                        waypoints.Enqueue(percentHelper(110, 76));
                        break;
                    case Path.enterTopRightExitCurveLeft:
                        enemyStartPosition = percentHelper(80, -10);
                        waypoints.Enqueue(percentHelper(80, 0));
                        waypoints.Enqueue(percentHelper(80, 41));
                        waypoints.Enqueue(percentHelper(75, 55));
                        waypoints.Enqueue(percentHelper(69.5f, 68));
                        waypoints.Enqueue(percentHelper(55, 76));
                        waypoints.Enqueue(percentHelper(-10, 76));
                        break;
                }
                dtWaves = 0;
            }

            if (dtSpawns > timeBetweenSpawns)
            {
                if (currentEnemies < numEnemies)
                {
                    Random ran = new Random();
                    switch (ran.Next(1, 6))
                    {
                        case 1:
                            enemies.Add(new Enemy(enemyTexture1, enemyStartPosition, enemyVelocity, enemyHealth, true, Viewport, enemyBulletTexture));
                            break;
                        case 2:
                            enemies.Add(new Enemy(enemyTexture2, enemyStartPosition, enemyVelocity, enemyHealth, true, Viewport, enemyBulletTexture));
                            break;
                        case 3:
                            enemies.Add(new Enemy(enemyTexture3, enemyStartPosition, enemyVelocity, enemyHealth, true, Viewport, enemyBulletTexture));
                            break;
                        case 4:
                            enemies.Add(new Enemy(enemyTexture4, enemyStartPosition, enemyVelocity, enemyHealth, true, Viewport, enemyBulletTexture));
                            break;
                        case 5:
                            enemies.Add(new Enemy(enemyTexture5, enemyStartPosition, enemyVelocity, enemyHealth, true, Viewport, enemyBulletTexture));
                            break;
                    }
                    enemies[enemies.Count - 1].setPath(waypoints);
                    currentEnemies++;
                    dtSpawns = 0;
                }
            }

            foreach (Enemy enemy in enemies)
                enemy.Update(gameTime, ref Player);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Enemy enemy in enemies)
                enemy.Draw(spriteBatch);
        }

        private Vector2 percentHelper(float percentX, float percentY)
        {
            Vector2 definedPoint = Vector2.Zero;
            definedPoint.X = Viewport.Width * (percentX / 100);
            definedPoint.Y = Viewport.Height * (percentY / 100);
            return definedPoint;
        }

        public List<Enemy> getEnemyList()
        {
            return enemies;
        }
    }
}
