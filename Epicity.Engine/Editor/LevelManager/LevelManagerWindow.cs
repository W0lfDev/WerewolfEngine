using System.ComponentModel;
using Werewolf.Engine.Core.LevelStuff;
using Werewolf.Engine.Game;

namespace Werewolf.Engine.Editor
{
    public partial class LevelManagerWindow : Form
    {
        private Level selectedLevel;
        private int lastSelectedIndex;

        private Sprite2D selectedSprite;
        private int lastSelectedSpriteIndex;

        private bool isShown = false;

        private int lastSpriteScrollbarPosition;

        private GameInstance GameInstance;
        private LevelManager GameLevelManager;

        #region Background workers
        private BackgroundWorker searchWorker;
        private BackgroundWorker updateSpriteListWorker;
        #endregion

        public LevelManagerWindow()
        {
            InitializeComponent();

            #region Stupid winforms bullshit to hide the scrollbars
            spritesPanel.HorizontalScroll.Maximum = 0;
            spritesPanel.VerticalScroll.Maximum = 0;
            spritesPanel.AutoScroll = false;
            spritesPanel.VerticalScroll.Visible = false;
            spritesPanel.HorizontalScroll.Visible = false;
            spritesPanel.AutoScroll = true;

            allLevelsPanel.VerticalScroll.Maximum = 0;
            allLevelsPanel.HorizontalScroll.Maximum = 0;
            allLevelsPanel.AutoScroll = false;
            allLevelsPanel.HorizontalScroll.Visible = false;
            allLevelsPanel.VerticalScroll.Visible = false;
            allLevelsPanel.AutoScroll = true;
            #endregion

            #region Events
            LevelManager.OnLevelAdded += GameLevelManager_OnLevelAdded;
            this.Load += LevelManagerWindow_Load;

            this.Activated += LevelManagerWindow_Activated;
            this.FormClosed += LevelManagerWindow_FormClosed;
            this.FormClosing += (sender, e) =>
            {
                e.Cancel = true;

                this.Hide();
            };

            spritesPanel.MouseWheel += (sender, e) =>
            {
                lastSpriteScrollbarPosition = -spritesPanel.AutoScrollPosition.Y;
            };

            searchSpriteTextbox.Click += searchSpriteTextbox_Click;
            searchSpriteTextbox.KeyDown += searchSpriteTextbox_KeyDown;
            #endregion

            #region Bacgkround Workers Init
            searchWorker = new BackgroundWorker();
            searchWorker.DoWork += SearchWorker_DoWork;
            searchWorker.RunWorkerCompleted += SearchWorker_RunWorkerCompleted;

            updateSpriteListWorker = new BackgroundWorker();
            updateSpriteListWorker.DoWork += UpdateSpriteListWorker_DoWork;
            updateSpriteListWorker.RunWorkerCompleted += UpdateSpriteListWorker_RunWorkerCompleted;
            #endregion

            #region Add Button Click
            createLevelButton.Click += async(sender, e) =>
            {
                statusText.Text = "Opening tilemap editor...";
                addSelectPanel.Visible = false;

                ToolsWindowOpener.OpenToolWindow(MainWindowEditorControls.LevelEditor);

                await Task.Delay(1000);
                statusText.Text = "Ready";
            };
            createTilemapButton.Click += async (sender, e) =>
            {
                statusText.Text = "Opening tilemap editor...";
                addSelectPanel.Visible = false;

                ToolsWindowOpener.OpenToolWindow(MainWindowEditorControls.TilemapEditorTool);

                await Task.Delay(1000);
                statusText.Text = "Ready";
            };
            #endregion
        }

        public void AttachGameInstance(GameInstance gameInstance)
        {
            this.GameInstance = gameInstance;
            this.GameLevelManager = GameInstance.LevelManager;
        }

        private void LevelManagerWindow_FormClosed(object? sender, FormClosedEventArgs e) => isShown = false;

        private async void LevelManagerWindow_Activated(object? sender, EventArgs e)
        {
            isShown = true;

            await Task.Run(async () =>
            {
                this.Invoke(new Action(() =>
                {

                    UpdateLevelsList();
                    UpdateSpriteList();

                    spritesPanel.AutoScrollPosition = new Point(0, lastSpriteScrollbarPosition);
                }));

                await Task.Delay(100);

                this.Invoke(new Action(() =>
                {
                    SelectLevelLabel(lastSelectedIndex);

                    SelectSpriteLabel(lastSelectedSpriteIndex);
                    UpdateSpriteProperties();

                }));
            });
        }

        private void LevelManagerWindow_Load(object? sender, EventArgs e)
        {
            selectedLevel = GameLevelManager.CurrentLevel;
            lastSelectedIndex = GameLevelManager.GetLevels().IndexOf(selectedLevel);

            lastSelectedSpriteIndex = 0;
            selectedSprite = GameLevelManager.CurrentLevel.Sprites[0];

            addSelectPanel.Visible = false;

            loadingAnimation.Visible = false;
            statusText.Text = "Ready";

            SetupHandleSpritePropertiesSet();
            EditorStyle.ApplyStyle(this);
        }

        #region Level Add, Load
        private void GameLevelManager_OnLevelAdded(object sender, Level level, EventArgs e)
        {
            if (isShown)
            {
                UpdateLevelsList();
            }
        }

        private void UpdateLevelsList()
        {
            this.Invoke(new Action(() =>
            {
                allLevelsPanel.Controls.Clear();
                foreach (Level level in GameLevelManager.GetLevels())
                {

                    string levelIcon = "";

                    if (level is Level)
                    {
                        levelIcon = "🏼";
                        
                        if (level is Tilemap)
                        {
                            levelIcon = "🏁";
                        }
                        else if (level is BatchLevel)
                        {
                            levelIcon = "⿻";
                        }
                    }

                    Label levelLabel = new Label();
                    levelLabel.Size = new Size(allLevelsPanel.Width - 2, 25);
                    levelLabel.BorderStyle = BorderStyle.FixedSingle;
                    levelLabel.Margin = new Padding(0);
                    levelLabel.TextAlign = ContentAlignment.MiddleCenter;
                    levelLabel.Click += LevelLabel_Click;
                    levelLabel.Text = $"{levelIcon} {level.Name}";

                    allLevelsPanel.Controls.Add(levelLabel);
                }

                EditorStyle.ApplyStyle(this);
                SelectLevelLabel(lastSelectedIndex);
            }));
        }

        private void LevelLabel_Click(object? sender, EventArgs e)
        {
            int selectedIndex = allLevelsPanel.Controls.GetChildIndex((Control)sender);
            lastSelectedIndex = selectedIndex;

            selectedLevel = GameLevelManager.GetLevels()[selectedIndex];
            SelectLevelLabel(selectedIndex);
        }
        private void SelectLevelLabel(int index)
        {
            foreach (Control control in allLevelsPanel.Controls)
            {
                control.BackColor = Color.FromArgb(60, 60, 60);
                control.Font = new Font("Segoe UI Emoji", 9.5f, FontStyle.Regular);
            }
            allLevelsPanel.Controls[index].BackColor = Color.FromArgb(100, 140, 180);
            allLevelsPanel.Controls[index].Font = new Font("Segoe UI Emoji", 9.5f, FontStyle.Bold);
        }

        private async void loadSelectedLevelButton_Click(object sender, EventArgs e)
        {
            loadingAnimation.Visible = true;
            statusText.Text = "Loading...";

            foreach (Control control in allLevelsPanel.Controls)
            {
                control.Text = control.Text.Replace(" ⏺", "");
            }
            allLevelsPanel.Controls[lastSelectedIndex].Text += " ⏺";

            if (selectedLevel == GameLevelManager.CurrentLevel)
            {
                Console.WriteLine("Reload");
                await GameLevelManager.ReloadLevel();
            }
            else
            {
                Console.WriteLine("Load");
                await GameLevelManager.LoadLevel(selectedLevel, true, false);
            }

            await Task.Run(async () =>
            {
                while (GameLevelManager.IsLoading) { }

                this.Invoke(new Action(() =>
                {
                    statusText.Text = "Ready";
                    loadingAnimation.Visible = false;

                    UpdateSpriteList();
                }));
            });
        }

        private void addLevelButton_Click(object sender, EventArgs e)
        {
            addSelectPanel.Location = new Point(addLevelButton.Location.X, addLevelButton.Location.Y - 50);
            addSelectPanel.Size = new Size(100, 62);
            addSelectPanel.Visible = true;

            createLevelButton.Font = new Font("Segoe UI", 9);
            createTilemapButton.Font = new Font("Segoe UI", 9);
        }
        #endregion

        #region Sprite List and Properties

        #region Sprite List Update
        private async void UpdateSpriteList()
        {
            loadingAnimation.Visible = true;
            spritesPanel.Visible = false;
            allLevelsPanel.Visible = false;
            statusText.Text = "Updating list...";

            updateSpriteListWorker.RunWorkerAsync(); 
        }
        private void UpdateSpriteListWorker_DoWork(object? sender, DoWorkEventArgs e)
        {
            this.Invoke((Action)(() =>
            {
                spritesPanel.Controls.Clear();
                foreach (Sprite2D sprite in GameLevelManager.CurrentLevel.Sprites)
                {
                    Label spriteLabel = new Label();
                    spriteLabel.Text = sprite.Name;
                    spriteLabel.Size = new Size(spritesPanel.Width - 2, 25);
                    spriteLabel.BorderStyle = BorderStyle.FixedSingle;
                    spriteLabel.Margin = new Padding(0);
                    spriteLabel.TextAlign = ContentAlignment.MiddleCenter;
                    spriteLabel.Click += SpriteLabel_Click;

                    spritesPanel.Controls.Add(spriteLabel);
                }

                EditorStyle.ApplyStyle(this);
                SelectSpriteLabel(lastSelectedSpriteIndex);
            }));
        }
        private void UpdateSpriteListWorker_RunWorkerCompleted(object? sender, RunWorkerCompletedEventArgs e)
        {
            statusText.Text = "Ready";

            loadingAnimation.Visible = false;
            spritesPanel.Visible = true;
            allLevelsPanel.Visible = true;
        }
        #endregion

        #region Search Sprite List
        private void searchSpriteTextbox_Click(object? sender, EventArgs e)
        {
            searchSpriteTextbox.Text = "";
        }
        private async void searchSpriteTextbox_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                spritesPanel.Visible = false;
                loadingAnimation.Visible = true;
                statusText.Text = "Searching...";

                searchWorker.RunWorkerAsync();
            }
        }
        private void SearchWorker_DoWork(object? sender, DoWorkEventArgs e)
        {
            this.Invoke(new Action(() =>
            {
                string searchTerm = searchSpriteTextbox.Text.ToLower();

                foreach (Control control in spritesPanel.Controls)
                {
                    if (control is Label label)
                    {
                        string labelText = label.Text.ToLower();
                        label.Visible = labelText.Contains(searchTerm);
                    }
                }
            }));
        }
        private void SearchWorker_RunWorkerCompleted(object? sender, RunWorkerCompletedEventArgs e)
        {
            loadingAnimation.Visible = false;
            spritesPanel.Visible = true;
            statusText.Text = "Ready";
        }
        #endregion

        #region Select Sprite
        private void SpriteLabel_Click(object? sender, EventArgs e)
        {
            // Get selected index
            int selectedIndex = spritesPanel.Controls.GetChildIndex((Control)sender);
            lastSelectedSpriteIndex = selectedIndex;

            SelectSpriteLabel(selectedIndex);
        }

        private void SelectSpriteLabel(int index)
        {
            // Get selected sprite
            selectedSprite = GameLevelManager.CurrentLevel.Sprites[index];

            // Highlight selected
            foreach (Control control in spritesPanel.Controls)
            {
                control.BackColor = Color.FromArgb(60, 60, 60);
                control.Font = new Font("Segoe UI", 9, FontStyle.Regular);
            }
            spritesPanel.Controls[index].BackColor = Color.FromArgb(100, 140, 180);
            spritesPanel.Controls[index].Font = new Font("Segoe UI", 9, FontStyle.Bold);

            // Set the sprite DrawSelected value
            foreach (Sprite2D sprite in GameLevelManager.CurrentLevel.Sprites)
            {
                sprite.DrawSelected = false;
            }
            selectedSprite.DrawSelected = true;

            UpdateSpriteProperties();
        }
        #endregion

        #region Sprite Properties
        private void UpdateSpriteProperties()
        {
            spriteNameInput.Text = selectedSprite.Name;
            posXInput.Text = selectedSprite.Position.X.ToString();
            posYInput.Text = selectedSprite.Position.Y.ToString();
            sizeXInput.Text = selectedSprite.Size.X.ToString();
            sizeYInput.Text = selectedSprite.Size.Y.ToString();
            collisionToggle.Checked = selectedSprite.DoCollision;
            drawDebugToggle.Checked = selectedSprite.DrawDebug;
        }
        private void SetupHandleSpritePropertiesSet()
        {
            if (GameLevelManager.CurrentLevel == null || selectedSprite == null)
                return;

            setSpriteNameButton.Click += (sender, e) =>
            {
                selectedSprite.Name = spriteNameInput.Text;
                UpdateSpriteList();
            };

            posXInput.OnValueChanged += (sender, e) =>
            {
                selectedSprite.Position.X = float.Parse(posXInput.Text);
            };
            posYInput.OnValueChanged += (sender, e) =>
            {
                selectedSprite.Position.Y = float.Parse(posYInput.Text);
            };
            sizeXInput.OnValueChanged += (sender, e) =>
            {
                if (uniformSizeToggle.Checked)
                {
                    sizeYInput.Text = sizeXInput.Text;
                }

                selectedSprite.Size.X = float.Parse(sizeXInput.Text);
            };
            sizeYInput.OnValueChanged += (sender, e) =>
            {
                if (uniformSizeToggle.Checked)
                {
                    sizeXInput.Text = sizeYInput.Text;
                }

                selectedSprite.Size.Y = float.Parse(sizeYInput.Text);
            };
            collisionToggle.CheckedChanged += (sender, e) =>
            {
                selectedSprite.DoCollision = collisionToggle.Checked;
            };
            drawDebugToggle.CheckedChanged += (sender, e) =>
            {
                selectedSprite.DrawDebug = drawDebugToggle.Checked;
            };
        }
        #endregion

        #endregion
    }
}
