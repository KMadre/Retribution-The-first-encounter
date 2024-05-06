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
        public FinalBossFactory finalBossFactory;

        private bool isMidBossWave;
        private bool isFinalBossWave;
        private int gruntACount;
        private int gruntBCount;
        private float WaveTime;

        private float intervalGruntA;
        private float intervalGruntB;

        private float TimePassedGruntA;
        private float TimePassedGruntB;

        private float WaveRemaining;

        public EnemyHandler(float waveTime, 
            bool isMidBoss,
            bool isFinalBoss,
            int enemyACount,
            int enemyBCount,
            string GruntABulletType,
            string GruntBBulletType,
            float GruntAInterval,
            float GruntBInterval,
            bool GruntALR,
            bool GruntBLR,
            float GruntAYAxis,
            float GruntBYAxis)
        {
            this.EnemyLimit = 10; //scriptload later for this

            this.gruntACount = enemyACount;
            this.gruntBCount = enemyBCount;
            this.intervalGruntA = GruntAInterval;
            this.intervalGruntB = GruntBInterval;
            this.isMidBossWave = isMidBoss;
            this.isFinalBossWave = isFinalBoss;
            this.WaveTime = waveTime;

            this.InitializeWaveSpawn();

            this.gruntAFactory = new GruntAFactory(GruntABulletType, GruntALR, GruntAYAxis);
            this.gruntBFactory = new GruntBFactory(GruntBBulletType, GruntBLR, GruntBYAxis);
            this.midBossFactory = new MidBossFactory();
            this.finalBossFactory = new FinalBossFactory();

            this.enemies = new List<BaseEnemy>();

            if (this.isMidBossWave)
            {
                this.enemies.Add(this.midBossFactory.createMidBoss());
            }
            if (this.isFinalBossWave)
            {
                this.enemies.Add(this.finalBossFactory.createMidBoss());
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
