using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Retribution.StageHandlerSpace.EnemyHandlerSpace.EnemySpace.EnemyTypes;

namespace Retribution.StageHandlerSpace.EnemyHandlerSpace.EnemySpace.EnemyFactories
{
    public class GruntAFactory
    {
        private int entityLimit;
        public Texture2D Texture;
        public GruntAFactory(int entityLimit_)
        {
            this.entityLimit = entityLimit_;
        }

        public void LoadTexture(ContentManager content)
        {
            this.Texture = content.Load<Texture2D>("Textures//GruntA");
        }

        public GruntA createGrunt()
        {
            GruntA gruntA = new GruntA();
            return gruntA;
        }
    }
}
