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
            foreach (BaseProjectile projectile in ProjectileList)
            {
                foreach(BaseEnemy enemy in enemyHandler.enemies)
                {
                    if (projectile.FiredUp) // the projectile came from the player
                    {
                        if (projectile.hitbox.Intersects(enemy.hitbox))
                        {
                            enemy.gotHit(projectile);
                            Globals.PauseGame();
                        }
                    }
                }
                if (!projectile.FiredUp)
                {
                    if (projectile.hitbox.Intersects(player.hitbox))
                    {
                        player.kill();
                    }
                }
            }
        }

        public void Draw()
        {
            foreach (PlayerProjectile projectile in ProjectileList)
            {
                if (projectile is PlayerProjectile)
                {
                    Globals.SpriteBatch.Draw(PlayerProjectileTexture, projectile.Position, Color.White);
                    Globals.SpriteBatch.Draw(PlayerProjectileTexture, projectile.hitbox, Color.White);
                }
            }
        }

        public void LoadTextures()
        {
            this.PlayerProjectileTexture = Globals.Content.Load<Texture2D>("Textures//DefaultProjectile");
        }
    }
}
