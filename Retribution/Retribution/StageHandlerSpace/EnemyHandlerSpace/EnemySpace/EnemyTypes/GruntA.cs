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
using Retribution.StageHandlerSpaceSpace.EnemyHandlerSpace.EnemySpace.EnemyMovementSpace.MovementPatterns;

namespace Retribution.StageHandlerSpaceSpace.EnemyHandlerSpace.EnemySpace.EnemyTypes
{
    public class GruntA : BaseEnemy
    {

        public GruntA() : base()
        { 
            LoadScript();
            this.movement = new StopGo();
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
        }
    }
}
