using Retribution.StageHandlerSpace.EnemyHandlerSpace.EnemySpace.EnemyTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retribution.StageHandlerSpace.EnemyHandlerSpace.EnemySpace.EnemyFactories
{
    public class FinalBossFactory
    {
        private string Bullet;
        public FinalBossFactory()
        {
            this.Bullet = "C";
        }

        public FinalBoss createMidBoss()
        {
            FinalBoss finalBoss = new FinalBoss(Bullet);
            return finalBoss;
        }
    }
}
