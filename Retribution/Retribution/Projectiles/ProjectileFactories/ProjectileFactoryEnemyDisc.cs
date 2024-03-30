using Microsoft.Xna.Framework;
using Retribution.Projectiles.ProjectileTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retribution.Projectiles.ProjectileFactories
{
    public class ProjectileFactoryEnemyDisc : BaseProjectileFactory
    {
        private static ProjectileFactoryEnemyDisc instance;

        private float pos;
        private float speed;
        private float size = 1;
        private float dmg = 1;
        private bool fireUp = false;
        private float spread = 0;

        public ProjectileFactoryEnemyDisc() : base()
        {
            instance = this;
            LoadScript();
        }

        private void LoadScript()
        {
            speed = 250;
        }

        public ProjectileFactoryEnemyDisc GetProjectileFactoryEnemyDisc()
        {
            if(instance == null)
            {
                instance = new ProjectileFactoryEnemyDisc();
            }
            return instance;
        }

        public override DiscProjectile MakeEnemyProjectile(Vector2 pos)
        {
            DiscProjectile discProjectile = new DiscProjectile(pos, size, speed, dmg, fireUp, spread);
            return discProjectile;
        }
    }
}
