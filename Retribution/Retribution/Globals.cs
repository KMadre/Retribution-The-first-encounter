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
        public static string difficulty = "Normal";
        public const int SCREEN_WIDTH = 500;
        public const int SCREEN_HEIGHT = 700;
        public static float Time { get; set; }
        public static ContentManager Content { get; set; }
        public static SpriteBatch SpriteBatch { get; set; }
        public static bool isPaused { get; set; }
        public static bool BulletTime { get; set; } = false;
        
        public static bool isGodMode { get; set; } = false;

        public static void ActivateGodMode()
        {
            isGodMode = true;
        }

        public static void DeactivateGodMode()
        {
            isGodMode = false;
        }

        public static void PauseGame()
        {
            isPaused = true;
        }
        public static void UnPauseGame()
        {
            isPaused = false;
        }
        public static void startBulletTime()
        {
            BulletTime = true;
        }
        public static void stopBulletTime()
        {
            BulletTime = false;
        }

        public static void Update(GameTime gt)
        {
            if (isPaused)
            {
                Time = 0.0f;
            }else if (BulletTime)
            {
                Time = (float)gt.ElapsedGameTime.TotalSeconds * 0.1f;
            }
            else
            {
                Time = (float)gt.ElapsedGameTime.TotalSeconds;
            }
        }

        public static void setDifficulty(string dif)
        {
            difficulty = dif;
        }

        public static string  getDifficulty()
        {
            return difficulty;
        }
    }
}
