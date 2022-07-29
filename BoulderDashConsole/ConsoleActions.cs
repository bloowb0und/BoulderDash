using System;
using BoulderDashClassLibrary.GameElements;

namespace BoulderDash
{
    public static class ConsoleActions
    {
        public static void ElementOnDrawElement(object sender, EventArgs e)
        {
            if (sender is not Element element)
            {
                return;
            }

            var symbol = element switch
            {
                Emptiness => ' ',
                Player => 'I',
                Sand => '·',
                Stone => 'o',
                Diamond => 'D',
                Wall => '#',
                Edge => '\n',
                _ => '?'
            };

            Console.Write(symbol);
        }

        public static void ClearScreen()
        {
            Console.Clear();
        }

        public static void EndGame(bool victoryStatus)
        {
            Console.Clear();
            if (victoryStatus)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(@"   ___                            _         _       _   _                    _                                        
  / __\___  _ __   __ _ _ __ __ _| |_ _   _| | __ _| |_(_) ___  _ __  ___   / \ /\_/\___  _   _  __      _____  _ __  
 / /  / _ \| '_ \ / _` | '__/ _` | __| | | | |/ _` | __| |/ _ \| '_ \/ __| /  / \_ _/ _ \| | | | \ \ /\ / / _ \| '_ \ 
/ /__| (_) | | | | (_| | | | (_| | |_| |_| | | (_| | |_| | (_) | | | \__ \/\_/   / \ (_) | |_| |  \ V  V / (_) | | | |
\____/\___/|_| |_|\__, |_|  \__,_|\__|\__,_|_|\__,_|\__|_|\___/|_| |_|___/\/     \_/\___/ \__,_|   \_/\_/ \___/|_| |_|
                  |___/                                                                                               ");
                return;
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(@"███   ▄███▄     ▄▄▄▄▀ ▄▄▄▄▀ ▄███▄   █▄▄▄▄     █       ▄   ▄█▄    █  █▀        ▄   ▄███▄      ▄     ▄▄▄▄▀        ▄▄▄▄▀ ▄█ █▀▄▀█ ▄███▄   
█  █  █▀   ▀ ▀▀▀ █ ▀▀▀ █    █▀   ▀  █  ▄▀     █        █  █▀ ▀▄  █▄█           █  █▀   ▀ ▀▄   █ ▀▀▀ █        ▀▀▀ █    ██ █ █ █ █▀   ▀  
█ ▀ ▄ ██▄▄       █     █    ██▄▄    █▀▀▌      █     █   █ █   ▀  █▀▄       ██   █ ██▄▄     █ ▀      █            █    ██ █ ▄ █ ██▄▄    
█  ▄▀ █▄   ▄▀   █     █     █▄   ▄▀ █  █      ███▄  █   █ █▄  ▄▀ █  █      █ █  █ █▄   ▄▀ ▄ █      █            █     ▐█ █   █ █▄   ▄▀ 
███   ▀███▀    ▀     ▀      ▀███▀     █           ▀ █▄ ▄█ ▀███▀    █       █  █ █ ▀███▀  █   ▀▄   ▀            ▀       ▐    █  ▀███▀   
                                     ▀               ▀▀▀          ▀        █   ██         ▀                                ▀           
                                                                                                                                       ");
        }

        public static void DrawInGameMenu(int diamondsCollected, int diamondsAmount)
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine(new string('=', 25));
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Use arrows to move around");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine(new string('=', 25));
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("To win collect all diamonds (D)");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Surrender - press L");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine(new string('=', 25));
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Diamonds collected: ");
            Console.ForegroundColor = diamondsCollected > 0 ? ConsoleColor.Green : ConsoleColor.Gray;
            Console.Write($"{diamondsCollected}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("/");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine($"{diamondsAmount}" + "\n");
        }

        public static void PrintIntro()
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