using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Retribution.PlayerRelated;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retribution.Upgrades
{
    public class UpgradeHandler
    {
        public static UpgradeHandler instance;
        public List<Upgrade> upgradeList;
        public Texture2D DmgTexture;
        public Texture2D SpdTexture;
        public Texture2D FireRateTexture;
        public Texture2D LifeTexture;


        public UpgradeHandler()
        {
            instance = this;
            upgradeList = new List<Upgrade>();
        }

        public static UpgradeHandler GetUpgradeHandler()
        {
            if (instance == null)
            {
                instance = new UpgradeHandler();
            }
            return instance;
        }

        public void Update()
        {
            foreach (Upgrade upgrade in upgradeList)
            {
                upgrade.Update();
            }
            CheckCollision();
        }

        private void CheckCollision()
        {
            Player player = Player.GetPlayer();
            List<Upgrade> toDelete = new List<Upgrade>();
            foreach(Upgrade upgrade in upgradeList)
            {
                if (upgrade.hitbox.Intersects(player.hitbox))
                {
                    upgrade.Interact();
                    toDelete.Add(upgrade);
                }
            }
            foreach (Upgrade upgrade in toDelete)
            {
                upgradeList.Remove(upgrade);
            }
        }

        public void Draw()
        {
            foreach(Upgrade upgrade in upgradeList)
            {
                switch (upgrade.itemType)
                {
                    case 0:
                        Globals.SpriteBatch.Draw(DmgTexture, upgrade.Position, Color.White);
                        break;
                    case 1:
                        Globals.SpriteBatch.Draw(SpdTexture, upgrade.Position, Color.White);
                        break;
                    case 2:
                        Globals.SpriteBatch.Draw(FireRateTexture, upgrade.Position, Color.White);
                        break;
                    case 3:
                        Globals.SpriteBatch.Draw(LifeTexture, upgrade.Position, Color.White);
                        break;
                }
            }
        }

        public void LoadTexture()
        {
            this.DmgTexture = Globals.Content.Load<Texture2D>("Textures//DmgUpgrade");
            this.FireRateTexture = Globals.Content.Load<Texture2D>("Textures//FRUpgrade");
            this.SpdTexture = Globals.Content.Load<Texture2D>("Textures//SpdUpgrade");
            this.LifeTexture = Globals.Content.Load<Texture2D>("Textures//LifeUpgrade");
        }

        public void GenerateUpgrade(Vector2 pos)
        {
            upgradeList.Add(new Upgrade(pos));
        }

        public void GenerateLife(Vector2 pos)
        {
            Upgrade upgrade = new Upgrade(pos);
            upgrade.MakeLifeUpgrade();
            upgradeList.Add(upgrade);
        }
    }
}
