using System;
using BoulderDashClassLibrary;
using BoulderDashClassLibrary.GameElements;

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
                while (true)
                {
                    var enteredKey = Console.ReadKey().Key.ToString();
                    enteredKey = enteredKey.ToLower().Replace("arrow", ""); // cut "arrow" part
                    
                    var isInterrupted = game.OnPressedButton(enteredKey);
                    if (isInterrupted)
                    {
                        break;
                    }
                }
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine("\n" + "Press 'r' to Restart game.");
                var pressedKey = Console.ReadKey().Key;

                if (pressedKey != ConsoleKey.R) break;
                Element.DrawElement -= ConsoleActions.ElementOnDrawElement;
            }
        }
    }
}