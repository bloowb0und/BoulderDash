using System;
using System.Collections.Generic;
using System.Linq;

namespace BoulderDash
{
    public class Game
    {
        private readonly List<List<Element>> _gameField;
        private readonly int _fieldWidth;
        private readonly int _fieldHeight;
        private readonly Player _player;
        private readonly int _amountOfDiamonds;
        private readonly List<Stone> _stoneList;
        private readonly List<Diamond> _diamondList;

        public Game()
        {
            this._gameField = new List<List<Element>>();

            this._fieldHeight = 5;
            this._fieldWidth = 15;

            for (var i = 0; i < _fieldHeight; i++)
            {
                this._gameField.Add(new List<Element>());

                for (var j = 0; j < _fieldWidth; j++)
                {
                    this._gameField[i].Add(new Sand(i, j));
                }
            }

            this._player = new Player(7, 2);
            this._gameField[_player.Y][_player.X] = _player;

            this._stoneList = new List<Stone>
            {
                new Stone(2, 3),
                new Stone(1, 4),
                new Stone(11, 1),
                new Stone(10, 0),
                new Stone(12, 1),
                new Stone(13, 1),
                new Stone(10, 1),
            };

            this._diamondList = new List<Diamond>
            {
                new Diamond(4, 2),
                new Diamond(12, 1),
            };
            
            foreach (var diamond in _diamondList)
            {
                this._gameField[diamond.Y][diamond.X] = diamond;
            }

            foreach (var stone in _stoneList)
            {
                this._gameField[stone.Y][stone.X] = stone;
            }

            this._amountOfDiamonds = _diamondList.Count;
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
                DrawField();

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

                if ((keyHorizontalMotion == 0 ? _player.Y + keyVerticalMotion : _player.X + keyHorizontalMotion) < (keyHorizontalMotion == 0 ? this._fieldHeight : this._fieldWidth)) // check right and bottom is wall
                {
                    if ((keyHorizontalMotion == 0
                            ? _player.Y + keyVerticalMotion
                            : _player.X + keyHorizontalMotion) >= 0) // check if left and top is wall
                    {
                        if (_gameField[_player.Y + keyVerticalMotion][_player.X + keyHorizontalMotion].GetType() !=
                            typeof(Stone)) // check if stone
                        {
                            if (_gameField[_player.Y + keyVerticalMotion][_player.X + keyHorizontalMotion].GetType() ==
                                typeof(Diamond))
                            {
                                diamondsCollected++;
                            }

                            _gameField[_player.Y][_player.X] = new Emptiness(_player.X, _player.Y);
                            _player.Y += keyVerticalMotion;
                            _player.X += keyHorizontalMotion;
                            _gameField[_player.Y][_player.X] = _player;
                        }
                    }
                }

                FallStones(keyVerticalMotion);

                if (IsStoneOnPlayer())
                {
                    EndGame(false);
                    return;
                }

                if (diamondsCollected == _amountOfDiamonds)
                {
                    EndGame(true);
                    return;
                }
                
                Console.Clear();
            }
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
            Console.WriteLine($"{_amountOfDiamonds}" + "\n");
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
                if (stone.Y + 1 == this._gameField.Count) // check if already at the bottom
                {
                    continue;
                }
                
                if (this._gameField[stone.Y + 1][stone.X].GetType() == typeof(Emptiness)
                    || keyVerticalMotion > 0 && _player.Y == _fieldHeight - 1 && this._gameField[stone.Y + 1][stone.X].GetType() == typeof(Player)) // if moving down and has nowhere to go
                {
                    this._gameField[stone.Y][stone.X] = new Emptiness(stone.X, stone.Y);
                    stone.Fall();
                    this._gameField[stone.Y][stone.X] = stone;
                }
            }
        }

        private void DrawField()
        {
            Console.WriteLine(" " + new string('-', _gameField[0].Count));
            for (var i = 0; i < _gameField.Count; i++)
            {
                Console.Write('|');
                for (var j = 0; j < _gameField[i].Count; j++)
                {
                    _gameField[i][j].Draw();
                }
                Console.WriteLine('|');
            }
            Console.WriteLine(" " + new string('-', _gameField[0].Count));
        }

        private void EndGame(bool victoryStatus)
        {
            Console.Clear();
            if (victoryStatus)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Congratulations! You won <3");
                return;
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Better luck next time :(");
        }
    }
}