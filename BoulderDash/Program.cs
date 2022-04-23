using System;

namespace BoulderDash
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintIntro();
            
            var game = new Game();
            game.StartGame();
        }

        static void PrintIntro()
        {
            var colorBefore = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.DarkRed;
            
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