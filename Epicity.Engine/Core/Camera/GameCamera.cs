using Werewolf.Engine.EngineManagement;
using Werewolf.Engine.Maths;

namespace Werewolf.Engine
{
    public class GameCamera
    {
        public static Vector2<float> Position = new Vector2<float>(0, 0);
        public static float Zoom = 1f;

        private static float lerpFactor;
        private static float centerX, centerY;

        /// <summary>
        /// Tell the camera to follow a sprite
        /// <para>Lower values of <b>distanceScaleFactor</b> will give more space between the camera and the sprite</para>
        /// </summary>
        /// <param name="sprite"></param>
        /// <param name="distanceScaleFactor"></param>
        public static void Follow(Sprite2D sprite, float deltaTime, float distanceScaleFactor = 1)
        {
            lerpFactor = distanceScaleFactor * 2 * deltaTime;

            centerX = sprite.Position.X + sprite.Size.X / 2 - EngineInstance.WindowWidth / (Zoom * 2);
            centerY = sprite.Position.Y + sprite.Size.Y / 2 - EngineInstance.WindowHeight / (Zoom * 2);

            Position = new Vector2<float>(
                Maths.GameMath.Lerp(Position.X, centerX, lerpFactor),
                Maths.GameMath.Lerp(Position.Y, centerY, lerpFactor)
            );
        }
    }
}
