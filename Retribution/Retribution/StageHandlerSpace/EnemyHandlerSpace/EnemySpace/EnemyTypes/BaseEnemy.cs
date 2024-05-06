using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Retribution.ScriptReader;
using Retribution.StageHandlerSpace.EnemyHandlerSpace.EnemySpace.EnemyMovementSpace.MovementPatterns;
using Retribution.Projectiles.ProjectileTypes;
using Retribution.Projectiles;
using Retribution.Projectiles.ProjectileFactories;
using Retribution.Upgrades;

namespace Retribution.StageHandlerSpace.EnemyHandlerSpace.EnemySpace.EnemyTypes
{
    public abstract class BaseEnemy : IEnemy
    {
        public Vector2 Position;
        public float curr_Health;
        public float Health;
        public float curr_Speed;
        public float Speed;
        public int Height;
        public int Width;
        public int initX;
        public int initY;

        public float health_modifier;
        public float speed_modifier;
        public float baseCDmultiplier;

        public float sinceLast;
        public float baseCD;

        public BaseMovement movement;
        public BaseProjectileFactory factory;

        public Rectangle hitbox;
        public BaseEnemy(string projectileType)
        {
            LoadScript();
            Position.X = initX;
            Position.Y = initY;
            this.curr_Health = Health;
            this.curr_Speed = Speed;
            this.sinceLast = 0.0f;
            this.movement = new StopGo();
            this.hitbox = new Rectangle(initX, initY, Width, Height);
            switch (projectileType)
            {
                case "A":
                    this.factory = new ProjectileFactoryEnemySniper();
                    break;
                case "B":
                    this.factory = new ProjectileFactoryEnemyDisc();
                    break;
                case "C":
                    this.factory = new ProjectileFactoryEnemyBlast(); 
                    break;
            }
            difficultySettings();
        }

        private void LoadScript()
        {
            GruntInterpreter gruntInterpreter = new GruntInterpreter("GruntBase.json");
            string valsConcated = gruntInterpreter.JsonInterpreter();
            string[] vals = valsConcated.Split(',');

            this.Health = float.Parse(vals[0]);
            this.Speed = float.Parse(vals[1]);
            this.Height = int.Parse(vals[2]);
            this.Width = int.Parse(vals[3]);
            this.initX = int.Parse(vals[4]);
            this.initY = int.Parse(vals[5]);
            this.baseCD = float.Parse(vals[6]);
        }
        public void handlePath(BaseEnemy enemy)
        {
            this.movement.Path(enemy);
            this.hitbox.X = (int)this.Position.X;
            this.hitbox.Y = (int)this.Position.Y;
        }

        public void gotHit(BaseProjectile projectile)
        {
            this.Health -= projectile.damage;
        }

        public bool isAlive()
        {
            if(this.Health > 0)
            {
                return true;
            }
            else
            {
                die();
                return false;
            }
        }

        public virtual void die()
        {
            UpgradeHandler upgradeHandler = UpgradeHandler.GetUpgradeHandler();
            upgradeHandler.GenerateUpgrade(this.Position);
        }

        public virtual void shoot()
        {
            if(factory != null)
            {
                sinceLast += Globals.Time;
                if (checkCD())
                {
                    ProjectileHandler projectileHandler = ProjectileHandler.GetProjectileHandler();
                    Vector2 newPos = this.Position;
                    newPos.X += (int)(0.45 * this.Width);
                    newPos.Y += this.Height;
                    projectileHandler.ProjectileList.Add(factory.MakeEnemyProjectile(newPos));
                }
                
            }
        }

        public bool checkCD()
        {
            if (sinceLast >= baseCD)
            {
                this.sinceLast = 0f;
                return true;
            }
            return false;
        }

        private void difficultySettings()
        {
            switch (Globals.getDifficulty())
            {
                case "Easy":
                    health_modifier = 0.5f;
                    speed_modifier = 0.5f;
                    baseCDmultiplier = 0.5f;
                    break;
                case "Normal":
                    health_modifier = 1f;
                    speed_modifier = 1f;
                    baseCDmultiplier = 1f;
                    break;
                case "Hard":
                    health_modifier = 1.5f;
                    speed_modifier = 1.5f;
                    baseCDmultiplier = 1.5f;
                    break;
            }
        }
    }
}
