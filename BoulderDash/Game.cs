using System;
using System.Collections.Generic;

namespace BoulderDash
{
    public class Game
    {
        private List<List<Element>> _gameField = new List<List<Element>>();

        public Game()
        {
            for (int i = 0; i < 5; i++)
            {  
                _gameField.Add(new List<Element>());

                for (int j = 0; j < 15; j++)
                {
                    _gameField[i].Add(new Sand(i, j));
                }
            }

            _gameField[2][7] = new Player(7, 2);
            
            _gameField[4][2] = new Diamond(4, 2);
            _gameField[3][2] = new Stone(3, 2);
            _gameField[4][1] = new Stone(1, 4);

            _gameField[1][12] = new Diamond(12, 1);
            _gameField[2][11] = new Stone(11, 1);
            _gameField[2][10] = new Stone(10, 1);
            _gameField[2][12] = new Stone(10, 1);
            _gameField[2][13] = new Stone(13, 1);
            _gameField[1][10] = new Stone(13, 1);
        }

        public void StartGame()
        {
            ConsoleKeyInfo enteredKey = default;
            Console.WriteLine("User arrows to move" + "\n\n");
            
            while (true)
            {
                DrawField();
                
                enteredKey = Console.ReadKey();
                Console.Clear();
            }
        }

        public void DrawField()
        {
            for (var i = 0; i < _gameField.Count; i++)
            {
                for (var j = 0; j < _gameField[i].Count; j++)
                {
                    _gameField[i][j].Draw();
                }
                Console.WriteLine();
            }
        }
    }
}