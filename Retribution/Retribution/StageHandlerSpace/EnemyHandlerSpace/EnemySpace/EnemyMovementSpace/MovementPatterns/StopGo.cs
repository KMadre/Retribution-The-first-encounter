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
        private TimeSpan spanCD;
        private TimeSpan sinceCD;
        private bool stop;
        public StopGo() : base()
        {
            spanCD = TimeSpan.FromMilliseconds(500);
            stop = false;
            sinceCD = TimeSpan.Zero;
        }
        public override void Path(GameTime gameTime, BaseEnemy enemy)
        {
            sinceCD += gameTime.ElapsedGameTime;
            if (!stop)
            {
                Vector2 pos = enemy.Position;
                pos.X += enemy.curr_Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                enemy.Position = pos;
            }
            checkCD();
        }
        private void checkCD()
        {
            if(sinceCD >= spanCD)
            {
                stop = !stop;
                sinceCD = TimeSpan.Zero;
            }
        }
    }
}
