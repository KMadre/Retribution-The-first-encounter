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
        Texture2D FinalBossTexture;
        public StageHandler() 
        {

            this.Wave_timers = new List<float>();
            this.enemyHandlerList = new List<EnemyHandler>();
            this.Wave = 0;
            LoadStageScript();

        }

        public void Update()
        {
            if (Wave_timers.Count == 0)
            {
                Globals.PauseGame();
            }
            this.Wave_timers[0] -= Globals.Time;
            if(Wave_timers[0] >= 0)
            {
                enemyHandlerList[0].WaveUpdate();
                enemyHandlerList[0].EnemyUpdate();
            }
            else
            {
                this.Wave_timers.RemoveAt(0);
                this.enemyHandlerList.RemoveAt(0);
                this.Wave++;
            }
            if(Wave_timers.Count == 0)
            {
                Globals.PauseGame();
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
                if(enemy is FinalBoss)
                {
                    Globals.SpriteBatch.Draw(FinalBossTexture, enemy.Position, Color.White);
                }
            }
        }

        public void LoadTextures()
        {
            this.GruntATexture = Globals.Content.Load<Texture2D>("Textures//GruntA");
            this.GruntBTexture = Globals.Content.Load<Texture2D>("Textures//GruntB");
            this.MidBossTexture = Globals.Content.Load<Texture2D>("Textures//MidBoss");
            this.FinalBossTexture = Globals.Content.Load<Texture2D>("Textures//FinalBoss");
        }

        public void LoadStageScript()
        {
            StageScriptInterpreter stageScriptInterpreter = new StageScriptInterpreter("StageHandlerScript.json");
            string valsConcated = stageScriptInterpreter.JsonInterpreter();
            string[] vals = valsConcated.Split(',');
            string dif = vals[0];
            Globals.setDifficulty(dif);
            this.Wave_amount = (vals.Count()-1) / 16;
            for(int i = 0; i < this.Wave_amount; i++)
            {
                float wave_timer = float.Parse(vals[(i * 16) + 1]);
                int enemyACount = int.Parse(vals[(i * 16) + 2]);
                string GruntABulletType = vals[(i * 16) + 3];
                float GruntAInterval = float.Parse(vals[(i * 16) + 4]);
                bool GruntALeft = bool.Parse(vals[(i * 16) + 5]);
                float GruntAYAxis = float.Parse(vals[(i * 16) + 6]);
                int enemyBCount = int.Parse(vals[(i * 16) + 7]);
                string GruntBBulletType = vals[(i * 16) + 8];
                float GruntBInterval = float.Parse(vals[(i * 16) + 9]);
                bool GruntBLeft = bool.Parse(vals[(i * 16) + 10]);
                float GruntBYAxis = float.Parse(vals[(i * 16) + 11]);
                bool isMidBoss = bool.Parse(vals[(i * 16) + 12]);
                bool isFinalBoss = bool.Parse(vals[(i * 16) + 13]);

                this.Wave_timers.Add(wave_timer);

                this.enemyHandlerList.Add(new EnemyHandler(
                    wave_timer, 
                    isMidBoss, 
                    isFinalBoss, 
                    enemyACount, 
                    enemyBCount, 
                    GruntABulletType, 
                    GruntBBulletType,
                    GruntAInterval,
                    GruntBInterval,
                    GruntALeft,
                    GruntBLeft,
                    GruntAYAxis,
                    GruntBYAxis
                    ));
            }
        }

    }
}
