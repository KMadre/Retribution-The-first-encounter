using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

/// <summary>
/// Reference used here from tutorial on youtube: https://www.youtube.com/watch?v=pwIMcREctik
/// purpose: make the important variables globally accessible without having to be passed
/// </summary>
namespace Retribution
{
    public static class Globals
    {
        public const int SCREEN_WIDTH = 500;
        public const int SCREEN_HEIGHT = 700;
        public static float Time { get; set; }
        public static ContentManager Content { get; set; }
        public static SpriteBatch SpriteBatch { get; set; }
        public static bool isPaused { get; set; }

        public static void PauseGame()
        {
            isPaused = true;
        }
        public static void UnPauseGame()
        {
            isPaused = false;
        }

        public static void Update(GameTime gt)
        {
            if (!isPaused)
            {
                Time = (float)gt.ElapsedGameTime.TotalSeconds;
            }
            else
            {
                Time = 0.0f;
            }
        }
    }
}
