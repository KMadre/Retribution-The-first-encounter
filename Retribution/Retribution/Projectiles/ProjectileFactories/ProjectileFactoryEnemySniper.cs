using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Retribution.Projectiles.ProjectileTypes;

namespace Retribution.Projectiles.ProjectileFactories
{
    public class ProjectileFactoryEnemySniper : BaseProjectileFactory
    {
        private static ProjectileFactoryEnemySniper instance;

        private float pos;
        private float speed;
        private float size = 1;
        private float dmg = 1;
        private bool fireUp = false;
        private float spread = 0;

        public ProjectileFactoryEnemySniper() : base()
        {
            instance = this;
            LoadScript();
        }

        private void LoadScript()
        {
            speed = 750;
        }

        public ProjectileFactoryEnemySniper GetProjectileFactoryEnemyDisc()
        {
            if (instance == null)
            {
                instance = new ProjectileFactoryEnemySniper();
            }
            return instance;
        }

        public override SniperProjectile MakeEnemyProjectile(Vector2 pos)
        {
            SniperProjectile sniperProjectile = new SniperProjectile(pos, size, speed, dmg, fireUp, spread);
            return sniperProjectile;
        }
    }
}
