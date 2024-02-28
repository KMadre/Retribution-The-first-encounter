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

namespace Retribution.StageHandler.EnemyHandlerSpace
{
    public class EnemyHandler
    {
        private int EnemyLimit;
        public List<BaseEnemy> enemies;
        public GruntAFactory gruntAFactory;
        public GruntBFactory gruntBFactory;

        public Texture2D gruntATexture;
        public Texture2D gruntBTexture;

        public EnemyHandler()
        {
            this.EnemyLimit = 10;
            this.gruntAFactory = new GruntAFactory(EnemyLimit);
            this.gruntBFactory = new GruntBFactory(EnemyLimit);
            this.enemies = new List<BaseEnemy>();
            this.enemies.Add(this.gruntAFactory.createGrunt());
            enemies[0].Position.Y = 200;
            this.enemies.Add(this.gruntBFactory.createGrunt());
            enemies[1].Position.Y = 100;
        }

        public void LoadTextures(ContentManager content)
        {
            this.gruntATexture = content.Load<Texture2D>("Textures//GruntA");
            this.gruntBTexture = content.Load<Texture2D>("Textures//GruntB");
        }

        public void HandlePathing(GameTime gameTime)
        {
            foreach(BaseEnemy enemy in enemies)
            {
                enemy.handlePath(gameTime, enemy);
            }
        }
    }
}
