namespace Werewolf.Engine.Editor
{
    partial class KeyframeEditor
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
            keyframesTitle = new Label();
            keyframesPanel = new FlowLayoutPanel();
            addKeyframeButton = new Button();
            panel1 = new Panel();
            changePosToggle = new Toggle();
            changeSizeToggle = new Toggle();
            label9 = new Label();
            label8 = new Label();
            visibleToggle = new Toggle();
            durationInput = new TextBox();
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
            label1 = new Label();
            saveButton = new Button();
            saveNameInput = new TextBox();
            clearButton = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // keyframesTitle
            // 
            keyframesTitle.BackColor = Color.FromArgb(60, 60, 60);
            keyframesTitle.BorderStyle = BorderStyle.FixedSingle;
            keyframesTitle.Font = new Font("Segoe UI", 8F);
            keyframesTitle.ForeColor = Color.WhiteSmoke;
            keyframesTitle.Location = new Point(12, 9);
            keyframesTitle.Name = "keyframesTitle";
            keyframesTitle.Size = new Size(81, 15);
            keyframesTitle.TabIndex = 18;
            keyframesTitle.Text = "Keyframes";
            keyframesTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // keyframesPanel
            // 
            keyframesPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            keyframesPanel.BorderStyle = BorderStyle.FixedSingle;
            keyframesPanel.FlowDirection = FlowDirection.TopDown;
            keyframesPanel.Location = new Point(12, 29);
            keyframesPanel.Name = "keyframesPanel";
            keyframesPanel.Size = new Size(200, 387);
            keyframesPanel.TabIndex = 17;
            keyframesPanel.WrapContents = false;
            // 
            // addKeyframeButton
            // 
            addKeyframeButton.Location = new Point(3, 377);
            addKeyframeButton.Name = "addKeyframeButton";
            addKeyframeButton.Size = new Size(267, 34);
            addKeyframeButton.TabIndex = 19;
            addKeyframeButton.Text = "Add Keyframe";
            addKeyframeButton.UseVisualStyleBackColor = true;
            addKeyframeButton.Click += addKeyframeButton_Click;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(changePosToggle);
            panel1.Controls.Add(changeSizeToggle);
            panel1.Controls.Add(label9);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(visibleToggle);
            panel1.Controls.Add(durationInput);
            panel1.Controls.Add(addKeyframeButton);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(sizeYInput);
            panel1.Controls.Add(sizeXInput);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(posYInput);
            panel1.Controls.Add(posXInput);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Location = new Point(218, 29);
            panel1.Name = "panel1";
            panel1.Size = new Size(275, 416);
            panel1.TabIndex = 20;
            // 
            // changePosToggle
            // 
            changePosToggle.AutoSize = true;
            changePosToggle.Location = new Point(13, 44);
            changePosToggle.MinimumSize = new Size(45, 22);
            changePosToggle.Name = "changePosToggle";
            changePosToggle.OffBackColor = Color.FromArgb(50, 50, 50);
            changePosToggle.OffToggleColor = Color.FromArgb(80, 80, 80);
            changePosToggle.OnBackColor = Color.FromArgb(100, 140, 180);
            changePosToggle.OnToggleColor = Color.LightGray;
            changePosToggle.Size = new Size(45, 22);
            changePosToggle.TabIndex = 32;
            changePosToggle.UseVisualStyleBackColor = true;
            // 
            // changeSizeToggle
            // 
            changeSizeToggle.AutoSize = true;
            changeSizeToggle.Location = new Point(13, 113);
            changeSizeToggle.MinimumSize = new Size(45, 22);
            changeSizeToggle.Name = "changeSizeToggle";
            changeSizeToggle.OffBackColor = Color.FromArgb(50, 50, 50);
            changeSizeToggle.OffToggleColor = Color.FromArgb(80, 80, 80);
            changeSizeToggle.OnBackColor = Color.FromArgb(100, 140, 180);
            changeSizeToggle.OnToggleColor = Color.LightGray;
            changeSizeToggle.Size = new Size(45, 22);
            changeSizeToggle.TabIndex = 31;
            changeSizeToggle.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.ForeColor = Color.WhiteSmoke;
            label9.Location = new Point(13, 348);
            label9.Name = "label9";
            label9.Size = new Size(56, 15);
            label9.TabIndex = 30;
            label9.Text = "Duration:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.ForeColor = Color.WhiteSmoke;
            label8.Location = new Point(13, 174);
            label8.Name = "label8";
            label8.Size = new Size(44, 15);
            label8.TabIndex = 29;
            label8.Text = "Visible:";
            // 
            // visibleToggle
            // 
            visibleToggle.AutoSize = true;
            visibleToggle.Checked = true;
            visibleToggle.CheckState = CheckState.Checked;
            visibleToggle.Location = new Point(110, 171);
            visibleToggle.MinimumSize = new Size(45, 22);
            visibleToggle.Name = "visibleToggle";
            visibleToggle.OffBackColor = Color.FromArgb(50, 50, 50);
            visibleToggle.OffToggleColor = Color.FromArgb(80, 80, 80);
            visibleToggle.OnBackColor = Color.FromArgb(100, 140, 180);
            visibleToggle.OnToggleColor = Color.LightGray;
            visibleToggle.Size = new Size(45, 22);
            visibleToggle.TabIndex = 28;
            visibleToggle.UseVisualStyleBackColor = true;
            // 
            // durationInput
            // 
            durationInput.Location = new Point(110, 345);
            durationInput.Name = "durationInput";
            durationInput.PlaceholderText = "in milliseconds (1000)";
            durationInput.Size = new Size(145, 23);
            durationInput.TabIndex = 27;
            durationInput.TextAlign = HorizontalAlignment.Center;
            // 
            // label7
            // 
            label7.BackColor = Color.Firebrick;
            label7.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label7.ForeColor = Color.WhiteSmoke;
            label7.Location = new Point(110, 82);
            label7.Name = "label7";
            label7.Size = new Size(20, 23);
            label7.TabIndex = 26;
            label7.Text = "X";
            label7.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            label4.BackColor = Color.Green;
            label4.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label4.ForeColor = Color.WhiteSmoke;
            label4.Location = new Point(110, 44);
            label4.Name = "label4";
            label4.Size = new Size(20, 23);
            label4.TabIndex = 25;
            label4.Text = "Y";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // sizeYInput
            // 
            sizeYInput.Location = new Point(130, 112);
            sizeYInput.Name = "sizeYInput";
            sizeYInput.ReadOnly = true;
            sizeYInput.Size = new Size(125, 23);
            sizeYInput.TabIndex = 24;
            sizeYInput.Text = "0";
            sizeYInput.TextAlign = HorizontalAlignment.Center;
            // 
            // sizeXInput
            // 
            sizeXInput.Location = new Point(130, 83);
            sizeXInput.Name = "sizeXInput";
            sizeXInput.ReadOnly = true;
            sizeXInput.Size = new Size(125, 23);
            sizeXInput.TabIndex = 23;
            sizeXInput.Text = "0";
            sizeXInput.TextAlign = HorizontalAlignment.Center;
            // 
            // label6
            // 
            label6.BackColor = Color.Green;
            label6.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label6.ForeColor = Color.WhiteSmoke;
            label6.Location = new Point(110, 111);
            label6.Name = "label6";
            label6.Size = new Size(20, 23);
            label6.TabIndex = 22;
            label6.Text = "Y";
            label6.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.ForeColor = Color.WhiteSmoke;
            label5.Location = new Point(13, 86);
            label5.Name = "label5";
            label5.Size = new Size(30, 15);
            label5.TabIndex = 21;
            label5.Text = "Size:";
            // 
            // posYInput
            // 
            posYInput.Location = new Point(130, 45);
            posYInput.Name = "posYInput";
            posYInput.ReadOnly = true;
            posYInput.Size = new Size(125, 23);
            posYInput.TabIndex = 20;
            posYInput.Text = "0";
            posYInput.TextAlign = HorizontalAlignment.Center;
            // 
            // posXInput
            // 
            posXInput.Location = new Point(130, 16);
            posXInput.Name = "posXInput";
            posXInput.ReadOnly = true;
            posXInput.Size = new Size(125, 23);
            posXInput.TabIndex = 19;
            posXInput.Text = "0";
            posXInput.TextAlign = HorizontalAlignment.Center;
            // 
            // label3
            // 
            label3.BackColor = Color.Firebrick;
            label3.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label3.ForeColor = Color.WhiteSmoke;
            label3.Location = new Point(110, 15);
            label3.Name = "label3";
            label3.Size = new Size(20, 23);
            label3.TabIndex = 18;
            label3.Text = "X";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.WhiteSmoke;
            label2.Location = new Point(13, 19);
            label2.Name = "label2";
            label2.Size = new Size(56, 15);
            label2.TabIndex = 17;
            label2.Text = "Position: ";
            // 
            // label1
            // 
            label1.BackColor = Color.FromArgb(60, 60, 60);
            label1.BorderStyle = BorderStyle.FixedSingle;
            label1.Font = new Font("Segoe UI", 8F);
            label1.ForeColor = Color.WhiteSmoke;
            label1.Location = new Point(218, 9);
            label1.Name = "label1";
            label1.Size = new Size(136, 15);
            label1.TabIndex = 21;
            label1.Text = "Keyframe Properties";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // saveButton
            // 
            saveButton.Location = new Point(145, 422);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(67, 23);
            saveButton.TabIndex = 22;
            saveButton.Text = "Save~";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += saveButton_Click;
            // 
            // saveNameInput
            // 
            saveNameInput.Location = new Point(12, 422);
            saveNameInput.Name = "saveNameInput";
            saveNameInput.PlaceholderText = "Name";
            saveNameInput.Size = new Size(127, 23);
            saveNameInput.TabIndex = 31;
            saveNameInput.TextAlign = HorizontalAlignment.Center;
            // 
            // clearButton
            // 
            clearButton.Font = new Font("Segoe UI Emoji", 9F);
            clearButton.Location = new Point(156, 6);
            clearButton.Name = "clearButton";
            clearButton.Size = new Size(56, 21);
            clearButton.TabIndex = 32;
            clearButton.Text = "🗑~";
            clearButton.UseVisualStyleBackColor = true;
            clearButton.Click += clearButton_Click;
            // 
            // KeyframeEditor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(55, 55, 55);
            ClientSize = new Size(508, 461);
            Controls.Add(clearButton);
            Controls.Add(saveNameInput);
            Controls.Add(saveButton);
            Controls.Add(label1);
            Controls.Add(panel1);
            Controls.Add(keyframesTitle);
            Controls.Add(keyframesPanel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "KeyframeEditor";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Keyframe Editor";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label keyframesTitle;
        private FlowLayoutPanel keyframesPanel;
        private Button addKeyframeButton;
        private Panel panel1;
        private Label label1;
        private Label label7;
        private Label label4;
        private SlideTextbox sizeYInput;
        private SlideTextbox sizeXInput;
        private Label label6;
        private Label label5;
        private SlideTextbox posYInput;
        private SlideTextbox posXInput;
        private Label label3;
        private Label label2;
        private TextBox durationInput;
        private Label label9;
        private Label label8;
        private Toggle visibleToggle;
        private Button saveButton;
        private TextBox saveNameInput;
        private Toggle changePosToggle;
        private Toggle changeSizeToggle;
        private Button clearButton;
    }
}