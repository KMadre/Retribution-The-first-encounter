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
using Retribution.StageHandlerSpace.EnemyHandlerSpace.EnemySpace.EnemyMovementSpace.MovementPatterns;

namespace Retribution.StageHandlerSpace.EnemyHandlerSpace.EnemySpace.EnemyMovementSpace.MovementPatterns
{
    public class StopGo : BaseMovement
    {
        private float spanCD;
        private float sinceCD;
        private bool stop;
        public StopGo() : base()
        {
            spanCD = 0.5f;
            stop = false;
            sinceCD = 0.0f;
        }
        public override void Path(BaseEnemy enemy)
        {
            sinceCD += Globals.Time;
            if (!stop)
            {
                Vector2 pos = enemy.Position;
                pos.X += enemy.curr_Speed * (float)Globals.Time;
                enemy.Position = pos;
            }
            checkCD();
            this.checkBounds(enemy);
        }
        private void checkCD()
        {
            if(sinceCD >= spanCD)
            {
                stop = !stop;
                sinceCD = 0.0f;
            }
        }
    }
}
