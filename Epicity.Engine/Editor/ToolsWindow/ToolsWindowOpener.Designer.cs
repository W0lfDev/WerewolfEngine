namespace Werewolf.Engine.Editor
{
    partial class ToolsWindowOpener
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
            brandingText = new Label();
            buttonsPanel = new FlowLayoutPanel();
            tilemapEditorButton = new Button();
            levelEditorButton = new Button();
            levelManagerButton = new Button();
            keyframeEditorButton = new Button();
            lunaButton = new Button();
            scriptCreateButton = new Button();
            lvBatcherButton = new Button();
            buttonsPanel.SuspendLayout();
            SuspendLayout();
            // 
            // brandingText
            // 
            brandingText.Anchor = AnchorStyles.Top;
            brandingText.AutoSize = true;
            brandingText.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            brandingText.ForeColor = Color.WhiteSmoke;
            brandingText.Location = new Point(67, 9);
            brandingText.Name = "brandingText";
            brandingText.Size = new Size(190, 32);
            brandingText.TabIndex = 0;
            brandingText.Text = "Werewolf Tools";
            // 
            // buttonsPanel
            // 
            buttonsPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            buttonsPanel.BorderStyle = BorderStyle.FixedSingle;
            buttonsPanel.Controls.Add(tilemapEditorButton);
            buttonsPanel.Controls.Add(levelEditorButton);
            buttonsPanel.Controls.Add(levelManagerButton);
            buttonsPanel.Controls.Add(lvBatcherButton);
            buttonsPanel.Controls.Add(keyframeEditorButton);
            buttonsPanel.Controls.Add(lunaButton);
            buttonsPanel.Controls.Add(scriptCreateButton);
            buttonsPanel.FlowDirection = FlowDirection.TopDown;
            buttonsPanel.Location = new Point(12, 55);
            buttonsPanel.Name = "buttonsPanel";
            buttonsPanel.Size = new Size(302, 356);
            buttonsPanel.TabIndex = 1;
            // 
            // tilemapEditorButton
            // 
            tilemapEditorButton.ForeColor = SystemColors.ControlText;
            tilemapEditorButton.Location = new Point(3, 3);
            tilemapEditorButton.Name = "tilemapEditorButton";
            tilemapEditorButton.Size = new Size(295, 42);
            tilemapEditorButton.TabIndex = 0;
            tilemapEditorButton.Text = "Tilemap Editor";
            tilemapEditorButton.UseVisualStyleBackColor = true;
            tilemapEditorButton.Click += tilemapEditorButton_Click;
            // 
            // levelEditorButton
            // 
            levelEditorButton.ForeColor = SystemColors.ControlText;
            levelEditorButton.Location = new Point(3, 51);
            levelEditorButton.Name = "levelEditorButton";
            levelEditorButton.Size = new Size(295, 42);
            levelEditorButton.TabIndex = 5;
            levelEditorButton.Text = "Level Editor";
            levelEditorButton.UseVisualStyleBackColor = true;
            levelEditorButton.Click += levelEditorButton_Click;
            // 
            // levelManagerButton
            // 
            levelManagerButton.ForeColor = SystemColors.ControlText;
            levelManagerButton.Location = new Point(3, 99);
            levelManagerButton.Name = "levelManagerButton";
            levelManagerButton.Size = new Size(295, 42);
            levelManagerButton.TabIndex = 1;
            levelManagerButton.Text = "Level Manager";
            levelManagerButton.UseVisualStyleBackColor = true;
            levelManagerButton.Click += levelManagerButton_Click;
            // 
            // keyframeEditorButton
            // 
            keyframeEditorButton.ForeColor = SystemColors.ControlText;
            keyframeEditorButton.Location = new Point(3, 195);
            keyframeEditorButton.Name = "keyframeEditorButton";
            keyframeEditorButton.Size = new Size(295, 42);
            keyframeEditorButton.TabIndex = 4;
            keyframeEditorButton.Text = "Keyframe Editor";
            keyframeEditorButton.UseVisualStyleBackColor = true;
            keyframeEditorButton.Click += keyframeEditorButton_Click;
            // 
            // lunaButton
            // 
            lunaButton.ForeColor = SystemColors.ControlText;
            lunaButton.Location = new Point(3, 243);
            lunaButton.Name = "lunaButton";
            lunaButton.Size = new Size(295, 42);
            lunaButton.TabIndex = 3;
            lunaButton.Text = "Luna Copilot (WIP)";
            lunaButton.UseVisualStyleBackColor = true;
            lunaButton.Click += lunaButton_Click;
            // 
            // scriptCreateButton
            // 
            scriptCreateButton.ForeColor = SystemColors.ControlText;
            scriptCreateButton.Location = new Point(3, 291);
            scriptCreateButton.Name = "scriptCreateButton";
            scriptCreateButton.Size = new Size(295, 42);
            scriptCreateButton.TabIndex = 2;
            scriptCreateButton.Text = "Create a Script";
            scriptCreateButton.UseVisualStyleBackColor = true;
            scriptCreateButton.Click += scriptCreateButton_Click;
            // 
            // lvBatcherButton
            // 
            lvBatcherButton.ForeColor = SystemColors.ControlText;
            lvBatcherButton.Location = new Point(3, 147);
            lvBatcherButton.Name = "lvBatcherButton";
            lvBatcherButton.Size = new Size(295, 42);
            lvBatcherButton.TabIndex = 6;
            lvBatcherButton.Text = "Level Batcher";
            lvBatcherButton.UseVisualStyleBackColor = true;
            lvBatcherButton.Click += lvBatcherButton_Click;
            // 
            // ToolsWindowOpener
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(55, 55, 55);
            ClientSize = new Size(326, 423);
            Controls.Add(buttonsPanel);
            Controls.Add(brandingText);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "ToolsWindowOpener";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Epicity Tools";
            buttonsPanel.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label brandingText;
        private FlowLayoutPanel buttonsPanel;
        private Button tilemapEditorButton;
        private Button levelManagerButton;
        private Button scriptCreateButton;
        private Button lunaButton;
        private Button keyframeEditorButton;
        private Button levelEditorButton;
        private Button lvBatcherButton;
    }
}