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
using Retribution.StageHandlerSpace.EnemyHandlerSpace.EnemySpace.EnemyMovementSpace.MovementPatterns;
using Retribution.Projectiles.ProjectileFactories;
using Retribution.Projectiles;
using Retribution.Upgrades;

namespace Retribution.StageHandlerSpace.EnemyHandlerSpace.EnemySpace.EnemyTypes
{
    public class MidBoss : BaseEnemy
    {
        private BaseProjectileFactory secondFactory;
        private float sinecLastSecondary;
        public MidBoss(string Bullet) : base(Bullet)
        {
            LoadScript();
            this.movement = new StopGo();
            secondFactory = new ProjectileFactoryEnemySniper();
            sinecLastSecondary = 0.0f;
        }

        public override void shoot()
        {
            sinceLast += Globals.Time;
            if (secondaryCD())
            {
                ProjectileHandler projectileHandler = ProjectileHandler.GetProjectileHandler();
                Vector2 newPos = this.Position;
                newPos.X += (int)(0.45 * this.Width);
                newPos.Y += this.Height;
                projectileHandler.ProjectileList.Add(factory.MakeEnemyProjectile(newPos));
                projectileHandler.ProjectileList.Add(secondFactory.MakeEnemyProjectile(newPos));
            }
            
        }
        private bool secondaryCD()
        {
            sinecLastSecondary += Globals.Time;
            if (sinecLastSecondary >= baseCD / 2)
            {
                this.sinecLastSecondary = 0f;
                return true;
            }
            return false;
        }

        public override void die()
        {
            UpgradeHandler upgradeHandler = UpgradeHandler.GetUpgradeHandler();
            for(int i = -11; i < 10; i++)
            {
                Vector2 temp = this.Position;
                temp.X += i * 10;
                upgradeHandler.GenerateUpgrade(temp);
            }
            upgradeHandler.GenerateLife(this.Position);
        }

        private void LoadScript()
        {
            GruntInterpreter gruntInterpreter = new GruntInterpreter("MidBossScript.json");
            string valsConcated = gruntInterpreter.JsonInterpreter();
            string[] vals = valsConcated.Split(',');

            this.Health = float.Parse(vals[0]);
            this.curr_Health = float.Parse(vals[0]);
            this.Speed = -1 * float.Parse(vals[1]);
            this.curr_Speed = -1 * float.Parse(vals[1]);
            this.Height = int.Parse(vals[2]);
            this.Width = int.Parse(vals[3]);
            this.initX = int.Parse(vals[4]);
            this.initY = int.Parse(vals[5]);

            this.Position.X = this.initX;
            this.Position.Y = this.initY;

            this.hitbox = new Rectangle(initX, initY, Width, Height);
        }

    }
}
