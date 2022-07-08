using System;
using BoulderDashClassLibrary;

namespace BoulderDash
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            ConsoleActions.PrintIntro();
            Console.Write("Press any key to play ");
            var colorBefore = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("BoulderDashConsole");
            Console.ForegroundColor = colorBefore;
            Console.WriteLine("...");
            Console.ReadKey();

            while (true)
            {
                Console.ForegroundColor = colorBefore;
                var game = new Game();
                Console.Clear();
                Console.CursorVisible = false;
                Element.DrawElement += ConsoleActions.ElementOnDrawElement;
                game.StartGame(_ => ConsoleActions.DrawInGameMenu(game.DiamondsCollected, game.DiamondList.Count),
                    ConsoleActions.EndGame, ConsoleActions.ClearScreen);
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine("\n" + "Press 'r' to Restart game.");
                var pressedKey = Console.ReadKey().Key;

                if (pressedKey != ConsoleKey.R) break;
                Element.DrawElement -= ConsoleActions.ElementOnDrawElement;
            }
        }
    }
}