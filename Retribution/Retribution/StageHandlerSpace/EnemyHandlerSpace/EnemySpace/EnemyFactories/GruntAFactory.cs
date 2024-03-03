using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Retribution.StageHandlerSpaceSpace.EnemyHandlerSpace.EnemySpace.EnemyTypes;

namespace Retribution.StageHandlerSpaceSpace.EnemyHandlerSpace.EnemySpace.EnemyFactories
{
    public class GruntAFactory
    {
        private int entityLimit;
        public GruntAFactory(int entityLimit_)
        {
            this.entityLimit = entityLimit_;
        }

        public GruntA createGrunt()
        {
            GruntA gruntA = new GruntA();
            return gruntA;
        }
    }
}
