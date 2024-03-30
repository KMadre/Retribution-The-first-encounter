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
    public abstract class BaseProjectilePath
    {

        public virtual void ProjectilePath(BaseProjectile projectile)
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
            setHitbox(projectile);
        }
        public void setHitbox(BaseProjectile projectile)
        {
            projectile.hitbox.X = (int)projectile.Position.X;
            projectile.hitbox.Y = (int)projectile.Position.Y;
        }
    }
}
