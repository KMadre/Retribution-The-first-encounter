using Microsoft.Xna.Framework;
using Retribution.PlayerRelated;
using Retribution.Projectiles.ProjectileTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retribution.Projectiles.ProjectilePaths
{
    public class AimedProjectilePath : BaseProjectilePath
    {
        private Vector2 targetPosition;
        private Vector2 direction;
        private bool hasTarget;
        public AimedProjectilePath() : base()
        {
            Player player = Player.GetPlayer();
            Vector2 pos = player.Position;
            pos.X += 16;
            pos.Y += 16;
            targetPosition = pos;
            hasTarget = false;
        }
        public override void ProjectilePath(BaseProjectile projectile)
        {
            if (!hasTarget)
            {
                direction = Vector2.Normalize(targetPosition - projectile.Position);
                hasTarget = true;
            }
            

            projectile.Position += direction * projectile.projectileSpeed * (float)Globals.Time;

            setHitbox(projectile);
        }
    }
}
