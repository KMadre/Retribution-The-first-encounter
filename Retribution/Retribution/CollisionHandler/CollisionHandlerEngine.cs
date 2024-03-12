using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Retribution.Projectiles;
using Retribution.StageHandlerSpace.EnemyHandlerSpace;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Retribution.CollisionHandler
{
    public class CollisionHandlerEngine
    {

        public CollisionHandlerEngine()
        {
            Rectangle rectangle = new Rectangle();
            rectangle.Width = 100;
            rectangle.Height = 100;

            Rectangle rectangle2 = new Rectangle();
            rectangle.Width = 100;
            rectangle.Height = 100;

            bool intersect = rectangle.Intersects(rectangle2);
        }
    }
}
