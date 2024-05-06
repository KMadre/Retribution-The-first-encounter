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
            switch (Globals.getDifficulty())
            {
                case "Easy":
                    speed = 200;
                    break;
                case "Normal":
                    speed = 250;
                    break;
                case "Hard":
                    speed = 300;
                    break;
            }
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
