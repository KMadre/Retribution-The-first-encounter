using Microsoft.Xna.Framework;
using Retribution.Projectiles.ProjectileTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retribution.Projectiles.ProjectileFactories
{
    public abstract class BaseProjectileFactory
    {
        private BaseProjectileFactory instance;
        public BaseProjectileFactory()
        {
            instance = this;
        }
        public virtual BaseProjectile MakeEnemyProjectile(Vector2 pos)
        {
            return null;
        }
    }
}
