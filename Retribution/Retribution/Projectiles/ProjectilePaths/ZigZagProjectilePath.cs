using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Retribution.Projectiles.ProjectileTypes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Retribution.Projectiles.ProjectilePaths
{
    public class ZigZagProjectilePath : BaseProjectilePath
    {
        private float spanCD;
        private float sinceCD;
        private bool left;

        public int randomness;
        public ZigZagProjectilePath() : base()
        {
            spanCD = 0.1f;
            sinceCD = 0.0f;
            Random rand = new Random();
            this.randomness = (int)rand.Next() % 2;
            if (randomness == 1)
            {
                this.left = true;
            }
         }
        public override void ProjectilePath(BaseProjectile projectile)
        {
            Vector2 pos = projectile.Position;
            if (projectile.FiredUp)
            {
                pos = projectile.Position;
                pos.Y -= projectile.projectileSpeed/2 * (float)Globals.Time;
                projectile.Position = pos;
            }
            else
            {
                pos = projectile.Position;
                pos.Y += projectile.projectileSpeed/2   * (float)Globals.Time;
                projectile.Position = pos;
            }

            if (left)
            {
                pos.X -= (300) * (float)Globals.Time;
                projectile.Position = pos;
            }
            else
            {
                pos.X += (300) * (float)Globals.Time;
                projectile.Position = pos;
            }
            sinceCD += Globals.Time;
            checkCD();
            
            setHitbox(projectile);
        }

        private void checkCD()
        {
            if (sinceCD >= spanCD)
            {
                left = !left;
                sinceCD = 0.0f;
            }
        }

    }
}
