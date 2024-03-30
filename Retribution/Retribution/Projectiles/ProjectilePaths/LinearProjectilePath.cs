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
    public class LinearProjectilePath : BaseProjectilePath
    {
        public override void ProjectilePath(BaseProjectile projectile)
        {
            if (projectile.FiredUp)
            {
                Vector2 pos = projectile.Position;
                pos.Y -= projectile.projectileSpeed * (float)Globals.Time;
                projectile.Position = pos;
            }
            else
            {
                Vector2 pos = projectile.Position;
                pos.Y += projectile.projectileSpeed * (float)Globals.Time;
                projectile.Position = pos;
            }

            if (projectile.Spread != 0f)
            {
                Vector2 pos = projectile.Position;
                if (projectile.randomnessDirection == 1)
                {
                    pos.X += (projectile.randomness * projectile.Spread) * (float)Globals.Time;
                    projectile.Position = pos;
                }
                else
                {
                    pos.X -= (projectile.randomness * projectile.Spread) * (float)Globals.Time;
                    projectile.Position = pos;
                }
            }
            setHitbox(projectile);
        }
    }
}
