using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Werewolf.Engine.EngineManagement;

namespace Werewolf.Engine.Editor.LevelBatchWindow
{
    public partial class LevelBatcher : Form
    {
        List<string> LevelsNames = new List<string>();

        public LevelBatcher()
        {
            InitializeComponent();
            this.FormClosing += (sender, e) =>
            {
                e.Cancel = true;
                this.Hide();
            };
            this.Load += (sender, e) =>
            {
                EditorStyle.ApplyStyle(this);
            };
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            LevelsNames.Add(levelNameInput.Text);
            levelNameInput.Text = "";

            UpdateLevelsList();
        }

        private void UpdateLevelsList()
        {
            levelsPanel.Controls.Clear();
            foreach (string levelName in LevelsNames)
            {
                Label levelNameLabel = new Label();
                levelNameLabel.Text = $"Level: {levelName}";
                levelNameLabel.Size = new Size(levelsPanel.Width - 2, 25);
                levelNameLabel.BorderStyle = BorderStyle.FixedSingle;
                levelNameLabel.Font = new Font("Segoe UI", 9f, FontStyle.Regular);
                levelNameLabel.Margin = new Padding(0);
                levelNameLabel.TextAlign = ContentAlignment.MiddleCenter;
                levelNameLabel.MouseClick += (sender, e) =>
                {
                    if (e.Button == MouseButtons.Right)
                    {
                        int index = levelsPanel.Controls.IndexOf((Control?)sender);
                        LevelsNames.RemoveAt(index);

                        UpdateLevelsList();
                    }
                };

                levelsPanel.Controls.Add(levelNameLabel);
            }

            EditorStyle.ApplyStyle(this);
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            string fullPath = EngineInstance.MainDirectory + $@"\LEVEL\{saveNameInput.Text}.lvbdata";
            string data = "";

            int n = 0;
            foreach (string levelName in LevelsNames)
            {
                n++;

                data += $"{levelName}";
                if (n  != LevelsNames.Count)
                {
                    data += "|";
                }
            }

            File.WriteAllText(fullPath, data);
            this.Hide();
        }
    }
}
