using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Werewolf.Engine.Editor
{
    public delegate void OnEnterPressedHandler(object sender, EventArgs e);
    public delegate void OnValueChangedHandler(object sender, EventArgs e);

    public class SlideTextbox : TextBox
    {
        private bool isDragging;
        private int initialMouseX;

        private float Value;

        public event OnEnterPressedHandler OnEnterPressed;
        public event OnValueChangedHandler OnValueChanged;

        public SlideTextbox()
        {
            this.ReadOnly = true;

            this.MouseDown += DraggableTextBox_MouseDown;
            this.MouseMove += DraggableTextBox_MouseMove;
            this.MouseUp += DraggableTextBox_MouseUp;
            this.KeyPress += DraggableTextBox_KeyPress;
            this.TextChanged += SlideTextbox_TextChanged;
        }

        private void SlideTextbox_TextChanged(object? sender, EventArgs e)
        {
            if (OnValueChanged != null)
                OnValueChanged(sender, EventArgs.Empty);
        }

        private void DraggableTextBox_MouseDown(object sender, MouseEventArgs e)
        {
            this.Select();

            if (e.Clicks == 2)
            {
                this.ReadOnly = false;
            }
            else
            {
                isDragging = true;
                this.ReadOnly = true;
                initialMouseX = e.X;
                Value = float.Parse(this.Text);
            }
        }

        private void DraggableTextBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                int deltaX = e.X - initialMouseX;

                // Adjust the TextBox value based on the change in Y position
                float newValue = Value - (-deltaX);

                // Update the TextBox text
                this.Text = newValue.ToString();

                if (OnValueChanged  != null)
                    OnValueChanged(this, EventArgs.Empty);
            }
        }

        private void DraggableTextBox_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
        }

        private void DraggableTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (OnEnterPressed != null)
                    OnEnterPressed(this, EventArgs.Empty);

                if (OnValueChanged != null)
                    OnValueChanged(this, EventArgs.Empty);

                e.Handled = true;
            }
        }
    }
}
