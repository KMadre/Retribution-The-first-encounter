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

namespace Retribution.StageHandlerSpace.EnemyHandlerSpace.EnemySpace.EnemyMovementSpace.MovementPatterns
{
    public abstract class BaseMovement
    {
        public BaseMovement() { }
        virtual public void Path(BaseEnemy enemy)
        {
            checkBounds(enemy);
            Vector2 pos = enemy.Position;
            pos.X += enemy.curr_Speed * (float)Globals.Time;
            enemy.Position = pos;
            enemy.hitbox.X = (int)pos.X;
            enemy.hitbox.Y = (int)pos.Y;
        }

        public void checkBounds(BaseEnemy enemy)
        {
            

            if((enemy.Position.X + enemy.Width) + (enemy.curr_Speed*Globals.Time) > Globals.SCREEN_WIDTH)
            {
                enemy.curr_Speed *= -1;
            }
            if ((enemy.Position.X) + (enemy.curr_Speed * Globals.Time) < 0)
            {
                enemy.curr_Speed *= -1;
            }
            
            if(enemy.Position.X < 0)
            {
                enemy.Position.X = 1;
            }else if(enemy.Position.X > Globals.SCREEN_WIDTH)
            {
                enemy.Position.X = Globals.SCREEN_WIDTH - 1;
            }
        }
    }
}
