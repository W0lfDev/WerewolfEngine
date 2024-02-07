namespace Werewolf.Engine.Editor
{
    partial class ToolboxSetup
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
            inToolboxPanel = new FlowLayoutPanel();
            tileImage = new PictureBox();
            tileNameTexbox = new TextBox();
            nameLbl = new Label();
            clickToAddLbl = new Label();
            tileSizeLbl = new Label();
            tileSizeXInput = new TextBox();
            xLbl = new Label();
            tileSizeYInput = new TextBox();
            tileCharLbl = new Label();
            tileCharInput = new TextBox();
            addButton = new Button();
            toolboxTitle = new Label();
            saveButton = new Button();
            hasColliderToggle = new Toggle();
            label1 = new Label();
            label2 = new Label();
            attachScriptButton = new Button();
            ((System.ComponentModel.ISupportInitialize)tileImage).BeginInit();
            SuspendLayout();
            // 
            // inToolboxPanel
            // 
            inToolboxPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            inToolboxPanel.AutoScroll = true;
            inToolboxPanel.BackColor = Color.FromArgb(60, 60, 60);
            inToolboxPanel.BorderStyle = BorderStyle.FixedSingle;
            inToolboxPanel.FlowDirection = FlowDirection.TopDown;
            inToolboxPanel.Location = new Point(219, 30);
            inToolboxPanel.Name = "inToolboxPanel";
            inToolboxPanel.Size = new Size(219, 533);
            inToolboxPanel.TabIndex = 0;
            inToolboxPanel.WrapContents = false;
            // 
            // tileImage
            // 
            tileImage.BackColor = Color.FromArgb(60, 60, 60);
            tileImage.BorderStyle = BorderStyle.FixedSingle;
            tileImage.Location = new Point(12, 12);
            tileImage.Name = "tileImage";
            tileImage.Size = new Size(192, 192);
            tileImage.TabIndex = 2;
            tileImage.TabStop = false;
            tileImage.Click += tileImage_Click;
            // 
            // tileNameTexbox
            // 
            tileNameTexbox.Anchor = AnchorStyles.Left;
            tileNameTexbox.Location = new Point(78, 219);
            tileNameTexbox.Name = "tileNameTexbox";
            tileNameTexbox.Size = new Size(126, 23);
            tileNameTexbox.TabIndex = 4;
            // 
            // nameLbl
            // 
            nameLbl.Anchor = AnchorStyles.Left;
            nameLbl.AutoSize = true;
            nameLbl.ForeColor = Color.WhiteSmoke;
            nameLbl.Location = new Point(12, 222);
            nameLbl.Name = "nameLbl";
            nameLbl.Size = new Size(63, 15);
            nameLbl.TabIndex = 5;
            nameLbl.Text = "Tile Name:";
            nameLbl.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // clickToAddLbl
            // 
            clickToAddLbl.AutoSize = true;
            clickToAddLbl.ForeColor = Color.WhiteSmoke;
            clickToAddLbl.Location = new Point(64, 100);
            clickToAddLbl.Name = "clickToAddLbl";
            clickToAddLbl.Size = new Size(83, 15);
            clickToAddLbl.TabIndex = 6;
            clickToAddLbl.Text = "Click to attach";
            clickToAddLbl.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tileSizeLbl
            // 
            tileSizeLbl.Anchor = AnchorStyles.Left;
            tileSizeLbl.AutoSize = true;
            tileSizeLbl.ForeColor = Color.WhiteSmoke;
            tileSizeLbl.Location = new Point(12, 268);
            tileSizeLbl.Name = "tileSizeLbl";
            tileSizeLbl.Size = new Size(51, 15);
            tileSizeLbl.TabIndex = 7;
            tileSizeLbl.Text = "Tile Size:";
            tileSizeLbl.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tileSizeXInput
            // 
            tileSizeXInput.Anchor = AnchorStyles.Left;
            tileSizeXInput.Location = new Point(77, 265);
            tileSizeXInput.Name = "tileSizeXInput";
            tileSizeXInput.Size = new Size(51, 23);
            tileSizeXInput.TabIndex = 8;
            // 
            // xLbl
            // 
            xLbl.Anchor = AnchorStyles.Left;
            xLbl.AutoSize = true;
            xLbl.ForeColor = Color.WhiteSmoke;
            xLbl.Location = new Point(134, 268);
            xLbl.Name = "xLbl";
            xLbl.Size = new Size(13, 15);
            xLbl.TabIndex = 9;
            xLbl.Text = "x";
            xLbl.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tileSizeYInput
            // 
            tileSizeYInput.Anchor = AnchorStyles.Left;
            tileSizeYInput.Location = new Point(153, 265);
            tileSizeYInput.Name = "tileSizeYInput";
            tileSizeYInput.Size = new Size(51, 23);
            tileSizeYInput.TabIndex = 10;
            // 
            // tileCharLbl
            // 
            tileCharLbl.Anchor = AnchorStyles.Left;
            tileCharLbl.AutoSize = true;
            tileCharLbl.ForeColor = Color.WhiteSmoke;
            tileCharLbl.Location = new Point(12, 313);
            tileCharLbl.Name = "tileCharLbl";
            tileCharLbl.Size = new Size(121, 15);
            tileCharLbl.TabIndex = 11;
            tileCharLbl.Text = "Associated Character:";
            tileCharLbl.TextAlign = ContentAlignment.MiddleRight;
            // 
            // tileCharInput
            // 
            tileCharInput.Anchor = AnchorStyles.Left;
            tileCharInput.Location = new Point(139, 310);
            tileCharInput.Name = "tileCharInput";
            tileCharInput.Size = new Size(65, 23);
            tileCharInput.TabIndex = 12;
            // 
            // addButton
            // 
            addButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            addButton.Font = new Font("Segoe UI", 9F);
            addButton.Location = new Point(12, 484);
            addButton.Name = "addButton";
            addButton.Size = new Size(192, 34);
            addButton.TabIndex = 13;
            addButton.Text = "Add to toolbox  ➕";
            addButton.UseVisualStyleBackColor = true;
            addButton.Click += addButton_Click;
            // 
            // toolboxTitle
            // 
            toolboxTitle.Anchor = AnchorStyles.Top;
            toolboxTitle.BackColor = Color.FromArgb(60, 60, 60);
            toolboxTitle.BorderStyle = BorderStyle.FixedSingle;
            toolboxTitle.Font = new Font("Segoe UI", 8F);
            toolboxTitle.ForeColor = Color.WhiteSmoke;
            toolboxTitle.Location = new Point(219, 9);
            toolboxTitle.Name = "toolboxTitle";
            toolboxTitle.Size = new Size(73, 15);
            toolboxTitle.TabIndex = 14;
            toolboxTitle.Text = "Toolbox";
            toolboxTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // saveButton
            // 
            saveButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            saveButton.Font = new Font("Segoe UI", 9F);
            saveButton.Location = new Point(12, 524);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(192, 34);
            saveButton.TabIndex = 15;
            saveButton.Text = "Save toolbox ";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += saveButton_Click;
            // 
            // hasColliderToggle
            // 
            hasColliderToggle.Anchor = AnchorStyles.Left;
            hasColliderToggle.AutoSize = true;
            hasColliderToggle.Checked = true;
            hasColliderToggle.CheckState = CheckState.Checked;
            hasColliderToggle.Location = new Point(153, 355);
            hasColliderToggle.MinimumSize = new Size(45, 22);
            hasColliderToggle.Name = "hasColliderToggle";
            hasColliderToggle.OffBackColor = Color.FromArgb(50, 50, 50);
            hasColliderToggle.OffToggleColor = Color.FromArgb(80, 80, 80);
            hasColliderToggle.OnBackColor = Color.FromArgb(100, 140, 180);
            hasColliderToggle.OnToggleColor = Color.LightGray;
            hasColliderToggle.Size = new Size(45, 22);
            hasColliderToggle.TabIndex = 16;
            hasColliderToggle.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Left;
            label1.AutoSize = true;
            label1.ForeColor = Color.WhiteSmoke;
            label1.Location = new Point(12, 358);
            label1.Name = "label1";
            label1.Size = new Size(94, 15);
            label1.TabIndex = 17;
            label1.Text = "Enable Collision:";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Left;
            label2.AutoSize = true;
            label2.ForeColor = Color.WhiteSmoke;
            label2.Location = new Point(12, 402);
            label2.Name = "label2";
            label2.Size = new Size(40, 15);
            label2.TabIndex = 18;
            label2.Text = "Script:";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // attachScriptButton
            // 
            attachScriptButton.Location = new Point(77, 395);
            attachScriptButton.Name = "attachScriptButton";
            attachScriptButton.Size = new Size(121, 29);
            attachScriptButton.TabIndex = 19;
            attachScriptButton.Text = "Attach";
            attachScriptButton.UseVisualStyleBackColor = true;
            attachScriptButton.Click += attachScriptButton_Click;
            // 
            // ToolboxSetup
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(58, 58, 58);
            ClientSize = new Size(450, 575);
            Controls.Add(attachScriptButton);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(hasColliderToggle);
            Controls.Add(saveButton);
            Controls.Add(toolboxTitle);
            Controls.Add(addButton);
            Controls.Add(tileCharInput);
            Controls.Add(tileCharLbl);
            Controls.Add(tileSizeYInput);
            Controls.Add(xLbl);
            Controls.Add(tileSizeXInput);
            Controls.Add(tileSizeLbl);
            Controls.Add(clickToAddLbl);
            Controls.Add(tileImage);
            Controls.Add(nameLbl);
            Controls.Add(tileNameTexbox);
            Controls.Add(inToolboxPanel);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            MaximizeBox = false;
            Name = "ToolboxSetup";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ToolboxSetup";
            ((System.ComponentModel.ISupportInitialize)tileImage).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlowLayoutPanel inToolboxPanel;
        private PictureBox tileImage;
        private TextBox tileNameTexbox;
        private Label nameLbl;
        private Label clickToAddLbl;
        private Label tileSizeLbl;
        private TextBox tileSizeXInput;
        private Label xLbl;
        private TextBox tileSizeYInput;
        private Label tileCharLbl;
        private TextBox tileCharInput;
        private Button addButton;
        private Label toolboxTitle;
        private Button saveButton;
        private Toggle hasColliderToggle;
        private Label label1;
        private Label label2;
        private Button attachScriptButton;
    }
}