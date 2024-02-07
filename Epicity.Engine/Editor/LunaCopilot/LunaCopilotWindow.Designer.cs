namespace Werewolf.Engine.Editor
{
    partial class LunaCopilotWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LunaCopilotWindow));
            askAiButton = new Button();
            userPromptInput = new TextBox();
            responseView = new Microsoft.Web.WebView2.WinForms.WebView2();
            loadingAnimation = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)responseView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)loadingAnimation).BeginInit();
            SuspendLayout();
            // 
            // askAiButton
            // 
            askAiButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            askAiButton.Font = new Font("Segoe UI Emoji", 9F);
            askAiButton.ForeColor = SystemColors.ControlText;
            askAiButton.Location = new Point(654, 466);
            askAiButton.Name = "askAiButton";
            askAiButton.Size = new Size(118, 33);
            askAiButton.TabIndex = 1;
            askAiButton.Text = "Ask Luna";
            askAiButton.UseVisualStyleBackColor = true;
            askAiButton.Click += askAiButton_Click;
            // 
            // userPromptInput
            // 
            userPromptInput.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            userPromptInput.BorderStyle = BorderStyle.FixedSingle;
            userPromptInput.Location = new Point(12, 466);
            userPromptInput.Multiline = true;
            userPromptInput.Name = "userPromptInput";
            userPromptInput.Size = new Size(636, 33);
            userPromptInput.TabIndex = 3;
            // 
            // responseView
            // 
            responseView.AllowExternalDrop = true;
            responseView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            responseView.CreationProperties = null;
            responseView.DefaultBackgroundColor = Color.FromArgb(60, 60, 60);
            responseView.Location = new Point(12, 12);
            responseView.Name = "responseView";
            responseView.Size = new Size(760, 437);
            responseView.TabIndex = 4;
            responseView.ZoomFactor = 1D;
            // 
            // loadingAnimation
            // 
            loadingAnimation.BackColor = Color.FromArgb(50, 50, 50);
            loadingAnimation.Dock = DockStyle.Fill;
            loadingAnimation.Image = (Image)resources.GetObject("loadingAnimation.Image");
            loadingAnimation.Location = new Point(0, 0);
            loadingAnimation.Name = "loadingAnimation";
            loadingAnimation.Size = new Size(784, 511);
            loadingAnimation.SizeMode = PictureBoxSizeMode.CenterImage;
            loadingAnimation.TabIndex = 5;
            loadingAnimation.TabStop = false;
            loadingAnimation.Visible = false;
            // 
            // LunaCopilotWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(55, 55, 55);
            ClientSize = new Size(784, 511);
            Controls.Add(responseView);
            Controls.Add(userPromptInput);
            Controls.Add(askAiButton);
            Controls.Add(loadingAnimation);
            Name = "LunaCopilotWindow";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Luna Copilot - Alpha";
            Load += LunaCopilotWindow_Load;
            ((System.ComponentModel.ISupportInitialize)responseView).EndInit();
            ((System.ComponentModel.ISupportInitialize)loadingAnimation).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button askAiButton;
        private TextBox userPromptInput;
        private Microsoft.Web.WebView2.WinForms.WebView2 responseView;
        private PictureBox loadingAnimation;
    }
}