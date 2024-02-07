using System.ComponentModel;
using System.Data;
using Werewolf.Engine.EngineManagement;

namespace Werewolf.Engine.Editor
{
    public partial class TilemapEditor : Form
    {
        private List<TilemapButton> selectedTiles = new List<TilemapButton>();
        private BackgroundWorker backgroundWorker;

        private Label tilesPanelLoadingLabel;

        private float currentZoom = 3f;

        private int tmButtonSizeFactor;
        private Tile selectedTile;

        private float tileScale = 0;

        private TilemapButtonsPanel tilemapButtonsPanel;

        public TilemapEditor()
        {
            this.FormClosing += (sender, args) =>
            {
                args.Cancel = true;

                backgroundWorker.CancelAsync();
                this.Hide();
            };
            this.Activated += (sender, args) =>
            {
                LoadToolbox();
            };

            this.DoubleBuffered = true;

            InitializeComponent();
            this.Load += TilemapEditor_Load;
        }

        private void TilemapEditor_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

            EditorStyle.ApplyStyle(this);
            createTilemap.Font = new Font("Segoe UI", 9);

            Tileset.LoadFromTilesetData();
            LoadToolbox();

            backgroundWorker = new BackgroundWorker();
            backgroundWorker.ProgressChanged += BackgroundWorker_ProgressChanged;
            backgroundWorker.WorkerReportsProgress = true;
            backgroundWorker.WorkerSupportsCancellation = true;
            backgroundWorker.DoWork += BackgroundWorker_DoWork; ;
            backgroundWorker.RunWorkerCompleted += BackgroundWorker_RunWorkerCompleted;

            tilesPanelLoadingLabel = new Label();
            tilesPanelLoadingLabel.Text = "Please wait...";
            tilesPanelLoadingLabel.Font = new Font("Consolas", 18);
            tilesPanelLoadingLabel.Dock = DockStyle.Fill;
            tilesPanelLoadingLabel.TextAlign = ContentAlignment.MiddleCenter;
            tilesPanelLoadingLabel.ForeColor = Color.White;
            tilesPanelLoadingLabel.Visible = false;
            Controls.Add(tilesPanelLoadingLabel);

            taskProgressBar.Visible = false;
            loadingAnimation.Visible = false;
            statusText.Text = "No tilemap";
        }

        private async void createTilemap_Click(object sender, EventArgs e)
        {
            if (scaleTextbox.Text == "" || !int.TryParse(scaleTextbox.Text, out _))
            {
                statusText.Text = "Invalid scale value!";
                return;
            }

            await Task.Run(async () =>
            {
                this.Invoke(new Action(() =>
                {
                    statusText.Text = "Clearing...";

                    loadingAnimation.Visible = true;
                    tilemapButtonsPanel.Visible = false;

                    tilesPanelLoadingLabel.BringToFront();
                }));

                await Task.Delay(100); // Ensure that ui is updated

                this.Invoke(new Action(() =>
                {
                    tilemapButtonsPanel.Controls.Clear();
                    selectedTiles.Clear();
                }));
            });

            this.tmButtonSizeFactor = int.Parse(scaleTextbox.Text);

            taskProgressBar.Visible = true;
            tilesPanelLoadingLabel.Visible = true;
            tilesPanelLoadingLabel.BringToFront();

            if (!backgroundWorker.IsBusy)
                backgroundWorker.RunWorkerAsync();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {

            string tempData = "";
            List<string> saveData = new List<string>();

            int lastXPos = 0;

            foreach (TilemapButton button in
                tilemapButtonsPanel.Controls
                    .Cast<TilemapButton>()
                    .OrderBy(b => b.Location.Y)
                    .ThenBy(b => b.Location.X))
            {
                Point currentPosition = new Point(button.Location.X / (int)(16 * currentZoom), button.Location.Y / (int)(16 * currentZoom));

                if (currentPosition.X < lastXPos)
                {
                    tempData += "\n";
                }

                lastXPos = currentPosition.X;
                tempData += $"|{button.AssociatedChar}";
            }

            // Clean commas
            foreach (string line in tempData.Split('\n'))
            {
                if (!string.IsNullOrEmpty(line))
                {
                    saveData.Add(line.Remove(0, 1));
                }
            }

            // Add Tile Size Data
            saveData.Insert(0, tileScaleInput.Text);
            // Get majority size
            int majoritySize = Maths.GameMath.GetMajorityValue(Tileset.GetTilesWidths());
            saveData.Insert(1, majoritySize.ToString());

            // Save
            File.WriteAllLines(EngineInstance.MainDirectory + $@"\LEVEL\{tilemapNameTextbox.Text}.tmdata", saveData);
            statusText.Text = "Saved";
        }

        #region Toolbox
        private void setupToolboxButton_Click(object sender, EventArgs e)
        {
            ToolsWindowOpener.OpenToolWindow(MainWindowEditorControls.ToolboxSetup);
        }

        private void LoadToolbox()
        {
            tilesToolbox.Controls.Clear();

            foreach (Tile tile in Tileset.GetTiles())
            {
                TileControl tileControl = new TileControl();
                tileControl.Create(tile);

                tileControl.Click += TileControl_Click;
                foreach (Control child in tileControl.Controls)
                {
                    child.Click += TileControl_Click;
                }

                tilesToolbox.Controls.Add(tileControl);
            }

            EditorStyle.ApplyStyle(this);
        }

        private void TileControl_Click(object? sender, EventArgs e)
        {
            TileControl? senderTileControl = null;
            if (sender is not TileControl)
            {
                Control parent = (sender as Control)?.Parent;
                if (parent != null)
                {
                    senderTileControl = parent as TileControl;
                }
            }
            else
            {
                senderTileControl = sender as TileControl;
            }

            foreach (TileControl control in tilesToolbox.Controls)
            {
                control.BorderStyle = BorderStyle.None;
            }
            senderTileControl.BorderStyle = BorderStyle.FixedSingle;

            selectedTile = senderTileControl!.AssignedTile;
        }
        #endregion

        #region Tilemap load
        private void BackgroundWorker_DoWork(object? sender, DoWorkEventArgs e)
        {
            InitializeButtons(e);
        }

        private async void BackgroundWorker_RunWorkerCompleted(object? sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                statusText.Text = "Operation cancelled";
                tilemapButtonsPanel.Controls.Clear();
            }
            else if (e.Error != null)
            {
                tilemapButtonsPanel.Controls.Clear();

                statusText.Text = "Error while creating tilemap";
            }
            else
            {
                tilesPanelLoadingLabel.BringToFront();
                statusText.Text = "Adding tiles...";

                await Task.Run(async () =>
                {
                    await Task.Delay(100);
                    this.Invoke((MethodInvoker)delegate
                    {
                        EditorStyle.ApplyStyle(this);
                        tilemapButtonsPanel.Visible = true;
                    });
                });

                statusText.Text = "Ready";
            }

            taskProgressBar.Visible = false;
            loadingAnimation.Visible = false;
            tilemapButtonsPanel.Visible = true;
            tilesPanelLoadingLabel.SendToBack();
        }

        private void BackgroundWorker_ProgressChanged(object? sender, ProgressChangedEventArgs e)
        {
            taskProgressBar.Value = e.ProgressPercentage;
            statusText.Text = $"Loading... {e.ProgressPercentage}%";
        }

        private void InitializeButtons(DoWorkEventArgs e)
        {
            int rows = 16 * tmButtonSizeFactor;
            int columns = 9 * tmButtonSizeFactor;

            int buttonWidth = (int)(16 * currentZoom);
            int buttonHeight = (int)(16 * currentZoom);

            int totalButtons = rows * columns;
            int buttonCount = 0;

            for (int x = 0; x < rows; x++)
            {
                for (int y = 0; y < columns; y++)
                {
                    if (backgroundWorker.CancellationPending)
                    {
                        e.Cancel = true;
                        return;
                    }

                    buttonCount++;

                    TilemapButton button = new TilemapButton();
                    button.Name = "tile" + (y * columns + x);
                    button.Text = "0";
                    button.AssociatedChar = "0";
                    button.Font = new Font("Segoe UI", 1);
                    button.ForeColor = Color.Gray;
                    button.Size = new Size(buttonWidth, buttonHeight);
                    button.Location = new Point(x * (buttonWidth), y * (buttonHeight));

                    button.MouseMove += TIlemapButton_MouseMove;
                    button.MouseClick += (sender, e) =>
                    {
                        if (e.Button == MouseButtons.Left)
                        {
                            SelectTile((TilemapButton)sender);
                        }
                        else if (e.Button == MouseButtons.Right)
                        {
                            DeselectTile((TilemapButton)sender);
                        }
                    };

                    if (tilemapButtonsPanel.InvokeRequired)
                    {
                        tilemapButtonsPanel.Invoke(() => tilemapButtonsPanel.Controls.Add(button));
                    }
                    else
                    {
                        tilemapButtonsPanel.Controls.Add(button);
                    }

                    int progress = (int)((double)buttonCount / totalButtons * 100);
                    backgroundWorker.ReportProgress(progress);
                }
            }
        }
        #endregion

        #region Tilemap drawing
        private void TIlemapButton_MouseMove(object? sender, MouseEventArgs e)
        {
            Point localMousePosition = tilemapButtonsPanel.PointToClient(MousePosition);
            TilemapButton tileUnderCursor = GetButtonAtPoint(localMousePosition);

            if (e.Button == MouseButtons.Left)
            {
                if (tileUnderCursor != null && !selectedTiles.Contains(tileUnderCursor))
                {
                    SelectTile(tileUnderCursor);
                }

                statusText.Text = "Ready*";
            }
            else if (e.Button == MouseButtons.Right)
            {
                if (tileUnderCursor != null && selectedTiles.Contains(tileUnderCursor))
                {
                    DeselectTile(tileUnderCursor);
                }

                statusText.Text = "Ready*";
            }
        }

        private void SelectTile(TilemapButton button)
        {
            if (selectedTile == null)
                return;

            button.Text = selectedTile.AssociatedChar;
            button.Image = selectedTile.GetImageSized(button.Size, 0);
            button.AssociatedChar = selectedTile.AssociatedChar;

            selectedTiles.Add(button);
        }
        private void DeselectTile(TilemapButton button)
        {
            button.Text = "0";
            button.ForeColor = Color.Gray;
            button.Image = null;
            button.AssociatedChar = "0";

            selectedTiles.Remove(button);
        }

        private TilemapButton GetButtonAtPoint(Point location)
        {
            return tilemapButtonsPanel.GetChildAtPoint(location) as TilemapButton;
        }
        #endregion

        #region Zoom In Out
        private async void zoomInButton_Click(object sender, EventArgs e)
        {
            await ZoomIn();
        }
        private async void zoomOutButton_Click(object sender, EventArgs e)
        {
            await ZoomOut();
        }
        async Task ZoomIn()
        {
            tilemapButtonsPanel.Visible = false;
            loadingAnimation.Visible = true;

            await Task.Delay(10);

            foreach (TilemapButton button in tilemapButtonsPanel.Controls)
            {
                button.Size = new Size((int)(button.Size.Width * 2), (int)(button.Size.Height * 2));
                button.Location = new Point((int)(button.Location.X * 2), (int)(button.Location.Y * 2));

                if (button.Image != null)
                    button.Image = new Bitmap(button.Image, button.Size);
            }

            currentZoom += 1;
            zoomText.Text = $"{currentZoom * 100}%";

            tilemapButtonsPanel.Visible = true;
            loadingAnimation.Visible = false;
        }
        async Task ZoomOut()
        {
            tilemapButtonsPanel.Visible = false;
            loadingAnimation.Visible = true;

            await Task.Delay(10);

            foreach (TilemapButton button in tilemapButtonsPanel.Controls)
            {
                button.Size = new Size((int)(button.Size.Width / 2), (int)(button.Size.Height / 2));
                button.Location = new Point((int)(button.Location.X / 2), (int)(button.Location.Y / 2));

                if (button.Image != null)
                    button.Image = new Bitmap(button.Image, button.Size);
            }

            currentZoom -= 1;
            zoomText.Text = $"{currentZoom * 100}%";

            tilemapButtonsPanel.Visible = true;
            loadingAnimation.Visible = false;
        }
        #endregion
    }

    public class TilemapButton : Button
    {
        public bool IsSelected { get; set; }
        public string AssociatedChar { get; set; }
    }
    public class TilemapButtonsPanel : System.Windows.Forms.Panel
    {
        private const int WM_NCCALCSIZE = 0x0083;
        private const int WM_MOUSEWHEEL = 0x020A;

        public TilemapButtonsPanel()
        {
            this.DoubleBuffered = true;

            this.AutoScroll = true;
            this.HScroll = false;
            this.VScroll = false;
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_NCCALCSIZE)
            {
                // Prevent the control from calculating the client area size, which hides the scroll bars
                m.Result = IntPtr.Zero;
            }
            else if (m.Msg == WM_MOUSEWHEEL)
            {
                int shiftPressed = (Control.ModifierKeys & Keys.Shift) == Keys.Shift ? 1 : 0;
                int delta = (int)m.WParam >> 16;

                if (shiftPressed != 0)
                {
                    // Manually scroll horizontally
                    int scrollAmount = SystemInformation.MouseWheelScrollLines * delta;
                    int newHorizontalScroll = this.HorizontalScroll.Value - scrollAmount;

                    // Ensure the new scroll position is within bounds
                    newHorizontalScroll = Math.Max(newHorizontalScroll, this.HorizontalScroll.Minimum);
                    newHorizontalScroll = Math.Min(newHorizontalScroll, this.HorizontalScroll.Maximum);

                    this.HorizontalScroll.Value = newHorizontalScroll;

                    // Prevent default vertical scrolling
                    m.Result = IntPtr.Zero;
                }
                else
                {
                    // Default vertical scrolling behavior
                    base.WndProc(ref m);
                }
            }
            else
            {
                base.WndProc(ref m);
            }
        }
    }
}
