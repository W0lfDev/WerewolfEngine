using Werewolf.Engine.Game;
using SkiaSharp;
using Werewolf.Engine.EngineManagement;
using Werewolf.Engine.Core.LevelStuff;
using System.Xml.Linq;

namespace Werewolf.Engine
{
    public delegate Task LoadEventHandler(object sender, EventArgs e);
    public delegate void LevelAddedEventHandler(object sender, Level level, EventArgs e);

    public class LevelManager
    {
        public static List<Level> Levels = new List<Level>();
        public Level CurrentLevel;

        public bool ShowLoadingScreen = false;
        public bool IsLoading { get; private set; }

        public event LoadEventHandler OnLoad;

        public static event LevelAddedEventHandler OnLevelAdded;

        private SKBitmap? LoadingBitmap;
        private float AnimationRotation = 0;
        public string Status = "Preparing";
        private SKTypeface? typeface = SKTypeface.FromFamilyName("Lucida Sans", SKFontStyleWeight.Normal, SKFontStyleWidth.Normal, SKFontStyleSlant.Upright);

        private GameInstance GameInstance;

        public LevelManager()
        {
            LoadingBitmap = SKBitmap.Decode(Path.Combine(EngineInstance.MainDirectory, "IMAGE", "engine", "_loading.png"));
            EngineInstance.UpdateGameLogic = true;
        }

        /// <summary>
        /// This is called when the level is being loaded
        /// </summary>
        /// <returns></returns>
        protected virtual async Task OnLoadEvent()
        {
            if (OnLoad != null)
            {
                int totalTasks = OnLoad.GetInvocationList().Length;

                List<Task> tasks = new List<Task>();
                foreach (LoadEventHandler handler in OnLoad.GetInvocationList())
                {
                    tasks.Add(InvokeAndTrackStatus(tasks.Count, totalTasks, handler));
                }

                await Task.WhenAll(tasks);
            }
        }
        private async Task InvokeAndTrackStatus(int currentTask, int totalTasks, LoadEventHandler handler)
        {
            Status = $"Loading {currentTask + 1}/{totalTasks}";
            await handler.Invoke(this, EventArgs.Empty);
        }

        public void AttachGameInstance(GameInstance instance) => this.GameInstance = instance;

        public void AddLevel(Level level)
        {
            Levels?.Add(level);
            OnLevelAdded?.Invoke(this, level, EventArgs.Empty);
        }
        public async Task LoadLevel(int index, bool unloadPrevious = false, bool isReload = false)
        {
            await LoadLevel(Levels[index], unloadPrevious, isReload);
        }
        public async Task LoadLevel(Level level, bool unloadPrevious = false, bool isReload = false)
        {
            await LoadLevel(level.Name, unloadPrevious, isReload);
        }
        public async Task LoadLevel(string name, bool unloadPrevious = false, bool isReload = false)
        {
            DateTime loadingStartTime = DateTime.Now;

            bool releaseUpdateLock = false;
            if (!isReload)
            {
                ShowLoadingScreen = true;
                IsLoading = true;

                if (EngineInstance.UpdateGameLogic == true)
                {
                    EngineInstance.UpdateGameLogic = false;
                    releaseUpdateLock = true;
                }

                EngineInstance.RenderCurrentLevel = false;
            }

            Level previous = CurrentLevel;

            Level? levelToLoad = null;
            foreach (var lvl in Levels)
            {
                if (lvl.Name == name)
                {
                    levelToLoad = lvl;
                }
            }

            if (levelToLoad == null)
            {
                Debug.Warning($"Can Not find Level [{name}]!");

                return;
            }
            CurrentLevel = levelToLoad;

            Status = "Cleaning";
            await ClearPrevious(unloadPrevious, previous);

            Status = "Loading...";
            await levelToLoad.Load(this, isReload);

            SetGameInstanceToSprites();

            Status = "Compiling...";
            bool hasCompiled = await CompileScripts();
            
            if (!hasCompiled)
            {
                Console.WriteLine("Compiling...");
                await ReloadLevel();
            }

            await ResetAllSpritesToDefault();

            await OnLoadEvent();

            Status = "Ready";
            Debug.Log($"Level [{CurrentLevel.Name}] loaded successfully in {(DateTime.Now - loadingStartTime).TotalSeconds.ToString("0.000")} seconds!");

            await Task.Delay(100);

            if (!isReload)
            {
                if (releaseUpdateLock)
                    EngineInstance.UpdateGameLogic = true;

                EngineInstance.RenderCurrentLevel = true;

                await Task.Delay(250);
                ShowLoadingScreen = false;
                IsLoading = false;
            }
        }

        public async Task ReloadLevel()
        {
            await Task.Run(async () =>
            {
                ShowLoadingScreen = true;
                IsLoading = true;
                EngineInstance.RenderCurrentLevel = false;
                EngineInstance.UpdateGameLogic = false;

                Status = "Reloading...";

                if (CurrentLevel is Tilemap tilemap)
                {
                    tilemap.ReInit();
                }
                else if (CurrentLevel is BatchLevel batch)
                {
                    await Task.Delay(100);

                    await batch.Unload();
                    await batch.InitBatch();
                }
                else if (CurrentLevel is Level level)
                {
                    await level.ReloadLevel();
                }

                await LoadLevel(CurrentLevel, false, true);
            });

            EngineInstance.UpdateGameLogic = true;
            EngineInstance.RenderCurrentLevel = true;
            IsLoading = false;
            ShowLoadingScreen = false;
        }

        public List<Level> GetLevels() { return Levels; }

        public static int ReportSpritesInLevelManager()
        {
            int n = 0;
            foreach (var lvl in Levels)
            {
                n += lvl.Sprites.Count;
            }

            return n;
        }

        public static int ReportInitalizedSpritesInLevel()
        {
            int n = 0;
            foreach (var lvl in Levels)
            {
                foreach (var sprite in lvl.Sprites)
                {
                    if (sprite.IsInit)
                    {
                        n += 1;
                    }
                }
            }

            return n;
        }

        public Sprite2D GetSpriteInLevel(int spriteIndex)
        {
            return CurrentLevel.Sprites.ElementAt(spriteIndex);
        }
        public Sprite2D GetSpriteInLevel(string tag)
        {
            foreach (var sprite in CurrentLevel.Sprites)
            {
                if (sprite.Name == tag)
                {
                    return sprite;
                }
            }

            Debug.Error("Failed to find sprite with tag: " + tag);
            return new Sprite2D(new Maths.Vector2<float>(0, 0));
        }

        public void AddSpriteToCurrent(AnimatedSprite2D sprite)
        {
            DateTime start = DateTime.Now;
            Task load = new Task(async () =>
            {
                if (sprite == null)
                {
                    Debug.Error($"Failed to initialize sprite at runtime!");
                    return;
                }

                await sprite.Init();
                Levels[Levels.IndexOf(CurrentLevel)].AddSpriteRuntime(sprite);

                Debug.Log($"Loaded sprite [{sprite.Name}] at runtime in {(DateTime.Now - start).TotalSeconds.ToString("0.000")} seconds");
            });
            load.Start();
            load.Wait();
        }

        public void UpdateSpritesInCurrentLevel(float dt)
        {
            CurrentLevel?.UpdateSpritesInLevel(dt);
        }

        public async Task<bool> CompileScripts()
        {
            IsLoading = true;
            ShowLoadingScreen = true;

            EngineInstance.UpdateGameLogic = false;
            EngineInstance.RenderCurrentLevel = false;

            int n = 1;

            foreach (Sprite2D sprite in CurrentLevel.Sprites)
            {
                Status = $"Script {n}/{CurrentLevel.Sprites.Count}";

                if (sprite.ScriptCompiler.Compile(sprite))
                {
                    if (sprite.ScriptCompiler.HasCompiled)
                    {
                        sprite.ScriptCompiler.InvokeMethod("Load", new object[] { sprite });
                    }
                }
                else
                {
                    return false;
                }

                n++;
            }

            await Task.Delay(200);

            IsLoading = false;
            ShowLoadingScreen = false;

            EngineInstance.UpdateGameLogic = true;
            EngineInstance.RenderCurrentLevel = true;

            return true;
        }


        private void SetGameInstanceToSprites()
        {
            foreach (var sprite in CurrentLevel.Sprites)
            {
                sprite.gameInstance = this.GameInstance;
            }
        }

        private async Task ClearPrevious(bool clear, Level level)
        {
            if (clear == true)
            {
                EngineInstance.ClearSprites();
                //await level.Unload();
            }
        }
        public async Task ResetAllSpritesToDefault()
        {
            foreach (var sprite in CurrentLevel.Sprites)
            {
                sprite.Reset();
            }
        }

        public void DrawLoadingScreen(SKCanvas g)
        {
            if (!ShowLoadingScreen || LoadingBitmap == null)
                return;

            AnimationRotation += 2.5f;
            float rotatedX = EngineInstance.WindowWidth - LoadingBitmap.Width * 1.57f;
            float rotatedY = EngineInstance.WindowHeight - LoadingBitmap.Height * 2.2f;

            g.DrawRect(EngineInstance.WindowWidth - 155, EngineInstance.WindowHeight - 77, 135, 35, new SKPaint() { Color = new SKColor(43, 43, 43, 128) });
            g.DrawText(Status, new SKPoint(EngineInstance.WindowWidth - 105, EngineInstance.WindowHeight - 55), new SKPaint()
            {
                Color = SKColors.White,
                Typeface = typeface,
                IsAntialias = true,
                TextAlign = SKTextAlign.Center,
            });

            g.Save();
            g.RotateDegrees(AnimationRotation, rotatedX + LoadingBitmap.Width / 2, rotatedY + LoadingBitmap.Height / 2);
            g.DrawBitmap(LoadingBitmap, new SKPoint(EngineInstance.WindowWidth - LoadingBitmap.Width * 1.57f, EngineInstance.WindowHeight - LoadingBitmap.Height * 2.2f));
            g.Restore();
        }
    }
}
