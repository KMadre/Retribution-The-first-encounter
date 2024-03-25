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
        private int entityLimit;
        public FinalBossFactory(int entityLimit_ = 1)
        {
            this.entityLimit = entityLimit_;
        }

        public FinalBoss createMidBoss()
        {
            FinalBoss finalBoss = new FinalBoss();
            return finalBoss;
        }
    }
}
