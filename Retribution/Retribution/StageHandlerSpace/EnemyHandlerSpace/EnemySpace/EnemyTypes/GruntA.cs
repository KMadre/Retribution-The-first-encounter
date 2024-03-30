using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Retribution.ScriptReader;
using Retribution.StageHandlerSpace.EnemyHandlerSpace.EnemySpace.EnemyMovementSpace.MovementPatterns;
using Retribution.Projectiles.ProjectileTypes;
using Retribution.Projectiles.ProjectileFactories;

namespace Retribution.StageHandlerSpace.EnemyHandlerSpace.EnemySpace.EnemyTypes
{
    public class GruntA : BaseEnemy
    {

        public GruntA() : base()
        { 
            LoadScript();
            this.movement = new StopGo();
            this.factory = new ProjectileFactoryEnemyDisc();
        }
   
        private void LoadScript()
        {
            GruntInterpreter gruntInterpreter = new GruntInterpreter("GruntAScript.json");
            string valsConcated = gruntInterpreter.JsonInterpreter();
            string[] vals = valsConcated.Split(',');

            this.Health = float.Parse(vals[0]);
            this.curr_Health = float.Parse(vals[0]);
            this.Speed = float.Parse(vals[1]);
            this.curr_Speed = float.Parse(vals[1]);
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
