using Markdig;
using System.Diagnostics;


namespace Werewolf.Engine.Editor
{
    public partial class LunaCopilotWindow : Form
    {
        public string codeInput = "";
        
        private string pyPath;
        private string template;

        private List<string[]> chatHistory = new List<string[]>();

        private bool HasLoaded = false;

        public LunaCopilotWindow(string pyhtonExePath)
        {
            InitializeComponent();
            this.FormClosing += (sender, e) =>
            {
                e.Cancel = true;
                this.Hide();
            };

            userPromptInput.KeyDown += async (sender, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    await AskLuna(userPromptInput.Text);
                }
            };

            this.pyPath = pyhtonExePath;
        }

        private async void LunaCopilotWindow_Load(object sender, EventArgs e)
        {
            try
            {
                HasLoaded = false;

                loadingAnimation.Visible = true;
                responseView.Visible = false;

                EditorStyle.ApplyStyle(this);
                await responseView.EnsureCoreWebView2Async();

                template = await GetPromptTemplate();

                loadingAnimation.Visible = false;
                HasLoaded = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException?.ToString() ?? ex.ToString());
            }
        }

        public async Task<string> AskAiFixCode(string code, string error)
        {
            if (template == null)
                template = await GetPromptTemplate();

            string userPrompt = $"I am getting error {error} in this code. " +
                $"You MUST fix, write the fixed code and answer by providing the code in C#:\n\"\n" + code + "\n\"\n";

            string fullPrompt = template
                                    .Replace("%usr_qstn%", userPrompt)
                                    .Replace("%chat_history", GetChatHistory());

            return await GenerateResponse(fullPrompt);
        }

        private async void askAiButton_Click(object sender, EventArgs e)
        {
            await AskLuna(userPromptInput.Text);
        }

        private async Task AskLuna(string userInput)
        {
            while (!HasLoaded)
            {
                await Task.Delay(100);
            }

            await this.Invoke(async () =>
            {
                try
                {
                    responseView.Visible = false;
                    loadingAnimation.Visible = true;

                    string fullPrompt = template
                                            .Replace("%usr_qstn%", userInput)
                                            .Replace("%chat_history", GetChatHistory());

                    string response = await GenerateResponse(fullPrompt);

                    string htmlResponse = ConvertMarkdownToHtml(response);
                    responseView.CoreWebView2.NavigateToString(htmlResponse);

                    chatHistory.Add(new string[]
                    {
                        userInput,
                        response
                    });
                }
                catch (Exception ex)
                {
                    Debug.Error(ex.ToString());
                }
            });

            loadingAnimation.Visible = false;
            responseView.Visible = true;
        }

        private string GetChatHistory()
        {
            if (chatHistory.Count <= 0)
            {
                return "no chat history";
            }

            string _history = "\n";
            foreach (string[] chat in chatHistory)
            {
                _history += $"question:{chat[0]}\n" +
                            $"response:{chat[1]}\n";
            }

            return _history;
        }

        private string ConvertMarkdownToHtml(string markdownText)
        {
            var pipeline = new Markdig.MarkdownPipelineBuilder().UseAdvancedExtensions().Build();
            string htmlText = Markdig.Markdown.ToHtml(markdownText, pipeline);

            string cssFilePath = @"luna\lunaStyle.css";
            string htmlWithCss = $@"
                        <!DOCTYPE html>
                        <html>
                        <head>
                            <link rel='stylesheet', href='{cssFilePath}'>
                            <link rel=""stylesheet"" href=""https://cdnjs.cloudflare.com/ajax/libs/highlight.js/10.7.2/styles/vs2015.min.css"">
                            <link rel=""stylesheet"" href=""https://fonts.googleapis.com/css2?family=Segoe+UI:wght@400;700&display=swap"">
                            <script src=""https://cdnjs.cloudflare.com/ajax/libs/highlight.js/10.7.2/highlight.min.js""></script>
                            <script>hljs.highlightAll();</script>
                        </head>
                        <body style = ""background-color: #3c3c3c; color: #e6edf3; font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; font-size: 16px; line-height: 1.5"">
                            <p>Luna: </p>
                            {htmlText}
                        </body>
                        </html>";

            return htmlWithCss;
        }

        private async Task<string> GetPromptTemplate()
        {
            string templateUrl = @"https://pastebin.com/raw/3SZyKPSv";
            string sourceUrl = @"https://pastebin.com/raw/z5sTeR4v";

            using (HttpClient httpClient = new HttpClient())
            {
                string template = await httpClient.GetStringAsync(templateUrl);
                string source_code = await httpClient.GetStringAsync(sourceUrl);

                return template.Replace("%source_code%", sourceUrl);
            }
        }

        private async Task<string> GenerateResponse(string fullPrompt)
        {
            try
            {
                return await Task.Run(() =>
                {
                    ProcessStartInfo processInfo = new ProcessStartInfo
                    {
                        FileName = pyPath,
                        Arguments = @"luna\luna.py",
                        RedirectStandardInput = true,
                        RedirectStandardOutput = true,
                        UseShellExecute = false,
                        //CreateNoWindow = true
                    };

                    using (Process process = new Process { StartInfo = processInfo })
                    {
                        process.Start();

                        StreamWriter sw = process.StandardInput;
                        StreamReader sr = process.StandardOutput;

                        sw.WriteLine(fullPrompt);

                        string response = sr.ReadToEnd();

                        process.WaitForExit();
                        return response;
                    }
                });
            }
            catch (Exception ex)
            {
                Debug.Error("Failed to run Luna Copilot: " + ex);
                return "error";
            }
        }
    }
}
