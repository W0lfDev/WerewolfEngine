
using Epicity.Engine.Editor.LevelEditor;
using Werewolf.Engine.EngineManagement;

namespace Werewolf.Engine.Editor
{
    public partial class LevelEditorWindow : Form
    {
        private List<AnimatedSprite2D> Sprites = new List<AnimatedSprite2D>();
        private PictureBox selectedSpritePreview;

        public LevelEditorWindow()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.FormClosing += (sender, e) =>
            {
                e.Cancel = true;
                this.Hide();
            };

            loadingAnimation.Visible = false;
        }

        private void LevelEditorWindow_Load(object sender, EventArgs e)
        {
            EditorStyle.ApplyStyle(this);
            statusText.Text = "Ready";
        }

        private void addSpriteButton_Click(object sender, EventArgs e)
        {
            new SpriteManager(this, false).ShowDialog();
        }

        public void AddSprite(AnimatedSprite2D sprite)
        {
            statusText.Text = "Ready";

            Sprites.Add(sprite);
            UpdateSpriteList();

            SelectLabel(Sprites.Count - 1);

            AddSpriteToViewport(sprite);
        }

        private void UpdateSpriteList()
        {
            levelSpritesPanel.Controls.Clear();
            foreach (AnimatedSprite2D sprite in Sprites)
            {
                Label spriteLabel = new Label();
                spriteLabel.Text = $"{sprite.Name} {sprite.Position.ToString()}";
                spriteLabel.Size = new Size(levelSpritesPanel.Width - 2, 25);
                spriteLabel.BorderStyle = BorderStyle.FixedSingle;
                spriteLabel.Margin = new Padding(0);
                spriteLabel.TextAlign = ContentAlignment.MiddleCenter;
                spriteLabel.MouseDoubleClick += SpriteLabel_MouseDoubleClick;
                spriteLabel.MouseClick += SpriteLabel_MouseClick;

                levelSpritesPanel.Controls.Add(spriteLabel);
            }

            EditorStyle.ApplyStyle(this);
        }

        private void SpriteLabel_MouseClick(object? sender, MouseEventArgs e)
        {
            int index = levelSpritesPanel.Controls.IndexOf((Control)sender);

            if (e.Button == MouseButtons.Left)
            {
                SelectLabel(index);
            }
            else if (e.Button == MouseButtons.Right)
            {
                Sprites.RemoveAt(index);
                RemoveSpriteFromViewport((PictureBox)viewportPanel.Controls[index]);
                UpdateSpriteList();
            }

            statusText.Text = "Ready";
        }

        private void SpriteLabel_MouseDoubleClick(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int index = levelSpritesPanel.Controls.IndexOf((Control)sender);
                new SpriteManager(this, true, Sprites.ElementAt(index)).ShowDialog();
            }
        }

        private void SelectLabel(int index)
        {
            foreach (Control control in levelSpritesPanel.Controls)
            {
                control.BackColor = Color.FromArgb(60, 60, 60);
                control.Font = new Font("Segoe UI", 9f, FontStyle.Regular);
            }
            levelSpritesPanel.Controls[index].BackColor = Color.FromArgb(100, 140, 180);
            levelSpritesPanel.Controls[index].Font = new Font("Segoe UI", 9f, FontStyle.Bold);
        }

        private void AddSpriteToViewport(AnimatedSprite2D sp)
        {
            PictureBox previewBox = new PictureBox();

            Bitmap spritePreview = (Bitmap)Image.FromFile(EngineInstance.MainDirectory + $@"\IMAGE\{sp.ImageNames[0]}.png");

            int scaledWidth = (int)(spritePreview.Width * sp.Scale);
            int scaledHeight = (int)(spritePreview.Height * sp.Scale);

            Bitmap scaledBitmap = new Bitmap(scaledWidth, scaledHeight);
            using (Graphics g = Graphics.FromImage(scaledBitmap))
            {
                g.DrawImage(spritePreview, new Rectangle(0, 0, scaledWidth, scaledHeight));
            }

            previewBox.Draggable(true);
            previewBox.Image = scaledBitmap;
            previewBox.Size = new Size(scaledWidth, scaledHeight);
            previewBox.MouseDown += PreviewBox_MouseDown;
            previewBox.MouseUp += SetSpritePositionToPreview;
            previewBox.LocationChanged += PreviewBox_LocationChanged;

            viewportPanel.Controls.Add(previewBox);
        }

        private void RemoveSpriteFromViewport(PictureBox spPreview)
        {
            viewportPanel.Controls.Remove(spPreview);
        }

        private void PreviewBox_LocationChanged(object? sender, EventArgs e)
        {
            PictureBox senderBox = (PictureBox)sender;
            senderBox.Location = new Point(
                Math.Clamp(senderBox.Location.X, -10, int.MaxValue),
                Math.Clamp(senderBox.Location.Y, -10, int.MaxValue)
            );
        }

        private void SetSpritePositionToPreview(object? sender, MouseEventArgs e)
        {
            int index = viewportPanel.Controls.IndexOf((Control)sender);
            PictureBox senderBox = (PictureBox)sender;

            Sprites[index].Position = new Maths.Vector2<float>(
                senderBox.Location.X,
                senderBox.Location.Y
            );

            UpdateSpriteList();
            statusText.Text = "Ready";
        }

        private void PreviewBox_MouseDown(object? sender, MouseEventArgs e)
        {
            SelectLabel(viewportPanel.Controls.IndexOf((Control)sender));
        }

        private async void saveButton_Click(object sender, EventArgs e)
        {
            loadingAnimation.Visible = true;
            statusText.Text = "Saving...";

            string fullPath = EngineInstance.MainDirectory + $@"\LEVEL\{levelNameTextbox.Text}.lvdata";
            string data = "";

            foreach (AnimatedSprite2D sp in Sprites)
            {
                string imageNames = "";
                foreach (string name in sp.ImageNames)
                {
                    imageNames += $"{name}~";
                }

                data += $"{sp.Name}|{imageNames}|{sp.Position.X}|{sp.Position.Y}|" +
                        $"{sp.Scale}|{sp.AnimationSpeed}|{sp.Layer}|" +
                        $"{sp.DoCollision}|{sp.IsVisible}|{sp.AttachedScriptName}|{sp.KeyframeAnimator.Name}";
            }

            await File.WriteAllTextAsync(fullPath, data);

            loadingAnimation.Visible = false;
            statusText.Text = "Saved";
        }
    }
}
