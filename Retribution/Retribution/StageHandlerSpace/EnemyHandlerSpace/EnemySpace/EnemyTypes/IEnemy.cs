using Retribution.Projectiles.ProjectileTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retribution.StageHandlerSpace.EnemyHandlerSpace.EnemySpace.EnemyTypes
{
    public interface IEnemy
    {
        public void handlePath(BaseEnemy enemy);
        public void gotHit(BaseProjectile projectile);
        public bool isAlive();
        public void shoot();
    }
}
