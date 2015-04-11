using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using ByteHunter.Waypoint_System;

namespace ByteHunter.Entity
{
    public enum WaypointBehavior
    {
        Linear,
        Steering,
    }

    public class Enemy : Unit
    {
        const float AtDestinationTolerance = 5f;

        Behavior currentBehavior;

        public WaypointBehavior BehaviorType
        {
            get { return behaviorType; }
            set
            {
                if (behaviorType != value || currentBehavior == null)
                {
                    behaviorType = value;
                    switch (behaviorType)
                    {
                        case WaypointBehavior.Linear:
                            currentBehavior = new LinearBehavior(this);
                            break;
                        //case WaypointBehavior.Steering:
                            //throw new NotImplementedException();
                            //break;
                        default:
                            break;
                    }
                }
            }
        }
        WaypointBehavior behaviorType;

        public Vector2 Direction
        {
            get { return direction; }
            set { direction = value; }
        }
        protected Vector2 direction;

        public Queue<Vector2> Waypoints
        {
            get { return waypoints; }
        }
        private Queue<Vector2> waypoints;

        public float DistanceToDestination
        {
            get { return Vector2.Distance(Position, waypoints.Peek()); }
        }

        public bool AtDestination
        {
            get { return DistanceToDestination < AtDestinationTolerance; }
        }

        public List<EnemyBullet> activeBullets;
        public BulletPattern bulletPattern;
        public Texture2D tex2DBulletTexture;
        public patternType thisPattern;
        public static Random ran = new Random();

        public Enemy(Texture2D Texture, Vector2 Position, float Velocity, float Health, bool isActive, Viewport Viewport, Texture2D bulletTexture)
        {
            this.Texture = Texture;
            halfHeight = Texture.Height / 2;
            halfWidth = Texture.Width / 2;
            this.Position = Position;
            this.Velocity = Velocity;
            this.Health = Health;
            this.isActive = true;
            this.Viewport = Viewport;
            Center = new Vector2(Texture.Width / 2, Texture.Height / 2);
            waypoints = new Queue<Vector2>();
            behaviorType = WaypointBehavior.Linear;
            currentBehavior = new LinearBehavior(this);

            activeBullets = new List<EnemyBullet>();
            bulletPattern = new BulletPattern(this);
            tex2DBulletTexture = bulletTexture;
            thisPattern = (patternType)ran.Next(0, 9);
        }

        public void setPath(Queue<Vector2> waypoints)
        {
            foreach (Vector2 vector in waypoints)
                this.waypoints.Enqueue(vector);
        }

        public List<EnemyBullet> Update(GameTime gameTime, ref Player player)
        {
            float deltaTime = gameTime.ElapsedGameTime.Milliseconds;

            if (waypoints.Count > 0)
            {
                if (AtDestination)
                {
                    waypoints.Dequeue();
                    activeBullets.AddRange(bulletPattern.createPattern(thisPattern, deltaTime, player.Position));
                    thisPattern = (patternType)ran.Next(0, 9);
                    return activeBullets;
                }
                else
                {
                    if (currentBehavior != null)
                    {
                        currentBehavior.Update(gameTime);
                    }
                    Position += (Direction * Velocity * deltaTime);
                }
            }

            return new List<EnemyBullet>();
        }

        public override void Move(float deltaTime)
        {
            throw new NotImplementedException();
        }

        public override void Destroy()
        {
            if (Health == 0)
            {
                isActive = false;
            }
        }

        public override void Shoot(float deltaTime)
        {
            throw new NotImplementedException();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (isActive == true)
                spriteBatch.Draw(Texture, Position, null, Color.White, (float)Math.PI, Center, 1f, SpriteEffects.None, 0f);
            }
        
        }
    }
