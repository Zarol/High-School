using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ByteHunter.Entity;
using Microsoft.Xna.Framework;

namespace ByteHunter.Waypoint_System
{
    public abstract class Behavior
    {
        public Enemy Enemy;

        protected Behavior(Enemy Enemy)
        {
            this.Enemy = Enemy;
        }

        public abstract void Update(GameTime gameTime);
    }
}
