using Werewolf.Engine;
using Werewolf.Engine.Game;

namespace Werewolf.Engine
{
    internal class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            Console.WriteLine("Hi from Werewolf!");

            try
            {
                new GameInstance();
            }
            catch (Exception ex)
            {
                Debug.ErrorBox("Critical error!\n" + ex);
            }
        }
    }
}
