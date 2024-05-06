using Microsoft.Xna.Framework;
using Retribution.ScriptReader;
using Retribution.StageHandlerSpace.EnemyHandlerSpace.EnemySpace.EnemyMovementSpace.MovementPatterns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Retribution.Projectiles.ProjectileFactories;
using Retribution.Projectiles;

namespace Retribution.StageHandlerSpace.EnemyHandlerSpace.EnemySpace.EnemyTypes
{
    public class FinalBoss : BaseEnemy
    {

        private BaseProjectileFactory secondFactory;
        private BaseProjectileFactory thirdFactory;

        private float sinecLastSecondary;
        private float sinecLastTrenary;


        public FinalBoss(string Bullet) : base(Bullet)
        {
            LoadScript();
            this.movement = new Blink();
            secondFactory = new ProjectileFactoryEnemySniper();
            thirdFactory = new ProjectileFactoryEnemyDisc();
            sinecLastSecondary = 0.0f;
        }

        private void LoadScript()
        {
            GruntInterpreter gruntInterpreter = new GruntInterpreter("FinalBossScript.json");
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

        public override void shoot()
        {
            sinceLast += Globals.Time;
            if (checkCD())
            {
                ProjectileHandler projectileHandler = ProjectileHandler.GetProjectileHandler();
                Vector2 origin = this.Position;
                origin.X += 64;
                origin.Y += 32;
                int numProjectiles = 16;
                float radius = 50; 

                for (int i = 0; i < numProjectiles; i++)
                {
                    float angle = i * (360f / numProjectiles);
                    float radians = MathHelper.ToRadians(angle);

                    Vector2 circlePos = new Vector2(
                        origin.X + (float)(radius * Math.Cos(radians)),
                        origin.Y + (float)(radius * Math.Sin(radians))
                    );
                    projectileHandler.ProjectileList.Add(factory.MakeEnemyProjectile(circlePos));
                }                
            }
            if (secondaryCD())
            {
                ProjectileHandler projectileHandler = ProjectileHandler.GetProjectileHandler();
                Vector2 newPos = this.Position;
                newPos.X += (int)(0.45 * this.Width);
                newPos.Y += this.Height;
                projectileHandler.ProjectileList.Add(secondFactory.MakeEnemyProjectile(newPos));
            }
            if (trenaryCD())
            {
                ProjectileHandler projectileHandler = ProjectileHandler.GetProjectileHandler();
                Vector2 newPos = this.Position;
                newPos.X += (int)(0.45 * this.Width);
                newPos.Y += this.Height;
                projectileHandler.ProjectileList.Add(thirdFactory.MakeEnemyProjectile(newPos));
            }
        }

        private bool secondaryCD()
        {
            sinecLastSecondary += Globals.Time;
            if (sinecLastSecondary >= baseCD/3)
            {
                this.sinecLastSecondary = 0f;
                return true;
            }
            return false;
        }

        private bool trenaryCD()
        {
            sinecLastTrenary += Globals.Time;
            if (sinecLastTrenary >= baseCD/1.5)
            {
                this.sinecLastTrenary = 0f;
                return true;
            }
            return false;
        }
    }
}
