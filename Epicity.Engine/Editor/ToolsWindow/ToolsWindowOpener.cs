using Werewolf.Engine.EngineManagement;
using Werewolf.Engine.Game;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Werewolf.Engine.Editor
{
    public partial class ToolsWindowOpener : Form
    {
        public static GameInstance gameInstance;

        public ToolsWindowOpener(MainWindowEditorControls editorControls)
        {
            InitializeComponent();

            this.FormClosing += (sender, args) =>
            {
                args.Cancel = true;
                this.Hide();
            };
            this.Load += (sender, e) =>
            {
                SetStartPos(this);

                EditorStyle.ApplyStyle(this);
                gameInstance = editorControls.gameInstance;
            };
        }

        private static void SetStartPos(Form window)
        {
            if (Screen.AllScreens.Length > 1)
            {
                Screen primaryScreen = Screen.PrimaryScreen;
                window.StartPosition = FormStartPosition.Manual;

                int centerX = primaryScreen.WorkingArea.Left + (primaryScreen.WorkingArea.Width - window.Width) / 2;
                int centerY = primaryScreen.WorkingArea.Top + (primaryScreen.WorkingArea.Height - window.Height) / 2;

                window.Location = new System.Drawing.Point(centerX, centerY);
            }
            else
            {
                if (EngineInstance.IsFullscreen)
                {
                    gameInstance!.ToggleFullscreen(true, false);
                }
            }
        }

        public static void OpenToolWindow(Form window)
        {
            SetStartPos(window);

            if (!window.Visible)
            {
                window.Show();
            }
            else if (window.Visible)
            {
                if (window.WindowState == FormWindowState.Minimized)
                {
                    window.WindowState = FormWindowState.Normal;
                }
            }

            window.Focus();
        }

        private void tilemapEditorButton_Click(object sender, EventArgs e)
        {
            try
            {
                OpenToolWindow(MainWindowEditorControls.TilemapEditorTool);
            }
            catch (Exception ex)
            {
                Debug.Warning("Failed to open Tilemap Editor: " + ex);
            }
        }

        private void levelManagerButton_Click(object sender, EventArgs e)
        {
            try
            {
                MainWindowEditorControls.LevelManagerWindow.AttachGameInstance(gameInstance);
                OpenToolWindow(MainWindowEditorControls.LevelManagerWindow);
            }
            catch (Exception ex)
            {
                Debug.Warning("Failed to open Level Manager: " + ex);
            }
        }

        private void scriptCreateButton_Click(object sender, EventArgs e)
        {
            try
            {
                OpenToolWindow(MainWindowEditorControls.ScriptCreatorWindow);
            }
            catch (Exception ex)
            {
                Debug.Warning("Failed to open Script Creator: " + ex);
            }
        }

        private void lunaButton_Click(object sender, EventArgs e)
        {
            try
            {
                OpenToolWindow(MainWindowEditorControls.CopilotWindow);
            }
            catch (Exception ex)
            {
                Debug.Warning("Failed to open Luna Copilot: " + ex);
            }
        }

        private void keyframeEditorButton_Click(object sender, EventArgs e)
        {
            try
            {
                OpenToolWindow(MainWindowEditorControls.KeyframeEditorWidnow);
            }
            catch (Exception ex)
            {
                Debug.Warning("Failed to open Keyframe Editor Window: " + ex);
            }
        }

        private void levelEditorButton_Click(object sender, EventArgs e)
        {
            try
            {
                OpenToolWindow(MainWindowEditorControls.LevelEditor);
            }
            catch (Exception ex)
            {
                Debug.Warning("Failed to open Level Editor Window: " + ex);
            }
        }

        private void lvBatcherButton_Click(object sender, EventArgs e)
        {
            try
            {
                OpenToolWindow(MainWindowEditorControls.LevelBatcherWindow);
            }
            catch (Exception ex)
            {
                Debug.Warning("Failed to open Level Batcher: " + ex);
            }
        }
    }
}
