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

        private Vector2 pos;
        public GruntBFactory(string Bullet_, bool GruntBLR, float GruntBYAxis)
        {
            this.Bullet = Bullet_;

            pos = new Vector2();
            if (GruntBLR)
            {
                pos.X = -32;
            }
            else
            {
                pos.X = Globals.SCREEN_WIDTH - 32;
            }
            pos.Y = GruntBYAxis;
        }

        public GruntB createGrunt()
        {
            GruntB gruntB = new GruntB(Bullet, pos);
            return gruntB;
        }
    }
}
