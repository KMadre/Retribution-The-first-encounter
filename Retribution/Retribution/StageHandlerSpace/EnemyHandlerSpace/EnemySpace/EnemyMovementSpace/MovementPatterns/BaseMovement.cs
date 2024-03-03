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

namespace Retribution.StageHandlerSpaceSpace.EnemyHandlerSpace.EnemySpace.EnemyMovementSpace.MovementPatterns
{
    public abstract class BaseMovement
    {
        public BaseMovement() { }
        virtual public void Path(BaseEnemy enemy)
        {
            Vector2 pos = enemy.Position;
            pos.X += enemy.curr_Speed * (float)Globals.Time;
            enemy.Position = pos;
        }
    }
}
