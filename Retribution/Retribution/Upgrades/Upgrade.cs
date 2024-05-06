using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Retribution.PlayerRelated;

namespace Retribution.Upgrades
{
    public class Upgrade
    {
        public Vector2 Position { get; set; }
        public Rectangle hitbox;
        public int itemType;

        public Upgrade(Vector2 pos)
        {
            Position = pos;
            hitbox = new Rectangle((int)this.Position.X, (int)this.Position.Y, 16, 16);
            GenerateItem();
        }

        private void GenerateItem()
        {
            Random random = new Random();
            int randomNumber = random.Next(0, 3);
            this.itemType = randomNumber;
        }

        public void MakeLifeUpgrade()
        {
            this.itemType = 3;
        }

        public void Update()
        {
            Vector2 pos = this.Position;
            pos.Y += 100f * (float)Globals.Time;
            this.Position = pos;
            this.hitbox.X = (int)this.Position.X;
            this.hitbox.Y = (int)this.Position.Y;
        }

        public void Interact()
        {
            Player instance = Player.GetPlayer();

            switch (itemType)
            {
                case 0:
                    instance.IncreaseDamage(5f);
                    break;
                case 1:
                    instance.IncreaseSpeed(1f);
                    break;
                case 2:
                    instance.IncreaseFireRate(20f);
                    break;
                case 3:
                    instance.IncreaseHealth();
                    break;
            }
        }
    }
}
