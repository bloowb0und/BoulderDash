using System;
using System.Collections.Generic;
using System.Linq;

namespace BoulderDash
{
    public class Game
    {
        private readonly List<List<Element>> _gameField;
        private readonly Player _player;
        private readonly int _amountOfDiamonds;
        private readonly List<Stone> _stoneList;

        public Game()
        {
            this._gameField = new List<List<Element>>();

            for (var i = 0; i < 5; i++)
            {
                this._gameField.Add(new List<Element>());

                for (var j = 0; j < 15; j++)
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

            this._gameField[4][2] = new Diamond(4, 2);
            this._gameField[0][12] = new Diamond(12, 1);
            
            this._gameField[_stoneList[0].Y][_stoneList[0].X] = _stoneList[0];
            this._gameField[_stoneList[1].Y][_stoneList[1].X] = _stoneList[1];
            this._gameField[_stoneList[2].Y][_stoneList[2].X] = _stoneList[2];
            this._gameField[_stoneList[3].Y][_stoneList[3].X] = _stoneList[3];
            this._gameField[_stoneList[4].Y][_stoneList[4].X] = _stoneList[4];
            this._gameField[_stoneList[5].Y][_stoneList[5].X] = _stoneList[5];
            this._gameField[_stoneList[6].Y][_stoneList[6].X] = _stoneList[6];

            _amountOfDiamonds = 2;
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
                var isVerticalMotion = false;
                switch (enteredKey.Key)
                {
                    case ConsoleKey.RightArrow:
                        if (_player.X + 1 < _gameField[_player.Y].Count // check if wall
                            && _gameField[_player.Y][_player.X + 1].GetType() != typeof(Stone)) // check if stone
                        {
                            if (_gameField[_player.Y][_player.X + 1].GetType() == typeof(Diamond))
                            {
                                diamondsCollected++;
                            }
                            _gameField[_player.Y][_player.X] = new Emptiness(_player.X, _player.Y);
                            _gameField[_player.Y][++_player.X] = _player;
                        }
                        isVerticalMotion = false;

                        break;

                    case ConsoleKey.LeftArrow:
                        if (_player.X - 1 >= 0 // check if wall
                            && _gameField[_player.Y][_player.X - 1].GetType() != typeof(Stone)) // check if stone
                        {
                            if (_gameField[_player.Y][_player.X - 1].GetType() == typeof(Diamond))
                            {
                                diamondsCollected++;
                            }
                            _gameField[_player.Y][_player.X] = new Emptiness(_player.X, _player.Y);
                            _gameField[_player.Y][--_player.X] = _player;
                        }
                        isVerticalMotion = false;

                        break;

                    case ConsoleKey.UpArrow:
                        if (_player.Y - 1 >= 0 // check if wall
                            && _gameField[_player.Y - 1][_player.X].GetType() != typeof(Stone)) // check if stone
                        {
                            if (_gameField[_player.Y - 1][_player.X].GetType() == typeof(Diamond))
                            {
                                diamondsCollected++;
                            }
                            _gameField[_player.Y][_player.X] = new Emptiness(_player.X, _player.Y);
                            _gameField[--_player.Y][_player.X] = _player;
                        }
                        isVerticalMotion = true;

                        break;

                    case ConsoleKey.DownArrow:
                        if (_player.Y + 1 < _gameField.Count // check if wall
                            && _gameField[_player.Y + 1][_player.X].GetType() != typeof(Stone)) // check if stone
                        {
                            if (_gameField[_player.Y + 1][_player.X].GetType() == typeof(Diamond))
                            {
                                diamondsCollected++;
                            }
                            _gameField[_player.Y][_player.X] = new Emptiness(_player.X, _player.Y);
                            _gameField[++_player.Y][_player.X] = _player;
                        }
                        isVerticalMotion = true;
                        
                        break;

                    case ConsoleKey.L:
                        EndGame(false);
                        return;
                }

                FallStones(isVerticalMotion);

                if (CheckIfPlayerIsUnderStone())
                {
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

        private bool CheckIfPlayerIsUnderStone()
        {
            if (this._stoneList.Any(stone => stone.X == this._player.X && stone.Y == this._player.Y))
            {
                EndGame(false);
                return true;
            }

            return false;
        }

        private void FallStones(bool isVerticalMotion)
        {
            if (this._stoneList.Count < 1)
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
                    || isVerticalMotion && this._gameField[stone.Y + 1][stone.X].GetType() == typeof(Player))
                {
                    this._gameField[stone.Y][stone.X] = new Emptiness(stone.X, stone.Y);
                    stone.Y++;
                    this._gameField[stone.Y][stone.X] = stone;
                    continue;
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