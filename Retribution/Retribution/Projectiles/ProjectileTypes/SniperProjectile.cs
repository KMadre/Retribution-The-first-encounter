using Microsoft.Xna.Framework;
using Retribution.Projectiles.ProjectilePaths;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retribution.Projectiles.ProjectileTypes
{
    public class SniperProjectile : BaseProjectile
    {
        public SniperProjectile(Vector2 pos, float size, float speed, float dmg, bool FireUp, float spread) : base(pos, size, speed, dmg, FireUp, spread)
        {
            this.path = new AimedProjectilePath();
        }
    }
}
