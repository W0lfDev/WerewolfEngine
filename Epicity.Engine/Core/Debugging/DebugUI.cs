using SkiaSharp;
using Werewolf.Engine.EngineManagement;

namespace Werewolf.Engine
{
    public class DebugUI
    {
        private static SKCanvas? g;
        private static SKTypeface defaultTypeface = SKTypeface.FromFamilyName("Consolas", SKFontStyleWeight.Normal, SKFontStyleWidth.Normal, SKFontStyleSlant.Upright);
        private static SKTypeface boldTypeface = SKTypeface.FromFamilyName("Consolas", SKFontStyleWeight.Bold, SKFontStyleWidth.Normal, SKFontStyleSlant.Upright);

        static SKColor fpsColor;

        static SKColor ramUsageColor;
        static SKColor cpuUsageColor;

        static int debugState = 2;

        public static void SetCanvas(SKCanvas graphics)
        {
            g = graphics;
        }

        public static void DrawDelta(bool draw = true)
        {
            if (!draw || g == null) return;

            g.DrawRect(5, 5, 160, 20, new SKPaint() { Color = new SKColor(43, 43, 43, 128) });
            g.DrawText(EngineInstance.DeltaTime.ToString("Delta Time: 0.000000"), 10, 20, new SKPaint()
            {
                Color = SKColors.White,
                TextSize = 14,
                Typeface = defaultTypeface,
                TextAlign = SKTextAlign.Left,
                IsAntialias = true,
            });
        }

        public static void DrawFPS(bool draw = true)
        {
            if (!draw || g == null) return;

            if (EngineInstance.FPS >= 50)
                fpsColor = new SKColor(0, 255, 125);
            else if (EngineInstance.FPS >= 40)
                fpsColor = new SKColor(255, 200, 0);
            else if (EngineInstance.FPS >= 35)
                fpsColor = new SKColor(255, 94, 0);
            else
                fpsColor = new SKColor(255, 0, 0);

            g.DrawRect(5, 26, 95, 20, new SKPaint() { Color = new SKColor(43, 43, 43, 128) });
            g.DrawText(EngineInstance.FPS.ToString("0.00 FPS"), 10, 41, new SKPaint()
            {
                Color = fpsColor,
                TextSize = 14,
                Typeface = boldTypeface,
                TextAlign = SKTextAlign.Left,
                IsAntialias = true,
            });
        }

        public static void DrawSpriteCount(bool draw = true)
        {
            if (!draw || g == null) return;

            g.DrawRect(5, 50, 260, 20, new SKPaint() { Color = new SKColor(43, 43, 43, 128) });
            g.DrawText($"Sprites in Level Manager: {LevelManager.ReportSpritesInLevelManager()}", 10, 65, new SKPaint()
            {
                Color = SKColors.White,
                TextSize = 14,
                Typeface = defaultTypeface,
                TextAlign = SKTextAlign.Left,
                IsAntialias = true,
            });
        }

        public static void DrawInitSpriteCount(bool draw = true)
        {
            if (!draw || g == null) return;

            g.DrawRect(5, 71, 350, 20, new SKPaint() { Color = new SKColor(43, 43, 43, 128) });
            g.DrawText($"Initialized Sprites in Current Level: {LevelManager.ReportInitalizedSpritesInLevel()}", 10, 86, new SKPaint()
            {
                Color = SKColors.White,
                TextSize = 14,
                Typeface = defaultTypeface,
                TextAlign = SKTextAlign.Left,
                IsAntialias = true,
            });
        }

        public static void DrawRenderedSpritesCount(bool draw = true)
        {
            if (!draw || g == null) return;

            g.DrawRect(5, 92, 350, 20, new SKPaint() { Color = new SKColor(43, 43, 43, 128) });
            g.DrawText($"Rendered Sprites in Current Level: {EngineInstance.SpritesOnScreen}", 10, 107, new SKPaint()
            {
                Color = SKColors.White,
                TextSize = 14,
                Typeface = defaultTypeface,
                TextAlign = SKTextAlign.Left,
                IsAntialias = true,
            });
        }

        public static void DrawRamUsage(bool draw = true)
        {
            if (!draw || g == null) return;

            if (EngineDiagnostics.ReportRamUsage() >= EngineDiagnostics.ReportTotalRam() / 3.5)
                ramUsageColor = new SKColor(255, 200, 0);
            else if (EngineDiagnostics.ReportRamUsage() >= EngineDiagnostics.ReportTotalRam() / 2.0)
                ramUsageColor = new SKColor(255, 94, 0);
            else if (EngineDiagnostics.ReportRamUsage() >= EngineDiagnostics.ReportTotalRam() / 1.2)
                ramUsageColor = new SKColor(255, 0, 0);
            else
                ramUsageColor = new SKColor(0, 255, 125);

            g.DrawRect(5, 119, 175, 20, new SKPaint() { Color = new SKColor(43, 43, 43, 128) });
            g.DrawText($"RAM Usage: {EngineDiagnostics.ReportRamUsage().ToString("0.00")} MB", 10, 134, new SKPaint()
            {
                Color = ramUsageColor,
                TextSize = 14,
                Typeface = boldTypeface,
                TextAlign = SKTextAlign.Left,
                IsAntialias = true,
            });

            g.DrawRect(182, 119, 110, 20, new SKPaint() { Color = new SKColor(43, 43, 43, 128) });
            g.DrawText($"Peak: {EngineDiagnostics.ReportPeakRamUsage().ToString("0")} MB", 185, 134, new SKPaint()
            {
                Color = ramUsageColor,
                TextSize = 14,
                Typeface = defaultTypeface,
                TextAlign = SKTextAlign.Left,
                IsAntialias = true,
            });

            g.DrawRect(294, 119, 125, 20, new SKPaint() { Color = new SKColor(43, 43, 43, 128) });
            g.DrawText($"Total: {EngineDiagnostics.ReportTotalRam().ToString("0")} MB", 298, 134, new SKPaint()
            {
                Color = SKColors.White,
                TextSize = 14,
                Typeface = defaultTypeface,
                TextAlign = SKTextAlign.Left,
                IsAntialias = true,
            });
        }

        public static void DrawCpuUsage(bool draw = true)
        {
            if (!draw || g == null) return;

            if (EngineDiagnostics.ReportCpuUsage() >= 35)
                cpuUsageColor = new SKColor(255, 200, 0);
            else if (EngineDiagnostics.ReportCpuUsage() >= 50)
                cpuUsageColor = new SKColor(255, 94, 0);
            else if (EngineDiagnostics.ReportCpuUsage() >= 85)
                cpuUsageColor = new SKColor(255, 0, 0);
            else
                cpuUsageColor = new SKColor(0, 255, 125);

            g.DrawRect(5, 141, 135, 20, new SKPaint() { Color = new SKColor(43, 43, 43, 128) });
            g.DrawText($"CPU Usage: {EngineDiagnostics.ReportCpuUsage().ToString("0.0")}%", 10, 156, new SKPaint()
            {
                Color = cpuUsageColor,
                TextSize = 14,
                Typeface = boldTypeface,
                TextAlign = SKTextAlign.Left,
                IsAntialias = true,
            });
        }

        public static void DrawUpdatePaused()
        {
            if (EngineInstance.UpdateGameLogic)
                return;

            float x = EngineInstance.WindowWidth - 300;
            float y = EngineInstance.WindowHeight - 100;

            // Stroke
            g.DrawText("Update Paused!", new SKPoint(x, y), new SKPaint()
            {
                Color = SKColors.Black,
                Typeface = boldTypeface,
                TextSize = 32,
                StrokeWidth = 5,
                Style = SKPaintStyle.StrokeAndFill
            });

            // Text
            g.DrawText("Update Paused!", new SKPoint(x, y), new SKPaint()
            {
                Color = SKColors.Yellow,
                Typeface = boldTypeface,
                TextSize = 32,
            });
        }

        public static void SetDebugState(int state) => debugState = state;
        public static int GetDebugState() { return debugState; }

        /// <summary>
        /// This is somewhat pretty performance intensive. Do not use in production!
        /// </summary>
        public static void DrawDiagnostics()
        {
            if (!EngineInstance.IS_DEBUG_BUILD)
                return;

            DrawUpdatePaused();

            bool engineDiag = false, spriteStuff = false, pcStuff = false;

            if (debugState >= 1)
                engineDiag = true;

            if (debugState >= 2)
                spriteStuff = true;

            if (debugState >= 3)
                pcStuff = true;

            if (!engineDiag)
                return;

            DrawDelta();
            DrawFPS();

            if (!spriteStuff)
                return;

            DrawSpriteCount();
            DrawInitSpriteCount();
            DrawRenderedSpritesCount();

            if (!pcStuff)
                return;

            DrawRamUsage();
            DrawCpuUsage();
        }
    }
}
