
using Werewolf.Engine.EngineManagement;

namespace Werewolf.Engine.Editor
{
    public partial class KeyframeEditor : Form
    {
        private List<Keyframe> Keyframes = new List<Keyframe>();
        private int selectedIndex = 0;

        public KeyframeEditor()
        {
            InitializeComponent();
            this.FormClosing += (sender, e) =>
            {
                e.Cancel = true;
                this.Hide();
            };
            this.Load += KeyframeEditor_Load;
        }

        private void KeyframeEditor_Load(object? sender, EventArgs e)
        {
            EditorStyle.ApplyStyle(this);
        }

        #region Add Keyframe
        private void addKeyframeButton_Click(object sender, EventArgs e)
        {
            Keyframe current = new Keyframe(
                float.Parse(durationInput.Text),
                new Maths.Vector2<float>(float.Parse(posXInput.Text), float.Parse(posYInput.Text)),
                new Maths.Vector2<float>(float.Parse(sizeXInput.Text), float.Parse(sizeYInput.Text)),
                visibleToggle.Checked
            );
            current.SetChanged(changePosToggle.Checked, changeSizeToggle.Checked);

            Keyframes.Add(current);
            UpdateKeyframesList();

            ResetProperties();
        }

        private void ResetProperties()
        {
            changePosToggle.Checked = false;
            changeSizeToggle.Checked = false;
            posXInput.Text = "0";
            posYInput.Text = "0";
            sizeXInput.Text = "0";
            sizeYInput.Text = "0";
            visibleToggle.Checked = true;
            durationInput.Text = "";
        }

        private void UpdateKeyframesList()
        {
            keyframesPanel.Controls.Clear();

            int n = 0;
            foreach (Keyframe keyframe in Keyframes)
            {
                n++;

                Label keyframeLabel = new Label();
                keyframeLabel.Text = $"Keyframe {n} / {Keyframes.Count}";
                keyframeLabel.Size = new Size(keyframesPanel.Width - 2, 25);
                keyframeLabel.BorderStyle = BorderStyle.FixedSingle;
                keyframeLabel.Font = new Font("Segoe UI", 9f, FontStyle.Regular);
                keyframeLabel.Margin = new Padding(0);
                keyframeLabel.TextAlign = ContentAlignment.MiddleCenter;
                keyframeLabel.MouseClick += KeyframeLabel_MouseClick;

                keyframesPanel.Controls.Add(keyframeLabel);
            }

            EditorStyle.ApplyStyle(this);
        }
        #endregion

        #region Select Keyframe and Set Properties
        private void KeyframeLabel_MouseClick(object? sender, MouseEventArgs e)
        {
            int selectedIndex = keyframesPanel.Controls.IndexOf((Control)sender);

            if (e.Button == MouseButtons.Left)
            {
                SelectKeyframeLabel(selectedIndex);
                UpdatePropertiesToSelected(selectedIndex);
            }
            else if (e.Button == MouseButtons.Right)
            {
                Keyframes.RemoveAt(selectedIndex);
                keyframesPanel.Controls.RemoveAt(selectedIndex);

                UpdateKeyframesList();
            }
        }

        private void SelectKeyframeLabel(int index)
        {
            foreach (Control control in keyframesPanel.Controls)
            {
                control.BackColor = Color.FromArgb(60, 60, 60);
                control.Font = new Font("Segoe UI", 9f, FontStyle.Regular);
            }
            keyframesPanel.Controls[index].BackColor = Color.FromArgb(100, 140, 180);
            keyframesPanel.Controls[index].Font = new Font("Segoe UI", 9f, FontStyle.Bold);
        }

        private void UpdatePropertiesToSelected(int index)
        {
            Keyframe selected = Keyframes.ElementAt(index);

            // Set properties
            changePosToggle.Checked = selected.ChangePos;
            changeSizeToggle.Checked = selected.ChangeSize;
            posXInput.Text = selected.KeyframePos.X.ToString();
            posYInput.Text = selected.KeyframePos.Y.ToString();
            sizeXInput.Text = selected.KeyframeSize.X.ToString();
            sizeYInput.Text = selected.KeyframeSize.Y.ToString();
            visibleToggle.Checked = selected.KeyframeVisible;
            durationInput.Text = selected.Time.ToString();
        }
        #endregion

        #region Save
        private void saveButton_Click(object sender, EventArgs e)
        {
            string fullPath = EngineInstance.MainDirectory + @$"\ANIMATION\{saveNameInput.Text}.animdata";
            string data = "";

            foreach (Keyframe keyframe in Keyframes)
            {
                data += $"{keyframe.Time}|{keyframe.ChangePos}|{keyframe.ChangeSize}|" +
                        $"{keyframe.KeyframePos.X}|{keyframe.KeyframePos.Y}|" +
                        $"{keyframe.KeyframeSize.X}|{keyframe.KeyframeSize.Y}|" +
                        $"{keyframe.KeyframeVisible.ToString()}" +
                        $"\n";
            }

            File.WriteAllText(fullPath, data);
        }
        #endregion

        private void clearButton_Click(object sender, EventArgs e)
        {
            Keyframes.Clear();
            UpdateKeyframesList();

            saveNameInput.Text = "";
            ResetProperties();
        }
    }
}
