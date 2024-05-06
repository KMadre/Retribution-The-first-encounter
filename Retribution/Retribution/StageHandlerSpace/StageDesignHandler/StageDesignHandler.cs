using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retribution.StageHandlerSpace.StageDesignHandlerSpace
{
    public class StageDesignHandler
    {
        public static StageDesignHandler Instance;
        private Texture2D backgroundMoving;
        private Vector2 original;
        private Vector2 Next;
        private Color color;

        public StageDesignHandler()
        {
            Instance = this;
            original = new Vector2();
            Next = new Vector2();
            randomizeColor();
        }

        public static StageDesignHandler getInstance()
        {
            return Instance;
        }

        public void randomizeColor()
        {
            Random random = new Random();
            color = new Color(random.Next(256), random.Next(256), random.Next(256));
        }

        public void Update()
        {
            original.Y += 300f * (float)Globals.Time;
            original.Y %= backgroundMoving.Height;

            if(original.Y >= 0)
            {
                Next.Y = original.Y - backgroundMoving.Height;
            }
            else
            {
                Next.Y = original.Y - backgroundMoving.Height;
            }
        }

        public void Draw()
        {
            Globals.SpriteBatch.Draw(backgroundMoving, original, color);
            Globals.SpriteBatch.Draw(backgroundMoving, Next, color);
        }

        public void LoadTextures()
        {
            this.backgroundMoving = Globals.Content.Load<Texture2D>("Textures//backgroundClouds");
        }
    }
}
