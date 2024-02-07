namespace Werewolf.Engine.Editor
{
    public partial class LunaErrorBox : Form
    {
        private string code;
        private string error;
        private string filePath;

        public LunaErrorBox(string error, string code, string filePath)
        {
            InitializeComponent();

            this.code = code;
            this.error = error;
            this.filePath = filePath;

            ignoreButton.Text = "Retry";
        }

        private void LunaErrorBox_Load(object sender, EventArgs e)
        {
            this.TopMost = true;

            errorText.Text = error;
            loadingAnimation.Visible = false;

            EditorStyle.ApplyStyle(this);
            SetStatusColor(Color.Firebrick);
        }

        private async void fixWithLunaButton_Click(object sender, EventArgs e)
        {
            loadingAnimation.Visible = true;
            statusText.Text = "Fixing...";
            statusIcon.Text = "🛠";
            SetStatusColor(Color.CornflowerBlue);

            string fix = await MainWindowEditorControls.CopilotWindow.AskAiFixCode(code, error);

            int startIndex = fix.IndexOf("```csharp") + "```csharp".Length;
            int endIndex = fix.IndexOf("```", startIndex);

            string extractedFix = fix.Substring(startIndex, endIndex - startIndex).Trim();

            await File.WriteAllTextAsync(filePath, extractedFix);

            loadingAnimation.Visible = false;
            statusText.Text = "Fixed!";
            statusIcon.Text = "✅";
            SetStatusColor(Color.Green);

            await Task.Delay(1000);

            this.Close();
        }

        private void SetStatusColor(Color color)
        {
            errorBackgroundPanel.BackColor = color;
            foreach (Control control in errorBackgroundPanel.Controls)
            {
                control.BackColor = color;
            }
        }

        private void ignoreButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
