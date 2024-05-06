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
        private bool L;
        private float YAxis;

        private Vector2 pos;
        public GruntAFactory(string Bullet_, bool GruntALR, float GruntAYAxis)
        {
            this.Bullet = Bullet_;

            pos = new Vector2();
            if (L)
            {
                pos.X = -32;
            }
            else
            {
                pos.X = Globals.SCREEN_WIDTH;
            }
            pos.Y = YAxis;
        }

        public GruntA createGrunt()
        {
            GruntA gruntA = new GruntA(Bullet, pos);
            return gruntA;
        }
    }
}
