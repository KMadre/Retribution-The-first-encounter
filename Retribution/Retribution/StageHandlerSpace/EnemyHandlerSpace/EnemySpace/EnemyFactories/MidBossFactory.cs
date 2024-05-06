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
    public class MidBossFactory
    {
        private string Bullet;
        public MidBossFactory()
        {
            this.Bullet = "C";
        }

        public MidBoss createMidBoss()
        {
            MidBoss midBoss = new MidBoss(Bullet);
            return midBoss;
        }
    }
}
