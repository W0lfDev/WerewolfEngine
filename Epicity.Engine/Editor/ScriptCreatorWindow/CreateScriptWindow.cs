using System.Diagnostics;
using System.Net;
using Werewolf.Engine.EngineManagement;

namespace Werewolf.Engine.Editor
{
    public partial class CreateScriptWindow : Form
    {
        public CreateScriptWindow()
        {
            InitializeComponent();
            this.FormClosing += (sender, e) =>
            {
                e.Cancel = true;

                this.Hide();
            };
            this.Activated += (sender, e) =>
            {
                scriptNameInput.Focus();
                scriptNameInput.Select();
            };
        }

        private void CreateScriptWindow_Load(object sender, EventArgs e)
        {
            EditorStyle.ApplyStyle(this);
        }

        private async void createButton_Click(object sender, EventArgs e)
        {
            loadingAnimation.Visible = true;

            string scriptName = scriptNameInput.Text.Replace(" ", "");

            const string templateUrl = @"https://pastebin.com/raw/2YLwCWBG";
            string template = "";

            string filePath = EngineInstance.MainDirectory + $@"\SCRIPT\{scriptName}.cs";
            string dirPath = EngineInstance.MainDirectory + @"\SCRIPT\";

            try
            {
                // Get the template data
                using (WebClient webClient = new WebClient())
                {
                    template = webClient.DownloadString(templateUrl);
                }

                // Set template class name
                template = template.Replace("Template", scriptName);

                // Create file with template
                File.WriteAllText(filePath, template);

                // Open the file in Visual Studio Code
                await OpenVSCode(dirPath, filePath, true);

                // Set some delay for hiding
                await Task.Delay(1000);

                // Reset and Hide the window
                loadingAnimation.Visible = false;
                scriptNameInput.Text = "";
                this.Hide();
            }
            catch (WebException ex)
            {
                Debug.Error("Failed to get template data: " + ex);
                return;
            }
            catch (Exception ex)
            {
                Debug.Error("Failed to create script: " + ex);
                return;
            }
        }

        public async Task OpenVSCode(string folderPath, string filePath, bool openFile)
        {
            try
            {
                string args = "";
                if (openFile) args = $"{folderPath} {filePath}";
                else args = folderPath;

                // Start Visual Studio Code
                ProcessStartInfo processInfo = new ProcessStartInfo
                {
                    FileName = "scriptcreate.bat",
                    Arguments = args,
                    CreateNoWindow = false,
                };
                using (Process process = new Process())
                {
                    process.StartInfo = processInfo;
                    process.Start();
                }
            }
            catch (Exception ex)
            {
                Debug.Error("Failed to open VSCode: " + ex);
            }
        }
    }
}
