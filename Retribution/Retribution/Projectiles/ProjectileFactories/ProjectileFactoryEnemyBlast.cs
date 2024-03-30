using Microsoft.Xna.Framework;
using Retribution.Projectiles.ProjectileTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retribution.Projectiles.ProjectileFactories
{
    public class ProjectileFactoryEnemyBlast : BaseProjectileFactory
    {
        private static ProjectileFactoryEnemyBlast instance;

        private float pos;
        private float speed;
        private float size = 1;
        private float dmg = 1;
        private bool fireUp = false;
        private float spread = 0;

        public ProjectileFactoryEnemyBlast() : base()
        {
            instance = this;
            LoadScript();
        }

        private void LoadScript()
        {
            speed = 250;
        }

        public ProjectileFactoryEnemyBlast GetProjectileFactoryEnemyBlast()
        {
            if (instance == null)
            {
                instance = new ProjectileFactoryEnemyBlast();
            }
            return instance;
        }

        public override BlastProjectile MakeEnemyProjectile(Vector2 pos)
        {
            BlastProjectile blastProjectile = new BlastProjectile(pos, size, speed, dmg, fireUp, spread);
            return blastProjectile;
        }
    }
}
