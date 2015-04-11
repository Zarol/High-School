using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ByteHunter.Entity;
using Microsoft.Xna.Framework;

namespace ByteHunter.Waypoint_System
{
    class LinearBehavior : Behavior
    {
        public LinearBehavior(Enemy Enemy)
            : base(Enemy)
        {
        }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            Vector2 direction = -(Enemy.Position - Enemy.Waypoints.Peek());
            direction.Normalize();
            Enemy.Direction = direction;
        }
    }
}
