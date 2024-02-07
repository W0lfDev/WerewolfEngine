using Epicity.Engine.Editor;

namespace Werewolf.Engine.Editor
{
    partial class LevelManagerWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LevelManagerWindow));
            allLevelsPanel = new FlowLayoutPanel();
            loadSelectedLevelButton = new Button();
            addLevelButton = new Button();
            editLevelButton = new Button();
            statusBar = new Panel();
            loadingAnimation = new PictureBox();
            statusText = new Label();
            addSelectPanel = new FlowLayoutPanel();
            createLevelButton = new TilemapButton();
            createTilemapButton = new TilemapButton();
            curLevelPanel = new Panel();
            searchSpriteTextbox = new TextBox();
            spritePropTitle = new Label();
            spritePropertiesPanel = new Panel();
            collisionToggle = new Toggle();
            label10 = new Label();
            drawDebugToggle = new Toggle();
            label9 = new Label();
            label8 = new Label();
            uniformSizeToggle = new Toggle();
            label7 = new Label();
            label4 = new Label();
            sizeYInput = new SlideTextbox();
            sizeXInput = new SlideTextbox();
            label6 = new Label();
            label5 = new Label();
            posYInput = new SlideTextbox();
            posXInput = new SlideTextbox();
            label3 = new Label();
            label2 = new Label();
            setSpriteNameButton = new Button();
            spriteNameInput = new TextBox();
            label1 = new Label();
            spritesTitle = new Label();
            spritesPanel = new FlowLayoutPanel();
            levelsTitle = new Label();
            curLevelTitle = new Label();
            statusBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)loadingAnimation).BeginInit();
            addSelectPanel.SuspendLayout();
            curLevelPanel.SuspendLayout();
            spritePropertiesPanel.SuspendLayout();
            SuspendLayout();
            // 
            // allLevelsPanel
            // 
            allLevelsPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            allLevelsPanel.BorderStyle = BorderStyle.FixedSingle;
            allLevelsPanel.FlowDirection = FlowDirection.TopDown;
            allLevelsPanel.Location = new Point(12, 29);
            allLevelsPanel.Name = "allLevelsPanel";
            allLevelsPanel.Size = new Size(200, 345);
            allLevelsPanel.TabIndex = 0;
            allLevelsPanel.WrapContents = false;
            // 
            // loadSelectedLevelButton
            // 
            loadSelectedLevelButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            loadSelectedLevelButton.ForeColor = SystemColors.ControlText;
            loadSelectedLevelButton.Location = new Point(88, 380);
            loadSelectedLevelButton.Name = "loadSelectedLevelButton";
            loadSelectedLevelButton.Size = new Size(124, 32);
            loadSelectedLevelButton.TabIndex = 1;
            loadSelectedLevelButton.Text = "Load Selected~";
            loadSelectedLevelButton.UseVisualStyleBackColor = true;
            loadSelectedLevelButton.Click += loadSelectedLevelButton_Click;
            // 
            // addLevelButton
            // 
            addLevelButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            addLevelButton.Font = new Font("Segoe UI Emoji", 9F);
            addLevelButton.Location = new Point(12, 380);
            addLevelButton.Name = "addLevelButton";
            addLevelButton.Size = new Size(32, 32);
            addLevelButton.TabIndex = 2;
            addLevelButton.Text = "➕";
            addLevelButton.UseVisualStyleBackColor = true;
            addLevelButton.Click += addLevelButton_Click;
            // 
            // editLevelButton
            // 
            editLevelButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            editLevelButton.Font = new Font("Segoe UI Emoji", 9F);
            editLevelButton.Location = new Point(50, 380);
            editLevelButton.Name = "editLevelButton";
            editLevelButton.Size = new Size(32, 32);
            editLevelButton.TabIndex = 3;
            editLevelButton.Text = "✍🏻";
            editLevelButton.UseVisualStyleBackColor = true;
            // 
            // statusBar
            // 
            statusBar.BorderStyle = BorderStyle.FixedSingle;
            statusBar.Controls.Add(loadingAnimation);
            statusBar.Controls.Add(statusText);
            statusBar.Dock = DockStyle.Bottom;
            statusBar.Location = new Point(0, 418);
            statusBar.Name = "statusBar";
            statusBar.Size = new Size(800, 32);
            statusBar.TabIndex = 4;
            // 
            // loadingAnimation
            // 
            loadingAnimation.Image = (Image)resources.GetObject("loadingAnimation.Image");
            loadingAnimation.Location = new Point(770, 3);
            loadingAnimation.Name = "loadingAnimation";
            loadingAnimation.Size = new Size(25, 24);
            loadingAnimation.TabIndex = 1;
            loadingAnimation.TabStop = false;
            // 
            // statusText
            // 
            statusText.AutoSize = true;
            statusText.Font = new Font("Segoe UI", 9.5F);
            statusText.ForeColor = Color.WhiteSmoke;
            statusText.Location = new Point(11, 5);
            statusText.Name = "statusText";
            statusText.Size = new Size(43, 17);
            statusText.TabIndex = 0;
            statusText.Text = "Status";
            // 
            // addSelectPanel
            // 
            addSelectPanel.BorderStyle = BorderStyle.FixedSingle;
            addSelectPanel.Controls.Add(createLevelButton);
            addSelectPanel.Controls.Add(createTilemapButton);
            addSelectPanel.FlowDirection = FlowDirection.TopDown;
            addSelectPanel.Location = new Point(91, 9);
            addSelectPanel.Name = "addSelectPanel";
            addSelectPanel.Size = new Size(71, 14);
            addSelectPanel.TabIndex = 5;
            // 
            // createLevelButton
            // 
            createLevelButton.AssociatedChar = null;
            createLevelButton.IsSelected = false;
            createLevelButton.Location = new Point(3, 3);
            createLevelButton.Name = "createLevelButton";
            createLevelButton.Size = new Size(92, 23);
            createLevelButton.TabIndex = 0;
            createLevelButton.Text = "New Level~";
            createLevelButton.UseVisualStyleBackColor = true;
            // 
            // createTilemapButton
            // 
            createTilemapButton.AssociatedChar = null;
            createTilemapButton.IsSelected = false;
            createTilemapButton.Location = new Point(101, 3);
            createTilemapButton.Name = "createTilemapButton";
            createTilemapButton.Size = new Size(92, 23);
            createTilemapButton.TabIndex = 1;
            createTilemapButton.Text = "New Tilemap~";
            createTilemapButton.UseVisualStyleBackColor = true;
            // 
            // curLevelPanel
            // 
            curLevelPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            curLevelPanel.BorderStyle = BorderStyle.FixedSingle;
            curLevelPanel.Controls.Add(searchSpriteTextbox);
            curLevelPanel.Controls.Add(spritePropTitle);
            curLevelPanel.Controls.Add(spritePropertiesPanel);
            curLevelPanel.Controls.Add(spritesTitle);
            curLevelPanel.Controls.Add(spritesPanel);
            curLevelPanel.Location = new Point(234, 29);
            curLevelPanel.Name = "curLevelPanel";
            curLevelPanel.Size = new Size(554, 383);
            curLevelPanel.TabIndex = 6;
            // 
            // searchSpriteTextbox
            // 
            searchSpriteTextbox.Location = new Point(91, 9);
            searchSpriteTextbox.Name = "searchSpriteTextbox";
            searchSpriteTextbox.Size = new Size(121, 23);
            searchSpriteTextbox.TabIndex = 20;
            searchSpriteTextbox.Text = "Search";
            searchSpriteTextbox.TextAlign = HorizontalAlignment.Center;
            // 
            // spritePropTitle
            // 
            spritePropTitle.BackColor = Color.FromArgb(60, 60, 60);
            spritePropTitle.BorderStyle = BorderStyle.FixedSingle;
            spritePropTitle.Font = new Font("Segoe UI", 8F);
            spritePropTitle.ForeColor = Color.WhiteSmoke;
            spritePropTitle.Location = new Point(220, 17);
            spritePropTitle.Name = "spritePropTitle";
            spritePropTitle.Size = new Size(127, 15);
            spritePropTitle.TabIndex = 19;
            spritePropTitle.Text = "Sprite Properties";
            spritePropTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // spritePropertiesPanel
            // 
            spritePropertiesPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            spritePropertiesPanel.BorderStyle = BorderStyle.FixedSingle;
            spritePropertiesPanel.Controls.Add(collisionToggle);
            spritePropertiesPanel.Controls.Add(label10);
            spritePropertiesPanel.Controls.Add(drawDebugToggle);
            spritePropertiesPanel.Controls.Add(label9);
            spritePropertiesPanel.Controls.Add(label8);
            spritePropertiesPanel.Controls.Add(uniformSizeToggle);
            spritePropertiesPanel.Controls.Add(label7);
            spritePropertiesPanel.Controls.Add(label4);
            spritePropertiesPanel.Controls.Add(sizeYInput);
            spritePropertiesPanel.Controls.Add(sizeXInput);
            spritePropertiesPanel.Controls.Add(label6);
            spritePropertiesPanel.Controls.Add(label5);
            spritePropertiesPanel.Controls.Add(posYInput);
            spritePropertiesPanel.Controls.Add(posXInput);
            spritePropertiesPanel.Controls.Add(label3);
            spritePropertiesPanel.Controls.Add(label2);
            spritePropertiesPanel.Controls.Add(setSpriteNameButton);
            spritePropertiesPanel.Controls.Add(spriteNameInput);
            spritePropertiesPanel.Controls.Add(label1);
            spritePropertiesPanel.Location = new Point(220, 38);
            spritePropertiesPanel.Name = "spritePropertiesPanel";
            spritePropertiesPanel.Size = new Size(321, 333);
            spritePropertiesPanel.TabIndex = 18;
            // 
            // collisionToggle
            // 
            collisionToggle.CheckAlign = ContentAlignment.MiddleCenter;
            collisionToggle.Checked = true;
            collisionToggle.CheckState = CheckState.Indeterminate;
            collisionToggle.Location = new Point(110, 184);
            collisionToggle.MinimumSize = new Size(45, 22);
            collisionToggle.Name = "collisionToggle";
            collisionToggle.OffBackColor = Color.FromArgb(50, 50, 50);
            collisionToggle.OffToggleColor = Color.FromArgb(80, 80, 80);
            collisionToggle.OnBackColor = Color.FromArgb(100, 140, 180);
            collisionToggle.OnToggleColor = Color.LightGray;
            collisionToggle.Size = new Size(54, 22);
            collisionToggle.TabIndex = 22;
            collisionToggle.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.ForeColor = Color.WhiteSmoke;
            label10.Location = new Point(13, 187);
            label10.Name = "label10";
            label10.Size = new Size(91, 15);
            label10.TabIndex = 21;
            label10.Text = "Enable Collision";
            // 
            // drawDebugToggle
            // 
            drawDebugToggle.CheckAlign = ContentAlignment.MiddleCenter;
            drawDebugToggle.Checked = true;
            drawDebugToggle.CheckState = CheckState.Indeterminate;
            drawDebugToggle.Location = new Point(110, 221);
            drawDebugToggle.MinimumSize = new Size(45, 22);
            drawDebugToggle.Name = "drawDebugToggle";
            drawDebugToggle.OffBackColor = Color.FromArgb(50, 50, 50);
            drawDebugToggle.OffToggleColor = Color.FromArgb(80, 80, 80);
            drawDebugToggle.OnBackColor = Color.FromArgb(100, 140, 180);
            drawDebugToggle.OnToggleColor = Color.LightGray;
            drawDebugToggle.Size = new Size(54, 22);
            drawDebugToggle.TabIndex = 20;
            drawDebugToggle.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.ForeColor = Color.WhiteSmoke;
            label9.Location = new Point(13, 224);
            label9.Name = "label9";
            label9.Size = new Size(72, 15);
            label9.TabIndex = 19;
            label9.Text = "Draw Debug";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.ForeColor = Color.WhiteSmoke;
            label8.Location = new Point(246, 111);
            label8.Name = "label8";
            label8.Size = new Size(54, 15);
            label8.TabIndex = 18;
            label8.Text = "Uniform:";
            // 
            // uniformSizeToggle
            // 
            uniformSizeToggle.CheckAlign = ContentAlignment.MiddleCenter;
            uniformSizeToggle.Checked = true;
            uniformSizeToggle.CheckState = CheckState.Indeterminate;
            uniformSizeToggle.Location = new Point(246, 131);
            uniformSizeToggle.MinimumSize = new Size(45, 22);
            uniformSizeToggle.Name = "uniformSizeToggle";
            uniformSizeToggle.OffBackColor = Color.FromArgb(50, 50, 50);
            uniformSizeToggle.OffToggleColor = Color.FromArgb(80, 80, 80);
            uniformSizeToggle.OnBackColor = Color.FromArgb(100, 140, 180);
            uniformSizeToggle.OnToggleColor = Color.LightGray;
            uniformSizeToggle.Size = new Size(54, 22);
            uniformSizeToggle.TabIndex = 17;
            uniformSizeToggle.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            label7.BackColor = Color.Firebrick;
            label7.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label7.ForeColor = Color.WhiteSmoke;
            label7.Location = new Point(79, 111);
            label7.Name = "label7";
            label7.Size = new Size(20, 23);
            label7.TabIndex = 16;
            label7.Text = "X";
            label7.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            label4.BackColor = Color.Green;
            label4.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label4.ForeColor = Color.WhiteSmoke;
            label4.Location = new Point(79, 73);
            label4.Name = "label4";
            label4.Size = new Size(20, 23);
            label4.TabIndex = 15;
            label4.Text = "Y";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // sizeYInput
            // 
            sizeYInput.Location = new Point(99, 141);
            sizeYInput.Name = "sizeYInput";
            sizeYInput.ReadOnly = true;
            sizeYInput.Size = new Size(125, 23);
            sizeYInput.TabIndex = 13;
            sizeYInput.Text = "0";
            sizeYInput.TextAlign = HorizontalAlignment.Center;
            // 
            // sizeXInput
            // 
            sizeXInput.Location = new Point(99, 112);
            sizeXInput.Name = "sizeXInput";
            sizeXInput.ReadOnly = true;
            sizeXInput.Size = new Size(125, 23);
            sizeXInput.TabIndex = 12;
            sizeXInput.Text = "0";
            sizeXInput.TextAlign = HorizontalAlignment.Center;
            // 
            // label6
            // 
            label6.BackColor = Color.Green;
            label6.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label6.ForeColor = Color.WhiteSmoke;
            label6.Location = new Point(79, 140);
            label6.Name = "label6";
            label6.Size = new Size(20, 23);
            label6.TabIndex = 11;
            label6.Text = "Y";
            label6.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.ForeColor = Color.WhiteSmoke;
            label5.Location = new Point(13, 115);
            label5.Name = "label5";
            label5.Size = new Size(30, 15);
            label5.TabIndex = 9;
            label5.Text = "Size:";
            // 
            // posYInput
            // 
            posYInput.Location = new Point(99, 74);
            posYInput.Name = "posYInput";
            posYInput.ReadOnly = true;
            posYInput.Size = new Size(125, 23);
            posYInput.TabIndex = 8;
            posYInput.Text = "0";
            posYInput.TextAlign = HorizontalAlignment.Center;
            // 
            // posXInput
            // 
            posXInput.Location = new Point(99, 45);
            posXInput.Name = "posXInput";
            posXInput.ReadOnly = true;
            posXInput.Size = new Size(125, 23);
            posXInput.TabIndex = 7;
            posXInput.Text = "0";
            posXInput.TextAlign = HorizontalAlignment.Center;
            // 
            // label3
            // 
            label3.BackColor = Color.Firebrick;
            label3.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label3.ForeColor = Color.WhiteSmoke;
            label3.Location = new Point(79, 44);
            label3.Name = "label3";
            label3.Size = new Size(20, 23);
            label3.TabIndex = 5;
            label3.Text = "X";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.WhiteSmoke;
            label2.Location = new Point(13, 48);
            label2.Name = "label2";
            label2.Size = new Size(56, 15);
            label2.TabIndex = 4;
            label2.Text = "Position: ";
            // 
            // setSpriteNameButton
            // 
            setSpriteNameButton.Font = new Font("Segoe UI", 9.5F);
            setSpriteNameButton.Location = new Point(230, 10);
            setSpriteNameButton.Name = "setSpriteNameButton";
            setSpriteNameButton.Size = new Size(75, 23);
            setSpriteNameButton.TabIndex = 2;
            setSpriteNameButton.Text = "Set";
            setSpriteNameButton.UseVisualStyleBackColor = true;
            // 
            // spriteNameInput
            // 
            spriteNameInput.Location = new Point(64, 10);
            spriteNameInput.Name = "spriteNameInput";
            spriteNameInput.Size = new Size(160, 23);
            spriteNameInput.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.WhiteSmoke;
            label1.Location = new Point(13, 13);
            label1.Name = "label1";
            label1.Size = new Size(45, 15);
            label1.TabIndex = 0;
            label1.Text = "Name: ";
            // 
            // spritesTitle
            // 
            spritesTitle.BackColor = Color.FromArgb(60, 60, 60);
            spritesTitle.BorderStyle = BorderStyle.FixedSingle;
            spritesTitle.Font = new Font("Segoe UI", 8F);
            spritesTitle.ForeColor = Color.WhiteSmoke;
            spritesTitle.Location = new Point(12, 17);
            spritesTitle.Name = "spritesTitle";
            spritesTitle.Size = new Size(73, 15);
            spritesTitle.TabIndex = 17;
            spritesTitle.Text = "Sprites";
            spritesTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // spritesPanel
            // 
            spritesPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            spritesPanel.BorderStyle = BorderStyle.FixedSingle;
            spritesPanel.FlowDirection = FlowDirection.TopDown;
            spritesPanel.Location = new Point(12, 38);
            spritesPanel.Name = "spritesPanel";
            spritesPanel.Size = new Size(200, 333);
            spritesPanel.TabIndex = 1;
            spritesPanel.WrapContents = false;
            // 
            // levelsTitle
            // 
            levelsTitle.BackColor = Color.FromArgb(60, 60, 60);
            levelsTitle.BorderStyle = BorderStyle.FixedSingle;
            levelsTitle.Font = new Font("Segoe UI", 8F);
            levelsTitle.ForeColor = Color.WhiteSmoke;
            levelsTitle.Location = new Point(12, 9);
            levelsTitle.Name = "levelsTitle";
            levelsTitle.Size = new Size(73, 15);
            levelsTitle.TabIndex = 16;
            levelsTitle.Text = "Levels";
            levelsTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // curLevelTitle
            // 
            curLevelTitle.BackColor = Color.FromArgb(60, 60, 60);
            curLevelTitle.BorderStyle = BorderStyle.FixedSingle;
            curLevelTitle.Font = new Font("Segoe UI", 8F);
            curLevelTitle.ForeColor = Color.WhiteSmoke;
            curLevelTitle.Location = new Point(234, 9);
            curLevelTitle.Name = "curLevelTitle";
            curLevelTitle.Size = new Size(125, 15);
            curLevelTitle.TabIndex = 16;
            curLevelTitle.Text = "Current Level";
            curLevelTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // LevelManagerWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(60, 60, 60);
            ClientSize = new Size(800, 450);
            Controls.Add(curLevelTitle);
            Controls.Add(levelsTitle);
            Controls.Add(curLevelPanel);
            Controls.Add(addSelectPanel);
            Controls.Add(statusBar);
            Controls.Add(editLevelButton);
            Controls.Add(addLevelButton);
            Controls.Add(loadSelectedLevelButton);
            Controls.Add(allLevelsPanel);
            ForeColor = SystemColors.ControlText;
            Name = "LevelManagerWindow";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Level Manager";
            Load += LevelManagerWindow_Load;
            statusBar.ResumeLayout(false);
            statusBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)loadingAnimation).EndInit();
            addSelectPanel.ResumeLayout(false);
            curLevelPanel.ResumeLayout(false);
            curLevelPanel.PerformLayout();
            spritePropertiesPanel.ResumeLayout(false);
            spritePropertiesPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel allLevelsPanel;
        private Button loadSelectedLevelButton;
        private Button addLevelButton;
        private Button editLevelButton;
        private Panel statusBar;
        private Label statusText;
        private PictureBox loadingAnimation;
        private FlowLayoutPanel addSelectPanel;
        private TilemapButton createLevelButton;
        private TilemapButton createTilemapButton;
        private Panel curLevelPanel;
        private Label levelsTitle;
        private Label curLevelTitle;
        private Label spritesTitle;
        private FlowLayoutPanel spritesPanel;
        private Label spritePropTitle;
        private Panel spritePropertiesPanel;
        private Label label2;
        private Button setSpriteNameButton;
        private TextBox spriteNameInput;
        private Label label1;
        private Label label3;
        private SlideTextbox posXInput;
        private Label label5;
        private SlideTextbox posYInput;
        private SlideTextbox sizeYInput;
        private SlideTextbox sizeXInput;
        private Label label6;
        private Label label7;
        private Label label4;
        private Toggle uniformSizeToggle;
        private Label label8;
        private Toggle drawDebugToggle;
        private Label label9;
        private Toggle collisionToggle;
        private Label label10;
        private TextBox searchSpriteTextbox;
    }
}