using Epicity.Engine.Editor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Werewolf.Engine.Editor;

namespace Werewolf.Engine
{
    public class Debug
    {
        public static void Log(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("[LOG] " + msg);
            Console.ForegroundColor = ConsoleColor.White;

            MainWindowEditorControls.AddMessageToConsole("log", "[LOG] " + msg);
        }

        public static void Warning(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("[WARNING] " + msg);
            Console.ForegroundColor = ConsoleColor.White;

            MainWindowEditorControls.AddMessageToConsole("warning", "[WARNING] " + msg);
        }

        public static void Error(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("[ERROR] " + msg);
            Console.ForegroundColor = ConsoleColor.White;
         
            MainWindowEditorControls.AddMessageToConsole("error", "[ERROR] " + msg);
        }

        public static void ErrorBox(string msg)
        {
            MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Error(msg);
        }
    }
}
