using SkiaSharp;
using SkiaSharp.Views.Desktop;
using System.Diagnostics;
using Werewolf.Engine.Editor;
using Werewolf.Engine.SplashScreen;
namespace Werewolf.Engine.EngineManagement
{
    public abstract class EngineInstance
    {
        #region Public Static
        public static readonly string MainDirectory = Directory.GetCurrentDirectory() + @"\ASSETS";
        public static int WindowWidth = 0, WindowHeight = 0;
        public static int StartWindowWidth = 0, StartWindowHeight = 0;
        public static int SpritesOnScreen = 0;
        public static bool IsFullscreen = false;
        #endregion

        internal SKGLControl glControl = new SKGLControl();
        internal Form mainWindow = new Form();

        internal Stopwatch deltaTimeWatch = new Stopwatch();
        internal Thread loopThread;

        internal DateTime deltaTimeFirst;
        internal DateTime deltaTimeSecond;
        public static double DeltaTime { get; internal set; }

        internal float fpsUpdateTimer;
        public static float FPS { get; internal set; }

        internal static List<Sprite2D> Sprites = new List<Sprite2D>();
        internal static List<Particle2D> ParticleSystems = new List<Particle2D>();
        public static bool UpdateGameLogic = false;
        public static bool RenderCurrentLevel = false;

        internal int renderErrorCount = 0;
        internal System.Windows.Forms.Timer renderErrorResetTimer = new System.Windows.Forms.Timer();

        internal static bool CRITICAL = false;

        internal SKPaint DefaultPaint = new SKPaint()
        {
            Color = SKColors.White
        };
        internal SKRect DefaultRect;

        public static bool IS_DEBUG_BUILD { get; internal set; }
        public MainWindowEditorControls editorControls;

        #region Abstract void

        /// <summary>
        /// Use to load assets
        /// </summary>
        public abstract void Init();
        /// <summary>
        /// Use to update game logic
        /// </summary>
        public abstract void Update(float dt);
        /// <summary>
        /// Use to draw game graphics
        /// </summary>
        /// <param name="g"></param>
        public abstract void Draw(SKCanvas g);
        /// <summary>
        /// Write a custom OnExit Event function.
        /// <para>Decide what the game does before it exits.</para>
        /// <para>For example, save the player's data.</para>
        /// </summary>
        #endregion

        #region OnExit
        public virtual void OnExit()
        {
            Debug.Log("Closing Epicity...");
            UpdateGameLogic = false;
            RenderCurrentLevel = false;

            Task cleanup = new Task(() =>
            {
                foreach (var sprite in Sprites)
                {
                    if (sprite.SpriteImage.Bitmap != null)
                    {
                        sprite.Dispose();
                    }
                }
            });
            cleanup.Start();
            cleanup.Wait();
        }
        #endregion

        #region Constructor
        public EngineInstance(string title, bool vsync = true, bool resizable = true)
        {
            IS_DEBUG_BUILD = true;

            this.mainWindow.Size = new Size(1280, 720);
            this.mainWindow.Text = title;
            this.mainWindow.StartPosition = FormStartPosition.CenterScreen;

            WindowWidth = this.mainWindow.Width;
            WindowHeight = this.mainWindow.Height;

            StartWindowWidth = WindowWidth;
            StartWindowHeight = WindowHeight;

            ScaleGameView();

            if (!resizable)
            {
                this.mainWindow.FormBorderStyle = FormBorderStyle.FixedSingle;
                this.mainWindow.MaximizeBox = false;
            }

            if (IS_DEBUG_BUILD == true)
            {
                editorControls = new MainWindowEditorControls(this.mainWindow);

                WindowHeight -= 35;

                this.glControl.Width = WindowWidth;
                this.glControl.Height = WindowHeight;
                this.glControl.Location = new Point(glControl.Location.X, glControl.Location.Y + 35);
            }
            else
            {
                this.glControl.Dock = DockStyle.Fill;
            }

            this.mainWindow.Controls.Add(this.glControl);

            this.mainWindow.Resize += OnWindowResize;
            this.mainWindow.MaximumSizeChanged += OnWindowResize;
            this.mainWindow.KeyPreview = true;
            this.mainWindow.KeyDown += Keyboard.HandleKeyDown;
            this.mainWindow.KeyUp += Keyboard.HandleKeyUp;

            this.glControl.PaintSurface += OnRender;
            this.glControl.VSync = vsync;

            loopThread = new Thread(Loop);
            loopThread.Start();

            renderErrorCount = 0;
            renderErrorResetTimer.Interval = 1000;
            renderErrorResetTimer.Tick += (sender, args) => renderErrorCount = 0;
            renderErrorResetTimer.Start();

            this.mainWindow.FormClosed += (sender, args) =>
            {
                OnExit();
                Environment.Exit(0);
            };

            ImmersiveWindow.TryEnable(this.mainWindow.Handle, true);
            CriticalErrorHandler.HandleOutOfRam(true);

            Application.EnableVisualStyles();
            Application.Run(this.mainWindow);
        }
        #endregion

        #region Sprite List Methods
        public static void AddSprite(Sprite2D sprite) { Sprites.Add(sprite); }
        public static void RemoveSprite(Sprite2D sprite) { Sprites.Remove(sprite); }
        public static void ClearSprites()
        {
            for (int i = Sprites.Count - 1; i >= 0; i--)
            {
                Sprites.RemoveAt(i);
            }
        }
        public static List<Sprite2D> GetSprites() { return Sprites; }
        #endregion

        #region Resize
        private void OnWindowResize(object? sender, EventArgs e)
        {
            // Set new values
            this.glControl.Size = this.mainWindow!.Size;
            WindowWidth = mainWindow!.Size.Width;
            WindowHeight = mainWindow!.Size.Height;

            // Scale the Game view
            ScaleGameView();
        }
        private void ScaleGameView()
        {
            float widthScale = (float)WindowWidth / StartWindowWidth;
            float heightScale = (float)WindowHeight / StartWindowHeight;

            GameCamera.Zoom = Math.Min(widthScale, heightScale);
        }
        public void ToggleFullscreen(bool setValue = false, bool value = false)
        {
            IsFullscreen = !IsFullscreen;

            if (setValue)
            {
                IsFullscreen = value;
            }

            if (IsFullscreen)
            {
                mainWindow.FormBorderStyle = FormBorderStyle.None;
                mainWindow.WindowState = FormWindowState.Maximized;
                mainWindow.TopMost = true;
            }
            else
            {
                mainWindow.WindowState = FormWindowState.Normal;
                mainWindow.FormBorderStyle = FormBorderStyle.FixedSingle;
                mainWindow.Size = new Size(StartWindowWidth, StartWindowHeight);
                mainWindow.TopMost = false;
            }
        }
        #endregion

        public static void CRIT()
        {
            CRITICAL = true;
        }

        #region Loop and Render
        private async void Loop()
        {
            Splash.LoadSplash(EngineInstance.MainDirectory + $@"\IMAGE\splash.png");
            if (IS_DEBUG_BUILD) EngineDiagnostics.Init();

            Init();

            while (loopThread.IsAlive && !CRITICAL)
            {
                this.glControl.Invalidate();
            }
        }

        private void OnRender(object? sender, SKPaintGLSurfaceEventArgs e)
        {
            Renderer2D.Render(this, e);
            Splash.DrawSplash(e.Surface.Canvas);
        }
        #endregion
    }
}
