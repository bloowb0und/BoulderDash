using System;
using System.Collections.Generic;

namespace BoulderDash
{
    public class Game
    {
        private readonly List<List<Element>> _gameField;
        private readonly Player _player;
        private readonly int amountOfDiamonds;

        public Game()
        {
            _gameField = new List<List<Element>>();

            for (var i = 0; i < 5; i++)
            {
                _gameField.Add(new List<Element>());

                for (var j = 0; j < 15; j++) _gameField[i].Add(new Sand(i, j));
            }

            _player = new Player(7, 2);
            _gameField[_player.Y][_player.X] = _player;

            _gameField[4][2] = new Diamond(4, 2);
            _gameField[3][2] = new Stone(3, 2);
            _gameField[4][1] = new Stone(1, 4);
            _gameField[1][12] = new Diamond(12, 1);
            _gameField[2][11] = new Stone(11, 1);
            _gameField[2][10] = new Stone(10, 1);
            _gameField[2][12] = new Stone(10, 1);
            _gameField[2][13] = new Stone(13, 1);
            _gameField[1][10] = new Stone(13, 1);

            amountOfDiamonds = 2;
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
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine("\n" + new string('=', 25));
                Console.WriteLine("Use arrows to move around");
                Console.WriteLine(new string('=', 25));
                Console.WriteLine("Win game - press W");
                Console.WriteLine("Lose game - press L");
                Console.WriteLine(new string('=', 25));
                Console.WriteLine($"Diamonds collected: {diamondsCollected}/{amountOfDiamonds}" + "\n");
                Console.ForegroundColor = prevColor;
                DrawField();

                enteredKey = Console.ReadKey();
                switch (enteredKey.Key.ToString())
                {
                    case "RightArrow":
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

                        break;

                    case "LeftArrow":
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

                        break;

                    case "UpArrow":
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

                        break;

                    case "DownArrow":
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
                        
                        break;

                    case "W":
                        EndGame(true);
                        return;

                    case "L":
                        EndGame(false);
                        return;
                }

                if (diamondsCollected == amountOfDiamonds)
                {
                    EndGame(true);
                    return;
                }
                
                Console.Clear();
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