using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using ByteHunter.Screen_Manager.Screens;
using ByteHunter.Entity;
using ByteHunter;

namespace ByteHunter
{
    public enum patternType
    {
        toPlayer = 1,
        randomDirection = 2,
        fullCircle = 3,
        halfCircle = 4,
        fourCorners = 5,
        upDown = 6,
        leftRight = 7,
        upDownLeftRight = 8,
        cosine = 9,
        sin = 10,
        tan = 11,
        sec = 12,
        cosec = 13,
        cotan = 14
    }

    public class BulletPattern
    {
        Random ran = new Random();
        Enemy myEnemy;
        float dTime;

        List<EnemyBullet> tempList = new List<EnemyBullet>();

        public BulletPattern(Enemy thisEnemy)
        {
            myEnemy = thisEnemy;
        }
        
        public List<EnemyBullet> createPattern(patternType pattern, float deltaTime, Vector2 playerPosition)
        {
            tempList = new List<EnemyBullet>();
            dTime = deltaTime;

            switch (pattern)
            {
                case patternType.toPlayer:
                    {
                        ToPlayer(playerPosition);
                        break;
                    }
                case patternType.randomDirection:
                    {
                        RandomDirection();
                        break;
                    }
                case patternType.fullCircle:
                    {
                        FullCircle();
                        break;
                    }
                case patternType.halfCircle:
                    {
                        HalfCircle();
                        break;
                    }
                case patternType.fourCorners:
                    {
                        FourCorners();
                        break;
                    }
                case patternType.upDown:
                    {
                        UpDown();
                        break;
                    }
                case patternType.leftRight:
                    {
                        LeftRight();
                        break;
                    }
                case patternType.upDownLeftRight:
                    {
                        UpDownLeftRight();
                        break;
                    }
                case patternType.cosine:
                    {
                        Cosine(playerPosition);
                        break;
                    }
                case patternType.sin:
                    {
                        break;
                    }
                case patternType.tan:
                    {
                        break;
                    }
                case patternType.sec:
                    {
                        break;
                    }
                case patternType.cosec:
                    {
                        break;
                    }
                case patternType.cotan:
                    {
                        break;
                    }
            }

            return tempList;
            
        }

        public List<EnemyBullet> createPattern(patternType pattern, float deltaTime, Vector2 playerPosition, int count)
        {
            tempList = new List<EnemyBullet>();
            dTime = deltaTime;
            for(int i = 0; i <= count; i++)
            {
            switch (pattern)
            {
                case patternType.toPlayer:
                    {
                        ToPlayer(playerPosition);
                        break;
                    }
                case patternType.randomDirection:
                    {
                        RandomDirection();
                        break;
                    }
                case patternType.fullCircle:
                    {
                        FullCircle();
                        break;
                    }
                case patternType.halfCircle:
                    {
                        HalfCircle();
                        break;
                    }
                case patternType.fourCorners:
                    {
                        FourCorners();
                        break;
                    }
                case patternType.upDown:
                    {
                        UpDown();
                        break;
                    }
                case patternType.leftRight:
                    {
                        LeftRight();
                        break;
                    }
                case patternType.upDownLeftRight:
                    {
                        UpDownLeftRight();
                        break;
                    }
                case patternType.cosine:
                    {
                        break;
                    }
                case patternType.sin:
                    {
                        break;
                    }
                case patternType.tan:
                    {
                        break;
                    }
                case patternType.sec:
                    {
                        break;
                    }
                case patternType.cosec:
                    {
                        break;
                    }
                case patternType.cotan:
                    {
                        break;
                    }

            }
            }

            return tempList;

        }

        protected void ToPlayer(Vector2 playerPosition)
        {
            tempList.Add(new EnemyBullet(myEnemy.Viewport, myEnemy.tex2DBulletTexture, myEnemy.Position + myEnemy.Center, 0.0f, myEnemy.Velocity * dTime * 2, patternType.toPlayer, playerPosition)); 
        }

        protected void RandomDirection()
        {
            tempList.Add(new EnemyBullet(myEnemy.Viewport, myEnemy.tex2DBulletTexture, myEnemy.Position + myEnemy.Center, 0.0f, myEnemy.Velocity * dTime * 2, patternType.randomDirection));
        }
        protected void FullCircle()
        {
            for (int i = 0; i <= 360; i+=10)
            {
                tempList.Add(new EnemyBullet(myEnemy.Viewport, myEnemy.tex2DBulletTexture, myEnemy.Position + myEnemy.Center, MathHelper.ToRadians(i), myEnemy.Velocity * dTime * 2, patternType.fullCircle));
            }
        }
        protected void HalfCircle()
        {
            for (int i = -90; i <= 90; i+=10)
            {
                tempList.Add(new EnemyBullet(myEnemy.Viewport, myEnemy.tex2DBulletTexture, myEnemy.Position + myEnemy.Center, MathHelper.ToRadians(i), myEnemy.Velocity * dTime * 2, patternType.fullCircle));
            }
        }
        protected void FourCorners()
        {
            tempList.Add(new EnemyBullet(myEnemy.Viewport, myEnemy.tex2DBulletTexture, myEnemy.Position + myEnemy.Center, (float)Math.PI / 4, myEnemy.Velocity * dTime * 2, patternType.fullCircle));
            tempList.Add(new EnemyBullet(myEnemy.Viewport, myEnemy.tex2DBulletTexture, myEnemy.Position + myEnemy.Center, (float)(3*(Math.PI / 4)), myEnemy.Velocity * dTime * 2, patternType.fullCircle));
            tempList.Add(new EnemyBullet(myEnemy.Viewport, myEnemy.tex2DBulletTexture, myEnemy.Position + myEnemy.Center, (float)(5 * (Math.PI / 4)), myEnemy.Velocity * dTime * 2, patternType.fullCircle));
            tempList.Add(new EnemyBullet(myEnemy.Viewport, myEnemy.tex2DBulletTexture, myEnemy.Position + myEnemy.Center, (float)(7 * (Math.PI / 4)), myEnemy.Velocity * dTime * 2, patternType.fullCircle));
        }

        protected void UpDown()
        {
            tempList.Add(new EnemyBullet(myEnemy.Viewport, myEnemy.tex2DBulletTexture, myEnemy.Position + myEnemy.Center, (float)((Math.PI)/2), myEnemy.Velocity * dTime * 2, patternType.fullCircle));
            tempList.Add(new EnemyBullet(myEnemy.Viewport, myEnemy.tex2DBulletTexture, myEnemy.Position + myEnemy.Center, (float)(3 * (Math.PI / 2)), myEnemy.Velocity * dTime * 2, patternType.fullCircle));
        }
        protected void LeftRight()
        {
            tempList.Add(new EnemyBullet(myEnemy.Viewport, myEnemy.tex2DBulletTexture, myEnemy.Position + myEnemy.Center, (float)0, myEnemy.Velocity * dTime * 2, patternType.fullCircle));
            tempList.Add(new EnemyBullet(myEnemy.Viewport, myEnemy.tex2DBulletTexture, myEnemy.Position + myEnemy.Center, (float)(Math.PI), myEnemy.Velocity * dTime * 2, patternType.fullCircle));
        }
        protected void UpDownLeftRight()
        {
            tempList.Add(new EnemyBullet(myEnemy.Viewport, myEnemy.tex2DBulletTexture, myEnemy.Position + myEnemy.Center, (float)0, myEnemy.Velocity * dTime * 2, patternType.fullCircle));
            tempList.Add(new EnemyBullet(myEnemy.Viewport, myEnemy.tex2DBulletTexture, myEnemy.Position + myEnemy.Center, (float)((Math.PI) / 2), myEnemy.Velocity * dTime * 2, patternType.fullCircle));
            tempList.Add(new EnemyBullet(myEnemy.Viewport, myEnemy.tex2DBulletTexture, myEnemy.Position + myEnemy.Center, (float)(Math.PI), myEnemy.Velocity * dTime * 2, patternType.fullCircle));
            tempList.Add(new EnemyBullet(myEnemy.Viewport, myEnemy.tex2DBulletTexture, myEnemy.Position + myEnemy.Center, (float)(3 * (Math.PI / 2)), myEnemy.Velocity * dTime * 2, patternType.fullCircle));
        }
        protected void Cosine(Vector2 playerPosition)
        {
            for (int i = 0; i < 100; i++)
            {
                if (i % 2 == 0)
                {
                    tempList.Add(new EnemyBullet(myEnemy.Viewport, myEnemy.tex2DBulletTexture, myEnemy.Position + new Vector2(i,i), 0.0f, myEnemy.Velocity * dTime/2, patternType.cosine));
                }
                else
                {
                    tempList.Add(new EnemyBullet(myEnemy.Viewport, myEnemy.tex2DBulletTexture, myEnemy.Position + myEnemy.Center + new Vector2(i, i), 0.0f, myEnemy.Velocity * dTime / 2, patternType.sin));
                }
            }
        }

        protected void Sin()
        {

        }

        protected void Tan()
        {

        }

        protected void Sec()
        {

        }

        protected void Cosec()
        {

        }

        protected void Cotan()
        {

        } 
    }
}
