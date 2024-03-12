using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Retribution.StageHandlerSpace.StageDesignFactorySpace;
using Retribution.StageHandlerSpace.EnemyHandlerSpace;
using Retribution.ScriptReader;
using Retribution.StageHandlerSpace.EnemyHandlerSpace.EnemySpace.EnemyTypes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Retribution.StageHandlerSpace
{
    public class StageHandler
    {
        private int Wave { get; set; }
        private int Wave_amount;
        private List<float> Wave_timers;
        //private List<StageDesignFactory> stageDesigns;
        public List<EnemyHandler> enemyHandlerList;

        Texture2D GruntATexture;
        Texture2D GruntBTexture;
        Texture2D MidBossTexture;

        public StageHandler() 
        {

            this.Wave_timers = new List<float>();
            this.enemyHandlerList = new List<EnemyHandler>();
            this.Wave = 0;
            LoadStageScript();

        }

        public void Update()
        {
            this.Wave_timers[0] -= Globals.Time;
            if(Wave_timers[0] >= 0)
            {
                enemyHandlerList[0].Update();
                enemyHandlerList[0].HandlePathing();
            }
            else
            {
                this.Wave_timers.RemoveAt(0);
                this.enemyHandlerList.RemoveAt(0);
                this.Wave++;
            }
        }

        public void Draw()
        {
            foreach (BaseEnemy enemy in enemyHandlerList[0].enemies)
            {
                if (enemy is GruntA)
                {
                    Globals.SpriteBatch.Draw(GruntATexture, enemy.Position, Color.White);
                }
                if (enemy is GruntB)
                {
                    Globals.SpriteBatch.Draw(GruntBTexture, enemy.Position, Color.White);
                }
                if(enemy is MidBoss)
                {
                    Globals.SpriteBatch.Draw(MidBossTexture, enemy.Position, Color.White);
                }
            }
        }

        public void LoadTextures()
        {
            this.GruntATexture = Globals.Content.Load<Texture2D>("Textures//GruntA");
            this.GruntBTexture = Globals.Content.Load<Texture2D>("Textures//GruntB");
            this.MidBossTexture = Globals.Content.Load<Texture2D>("Textures//MidBoss");
        }

        public void LoadStageScript()
        {
            StageScriptInterpreter stageScriptInterpreter = new StageScriptInterpreter("StageHandlerScript.json");
            string valsConcated = stageScriptInterpreter.JsonInterpreter();
            string[] vals = valsConcated.Split(',');

            this.Wave_amount = vals.Count() / 6;
            for(int i = 0; i < this.Wave_amount; i++)
            {
                float wave_timer = float.Parse(vals[(i * 6) + 0]);
                bool isBoss = bool.Parse(vals[(i * 6) + 2]);
                int enemyCount = int.Parse(vals[(i * 6) + 1]);

                this.Wave_timers.Add(wave_timer+5); // allow for more time that enemies can move off screen

                this.enemyHandlerList.Add(new EnemyHandler(wave_timer, isBoss, enemyCount));
            }
        }

    }
}
