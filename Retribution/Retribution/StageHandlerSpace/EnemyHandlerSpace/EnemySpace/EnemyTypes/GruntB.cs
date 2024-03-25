using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Retribution.Projectiles.ProjectileFactories;
using Retribution.ScriptReader;
using Retribution.StageHandlerSpace.EnemyHandlerSpace.EnemySpace.EnemyMovementSpace.MovementPatterns;

namespace Retribution.StageHandlerSpace.EnemyHandlerSpace.EnemySpace.EnemyTypes
{
    public class GruntB : BaseEnemy
    {
        public GruntB() : base()
        {
            LoadScript();
            this.movement = new StopGo();
            this.factory = new ProjectileFactoryEnemySniper();
        }

        private void LoadScript()
        {
            GruntInterpreter gruntInterpreter = new GruntInterpreter("GruntBScript.json");
            string valsConcated = gruntInterpreter.JsonInterpreter();
            string[] vals = valsConcated.Split(',');

            this.Health = float.Parse(vals[0]);
            this.curr_Health = float.Parse(vals[0]);
            this.Speed = -1*float.Parse(vals[1]);
            this.curr_Speed = -1*float.Parse(vals[1]);
            this.Height = int.Parse(vals[2]);
            this.Width = int.Parse(vals[3]);
            this.initX = int.Parse(vals[4]);
            this.initY = int.Parse(vals[5]);

            this.Position.X = this.initX;
            this.Position.Y = this.initY;

            this.hitbox = new Rectangle(initX, initY, Width, Height);
        }

    }
}
