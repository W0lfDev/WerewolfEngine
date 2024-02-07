namespace Werewolf.Engine.Editor
{
    partial class TilemapEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TilemapEditor));
            tilemapButtonsPanel = new TilemapButtonsPanel();
            panel1 = new Panel();
            zoomText = new Label();
            zoomOutButton = new Button();
            zoomInButton = new Button();
            loadingAnimation = new PictureBox();
            statusText = new Label();
            taskProgressBar = new ProgressBar();
            tilesToolbox = new FlowLayoutPanel();
            setupToolboxButton = new Button();
            tilemapNameTextbox = new TextBox();
            label2 = new Label();
            saveButton = new Button();
            scaleTextbox = new TextBox();
            createTilemap = new Button();
            label3 = new Label();
            toolboxTitle = new Label();
            label1 = new Label();
            tileScaleInput = new TextBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)loadingAnimation).BeginInit();
            SuspendLayout();
            // 
            // tilemapButtonsPanel
            // 
            tilemapButtonsPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tilemapButtonsPanel.AutoScroll = true;
            tilemapButtonsPanel.BackColor = Color.FromArgb(60, 60, 60);
            tilemapButtonsPanel.Location = new Point(226, 0);
            tilemapButtonsPanel.Margin = new Padding(1);
            tilemapButtonsPanel.Name = "tilemapButtonsPanel";
            tilemapButtonsPanel.Size = new Size(1037, 648);
            tilemapButtonsPanel.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(60, 60, 60);
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(zoomText);
            panel1.Controls.Add(zoomOutButton);
            panel1.Controls.Add(zoomInButton);
            panel1.Controls.Add(loadingAnimation);
            panel1.Controls.Add(statusText);
            panel1.Controls.Add(taskProgressBar);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 649);
            panel1.Name = "panel1";
            panel1.Size = new Size(1264, 32);
            panel1.TabIndex = 1;
            // 
            // zoomText
            // 
            zoomText.Anchor = AnchorStyles.Right;
            zoomText.AutoSize = true;
            zoomText.ForeColor = Color.WhiteSmoke;
            zoomText.Location = new Point(1009, 7);
            zoomText.Name = "zoomText";
            zoomText.Size = new Size(35, 15);
            zoomText.TabIndex = 5;
            zoomText.Text = "300%";
            zoomText.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // zoomOutButton
            // 
            zoomOutButton.Anchor = AnchorStyles.Right;
            zoomOutButton.Location = new Point(978, 2);
            zoomOutButton.Name = "zoomOutButton";
            zoomOutButton.Size = new Size(25, 25);
            zoomOutButton.TabIndex = 4;
            zoomOutButton.Text = "➖";
            zoomOutButton.UseVisualStyleBackColor = true;
            zoomOutButton.Click += zoomOutButton_Click;
            // 
            // zoomInButton
            // 
            zoomInButton.Anchor = AnchorStyles.Right;
            zoomInButton.Location = new Point(1050, 2);
            zoomInButton.Name = "zoomInButton";
            zoomInButton.Size = new Size(25, 25);
            zoomInButton.TabIndex = 3;
            zoomInButton.Text = "➕";
            zoomInButton.UseVisualStyleBackColor = true;
            zoomInButton.Click += zoomInButton_Click;
            // 
            // loadingAnimation
            // 
            loadingAnimation.Anchor = AnchorStyles.Right;
            loadingAnimation.Image = (Image)resources.GetObject("loadingAnimation.Image");
            loadingAnimation.Location = new Point(1230, 4);
            loadingAnimation.Margin = new Padding(0);
            loadingAnimation.Name = "loadingAnimation";
            loadingAnimation.Size = new Size(24, 24);
            loadingAnimation.TabIndex = 2;
            loadingAnimation.TabStop = false;
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
            statusText.TabIndex = 1;
            statusText.Text = "Status";
            statusText.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // taskProgressBar
            // 
            taskProgressBar.Anchor = AnchorStyles.Right;
            taskProgressBar.ForeColor = Color.LightGreen;
            taskProgressBar.Location = new Point(1081, 4);
            taskProgressBar.Name = "taskProgressBar";
            taskProgressBar.Size = new Size(135, 23);
            taskProgressBar.TabIndex = 0;
            // 
            // tilesToolbox
            // 
            tilesToolbox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            tilesToolbox.BorderStyle = BorderStyle.FixedSingle;
            tilesToolbox.FlowDirection = FlowDirection.TopDown;
            tilesToolbox.Location = new Point(12, 28);
            tilesToolbox.Name = "tilesToolbox";
            tilesToolbox.Size = new Size(201, 444);
            tilesToolbox.TabIndex = 2;
            // 
            // setupToolboxButton
            // 
            setupToolboxButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            setupToolboxButton.Location = new Point(12, 478);
            setupToolboxButton.Name = "setupToolboxButton";
            setupToolboxButton.Size = new Size(201, 31);
            setupToolboxButton.TabIndex = 3;
            setupToolboxButton.Text = "Setup Toolbox";
            setupToolboxButton.UseVisualStyleBackColor = true;
            setupToolboxButton.Click += setupToolboxButton_Click;
            // 
            // tilemapNameTextbox
            // 
            tilemapNameTextbox.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            tilemapNameTextbox.BorderStyle = BorderStyle.FixedSingle;
            tilemapNameTextbox.Location = new Point(12, 586);
            tilemapNameTextbox.Name = "tilemapNameTextbox";
            tilemapNameTextbox.Size = new Size(201, 23);
            tilemapNameTextbox.TabIndex = 6;
            tilemapNameTextbox.Text = "Tilemap Save Name";
            tilemapNameTextbox.TextAlign = HorizontalAlignment.Center;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label2.BackColor = Color.White;
            label2.BorderStyle = BorderStyle.FixedSingle;
            label2.ForeColor = Color.White;
            label2.Location = new Point(12, 519);
            label2.Name = "label2";
            label2.Size = new Size(201, 2);
            label2.TabIndex = 7;
            label2.Text = "label2";
            // 
            // saveButton
            // 
            saveButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            saveButton.Location = new Point(12, 615);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(201, 28);
            saveButton.TabIndex = 8;
            saveButton.Text = "Save";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += saveButton_Click;
            // 
            // scaleTextbox
            // 
            scaleTextbox.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            scaleTextbox.BorderStyle = BorderStyle.FixedSingle;
            scaleTextbox.Location = new Point(119, 533);
            scaleTextbox.MaxLength = 2;
            scaleTextbox.Name = "scaleTextbox";
            scaleTextbox.Size = new Size(38, 23);
            scaleTextbox.TabIndex = 9;
            scaleTextbox.Text = "1";
            scaleTextbox.WordWrap = false;
            // 
            // createTilemap
            // 
            createTilemap.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            createTilemap.Location = new Point(163, 533);
            createTilemap.Name = "createTilemap";
            createTilemap.Size = new Size(50, 47);
            createTilemap.TabIndex = 12;
            createTilemap.Text = "Create";
            createTilemap.UseVisualStyleBackColor = true;
            createTilemap.Click += createTilemap_Click;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F);
            label3.ForeColor = Color.WhiteSmoke;
            label3.Location = new Point(12, 533);
            label3.Name = "label3";
            label3.Size = new Size(101, 19);
            label3.TabIndex = 13;
            label3.Text = "TM Size Factor:";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // toolboxTitle
            // 
            toolboxTitle.BackColor = Color.FromArgb(60, 60, 60);
            toolboxTitle.BorderStyle = BorderStyle.FixedSingle;
            toolboxTitle.Font = new Font("Segoe UI", 8F);
            toolboxTitle.ForeColor = Color.WhiteSmoke;
            toolboxTitle.Location = new Point(12, 9);
            toolboxTitle.Name = "toolboxTitle";
            toolboxTitle.Size = new Size(73, 15);
            toolboxTitle.TabIndex = 15;
            toolboxTitle.Text = "Toolbox";
            toolboxTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F);
            label1.ForeColor = Color.WhiteSmoke;
            label1.Location = new Point(12, 559);
            label1.Name = "label1";
            label1.Size = new Size(66, 19);
            label1.TabIndex = 16;
            label1.Text = "Tile Scale:";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tileScaleInput
            // 
            tileScaleInput.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            tileScaleInput.BorderStyle = BorderStyle.FixedSingle;
            tileScaleInput.Location = new Point(84, 557);
            tileScaleInput.MaxLength = 10;
            tileScaleInput.Name = "tileScaleInput";
            tileScaleInput.Size = new Size(73, 23);
            tileScaleInput.TabIndex = 17;
            tileScaleInput.Text = "1";
            tileScaleInput.WordWrap = false;
            // 
            // TilemapEditor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(55, 55, 55);
            ClientSize = new Size(1264, 681);
            Controls.Add(tileScaleInput);
            Controls.Add(label1);
            Controls.Add(toolboxTitle);
            Controls.Add(label3);
            Controls.Add(createTilemap);
            Controls.Add(scaleTextbox);
            Controls.Add(saveButton);
            Controls.Add(label2);
            Controls.Add(tilemapNameTextbox);
            Controls.Add(setupToolboxButton);
            Controls.Add(tilesToolbox);
            Controls.Add(panel1);
            Controls.Add(tilemapButtonsPanel);
            Name = "TilemapEditor";
            Text = "TilemapEditor";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)loadingAnimation).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private ProgressBar taskProgressBar;
        private Label statusText;
        private FlowLayoutPanel tilesToolbox;
        private Button setupToolboxButton;
        private Label brandingText;
        private TextBox tilemapNameTextbox;
        private Label label2;
        private Button saveButton;
        private TextBox scaleTextbox;
        private Button createTilemap;
        private Label label3;
        private PictureBox loadingAnimation;
        private Label toolboxTitle;
        private Label zoomText;
        private Button zoomOutButton;
        private Button zoomInButton;
        private Label label1;
        private TextBox tileScaleInput;
    }
}