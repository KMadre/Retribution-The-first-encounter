﻿using System;
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
    public class GruntB : BaseEnemy
    {
        public GruntB() : base()
        {
            LoadScript();
            Vector2 pos = new Vector2();
            pos.X = Globals.SCREEN_WIDTH;
            pos.Y = 128;

            this.Position = pos;
            this.movement = new StopGo();
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
        }

    }
}
