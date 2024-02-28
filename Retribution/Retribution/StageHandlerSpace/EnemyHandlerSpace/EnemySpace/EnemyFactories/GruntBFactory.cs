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
    public class GruntBFactory
    {

        public Texture2D Texture;
        private int entityLimit;
        public GruntBFactory(int entityLimit_)
        {
            this.entityLimit = entityLimit_;
        }

        public GruntB createGrunt()
        {
            GruntB gruntB = new GruntB();
            return gruntB;
        }

        public void LoadTexture(ContentManager content)
        {
            this.Texture = content.Load<Texture2D>("Textures//GruntB");
        }

    }
}
