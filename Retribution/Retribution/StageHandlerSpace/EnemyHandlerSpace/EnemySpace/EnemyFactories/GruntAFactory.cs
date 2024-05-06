using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Retribution.StageHandlerSpace.EnemyHandlerSpace.EnemySpace.EnemyTypes;

namespace Retribution.StageHandlerSpace.EnemyHandlerSpace.EnemySpace.EnemyFactories
{
    public class GruntAFactory
    {
        private string Bullet;
        public GruntAFactory(string Bullet_)
        {
            this.Bullet = Bullet_;
        }

        public GruntA createGrunt()
        {
            GruntA gruntA = new GruntA(Bullet);
            return gruntA;
        }
    }
}
