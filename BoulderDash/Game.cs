using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace BoulderDash
{
    public class Game
    {
        private Field _field;
        private Player _player;
        private List<Stone> _stoneList;
        private List<Diamond> _diamondList;
        private int curLevel = 1;

        public Game()
        {
            // this._field.SaveToJson("lvl1.json", _diamondList, _stoneList, _player);
            LoadFromJson("lvl1.json");
        }

        public void StartGame()
        {
            Console.Clear();
            Console.CursorVisible = false;
            ConsoleKeyInfo enteredKey;
            var diamondsCollected = 0;

            while (true)
            {
                var prevColor = Console.ForegroundColor;
                DrawInGameMenu(diamondsCollected);
                Console.ForegroundColor = prevColor;
                this._field.Draw();

                enteredKey = Console.ReadKey();

                var keyHorizontalMotion = 0;
                var keyVerticalMotion = 0;
                switch (enteredKey.Key)
                {
                    case ConsoleKey.RightArrow:
                        keyHorizontalMotion = 1;

                        break;

                    case ConsoleKey.LeftArrow:
                        keyHorizontalMotion = -1;

                        break;

                    case ConsoleKey.UpArrow:
                        keyVerticalMotion = -1;

                        break;

                    case ConsoleKey.DownArrow:
                        keyVerticalMotion = 1;

                        break;

                    case ConsoleKey.L:
                        EndGame(false);
                        return;
                }

                diamondsCollected = MakeMove(keyHorizontalMotion, keyVerticalMotion, diamondsCollected);

                FallStones(keyVerticalMotion);

                if (IsStoneOnPlayer())
                {
                    EndGame(false);
                    return;
                }

                if (diamondsCollected == _diamondList.Count)
                {
                    EndGame(true);
                    return;
                }
                
                Console.Clear();
            }
        }

        private int MakeMove(int keyHorizontalMotion, int keyVerticalMotion, int diamondsCollected)
        {
            if ((keyHorizontalMotion == 0 ? _player.Y + keyVerticalMotion : _player.X + keyHorizontalMotion) <
                (keyHorizontalMotion == 0 ? this._field.Height : this._field.Width)) // check right and bottom is wall
            {
                if ((keyHorizontalMotion == 0
                        ? _player.Y + keyVerticalMotion
                        : _player.X + keyHorizontalMotion) >= 0) // check if left and top is wall
                {
                    if (_field[_player.X + keyHorizontalMotion, _player.Y + keyVerticalMotion].GetType() !=
                        typeof(Stone)) // check if stone
                    {
                        if (_field[_player.X + keyHorizontalMotion, _player.Y + keyVerticalMotion].GetType() ==
                            typeof(Diamond))
                        {
                            diamondsCollected++;
                        }

                        _field[_player.X, _player.Y] = new Emptiness(_player.X, _player.Y);
                        _player.Y += keyVerticalMotion;
                        _player.X += keyHorizontalMotion;
                        _field[_player.X, _player.Y] = _player;
                    }
                }
            }

            return diamondsCollected;
        }

        private void DrawInGameMenu(int diamondsCollected)
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
            Console.Write($"Diamonds collected: ");
            Console.ForegroundColor = diamondsCollected > 0 ? ConsoleColor.Green : ConsoleColor.Gray;
            Console.Write($"{diamondsCollected}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"/");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine($"{_diamondList.Count}" + "\n");
        }

        private bool IsStoneOnPlayer()
        {
            return this._stoneList.Any(stone => stone.X == this._player.X && stone.Y == this._player.Y);
        }

        private void FallStones(int keyVerticalMotion)
        {
            if (this._stoneList.Count == 0)
            {
                return;
            }

            foreach (var stone in this._stoneList)
            {
                if (stone.Y + 1 == this._field.Height) // check if already at the bottom
                {
                    continue;
                }
                
                if (this._field[stone.X,stone.Y + 1].GetType() == typeof(Emptiness)
                    || keyVerticalMotion > 0 && _player.Y == this._field.Height - 1 && this._field[stone.X,stone.Y + 1].GetType() == typeof(Player)) // if moving down and has nowhere to go
                {
                    this._field[stone.X,stone.Y] = new Emptiness(stone.X, stone.Y);
                    stone.Fall();
                    this._field[stone.X,stone.Y] = stone;
                }
            }
        }

        private void EndGame(bool victoryStatus)
        {
            Console.Clear();
            if (victoryStatus)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                // Console.WriteLine("Congratulations! You won <3");
                Console.WriteLine(@"   ___                            _         _       _   _                    _                                        
  / __\___  _ __   __ _ _ __ __ _| |_ _   _| | __ _| |_(_) ___  _ __  ___   / \ /\_/\___  _   _  __      _____  _ __  
 / /  / _ \| '_ \ / _` | '__/ _` | __| | | | |/ _` | __| |/ _ \| '_ \/ __| /  / \_ _/ _ \| | | | \ \ /\ / / _ \| '_ \ 
/ /__| (_) | | | | (_| | | | (_| | |_| |_| | | (_| | |_| | (_) | | | \__ \/\_/   / \ (_) | |_| |  \ V  V / (_) | | | |
\____/\___/|_| |_|\__, |_|  \__,_|\__|\__,_|_|\__,_|\__|_|\___/|_| |_|___/\/     \_/\___/ \__,_|   \_/\_/ \___/|_| |_|
                  |___/                                                                                               ");
                return;
            }

            Console.ForegroundColor = ConsoleColor.Red;
            // Console.WriteLine("Better luck next time :(");
            Console.WriteLine(@"███   ▄███▄     ▄▄▄▄▀ ▄▄▄▄▀ ▄███▄   █▄▄▄▄     █       ▄   ▄█▄    █  █▀        ▄   ▄███▄      ▄     ▄▄▄▄▀        ▄▄▄▄▀ ▄█ █▀▄▀█ ▄███▄   
█  █  █▀   ▀ ▀▀▀ █ ▀▀▀ █    █▀   ▀  █  ▄▀     █        █  █▀ ▀▄  █▄█           █  █▀   ▀ ▀▄   █ ▀▀▀ █        ▀▀▀ █    ██ █ █ █ █▀   ▀  
█ ▀ ▄ ██▄▄       █     █    ██▄▄    █▀▀▌      █     █   █ █   ▀  █▀▄       ██   █ ██▄▄     █ ▀      █            █    ██ █ ▄ █ ██▄▄    
█  ▄▀ █▄   ▄▀   █     █     █▄   ▄▀ █  █      ███▄  █   █ █▄  ▄▀ █  █      █ █  █ █▄   ▄▀ ▄ █      █            █     ▐█ █   █ █▄   ▄▀ 
███   ▀███▀    ▀     ▀      ▀███▀     █           ▀ █▄ ▄█ ▀███▀    █       █  █ █ ▀███▀  █   ▀▄   ▀            ▀       ▐    █  ▀███▀   
                                     ▀               ▀▀▀          ▀        █   ██         ▀                                ▀           
                                                                                                                                       ");
        }
        
        public void LoadFromJson(string fileName)
        {
            var level = File.ReadAllText($"levels/{fileName}");
            
            var deserializedProduct = JsonConvert.DeserializeObject<LevelSerialization>(level);
            if (deserializedProduct != null)
            {
                this._field = new Field(deserializedProduct.Width, deserializedProduct.Height);

                _diamondList = deserializedProduct.Diamonds;
                foreach (var diamond in deserializedProduct.Diamonds)
                {
                    this._field[diamond.X,diamond.Y] = diamond;
                }

                _stoneList = deserializedProduct.Stones;
                foreach (var stone in deserializedProduct.Stones)
                {
                    this._field[stone.X,stone.Y] = stone;
                }
                
                this._player = new Player(deserializedProduct.Player.X, deserializedProduct.Player.Y);
                this._field[_player.X,_player.Y] = _player;
            }
        }
    }
}