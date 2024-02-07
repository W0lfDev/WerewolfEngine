namespace Werewolf.Engine.Editor.LevelBatchWindow
{
    partial class LevelBatcher
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
            saveNameInput = new TextBox();
            saveButton = new Button();
            batchTitle = new Label();
            levelsPanel = new FlowLayoutPanel();
            levelNameInput = new TextBox();
            addButton = new Button();
            SuspendLayout();
            // 
            // saveNameInput
            // 
            saveNameInput.Location = new Point(12, 422);
            saveNameInput.Name = "saveNameInput";
            saveNameInput.PlaceholderText = "Batch Name";
            saveNameInput.Size = new Size(127, 23);
            saveNameInput.TabIndex = 35;
            saveNameInput.TextAlign = HorizontalAlignment.Center;
            // 
            // saveButton
            // 
            saveButton.Location = new Point(145, 422);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(67, 23);
            saveButton.TabIndex = 34;
            saveButton.Text = "Save~";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += saveButton_Click;
            // 
            // batchTitle
            // 
            batchTitle.BackColor = Color.FromArgb(60, 60, 60);
            batchTitle.BorderStyle = BorderStyle.FixedSingle;
            batchTitle.Font = new Font("Segoe UI", 8F);
            batchTitle.ForeColor = Color.WhiteSmoke;
            batchTitle.Location = new Point(12, 9);
            batchTitle.Name = "batchTitle";
            batchTitle.Size = new Size(111, 15);
            batchTitle.TabIndex = 33;
            batchTitle.Text = "Levels in batch";
            batchTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // levelsPanel
            // 
            levelsPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            levelsPanel.BorderStyle = BorderStyle.FixedSingle;
            levelsPanel.FlowDirection = FlowDirection.TopDown;
            levelsPanel.Location = new Point(12, 29);
            levelsPanel.Name = "levelsPanel";
            levelsPanel.Size = new Size(200, 355);
            levelsPanel.TabIndex = 32;
            levelsPanel.WrapContents = false;
            // 
            // levelNameInput
            // 
            levelNameInput.Location = new Point(12, 390);
            levelNameInput.Name = "levelNameInput";
            levelNameInput.PlaceholderText = "Level Name";
            levelNameInput.Size = new Size(127, 23);
            levelNameInput.TabIndex = 37;
            levelNameInput.TextAlign = HorizontalAlignment.Center;
            // 
            // addButton
            // 
            addButton.Location = new Point(145, 390);
            addButton.Name = "addButton";
            addButton.Size = new Size(67, 23);
            addButton.TabIndex = 36;
            addButton.Text = "Add~";
            addButton.UseVisualStyleBackColor = true;
            addButton.Click += addButton_Click;
            // 
            // LevelBatcher
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(55, 55, 55);
            ClientSize = new Size(223, 456);
            Controls.Add(levelNameInput);
            Controls.Add(addButton);
            Controls.Add(saveNameInput);
            Controls.Add(saveButton);
            Controls.Add(batchTitle);
            Controls.Add(levelsPanel);
            Name = "LevelBatcher";
            Text = "LevelBatcher";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox saveNameInput;
        private Button saveButton;
        private Label batchTitle;
        private FlowLayoutPanel levelsPanel;
        private TextBox levelNameInput;
        private Button addButton;
    }
}