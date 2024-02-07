using SkiaSharp.Views.Desktop;
using Werewolf.Engine;
using Werewolf.Engine.Editor;
using Werewolf.Engine.EngineManagement;
using Werewolf.Engine.Maths;

namespace Epicity.Engine.Editor.LevelEditor
{
    public partial class SpriteManager : Form
    {
        private List<string> currentPaths = new List<string>();
        private List<Image> currentImages = new List<Image>();

        private bool isAttachedScript = false;
        private string currentScriptName;

        private bool isAttachedKeyframeAnimation = false;
        private string currentKeyframeAnimationName;

        private LevelEditorWindow levelEditor;

        private bool isNewSprite;
        private AnimatedSprite2D currentSprite;

        public SpriteManager(LevelEditorWindow levelEditorWindow, bool isNewSprite, AnimatedSprite2D sp = null)
        {
            InitializeComponent();

            this.levelEditor = levelEditorWindow;
            this.isNewSprite = isNewSprite;
            this.currentSprite = sp;
        }

        private void SpriteManager_Load(object sender, EventArgs e)
        {
            EditorStyle.ApplyStyle(this);
            ResetProperties();

            if (isNewSprite)
            {
                SetProperties(currentSprite);
            }
        }

        private void ResetProperties()
        {
            spriteNameTexbox.Text = "Default";
            posXInput.Text = "0";
            posYInput.Text = "0";
            spriteScaleInput.Text = "1";
            animSpeedInput.Text = "1";
            spriteLayerInput.Text = "0";
            isAttachedScript = false;
            currentImages.Clear();
            currentPaths.Clear();
        }

        private void SetProperties(AnimatedSprite2D sprite)
        {
            spriteNameTexbox.Text = sprite.Name;
            posXInput.Text = sprite.Position.X.ToString();
            posYInput.Text = sprite.Position.Y.ToString();
            spriteScaleInput.Text = sprite.Scale.ToString();
            animSpeedInput.Text = sprite.AnimationSpeed.ToString();
            spriteLayerInput.Text = sprite.Layer.ToString();
            isAttachedScript = sprite.AttachedScript != null;

            foreach (var spriteImage in sprite.Images)
            {
                currentImages.Add(spriteImage.Bitmap.ToBitmap());
            }
            foreach (var imgName in sprite.ImageNames)
            {
                currentPaths.Add(imgName);
            }

            spriteImage.Image = new Bitmap(Image.FromFile(EngineInstance.MainDirectory + @$"\IMAGE\{currentPaths[0]}.png"), spriteImage.Size);
        }

        private void spriteImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files (*.bmp;*.jpg;*.jpeg;*.png)|*.bmp;*.jpg;*.jpeg;*.png|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.InitialDirectory = EngineInstance.MainDirectory + @"\IMAGES\";
                openFileDialog.Multiselect = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    currentPaths.Clear();
                    currentImages.Clear();

                    currentPaths.AddRange(openFileDialog.FileNames);
                    foreach (string path in currentPaths)
                    {
                        currentImages.Add(Image.FromFile(path));
                    }

                    int totalWidth = 0;
                    int maxHeight = 0;

                    foreach (Image img in currentImages)
                    {
                        totalWidth += img.Width;
                        maxHeight = System.Math.Max(maxHeight, img.Height);
                    }

                    Bitmap compositeImage = new Bitmap(totalWidth, maxHeight);
                    using (Graphics g = Graphics.FromImage(compositeImage))
                    {
                        int x = 0;

                        foreach (Image img in currentImages)
                        {
                            g.DrawImage(img, x, 0);
                            x += img.Width;
                        }
                    }

                    spriteImage.Image = new Bitmap(compositeImage, spriteImage.Size);
                    clickToAddLbl.Visible = false;
                }
            }
        }

        private void attachScriptButton_Click(object sender, EventArgs e)
        {
            if (isAttachedScript == false)
            {
                using (OpenFileDialog dialog = new OpenFileDialog())
                {
                    dialog.Filter = "Script Files *.cs|*.cs|All files (*.*)|*.*";
                    dialog.FilterIndex = 1;
                    dialog.Multiselect = false;
                    dialog.InitialDirectory = EngineInstance.MainDirectory + @"\SCRIPT";

                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        isAttachedScript = true;
                        attachScriptButton.Text = "Remove";

                        currentScriptName = Path.GetFileName(dialog.FileName);
                    }
                }
            }
            else
            {
                isAttachedScript = false;
                attachScriptButton.Text = "Attach";

                currentScriptName = "";
            }
        }
        private void attachKeyframesButton_Click(object sender, EventArgs e)
        {
            if (isAttachedKeyframeAnimation == false)
            {
                using (OpenFileDialog dialog = new OpenFileDialog())
                {
                    dialog.Filter = "Animation File *.animdata|*.animdata|All files (*.*)|*.*";
                    dialog.FilterIndex = 1;
                    dialog.Multiselect = false;
                    dialog.InitialDirectory = EngineInstance.MainDirectory + @"\ANIMATION";

                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        isAttachedKeyframeAnimation = true;
                        attachKeyframesButton.Text = "Remove";

                        currentKeyframeAnimationName = Path.GetFileName(dialog.FileName);
                    }
                }
            }
            else
            {
                isAttachedKeyframeAnimation = false;
                attachKeyframesButton.Text = "Attach";

                currentKeyframeAnimationName = "";
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            List<string> imageFilenames = new List<string>();
            foreach (string filename in currentPaths)
            {
                imageFilenames.Add(Path.GetFileNameWithoutExtension(filename));
            }

            AnimatedSprite2D current = new AnimatedSprite2D(
                new Vector2<float>(float.Parse(posXInput.Text), float.Parse(posYInput.Text)),
                imageFilenames, float.Parse(animSpeedInput.Text), float.Parse(spriteScaleInput.Text),
                spriteNameTexbox.Text, int.Parse(spriteLayerInput.Text)
            );
            current.DoCollision = hasColliderToggle.Checked;
            current.IsVisible = visibleToggle.Checked;
            current.AttachedScriptName = currentScriptName;
            current.KeyframeAnimator.LoadAnimation(currentKeyframeAnimationName);

            levelEditor.AddSprite(current);
            this.Close();
        }
    }
}
