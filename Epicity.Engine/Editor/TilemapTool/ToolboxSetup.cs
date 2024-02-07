using Werewolf.Engine.EngineManagement;

namespace Werewolf.Engine.Editor
{
    public partial class ToolboxSetup : Form
    {
        private string currentTileName;
        private int currentWidth, currentHeight;
        private string currentTileChar;
        private bool currentHasCollider;

        private List<Image>? currentImages;
        private List<string> currentPaths;

        private bool isAttachedScript = false;
        private string currentScriptName;

        public ToolboxSetup()
        {
            InitializeComponent();

            this.FormClosing += (sender, e) =>
            {
                e.Cancel = true;
                this.Hide();
            };
            this.Load += (sender, e) =>
            {
                EditorStyle.ApplyStyle(this);
                ResetValues();

                UpdateToolbox();
            };
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            List<string> saveTileData = new List<string>();
            foreach (Tile tile in Tileset.GetTiles())
            {
                string imagePathsData = "";
                foreach (string path in tile.ImagePaths)
                {
                    imagePathsData += Path.GetFileName(path);
                    if (tile.ImagePaths.Count > 1)
                    {
                        imagePathsData += "~";
                    }
                }

                if (tile.ImagePaths.Count > 1)
                {
                    if (!string.IsNullOrEmpty(imagePathsData))
                    {
                        imagePathsData = imagePathsData.Remove(imagePathsData.Length - 1);
                    }
                }

                string tileData = $"{tile.Name}|{tile.Width}|{tile.Height}|{tile.AssociatedChar}|{imagePathsData}|{tile.AttachedScriptName}|{tile.DoCollision}";
                saveTileData.Add(tileData);
            }

            File.WriteAllLines(EngineInstance.MainDirectory + @"\LEVEL\tileset.tsdata", saveTileData);

            this.Hide();
        }

        private void tileImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files (*.bmp;*.jpg;*.jpeg;*.png)|*.bmp;*.jpg;*.jpeg;*.png|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.Multiselect = true;
                openFileDialog.InitialDirectory = EngineInstance.MainDirectory + @"\IMAGES";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
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

                    tileImage.Image = new Bitmap(compositeImage, tileImage.Size);

                    tileSizeXInput.Text = currentImages[0].Width.ToString();
                    tileSizeYInput.Text = currentImages[0].Height.ToString();

                    clickToAddLbl.Visible = false;
                }
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            try
            {
                currentTileName = tileNameTexbox.Text;
                currentWidth = int.Parse(tileSizeXInput.Text);
                currentHeight = int.Parse(tileSizeYInput.Text);
                currentTileChar = tileCharInput.Text;
                currentHasCollider = hasColliderToggle.Checked;

                // Check size
                int majorityWidth = Maths.GameMath.GetMajorityValue(Tileset.GetTilesWidths());
                int majorityHeight = Maths.GameMath.GetMajorityValue(Tileset.GetTilesHeights());

                if (currentWidth != majorityWidth || currentHeight != majorityHeight)
                {
                    if (majorityWidth != 0 && majorityHeight != 0)
                    {
                        currentWidth = majorityWidth;
                        currentHeight = majorityHeight;
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.Error("Failed to add tile: " + ex.Message);
                return;
            }

            if (currentTileName == "" || currentWidth <= 0 || currentHeight <= 0 || currentTileChar == "" || currentImages == null || currentPaths == null)
                return;

            Tile currentTile = new Tile(currentTileName, currentWidth, currentHeight, currentTileChar, currentImages, currentPaths, currentScriptName, currentHasCollider);
            Tileset.AddTile(currentTile);

            UpdateToolbox();
            ResetValues();
        }

        void UpdateToolbox()
        {
            inToolboxPanel.Controls.Clear();

            foreach (Tile tile in Tileset.GetTiles())
            {
                PictureBox tilePreview = new PictureBox();
                tilePreview.Size = tile.PreviewSizeSmall;
                tilePreview.Image = new Bitmap(tile.PreviewImage, tile.PreviewSizeSmall);
                tilePreview.MouseClick += (sender, e) =>
                {
                    if (e.Button == MouseButtons.Right)
                    {
                        int index = inToolboxPanel.Controls.IndexOf((PictureBox)sender);

                        Tileset.RemoveTile(Tileset.GetTiles()[index]);
                        inToolboxPanel.Controls.RemoveAt(index);

                        UpdateToolbox();
                    }
                };

                inToolboxPanel.Controls.Add(tilePreview);
            }
        }

        void ResetValues()
        {
            currentTileName = "";
            currentWidth = 0;
            currentHeight = 0;
            currentTileName = "";
            currentPaths = new List<string>();
            currentImages = new List<Image>();
            currentScriptName = "";

            tileNameTexbox.Text = "";
            tileSizeXInput.Text = "0";
            tileSizeYInput.Text = "0";
            tileCharInput.Text = "";
            tileImage.Image = null;

            attachScriptButton.Text = "Attach";
            isAttachedScript = false;

            clickToAddLbl.Visible = true;
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
    }
}
