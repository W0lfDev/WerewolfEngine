using Werewolf.Engine.EngineManagement;
using Werewolf.Engine.Game;

namespace Werewolf.Engine.Editor
{
    public class MainWindowEditorControls
    {
        private static FlowLayoutPanel debugConsolePanel;

        public GameInstance? gameInstance;

        public static ToolsWindowOpener ToolsWindowOpener;
        public static TilemapEditor TilemapEditorTool;
        public static ToolboxSetup ToolboxSetup;
        public static LevelManagerWindow LevelManagerWindow;
        public static CreateScriptWindow ScriptCreatorWindow;
        public static LunaCopilotWindow CopilotWindow;
        public static KeyframeEditor KeyframeEditorWidnow;
        public static LevelEditorWindow LevelEditor;
        public static LevelBatchWindow.LevelBatcher LevelBatcherWindow;

        public MainWindowEditorControls(Form mainWindow)
        {
            Debug.Log("Loading EPICITY Editor...");

            ToolsWindowOpener = new ToolsWindowOpener(this);
            TilemapEditorTool = new TilemapEditor();
            ToolboxSetup = new ToolboxSetup();
            LevelManagerWindow = new LevelManagerWindow();
            ScriptCreatorWindow = new CreateScriptWindow();
            CopilotWindow = new LunaCopilotWindow(@"C:\Users\Preslav\AppData\Local\Programs\Python\Python310\python.exe");
            KeyframeEditorWidnow = new KeyframeEditor();
            LevelEditor = new LevelEditorWindow();
            LevelBatcherWindow = new LevelBatchWindow.LevelBatcher();

            AddButtons(mainWindow);
            AddFileExplorerLogic(mainWindow);

            AddDebugConsole(mainWindow);

            EditorStyle.ApplyStyle(mainWindow);
        }

        public void AttachGameInstance(GameInstance gameInstance) => this.gameInstance = gameInstance;

        #region Toolbar
        void AddButtons(Form form)
        {
            FlowLayoutPanel panel = new FlowLayoutPanel();
            panel.Dock = DockStyle.Top;
            panel.Height = 35;
            panel.BorderStyle = BorderStyle.FixedSingle;
            panel.BackColor = Color.FromArgb(55, 55, 55);
            panel.FlowDirection = FlowDirection.LeftToRight;
            panel.BorderStyle = BorderStyle.None;
            panel.WrapContents = false;

            Label brandingText = new Label();
            brandingText.Text = "Werewolf Engine";
            brandingText.Font = new Font("Segoe UI", 16, FontStyle.Bold);
            brandingText.Margin = new Padding(5, 0, 5, 0);
            brandingText.ForeColor = Color.White;
            brandingText.AutoSize = true;

            Button toolsWindowButton = new Button();
            toolsWindowButton.Text = "☰-";
            toolsWindowButton.Font = new Font("Segoe UI Emoji", 11);
            toolsWindowButton.ForeColor = Color.WhiteSmoke;
            toolsWindowButton.AutoSize = true;
            toolsWindowButton.Margin = new Padding(0, 0, 5, 0);
            toolsWindowButton.Click += (sender, args) =>
            {
                try
                {
                    if (gameInstance == null)
                        return;

                    if (gameInstance!.LevelManager.IsLoading)
                        return;

                    if (Screen.AllScreens.Length > 1)
                    {
                        Screen nonPrimaryScreen = Screen.AllScreens.FirstOrDefault(s => !s.Primary);

                        if (nonPrimaryScreen != null)
                        {
                            ToolsWindowOpener.StartPosition = FormStartPosition.Manual;

                            int centerX = nonPrimaryScreen.WorkingArea.Left + (nonPrimaryScreen.WorkingArea.Width - ToolsWindowOpener.Width) / 2;
                            int centerY = nonPrimaryScreen.WorkingArea.Top + (nonPrimaryScreen.WorkingArea.Height - ToolsWindowOpener.Height) / 2;
                            ToolsWindowOpener.Location = new Point(centerX, centerY);
                        }
                    }
                    else
                    {
                        gameInstance!.ToggleFullscreen(true, false);
                    }

                    if (ToolsWindowOpener == null)
                    {
                        ToolsWindowOpener = new ToolsWindowOpener(this);
                        ToolsWindowOpener.Show();
                    }
                    else if (!ToolsWindowOpener.Visible)
                    {
                        ToolsWindowOpener.Show();
                    }
                    else if (ToolsWindowOpener.Visible)
                    {
                        if (ToolsWindowOpener.WindowState == FormWindowState.Minimized)
                        {
                            ToolsWindowOpener.WindowState = FormWindowState.Normal;
                        }
                        ToolsWindowOpener.Focus();
                    }
                }
                catch (Exception ex)
                {
                    Debug.Warning("Failed to open editor toolset: " + ex);
                }
            };

            Button openFolderButton = new Button();
            openFolderButton.Text = $"📁-";
            openFolderButton.Font = new Font("Segoe UI Emoji", 11);
            openFolderButton.TextAlign = ContentAlignment.MiddleCenter;
            openFolderButton.AutoSize = true;
            openFolderButton.Margin = new Padding(0, 0, 5, 0);
            openFolderButton.ForeColor = Color.Yellow;
            openFolderButton.Click += (sender, args) =>
            {
                OpenFileExplorer();
            };

            Button openVSCodeProjectButton = new Button();
            openVSCodeProjectButton.Text = $"-";
            openVSCodeProjectButton.Image = Image.FromFile(Directory.GetCurrentDirectory() + @"\_vscode.icon.png");
            openVSCodeProjectButton.Font = new Font("Segoe UI Emoji", 11);
            openVSCodeProjectButton.TextAlign = ContentAlignment.MiddleCenter;
            openVSCodeProjectButton.AutoSize = true;
            openVSCodeProjectButton.Margin = new Padding(0, 0, 25, 0);
            openVSCodeProjectButton.ForeColor = Color.Yellow;
            openVSCodeProjectButton.Click += async (sender, args) =>
            {
                await ScriptCreatorWindow.OpenVSCode(EngineInstance.MainDirectory + @"\SCRIPT\", null, false);
            };

            Button playPauseButton = new Button();
            playPauseButton.Text = "⏸️-";
            playPauseButton.Font = new Font("Segoe UI Emoji", 16);
            playPauseButton.Size = new Size(30, 30);
            playPauseButton.ForeColor = Color.LightBlue;
            playPauseButton.Click += (sender, args) =>
            {
                if (EngineInstance.UpdateGameLogic)
                {
                    playPauseButton.Text = "▶️-";
                    playPauseButton.ForeColor = Color.LightGreen;
                    EngineInstance.UpdateGameLogic = false;
                }
                else
                {
                    playPauseButton.Text = "⏸️-";
                    playPauseButton.ForeColor = Color.LightBlue;
                    EngineInstance.UpdateGameLogic = true;
                }
            };

            Button stopButton = new Button();
            stopButton.Text = "⏹-";
            stopButton.Font = new Font("Segoe UI Emoji", 14);
            stopButton.Size = new Size(30, 30);
            stopButton.ForeColor = Color.Red;
            stopButton.Click += (sender, args) =>
            {
                form.Close();
            };

            Button restartButton = new Button();
            restartButton.Text = "♻-";
            restartButton.Font = new Font("Segoe UI Emoji", 14);
            restartButton.Size = new Size(30, 30);
            restartButton.ForeColor = Color.Orange;
            restartButton.Click += (sender, args) =>
            {
                string executablePath = Application.ExecutablePath;
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                {
                    FileName = executablePath,
                    UseShellExecute = true
                });

                form.Close();
            };

            Button hotReloadButton = new Button();
            hotReloadButton.Text = "🔥-";
            hotReloadButton.Font = new Font("Segoe UI Emoji", 14);
            hotReloadButton.Size = new Size(30, 30);
            hotReloadButton.Margin = new Padding(10, 0, 0, 0);
            hotReloadButton.ForeColor = Color.Red;
            hotReloadButton.Click += async (sender, args) =>
            {
                Debug.Warning("[Hot Reload] Not implemented yet!");
                //await gameInstance!.LevelManager!.CompileScripts();
            };

            Button resetSprites = new Button();
            resetSprites.Text = "Reset States ↻";
            resetSprites.Font = new Font("Segoe UI Emoji", 11, FontStyle.Bold);
            resetSprites.AutoSize = true;
            resetSprites.Margin = new Padding(35, 0, 0, 0);
            resetSprites.ForeColor = Color.LightGreen;
            resetSprites.Click += (sender, args) =>
            {
                gameInstance?.LevelManager?.ResetAllSpritesToDefault();
            };

            Button reloadLevelButton = new Button();
            reloadLevelButton.Text = "Reload Level 🔄";
            reloadLevelButton.Font = new Font("Segoe UI Emoji", 11, FontStyle.Bold);
            reloadLevelButton.Width = 145;
            reloadLevelButton.Height = 35;
            reloadLevelButton.Margin = new Padding(25, 0, 0, 0);
            reloadLevelButton.TextAlign = ContentAlignment.MiddleCenter;
            reloadLevelButton.ForeColor = Color.LightGreen;
            reloadLevelButton.Click += async (sender, args) =>
            {
                await gameInstance?.LevelManager?.ReloadLevel();
            };

            int debugState = DebugUI.GetDebugState();
            Button setDebugButton = new Button();
            setDebugButton.Text = $"Debug {debugState}";
            setDebugButton.Font = new Font("Segoe UI Emoji", 11);
            setDebugButton.AutoSize = true;
            setDebugButton.Margin = new Padding(25, 0, 0, 0);
            setDebugButton.ForeColor = Color.WhiteSmoke;
            setDebugButton.Click += (sender, args) =>
            {
                debugState++;
                if (debugState > 3)
                    debugState = 0;

                setDebugButton.Text = $"Debug {debugState}";

                DebugUI.SetDebugState(debugState);
            };

            Button fullscreenButton = new Button();
            fullscreenButton.Text = $"Toggle FullScreen";
            fullscreenButton.Font = new Font("Segoe UI Emoji", 11);
            fullscreenButton.AutoSize = true;
            fullscreenButton.Margin = new Padding(75, 0, 0, 0);
            fullscreenButton.ForeColor = Color.WhiteSmoke;
            fullscreenButton.Click += (sender, args) =>
            {
                string isFullscreenText = EngineInstance.IsFullscreen ? "OFF" : "ON";
                fullscreenButton.Text = $"FullScreen {isFullscreenText}";

                gameInstance?.ToggleFullscreen();
            };

            panel.Controls.Add(brandingText);
            panel.Controls.Add(toolsWindowButton);
            panel.Controls.Add(openFolderButton);
            panel.Controls.Add(openVSCodeProjectButton);
            panel.Controls.Add(playPauseButton);
            panel.Controls.Add(stopButton);
            panel.Controls.Add(restartButton);
            panel.Controls.Add(hotReloadButton);
            panel.Controls.Add(resetSprites);
            panel.Controls.Add(reloadLevelButton);
            panel.Controls.Add(setDebugButton);
            panel.Controls.Add(fullscreenButton);

            form.Controls.Add(panel);
        }

        void AddFileExplorerLogic(Form form)
        {
            form.KeyDown += (sender, e) =>
            {
                if (e.Control && e.KeyCode == Keys.Space)
                {
                    OpenFileExplorer();
                    e.Handled = true;
                }
            };
        }
        void OpenFileExplorer()
        {
            try
            {
                string arguments = $@"{EngineInstance.MainDirectory}";
                System.Diagnostics.Process.Start("explorer.exe", arguments);
            }
            catch (Exception ex)
            {
                Debug.ErrorBox($"Error opening File Explorer: {ex.Message}");
            }
        }
        #endregion

        private void AddDebugConsole(Form mainWindow)
        {
            debugConsolePanel = new FlowLayoutPanel();
            debugConsolePanel.FlowDirection = FlowDirection.TopDown;
            debugConsolePanel.WrapContents = false;
            debugConsolePanel.BringToFront();
            debugConsolePanel.Size = new Size(400, 30);
            debugConsolePanel.Location = new Point(5, EngineInstance.WindowHeight - 75);
            debugConsolePanel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            debugConsolePanel.BackColor = Color.FromArgb(50, 50, 50);
            debugConsolePanel.BorderStyle = BorderStyle.FixedSingle;

            #region Remove scroll bars and set auto scroll
            debugConsolePanel.VerticalScroll.Maximum = 0;
            debugConsolePanel.HorizontalScroll.Maximum = 0;
            debugConsolePanel.AutoScroll = false;
            debugConsolePanel.VerticalScroll.Visible = false;
            debugConsolePanel.HorizontalScroll.Visible = false;
            debugConsolePanel.AutoScroll = true;
            #endregion

            debugConsolePanel.MouseDoubleClick += (sender, args) =>
            {
                if (debugConsolePanel.Height <= 75)
                {
                    debugConsolePanel.Height = 200;
                    debugConsolePanel.Location = new Point(5, EngineInstance.WindowHeight - 210);
                }
                else
                {
                    debugConsolePanel.Height = 30;
                    debugConsolePanel.Location = new Point(5, EngineInstance.WindowHeight - 40);
                }
            };

            mainWindow.Controls.Add(debugConsolePanel);
        }

        public static void AddMessageToConsole(string type, string msg)
        {
            if (debugConsolePanel == null)
                return;

            debugConsolePanel.Invoke(new Action(() =>
            {
                Label message = new Label();
                message.Text = msg;
                message.Font = new Font("Consolas", 11);
                message.AutoSize = true;
                message.MaximumSize = new Size(debugConsolePanel.Width - 1, 0);
                message.Margin = new Padding(10, 10, 5, 0);

                if (type.ToLower() == "log") message.ForeColor = Color.Cyan;
                else if (type.ToLower() == "warning") message.ForeColor = Color.Yellow;
                else if (type.ToLower() == "error") message.ForeColor = Color.Red;

                debugConsolePanel.Controls.Add(message);

                debugConsolePanel.ScrollControlIntoView(message);
            }));
        }
    }
}
