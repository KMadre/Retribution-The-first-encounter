using Microsoft.Xna.Framework;
using Retribution.StageHandlerSpace.EnemyHandlerSpace.EnemySpace.EnemyTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retribution.StageHandlerSpace.EnemyHandlerSpace.EnemySpace.EnemyMovementSpace.MovementPatterns
{
    public class Blink : BaseMovement
    {
        private float spanCD;
        private float sinceCD;
        public Blink() : base()
        {
            spanCD = 2f;
            sinceCD = 0.0f;
        }
        public override void Path(BaseEnemy enemy)
        {
            sinceCD += Globals.Time;
            
            Vector2 pos = enemy.Position;
            pos.X += enemy.curr_Speed * enemy.speed_modifier * (float)Globals.Time;
            

            if (checkCD())
            {
                pos.X += enemy.curr_Speed*5;
            }
            enemy.Position = pos;
            this.checkBounds(enemy);
        }
        private bool checkCD()
        {
            if (sinceCD >= spanCD)
            {
                sinceCD = 0.0f;
                return true;
            }
            return false;
        }
    }
}
