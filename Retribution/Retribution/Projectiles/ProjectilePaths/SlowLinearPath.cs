using Microsoft.Xna.Framework;
using Retribution.Projectiles.ProjectileTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retribution.Projectiles.ProjectilePaths
{
    public class SlowLinearPath : BaseProjectilePath
    {
        public override void ProjectilePath(BaseProjectile projectile)
        {
            if (projectile.FiredUp)
            {
                Vector2 pos = projectile.Position;
                pos.Y -= projectile.projectileSpeed/2 * (float)Globals.Time;
                projectile.Position = pos;
            }
            else
            {
                Vector2 pos = projectile.Position;
                pos.Y += projectile.projectileSpeed/2 * (float)Globals.Time;
                projectile.Position = pos;
            }
            setHitbox(projectile);
        }
    }
}
