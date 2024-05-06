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
    public class GruntBFactory
    {
        private string Bullet;
        public GruntBFactory(string Bullet_)
        {
            this.Bullet = Bullet_;
        }

        public GruntB createGrunt()
        {
            GruntB gruntB = new GruntB(Bullet);
            return gruntB;
        }
    }
}
