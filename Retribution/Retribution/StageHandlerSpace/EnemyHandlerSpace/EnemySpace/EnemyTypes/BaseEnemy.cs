using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Retribution.ScriptReader;
using Retribution.StageHandlerSpace.EnemyHandlerSpace.EnemySpace.EnemyMovementSpace.MovementPatterns;

namespace Retribution.StageHandlerSpace.EnemyHandlerSpace.EnemySpace.EnemyTypes
{
    public abstract class BaseEnemy
    {
        public Vector2 Position;
        public float curr_Health;
        public float Health;
        public float curr_Speed;
        public float Speed;
        public BaseMovement movement;
        public BaseEnemy()
        {
            Position = Vector2.Zero;
            LoadScript();
            this.curr_Health = Health;
            this.curr_Speed = Speed;
            this.movement = new StopGo();
        }

        private void LoadScript()
        {
            GruntInterpreter gruntInterpreter = new GruntInterpreter("GruntBase.json");
            string valsConcated = gruntInterpreter.JsonInterpreter();
            string[] vals = valsConcated.Split(',');

            this.Health = float.Parse(vals[0]);
            this.Speed = float.Parse(vals[1]);
        }
        public void handlePath(BaseEnemy enemy)
        {
            this.movement.Path(enemy);
        }
    }
}
