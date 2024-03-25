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

        private float sinceLast;
        private float baseCD;

        public BaseMovement movement;
        public BaseProjectileFactory factory;

        public Rectangle hitbox;
        public BaseEnemy()
        {
            LoadScript();
            Position.X = initX;
            Position.Y = initY;
            this.curr_Health = Health;
            this.curr_Speed = Speed;
            this.sinceLast = 0.0f;
            this.movement = new StopGo();
            this.hitbox = new Rectangle(initX, initY, Width, Height);
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
                return false;
            }
        }
        public void shoot()
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

        private bool checkCD()
        {
            if (sinceLast >= baseCD)
            {
                this.sinceLast = 0f;
                return true;
            }
            return false;
        }
    }
}
