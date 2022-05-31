using System;

namespace BoulderDash
{
    class Program
    {
        public static void Main(string[] args)
        {
            PrintIntro();
            Console.Write("Press any key to play ");
            var colorBefore = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("BoulderDash");
            Console.ForegroundColor = colorBefore;
            Console.WriteLine("...");
            Console.ReadKey();

            while (true)
            {
                Console.ForegroundColor = colorBefore;
                var game = new Game();
                game.StartGame();
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine("\n" + "Press 'r' to Restart game.");
                var pressedKey = Console.ReadKey().Key;

                if (pressedKey != ConsoleKey.R)
                {
                    break;
                }
            }
        }

        private static void PrintIntro()
        {
            var colorBefore = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            
            Console.WriteLine(@"  ____                 _      _                   _              _     ");
            Console.WriteLine(@" | __ )   ___   _   _ | |  __| |  ___  _ __    __| |  __ _  ___ | |__  ");
            Console.WriteLine(@" |  _ \  / _ \ | | | || | / _` | / _ \| '__|  / _` | / _` |/ __|| '_ \ ");
            Console.WriteLine(@" | |_) || (_) || |_| || || (_| ||  __/| |    | (_| || (_| |\__ \| | | |");
            Console.WriteLine(@" |____/  \___/  \__,_||_| \__,_| \___||_|     \__,_| \__,_||___/|_| |_|");
            Console.WriteLine(@"                                                                       ");

            Console.WriteLine();
            Console.WriteLine();

            Console.ForegroundColor = colorBefore;
        }
    }
}