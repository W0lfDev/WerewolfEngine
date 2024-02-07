using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Werewolf.Engine.Editor
{
    public class EditorStyle
    {
        public static void ApplyStyle(Form form)
        {
            foreach (Control control in GetAllControls(form))
            {
                
                if (control is Button buttonControl)
                {
                    buttonControl.FlatStyle = FlatStyle.Flat;
                    buttonControl.FlatAppearance.BorderSize = 1;
                    buttonControl.FlatAppearance.BorderColor = Color.FromArgb(69, 69, 69);
                    buttonControl.BackColor = Color.FromArgb(65, 65, 65);
                    buttonControl.FlatAppearance.MouseDownBackColor = Color.FromArgb(69, 69, 69);
                    buttonControl.TextAlign = ContentAlignment.MiddleCenter;
                    
                    control.BackColor = Color.FromArgb(60, 60, 60);

                    if (buttonControl.ForeColor == SystemColors.ControlText)
                    {
                        buttonControl.ForeColor = Color.WhiteSmoke;
                        buttonControl.Font = new Font("Segoe UI", 12);
                    }

                    if (buttonControl.Text.EndsWith("-")) // Should not have a back color and border
                    {
                        buttonControl.Text = buttonControl.Text.Substring(0, buttonControl.Text.Length - 1);

                        buttonControl.BackColor = Color.FromArgb(60, 60, 60);
                        buttonControl.FlatAppearance.BorderColor = buttonControl.BackColor;
                        buttonControl.FlatAppearance.BorderSize = 0;
                    }
                    else if (buttonControl.Text.EndsWith("~")) // Should not have a back color and border
                    {
                        buttonControl.Text = buttonControl.Text.Substring(0, buttonControl.Text.Length - 1);
                        buttonControl.Font = new Font("Segoe UI Emoji", 10);
                    }
                }
                else if (control is TextBox textBox)
                {
                    textBox.ForeColor = Color.WhiteSmoke;
                    textBox.BorderStyle = BorderStyle.FixedSingle;
                    
                    control.BackColor = Color.FromArgb(60, 60, 60);
                }
                else if (control is Label label)
                {
                    label.ForeColor = Color.WhiteSmoke;
                }
                else if (control is CheckBox checkbox)
                {
                    checkbox.BackColor = Color.FromArgb(55, 55, 55);
                    checkbox.FlatStyle = FlatStyle.Flat;
                    checkbox.FlatAppearance.BorderSize = 1;
                    checkbox.FlatAppearance.BorderColor = Color.FromArgb(55, 55, 55);
                    checkbox.ForeColor = Color.WhiteSmoke;
                }
            }

            ImmersiveWindow.TryEnable(form.Handle, true);
        }

        private static List<Control> GetAllControls(Form form)
        {
            List<Control> controls = new List<Control>();

            foreach (Control control in form.Controls)
            {
                controls.Add(control);
                controls.AddRange(GetAllControlsRecursive(control));
            }

            return controls;
        }

        private static List<Control> GetAllControlsRecursive(Control container)
        {
            List<Control> controls = new List<Control>();

            foreach (Control control in container.Controls)
            {
                controls.Add(control);
                controls.AddRange(GetAllControlsRecursive(control));
            }

            return controls;
        }
    }
}
