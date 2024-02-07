using Werewolf.Engine.Game;
using Werewolf.Engine.Maths;
using SkiaSharp;
using Werewolf.Engine.Scripting;
using Werewolf.Engine.EngineManagement;

namespace Werewolf.Engine
{
    public class Sprite2D : IDisposable
    {
        public Vector2<float>? Position;
        public Vector2<float>? Size;
        public float Scale;
        public string Name;
        public int Layer;

        public Vector2<float> Center;

        public SpriteImage SpriteImage;
        public string ImageName { get; private set; }

        public Vector2<float>? InitialPosition;
        public Vector2<float>? InitialSize;
        private float InitialScale;
        private string InitialName;

        public Vector2<float> LastPosition;

        public Vector2<float> CollisionBoxPosition;
        public Vector2<float> CollisionBoxSize;

        public bool DoCollision = true;
        public float ColXOffset = 0, ColYOffset = 0;
        public float ColWidthOffset = 0, ColHeightOffset = 0;

        internal string AttachedScript;
        internal string AttachedScriptName;
        internal string AttachedScriptFilePath;
        internal ScriptCompiler ScriptCompiler;

        public KeyframeAnimation2D KeyframeAnimator;

        public GameInstance gameInstance;

        public bool IsDisabled { get; private set; }

        public bool IsVisible = true;

        public bool IsInit { get; private set; }
        public bool IsResizing { get; private set; }

        public bool DrawDebug { get; set; }
        public bool DrawSelected { get; set; }
        public SKPaint spriteDebugPaint = new SKPaint
        {
            IsAntialias = true,
            Color = SKColors.Blue,
            Style = SKPaintStyle.Stroke,
            StrokeWidth = 1
        };
        public SKPaint spriteColDebugPaint = new SKPaint
        {
            IsAntialias = true,
            Color = SKColors.Green,
            Style = SKPaintStyle.Stroke,
            StrokeWidth = 1
        };
        public SKPaint spriteTextDebugPaint = new SKPaint
        {
            IsAntialias = true,
            Color = SKColors.Blue,
        };
        public SKPaint spriteSelectedPaint = new SKPaint
        {
            IsAntialias = true,
            Color = SKColors.MediumSeaGreen,
            Style = SKPaintStyle.Stroke,
            StrokeWidth = 2
        };

        public Sprite2D(Vector2<float> position, string imageName = "none", float scale = 1, string name = "Default", int layer = 0)
        {
            this.Position = position;
            this.Scale = scale;
            this.Name = name;
            this.Layer = layer;

            this.ImageName = imageName;

            ScriptCompiler = new ScriptCompiler();

            //Set start vars
            this.InitialPosition = position;
            this.InitialScale = scale;
            this.InitialName = name;

            this.LastPosition = this.Position.Copy();

            this.KeyframeAnimator = new KeyframeAnimation2D(this);
        }

        public async Task Init()
        {
            await CustomInit();

            Reset();
            await AttachImage(ImageName);

            this.InitialSize = this.Size.Copy();

            UpdateCollider();
            IsInit = true;
        }

        public virtual async Task CustomInit() { }
        public virtual void CustomDisable() { }
        public virtual void CustomReset() { }

        internal void AttachScript(string scriptName)
        {
            string fullPath = EngineInstance.MainDirectory + @$"\SCRIPT\{scriptName}";
            AttachedScriptFilePath = fullPath;
            AttachedScriptName = Path.GetFileNameWithoutExtension(scriptName);
            AttachedScript = File.ReadAllText(fullPath);
        }

        internal async Task AttachImage(string imageName)
        {
            this.SpriteImage = await ImageManager.GetSpriteImageFromImageName(imageName);
            this.Size = new Vector2<float>(SpriteImage.Width * Scale, SpriteImage.Height * Scale);
        }
        internal void AttachImageFromImage(SpriteImage img)
        {
            this.SpriteImage = img;
            this.Size = new Vector2<float>(SpriteImage.Width * Scale, SpriteImage.Height * Scale);
        }

        /// <summary>
        /// This will only work before the sprite is initialized (or the level is loaded)!
        /// </summary>
        /// <param name="imageName"></param>
        public void AssignImageName(string imageName)
        {
            this.ImageName = imageName;
        }

        /// <summary>
        /// This will call all update functions for the sprite automatically.
        /// <para><b>UpdateLastPosition()</b> will NOT be called as it may be used by the user for different purposes!</para>
        /// </summary>
        public void UpdateSprite(float dt)
        {
            try
            {
                ScriptCompiler.InvokeMethod("Update", new object[] { dt });
                UpdateCollider();
            }
            catch (Exception ex)
            {
                Debug.Warning($"Failed to update sprite [{this.Name}]: {ex.Message}");
            }
        }
        public void UpdateLastPosition()
        {
            LastPosition = this.Position.Copy();
        }
        public void UpdateCollider()
        {
            this.CollisionBoxPosition = this.Position.Copy();
            this.CollisionBoxSize = this.Size.Copy();
        }

        public void SetToLastPosition()
        {
            this.Position = LastPosition.Copy();
        }

        public bool GetCollisionValue()
        {
            if (GetCollision() != null)
            {
                return true;
            }

            return false;
        }
        public string GetCollisionName()
        {
            if (GetCollision() != null)
            {
                return GetCollision().Name;
            }

            return "none";
        }
        public Sprite2D GetCollision()
        {
            if (!DoCollision)
                return null;

            foreach (Sprite2D sp in EngineInstance.GetSprites())
            {
                try
                {
                    if (sp == this || !sp.DoCollision | this.Size == null || this.Position == null)
                        continue;

                    ColXOffset = this.Size.X / 4;
                    ColYOffset = this.Size.Y / 2;
                    ColWidthOffset = this.Size.X / 4;
                    ColHeightOffset = this.Size.Y / 8;

                    if (this.Position.X + ColXOffset < sp.Position.X + sp.Size.X + sp.ColWidthOffset &&
                        this.Position.X + this.Size.X - ColWidthOffset > sp.Position.X + sp.ColXOffset &&
                        this.Position.Y + ColYOffset < sp.Position.Y + sp.Size.Y + sp.ColHeightOffset &&
                        this.Position.Y + this.Size.Y - ColHeightOffset > sp.Position.Y + sp.ColYOffset)
                    {
                        return sp;
                    }    
                }
                catch
                {
                    Debug.Warning("Failed to check for collision!");
                }
            }

            return null;
        }

        public void Disable()
        {
            CustomDisable();

            IsDisabled = true;
            DoCollision = false;
        }
        public void Enable()
        {
            IsDisabled = false;
            DoCollision = true;
        }

        /// <summary>
        /// Reset the Position, Scale, and Tag to the ones set when the sprite was created
        /// </summary>
        public void Reset()
        {
            this.Position = InitialPosition?.Copy();
            this.LastPosition = this.Position.Copy();
            this.Scale = InitialScale;
            this.Name = InitialName;

            this.DoCollision = true;
            this.IsDisabled = false;

            ScriptCompiler.InvokeMethod("Start");

            CustomReset();
        }

        public void Dispose()
        {
            this.IsInit = false;
            GC.SuppressFinalize(this);
        }
    }
}
