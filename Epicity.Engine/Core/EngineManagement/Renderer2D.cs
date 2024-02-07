using SkiaSharp;
using SkiaSharp.Views.Desktop;
using Werewolf.Engine.Maths;

namespace Werewolf.Engine.EngineManagement
{
    public class Renderer2D
    {
        public static void Render(EngineInstance engineInstance, SKPaintGLSurfaceEventArgs e)
        {
            try
            {
                engineInstance.deltaTimeSecond = DateTime.Now;
                EngineInstance.DeltaTime = (engineInstance.deltaTimeSecond.Ticks - engineInstance.deltaTimeFirst.Ticks) / (TimeSpan.TicksPerSecond * 1.0);

                engineInstance.fpsUpdateTimer += (float)EngineInstance.DeltaTime;
                if (engineInstance.fpsUpdateTimer >= 0.5f)
                {
                    EngineInstance.FPS = (float)(1.0f / EngineInstance.DeltaTime);
                    engineInstance.fpsUpdateTimer = 0;
                }

                if (EngineInstance.UpdateGameLogic)
                    engineInstance.Update((float)EngineInstance.DeltaTime);

                SKCanvas g = e.Surface.Canvas;
                g.Clear(SKColors.Cyan);

                if (EngineInstance.RenderCurrentLevel)
                {
                    EngineInstance.SpritesOnScreen = 0;

                    g.Save();

                    g.Translate(new SKPoint(GameCamera.Position.X * -1 * GameCamera.Zoom, GameCamera.Position.Y * -1 * GameCamera.Zoom));
                    g.Scale(GameCamera.Zoom);

                    foreach (var sprite in EngineInstance.Sprites)
                    {
                        if (sprite.SpriteImage.Bitmap == null || sprite.IsDisabled || !sprite.IsVisible)
                            continue;

                        float transformedX = (sprite.Position.X - GameCamera.Position.X) * GameCamera.Zoom;
                        float transformedY = (sprite.Position.Y - GameCamera.Position.Y) * GameCamera.Zoom;

                        SKPoint transformedPosition = new SKPoint(transformedX, transformedY);

                        bool isInsideViewport =
                            transformedPosition.X >= -sprite.Size.X * GameCamera.Zoom &&
                            transformedPosition.X < EngineInstance.WindowWidth + sprite.Size.X * GameCamera.Zoom &&
                            transformedPosition.Y >= -sprite.Size.Y * GameCamera.Zoom &&
                            transformedPosition.Y < EngineInstance.WindowHeight + sprite.Size.Y * GameCamera.Zoom;

                        if (isInsideViewport)
                        {
                            engineInstance.DefaultRect.Location = sprite.Position!.ToSKPoint();
                            engineInstance.DefaultRect.Size = sprite.Size!.ToSKSize();

                            try
                            {
                                g.DrawBitmap(sprite.SpriteImage.Bitmap, engineInstance.DefaultRect, engineInstance.DefaultPaint);

                                if (sprite.DrawDebug)
                                {
                                    // Draw Collision box
                                    SKRect colliderRect = new SKRect(
                                        sprite.Position.X + sprite.ColXOffset,
                                        sprite.Position.Y + sprite.ColYOffset,
                                        sprite.Position.X + sprite.Size.X - sprite.ColWidthOffset,
                                        sprite.Position.Y + sprite.Size.Y - sprite.ColHeightOffset
                                    );
                                    g.DrawRect(colliderRect, sprite.spriteColDebugPaint);


                                    // Draw Bounds box
                                    g.DrawRect(engineInstance.DefaultRect, sprite.spriteDebugPaint);

                                    Vector2<float> sizeTextPosition = new Vector2<float>(sprite.Position.X + 5, sprite.Position.Y + 15);
                                    g.DrawText(sprite.Size.ToString(), sizeTextPosition.ToSKPoint(), sprite.spriteTextDebugPaint);

                                    Vector2<float> posTextPosition = new Vector2<float>(sprite.Position.X + 5, sprite.Position.Y + sprite.Size.Y - 5);
                                    g.DrawText(sprite.Position.ToString(), posTextPosition.ToSKPoint(), sprite.spriteTextDebugPaint);
                                }

                                if (sprite.DrawSelected)
                                {
                                    g.DrawLine(
                                        sprite.Position.X, sprite.Position.Y,
                                        sprite.Position.X + sprite.Size.X,
                                        sprite.Position.Y + sprite.Size.Y,
                                        sprite.spriteSelectedPaint
                                    );
                                    g.DrawLine(
                                        sprite.Position.X + sprite.Size.X,
                                        sprite.Position.Y,
                                        sprite.Position.X,
                                        sprite.Position.Y + sprite.Size.Y,
                                        sprite.spriteSelectedPaint
                                    );

                                    g.DrawRect(engineInstance.DefaultRect, sprite.spriteSelectedPaint);
                                }
                            }
                            catch
                            {
                                Debug.Warning("Failed to draw sprite");
                            }

                            EngineInstance.SpritesOnScreen++;
                        }
                    }

                    g.Restore();
                }

                DebugUI.SetCanvas(g);

                engineInstance.Draw(g);

                engineInstance.deltaTimeFirst = engineInstance.deltaTimeSecond;
            }
            catch (Exception ex)
            {
                engineInstance.renderErrorCount++;

                if (engineInstance.renderErrorCount >= 5)
                {
                    Debug.ErrorBox($"Failed to recover from Rendering error! Exception: \n{ex.ToString()}");
                    Environment.Exit(1);
                }
            }
        }
    }
}
