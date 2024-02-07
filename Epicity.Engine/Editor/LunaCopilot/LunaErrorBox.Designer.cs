namespace Werewolf.Engine.Editor
{
    partial class LunaErrorBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LunaErrorBox));
            errorBackgroundPanel = new Panel();
            statusIcon = new Label();
            statusText = new Label();
            errorText = new Label();
            fixWithLunaButton = new Button();
            ignoreButton = new Button();
            loadingAnimation = new PictureBox();
            errorBackgroundPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)loadingAnimation).BeginInit();
            SuspendLayout();
            // 
            // errorBackgroundPanel
            // 
            errorBackgroundPanel.BackColor = Color.Firebrick;
            errorBackgroundPanel.BorderStyle = BorderStyle.FixedSingle;
            errorBackgroundPanel.Controls.Add(statusIcon);
            errorBackgroundPanel.Controls.Add(statusText);
            errorBackgroundPanel.Location = new Point(-2, 0);
            errorBackgroundPanel.Name = "errorBackgroundPanel";
            errorBackgroundPanel.Size = new Size(486, 60);
            errorBackgroundPanel.TabIndex = 0;
            // 
            // statusIcon
            // 
            statusIcon.AutoSize = true;
            statusIcon.Font = new Font("Segoe UI Emoji", 21F, FontStyle.Bold);
            statusIcon.ForeColor = Color.WhiteSmoke;
            statusIcon.Location = new Point(415, 10);
            statusIcon.Name = "statusIcon";
            statusIcon.Size = new Size(56, 37);
            statusIcon.TabIndex = 1;
            statusIcon.Text = "⚠";
            // 
            // statusText
            // 
            statusText.AutoSize = true;
            statusText.Font = new Font("Segoe UI Semibold", 16.5F, FontStyle.Bold);
            statusText.ForeColor = Color.WhiteSmoke;
            statusText.Location = new Point(10, 15);
            statusText.Name = "statusText";
            statusText.Size = new Size(196, 30);
            statusText.TabIndex = 0;
            statusText.Text = "Compilation Error!";
            // 
            // errorText
            // 
            errorText.BackColor = Color.FromArgb(50, 50, 50);
            errorText.BorderStyle = BorderStyle.FixedSingle;
            errorText.FlatStyle = FlatStyle.Flat;
            errorText.ForeColor = Color.WhiteSmoke;
            errorText.Location = new Point(10, 76);
            errorText.Name = "errorText";
            errorText.Size = new Size(461, 146);
            errorText.TabIndex = 1;
            errorText.Text = "Error Text";
            // 
            // fixWithLunaButton
            // 
            fixWithLunaButton.Location = new Point(347, 236);
            fixWithLunaButton.Name = "fixWithLunaButton";
            fixWithLunaButton.Size = new Size(124, 33);
            fixWithLunaButton.TabIndex = 2;
            fixWithLunaButton.Text = "Fix with Luna";
            fixWithLunaButton.UseVisualStyleBackColor = true;
            fixWithLunaButton.Click += fixWithLunaButton_Click;
            // 
            // ignoreButton
            // 
            ignoreButton.Location = new Point(217, 236);
            ignoreButton.Name = "ignoreButton";
            ignoreButton.Size = new Size(124, 33);
            ignoreButton.TabIndex = 3;
            ignoreButton.Text = "Ignore";
            ignoreButton.UseVisualStyleBackColor = true;
            ignoreButton.Click += ignoreButton_Click;
            // 
            // loadingAnimation
            // 
            loadingAnimation.Image = (Image)resources.GetObject("loadingAnimation.Image");
            loadingAnimation.Location = new Point(12, 245);
            loadingAnimation.Name = "loadingAnimation";
            loadingAnimation.Size = new Size(24, 24);
            loadingAnimation.TabIndex = 4;
            loadingAnimation.TabStop = false;
            // 
            // LunaErrorBox
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(55, 55, 55);
            ClientSize = new Size(484, 281);
            Controls.Add(loadingAnimation);
            Controls.Add(ignoreButton);
            Controls.Add(fixWithLunaButton);
            Controls.Add(errorText);
            Controls.Add(errorBackgroundPanel);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "LunaErrorBox";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "LunaErrorBox";
            Load += LunaErrorBox_Load;
            errorBackgroundPanel.ResumeLayout(false);
            errorBackgroundPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)loadingAnimation).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel errorBackgroundPanel;
        private Label statusIcon;
        private Label statusText;
        private Label errorText;
        private Button fixWithLunaButton;
        private Button ignoreButton;
        private PictureBox loadingAnimation;
    }
}