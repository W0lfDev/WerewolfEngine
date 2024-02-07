using Werewolf.Engine.Editor;

namespace Epicity.Engine.Editor.LevelEditor
{
    partial class SpriteManager
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
            attachScriptButton = new Button();
            label2 = new Label();
            label1 = new Label();
            hasColliderToggle = new Toggle();
            addButton = new Button();
            clickToAddLbl = new Label();
            spriteImage = new PictureBox();
            nameLbl = new Label();
            spriteNameTexbox = new TextBox();
            label3 = new Label();
            visibleToggle = new Toggle();
            posYInput = new TextBox();
            label4 = new Label();
            posXInput = new TextBox();
            label5 = new Label();
            label6 = new Label();
            spriteScaleInput = new TextBox();
            label7 = new Label();
            animSpeedInput = new TextBox();
            spriteLayerInput = new TextBox();
            label8 = new Label();
            attachKeyframesButton = new Button();
            label9 = new Label();
            ((System.ComponentModel.ISupportInitialize)spriteImage).BeginInit();
            SuspendLayout();
            // 
            // attachScriptButton
            // 
            attachScriptButton.Location = new Point(67, 265);
            attachScriptButton.Name = "attachScriptButton";
            attachScriptButton.Size = new Size(137, 34);
            attachScriptButton.TabIndex = 34;
            attachScriptButton.Text = "Attach Script~";
            attachScriptButton.UseVisualStyleBackColor = true;
            attachScriptButton.Click += attachScriptButton_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.WhiteSmoke;
            label2.Location = new Point(12, 275);
            label2.Name = "label2";
            label2.Size = new Size(40, 15);
            label2.TabIndex = 33;
            label2.Text = "Script:";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.ForeColor = Color.WhiteSmoke;
            label1.Location = new Point(218, 203);
            label1.Name = "label1";
            label1.Size = new Size(94, 15);
            label1.TabIndex = 32;
            label1.Text = "Enable Collision:";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // hasColliderToggle
            // 
            hasColliderToggle.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            hasColliderToggle.AutoSize = true;
            hasColliderToggle.Checked = true;
            hasColliderToggle.CheckState = CheckState.Checked;
            hasColliderToggle.Location = new Point(354, 200);
            hasColliderToggle.MinimumSize = new Size(45, 22);
            hasColliderToggle.Name = "hasColliderToggle";
            hasColliderToggle.OffBackColor = Color.FromArgb(50, 50, 50);
            hasColliderToggle.OffToggleColor = Color.FromArgb(80, 80, 80);
            hasColliderToggle.OnBackColor = Color.FromArgb(100, 140, 180);
            hasColliderToggle.OnToggleColor = Color.LightGray;
            hasColliderToggle.Size = new Size(45, 22);
            hasColliderToggle.TabIndex = 31;
            hasColliderToggle.UseVisualStyleBackColor = true;
            // 
            // addButton
            // 
            addButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            addButton.Font = new Font("Segoe UI", 9F);
            addButton.Location = new Point(218, 265);
            addButton.Name = "addButton";
            addButton.Size = new Size(206, 34);
            addButton.TabIndex = 30;
            addButton.Text = "Add Sprite ➕~";
            addButton.UseVisualStyleBackColor = true;
            addButton.Click += addButton_Click;
            // 
            // clickToAddLbl
            // 
            clickToAddLbl.AutoSize = true;
            clickToAddLbl.ForeColor = Color.WhiteSmoke;
            clickToAddLbl.Location = new Point(67, 102);
            clickToAddLbl.Name = "clickToAddLbl";
            clickToAddLbl.Size = new Size(83, 15);
            clickToAddLbl.TabIndex = 23;
            clickToAddLbl.Text = "Click to attach";
            clickToAddLbl.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // spriteImage
            // 
            spriteImage.BackColor = Color.FromArgb(60, 60, 60);
            spriteImage.BorderStyle = BorderStyle.FixedSingle;
            spriteImage.Location = new Point(12, 12);
            spriteImage.Name = "spriteImage";
            spriteImage.Size = new Size(192, 192);
            spriteImage.TabIndex = 20;
            spriteImage.TabStop = false;
            spriteImage.Click += spriteImage_Click;
            // 
            // nameLbl
            // 
            nameLbl.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            nameLbl.AutoSize = true;
            nameLbl.ForeColor = Color.WhiteSmoke;
            nameLbl.Location = new Point(218, 39);
            nameLbl.Name = "nameLbl";
            nameLbl.Size = new Size(75, 15);
            nameLbl.TabIndex = 22;
            nameLbl.Text = "Sprite Name:";
            nameLbl.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // spriteNameTexbox
            // 
            spriteNameTexbox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            spriteNameTexbox.Location = new Point(297, 36);
            spriteNameTexbox.Name = "spriteNameTexbox";
            spriteNameTexbox.Size = new Size(128, 23);
            spriteNameTexbox.TabIndex = 21;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.ForeColor = Color.WhiteSmoke;
            label3.Location = new Point(218, 234);
            label3.Name = "label3";
            label3.Size = new Size(44, 15);
            label3.TabIndex = 36;
            label3.Text = "Visible:";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // visibleToggle
            // 
            visibleToggle.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            visibleToggle.AutoSize = true;
            visibleToggle.Checked = true;
            visibleToggle.CheckState = CheckState.Checked;
            visibleToggle.Location = new Point(354, 231);
            visibleToggle.MinimumSize = new Size(45, 22);
            visibleToggle.Name = "visibleToggle";
            visibleToggle.OffBackColor = Color.FromArgb(50, 50, 50);
            visibleToggle.OffToggleColor = Color.FromArgb(80, 80, 80);
            visibleToggle.OnBackColor = Color.FromArgb(100, 140, 180);
            visibleToggle.OnToggleColor = Color.LightGray;
            visibleToggle.Size = new Size(45, 22);
            visibleToggle.TabIndex = 35;
            visibleToggle.UseVisualStyleBackColor = true;
            // 
            // posYInput
            // 
            posYInput.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            posYInput.Location = new Point(373, 68);
            posYInput.Name = "posYInput";
            posYInput.Size = new Size(51, 23);
            posYInput.TabIndex = 40;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.ForeColor = Color.WhiteSmoke;
            label4.Location = new Point(354, 71);
            label4.Name = "label4";
            label4.Size = new Size(13, 15);
            label4.TabIndex = 39;
            label4.Text = "x";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // posXInput
            // 
            posXInput.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            posXInput.Location = new Point(297, 68);
            posXInput.Name = "posXInput";
            posXInput.Size = new Size(51, 23);
            posXInput.TabIndex = 38;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label5.AutoSize = true;
            label5.ForeColor = Color.WhiteSmoke;
            label5.Location = new Point(218, 71);
            label5.Name = "label5";
            label5.Size = new Size(62, 15);
            label5.TabIndex = 37;
            label5.Text = "Sprite Pos:";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label6.AutoSize = true;
            label6.ForeColor = Color.WhiteSmoke;
            label6.Location = new Point(218, 102);
            label6.Name = "label6";
            label6.Size = new Size(70, 15);
            label6.TabIndex = 41;
            label6.Text = "Sprite Scale:";
            label6.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // spriteScaleInput
            // 
            spriteScaleInput.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            spriteScaleInput.Location = new Point(297, 99);
            spriteScaleInput.Name = "spriteScaleInput";
            spriteScaleInput.Size = new Size(51, 23);
            spriteScaleInput.TabIndex = 42;
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label7.AutoSize = true;
            label7.ForeColor = Color.WhiteSmoke;
            label7.Location = new Point(218, 145);
            label7.Name = "label7";
            label7.Size = new Size(101, 15);
            label7.TabIndex = 43;
            label7.Text = "Animation Speed:";
            label7.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // animSpeedInput
            // 
            animSpeedInput.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            animSpeedInput.Location = new Point(325, 142);
            animSpeedInput.Name = "animSpeedInput";
            animSpeedInput.Size = new Size(99, 23);
            animSpeedInput.TabIndex = 44;
            // 
            // spriteLayerInput
            // 
            spriteLayerInput.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            spriteLayerInput.Location = new Point(325, 174);
            spriteLayerInput.Name = "spriteLayerInput";
            spriteLayerInput.Size = new Size(99, 23);
            spriteLayerInput.TabIndex = 46;
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label8.AutoSize = true;
            label8.ForeColor = Color.WhiteSmoke;
            label8.Location = new Point(218, 174);
            label8.Name = "label8";
            label8.Size = new Size(71, 15);
            label8.TabIndex = 45;
            label8.Text = "Sprite Layer:";
            label8.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // attachKeyframesButton
            // 
            attachKeyframesButton.Location = new Point(83, 224);
            attachKeyframesButton.Name = "attachKeyframesButton";
            attachKeyframesButton.Size = new Size(121, 34);
            attachKeyframesButton.TabIndex = 47;
            attachKeyframesButton.Text = "Attach Animation~";
            attachKeyframesButton.UseVisualStyleBackColor = true;
            attachKeyframesButton.Click += attachKeyframesButton_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.ForeColor = Color.WhiteSmoke;
            label9.Location = new Point(12, 234);
            label9.Name = "label9";
            label9.Size = new Size(65, 15);
            label9.TabIndex = 48;
            label9.Text = "Keyframes:";
            label9.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // SpriteManager
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(55, 55, 55);
            ClientSize = new Size(436, 311);
            Controls.Add(label9);
            Controls.Add(attachKeyframesButton);
            Controls.Add(spriteLayerInput);
            Controls.Add(label8);
            Controls.Add(animSpeedInput);
            Controls.Add(label7);
            Controls.Add(spriteScaleInput);
            Controls.Add(label6);
            Controls.Add(posYInput);
            Controls.Add(label4);
            Controls.Add(posXInput);
            Controls.Add(label5);
            Controls.Add(label3);
            Controls.Add(visibleToggle);
            Controls.Add(attachScriptButton);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(hasColliderToggle);
            Controls.Add(addButton);
            Controls.Add(clickToAddLbl);
            Controls.Add(spriteImage);
            Controls.Add(nameLbl);
            Controls.Add(spriteNameTexbox);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "SpriteManager";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Add a Sprite";
            Load += SpriteManager_Load;
            ((System.ComponentModel.ISupportInitialize)spriteImage).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button attachScriptButton;
        private Label label2;
        private Label label1;
        private Toggle hasColliderToggle;
        private Button addButton;
        private Label clickToAddLbl;
        private PictureBox spriteImage;
        private Label nameLbl;
        private TextBox spriteNameTexbox;
        private Label label3;
        private Toggle visibleToggle;
        private TextBox posYInput;
        private Label label4;
        private TextBox posXInput;
        private Label label5;
        private Label label6;
        private TextBox spriteScaleInput;
        private Label label7;
        private TextBox animSpeedInput;
        private TextBox spriteLayerInput;
        private Label label8;
        private Button attachKeyframesButton;
        private Label label9;
    }
}