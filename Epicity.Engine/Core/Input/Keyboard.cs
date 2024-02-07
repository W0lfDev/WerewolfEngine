using OpenTK.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Werewolf.Engine
{
    public class Keyboard
    {
        private static bool[] keys = new bool[256];

        public static void HandleKeyDown(object? sender, KeyEventArgs e)
        {
            keys[(int)e.KeyCode] = true;
        }

        public static void HandleKeyUp(object? sender, KeyEventArgs e)
        {
            keys[(int)e.KeyCode] = false;
        }

        public static bool IsKeyPressed(Keys key)
        {
            return keys[(int)key];
        }
    }
}
