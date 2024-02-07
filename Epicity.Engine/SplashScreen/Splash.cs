using SkiaSharp;
using Werewolf.Engine.EngineManagement;

namespace Werewolf.Engine.SplashScreen
{
    public class Splash
    {
        public static bool DoDrawSpash = false;
        static SKBitmap splashImage;

        public static void LoadSplash(string path)
        {
            splashImage = SKBitmap.Decode(path);
            splashImage = splashImage.Resize(new SKImageInfo(192, 192), SKFilterQuality.High);
        }

        public static void DrawSplash(SKCanvas g)
        {
            if (!DoDrawSpash)
                return;

            g.DrawRect(0, 0, EngineInstance.WindowWidth, EngineInstance.WindowHeight, new SKPaint() { Color = SKColors.Black });
            
            float bitmapX = (EngineInstance.WindowWidth - splashImage.Width) / 2;
            float bitmapY = (EngineInstance.WindowHeight - splashImage.Height) / 2;
            g.DrawBitmap(splashImage, new SKPoint(bitmapX, bitmapY));
        }
    }
}
