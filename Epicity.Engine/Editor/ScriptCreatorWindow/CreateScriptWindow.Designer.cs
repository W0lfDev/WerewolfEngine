namespace Werewolf.Engine.Editor
{
    partial class CreateScriptWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateScriptWindow));
            scriptNameInput = new TextBox();
            label1 = new Label();
            createButton = new Button();
            loadingAnimation = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)loadingAnimation).BeginInit();
            SuspendLayout();
            // 
            // scriptNameInput
            // 
            scriptNameInput.Location = new Point(93, 12);
            scriptNameInput.Name = "scriptNameInput";
            scriptNameInput.Size = new Size(209, 23);
            scriptNameInput.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 15);
            label1.Name = "label1";
            label1.Size = new Size(75, 15);
            label1.TabIndex = 1;
            label1.Text = "Script Name:";
            // 
            // createButton
            // 
            createButton.Location = new Point(12, 51);
            createButton.Name = "createButton";
            createButton.Size = new Size(290, 46);
            createButton.TabIndex = 2;
            createButton.Text = "Create";
            createButton.UseVisualStyleBackColor = true;
            createButton.Click += createButton_Click;
            // 
            // loadingAnimation
            // 
            loadingAnimation.Image = (Image)resources.GetObject("loadingAnimation.Image");
            loadingAnimation.Location = new Point(265, 63);
            loadingAnimation.Name = "loadingAnimation";
            loadingAnimation.Size = new Size(24, 24);
            loadingAnimation.TabIndex = 3;
            loadingAnimation.TabStop = false;
            loadingAnimation.Visible = false;
            // 
            // CreateScriptWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(55, 55, 55);
            ClientSize = new Size(314, 109);
            Controls.Add(loadingAnimation);
            Controls.Add(createButton);
            Controls.Add(label1);
            Controls.Add(scriptNameInput);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "CreateScriptWindow";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Create a script";
            Load += CreateScriptWindow_Load;
            ((System.ComponentModel.ISupportInitialize)loadingAnimation).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox scriptNameInput;
        private Label label1;
        private Button createButton;
        private PictureBox loadingAnimation;
    }
}