namespace Werewolf.Engine.Editor
{
    partial class LevelEditorWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LevelEditorWindow));
            toolboxTitle = new Label();
            saveButton = new Button();
            levelNameTextbox = new TextBox();
            levelSpritesPanel = new FlowLayoutPanel();
            panel1 = new Panel();
            statusText = new Label();
            zoomText = new Label();
            zoomOutButton = new Button();
            zoomInButton = new Button();
            loadingAnimation = new PictureBox();
            label2 = new Label();
            addSpriteButton = new Button();
            viewportPanel = new Panel();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)loadingAnimation).BeginInit();
            SuspendLayout();
            // 
            // toolboxTitle
            // 
            toolboxTitle.BackColor = Color.FromArgb(60, 60, 60);
            toolboxTitle.BorderStyle = BorderStyle.FixedSingle;
            toolboxTitle.Font = new Font("Segoe UI", 8F);
            toolboxTitle.ForeColor = Color.WhiteSmoke;
            toolboxTitle.Location = new Point(12, 9);
            toolboxTitle.Name = "toolboxTitle";
            toolboxTitle.Size = new Size(90, 15);
            toolboxTitle.TabIndex = 26;
            toolboxTitle.Text = "Level Sprites";
            toolboxTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // saveButton
            // 
            saveButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            saveButton.Location = new Point(12, 615);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(201, 28);
            saveButton.TabIndex = 22;
            saveButton.Text = "Save~";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += saveButton_Click;
            // 
            // levelNameTextbox
            // 
            levelNameTextbox.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            levelNameTextbox.BorderStyle = BorderStyle.FixedSingle;
            levelNameTextbox.Location = new Point(12, 586);
            levelNameTextbox.Name = "levelNameTextbox";
            levelNameTextbox.PlaceholderText = "Level Save Name";
            levelNameTextbox.Size = new Size(201, 23);
            levelNameTextbox.TabIndex = 20;
            levelNameTextbox.TextAlign = HorizontalAlignment.Center;
            // 
            // levelSpritesPanel
            // 
            levelSpritesPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            levelSpritesPanel.BorderStyle = BorderStyle.FixedSingle;
            levelSpritesPanel.FlowDirection = FlowDirection.TopDown;
            levelSpritesPanel.Location = new Point(12, 28);
            levelSpritesPanel.Name = "levelSpritesPanel";
            levelSpritesPanel.Size = new Size(201, 552);
            levelSpritesPanel.TabIndex = 18;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(60, 60, 60);
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(statusText);
            panel1.Controls.Add(zoomText);
            panel1.Controls.Add(zoomOutButton);
            panel1.Controls.Add(zoomInButton);
            panel1.Controls.Add(loadingAnimation);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 649);
            panel1.Name = "panel1";
            panel1.Size = new Size(1264, 32);
            panel1.TabIndex = 27;
            // 
            // statusText
            // 
            statusText.Anchor = AnchorStyles.Left;
            statusText.AutoSize = true;
            statusText.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            statusText.ForeColor = Color.WhiteSmoke;
            statusText.Location = new Point(3, 5);
            statusText.Name = "statusText";
            statusText.Size = new Size(50, 20);
            statusText.TabIndex = 6;
            statusText.Text = "Status";
            statusText.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // zoomText
            // 
            zoomText.Anchor = AnchorStyles.Right;
            zoomText.AutoSize = true;
            zoomText.ForeColor = Color.WhiteSmoke;
            zoomText.Location = new Point(2071, -28);
            zoomText.Name = "zoomText";
            zoomText.Size = new Size(35, 15);
            zoomText.TabIndex = 5;
            zoomText.Text = "300%";
            zoomText.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // zoomOutButton
            // 
            zoomOutButton.Anchor = AnchorStyles.Right;
            zoomOutButton.Location = new Point(2040, -33);
            zoomOutButton.Name = "zoomOutButton";
            zoomOutButton.Size = new Size(25, 25);
            zoomOutButton.TabIndex = 4;
            zoomOutButton.Text = "➖";
            zoomOutButton.UseVisualStyleBackColor = true;
            // 
            // zoomInButton
            // 
            zoomInButton.Anchor = AnchorStyles.Right;
            zoomInButton.Location = new Point(2112, -33);
            zoomInButton.Name = "zoomInButton";
            zoomInButton.Size = new Size(25, 25);
            zoomInButton.TabIndex = 3;
            zoomInButton.Text = "➕";
            zoomInButton.UseVisualStyleBackColor = true;
            // 
            // loadingAnimation
            // 
            loadingAnimation.Anchor = AnchorStyles.Right;
            loadingAnimation.Image = (Image)resources.GetObject("loadingAnimation.Image");
            loadingAnimation.Location = new Point(2292, -31);
            loadingAnimation.Margin = new Padding(0);
            loadingAnimation.Name = "loadingAnimation";
            loadingAnimation.Size = new Size(24, 24);
            loadingAnimation.TabIndex = 2;
            loadingAnimation.TabStop = false;
            // 
            // label2
            // 
            label2.BackColor = Color.FromArgb(60, 60, 60);
            label2.BorderStyle = BorderStyle.FixedSingle;
            label2.Font = new Font("Segoe UI", 8F);
            label2.ForeColor = Color.WhiteSmoke;
            label2.Location = new Point(227, 9);
            label2.Name = "label2";
            label2.Size = new Size(105, 15);
            label2.TabIndex = 29;
            label2.Text = "Level Viewport";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // addSpriteButton
            // 
            addSpriteButton.Location = new Point(163, 6);
            addSpriteButton.Name = "addSpriteButton";
            addSpriteButton.Size = new Size(50, 20);
            addSpriteButton.TabIndex = 30;
            addSpriteButton.Text = "➕~";
            addSpriteButton.UseVisualStyleBackColor = true;
            addSpriteButton.Click += addSpriteButton_Click;
            // 
            // viewportPanel
            // 
            viewportPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            viewportPanel.BackColor = Color.FromArgb(55, 55, 55);
            viewportPanel.BorderStyle = BorderStyle.FixedSingle;
            viewportPanel.Location = new Point(227, 28);
            viewportPanel.Name = "viewportPanel";
            viewportPanel.Size = new Size(1024, 576);
            viewportPanel.TabIndex = 31;
            // 
            // LevelEditorWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(55, 55, 55);
            ClientSize = new Size(1264, 681);
            Controls.Add(viewportPanel);
            Controls.Add(addSpriteButton);
            Controls.Add(label2);
            Controls.Add(panel1);
            Controls.Add(toolboxTitle);
            Controls.Add(saveButton);
            Controls.Add(levelNameTextbox);
            Controls.Add(levelSpritesPanel);
            Name = "LevelEditorWindow";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Level Editor";
            Load += LevelEditorWindow_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)loadingAnimation).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tileScaleInput;
        private Label toolboxTitle;
        private Label label3;
        private Button createTilemap;
        private TextBox scaleTextbox;
        private Button saveButton;
        private TextBox levelNameTextbox;
        private Button setupToolboxButton;
        private FlowLayoutPanel levelSpritesPanel;
        private Panel panel1;
        private Label zoomText;
        private Button zoomOutButton;
        private Button zoomInButton;
        private Label statusText;
        private PictureBox loadingAnimation;
        private Label label2;
        private Button addSpriteButton;
        private Panel viewportPanel;
    }
}