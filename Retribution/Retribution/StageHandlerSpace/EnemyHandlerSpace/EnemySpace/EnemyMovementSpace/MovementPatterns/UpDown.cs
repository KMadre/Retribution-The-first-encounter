using Microsoft.Xna.Framework;
using Retribution.StageHandlerSpace.EnemyHandlerSpace.EnemySpace.EnemyTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retribution.StageHandlerSpace.EnemyHandlerSpace.EnemySpace.EnemyMovementSpace.MovementPatterns
{
    public class UpDown : BaseMovement
    {
        private float spanCD;
        private float sinceCD;
        private bool up;
        public UpDown() : base()
        {
            spanCD = 0.5f;
            up = false;
            sinceCD = 0.0f;
        }
        public override void Path(BaseEnemy enemy)
        {
            sinceCD += Globals.Time;
            Vector2 pos = enemy.Position;
            pos.X += enemy.curr_Speed/2 * enemy.speed_modifier * (float)Globals.Time;
            if (up)
            {
                pos.Y += enemy.curr_Speed/2 * enemy.speed_modifier * (float)Globals.Time;
            }
            else
            {
                pos.Y -= enemy.curr_Speed/2 * enemy.speed_modifier * (float)Globals.Time;
            }
            enemy.Position = pos;
            checkCD();
            this.checkBounds(enemy);
        }
        private void checkCD()
        {
            if (sinceCD >= spanCD)
            {
                up = !up;
                sinceCD = 0.0f;
            }
        }
    }
}
