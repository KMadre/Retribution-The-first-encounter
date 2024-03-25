using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Retribution.StageHandlerSpace.EnemyHandlerSpace.EnemySpace.EnemyFactories;
using Retribution.StageHandlerSpace.EnemyHandlerSpace.EnemySpace.EnemyTypes;

namespace Retribution.StageHandlerSpace.EnemyHandlerSpace
{
    public class EnemyHandler
    {
        private int EnemyLimit;
        public List<BaseEnemy> enemies;
        public GruntAFactory gruntAFactory;
        public GruntBFactory gruntBFactory;
        public MidBossFactory midBossFactory;

        private bool isBossWave;
        private int baseAmountEnemiesWave;
        private int gruntACount;
        private int gruntBCount;
        private float WaveTime;

        private float intervalGruntA;
        private float intervalGruntB;

        private float TimePassedGruntA;
        private float TimePassedGruntB;

        private float WaveRemaining;

        public EnemyHandler(float waveTime, bool isBoss, int amountEnemies)
        {
            this.EnemyLimit = 10; //scriptload later for this

            this.baseAmountEnemiesWave = amountEnemies;
            this.isBossWave = isBoss;
            this.WaveTime = waveTime;

            this.DistributeRatio();
            this.InitializeWaveSpawn();

            this.gruntAFactory = new GruntAFactory(EnemyLimit);
            this.gruntBFactory = new GruntBFactory(EnemyLimit);
            this.midBossFactory = new MidBossFactory();

            this.enemies = new List<BaseEnemy>();

            if (this.isBossWave)
            {
                this.enemies.Add(this.midBossFactory.createMidBoss());
            }
        }

        private void DistributeRatio()
        {
            if(this.baseAmountEnemiesWave > 0)
            {
                Random rand = new Random();
                float RNGRatio = (float)(0.3 + (rand.NextDouble() * 0.4));

                float GruntAPercent = RNGRatio;

                this.gruntACount = (int)(this.baseAmountEnemiesWave * GruntAPercent);
                this.gruntBCount = this.baseAmountEnemiesWave - gruntACount;


            }
        }

        public void WaveUpdate()
        {
            this.WaveRemaining -= Globals.Time;
            this.TimePassedGruntA -= Globals.Time;
            this.TimePassedGruntB -= Globals.Time;
            if(this.WaveRemaining > 0.0f)
            {
                if(TimePassedGruntA <= 0.0 && gruntACount > 0)
                {
                    this.enemies.Add(this.gruntAFactory.createGrunt());
                    this.TimePassedGruntA = this.intervalGruntA;
                    this.gruntACount--;
                }
                if(this.TimePassedGruntB <= 0.0 && gruntBCount > 0)
                {
                    this.enemies.Add(this.gruntBFactory.createGrunt());
                    this.TimePassedGruntB = this.intervalGruntB;
                    this.gruntBCount--;
                }
            }
        }

        private void InitializeWaveSpawn()
        {
            this.intervalGruntA = (this.WaveTime / this.gruntACount);
            this.intervalGruntB = (this.WaveTime / this.gruntBCount);

            this.TimePassedGruntA = 0f;
            this.TimePassedGruntB = 0f;

            this.WaveRemaining = this.WaveTime;
        }

        public void EnemyUpdate()
        {
            foreach(BaseEnemy enemy in enemies)
            {
                enemy.handlePath(enemy);
                enemy.shoot();
            }
        }
    }
}
