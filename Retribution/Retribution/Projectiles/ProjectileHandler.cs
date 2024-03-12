using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Retribution.StageHandlerSpace.EnemyHandlerSpace;
using Retribution.PlayerRelated;
using Retribution.Projectiles.ProjectileTypes;
using Retribution.StageHandlerSpace.EnemyHandlerSpace.EnemySpace.EnemyTypes;

namespace Retribution.Projectiles
{
    public class ProjectileHandler
    {
        public List<BaseProjectile> ProjectileList;
        public Texture2D PlayerProjectileTexture;
        public Texture2D SniperProjectileTexture;
        public Texture2D BlastProjectileTexture;
        public Texture2D LazerProjectileTexture;
        // need a script loader with the interpeter I already made!!!!!
        public ProjectileHandler()
        {
            ProjectileList = new List<BaseProjectile>();

        }

        public void Path()
        {
            foreach(BaseProjectile projectile in ProjectileList)
            {
                projectile.Path(projectile);
            }
        }

        public void Update(EnemyHandler enemyHandler, Player player)
        {
            List<BaseEnemy> markForDeath = new List<BaseEnemy>();
            List<BaseProjectile> markHit = new List<BaseProjectile>();
            bool PlayerHit = false;
            foreach (BaseProjectile projectile in ProjectileList)
            {
                foreach(BaseEnemy enemy in enemyHandler.enemies)
                {
                    if (projectile.FiredUp) // the projectile came from the player
                    {
                        if (projectile.hitbox.Intersects(enemy.hitbox))
                        {
                            enemy.gotHit(projectile);
                            if (!enemy.isAlive())
                            {
                                markForDeath.Add(enemy);
                            }
                            markHit.Add(projectile);
                            //Globals.PauseGame();
                        }
                    }
                }
                if (!projectile.FiredUp)
                {
                    if (projectile.hitbox.Intersects(player.hitbox))
                    {
                        player.kill();
                        PlayerHit = true;
                    }
                }
            }

            for(int i = markForDeath.Count - 1; i >= 0; i--)
            {
                //markForDeath[i].kill();
                enemyHandler.enemies.Remove(markForDeath[i]);
            }
            for(int i = markHit.Count - 1; i >= 0; i--)
            {
                ProjectileList.Remove(markHit[i]);
            }
        }

        public void Draw()
        {
            foreach (PlayerProjectile projectile in ProjectileList)
            {
                if (projectile is PlayerProjectile)
                {
                    Globals.SpriteBatch.Draw(PlayerProjectileTexture, projectile.Position, Color.White);
                }
            }
        }

        public void LoadTextures()
        {
            this.PlayerProjectileTexture = Globals.Content.Load<Texture2D>("Textures//DefaultProjectile");
        }
    }
}
