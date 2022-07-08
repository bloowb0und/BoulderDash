using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using BoulderDash;
using Newtonsoft.Json;

namespace BoulderDashClassLibrary
{
    public class Game
    {
        public Field Field;
        private Player _player;
        private List<Stone> _stoneList;
        public List<Diamond> DiamondList;
        public int DiamondsCollected;
        private int curLevel = 1;

        private readonly Dictionary<ConsoleKey, (int, int)> _directions = new()
        {
            {ConsoleKey.RightArrow, (1, 0)},
            {ConsoleKey.LeftArrow, (-1, 0)},
            {ConsoleKey.UpArrow, (0, -1)},
            {ConsoleKey.DownArrow, (0, 1)},
        };

        public Game()
        {
            // this._field.SaveToJson("lvl1.json", _diamondList, _stoneList, _player);
            LoadFromJson("lvl1.json");
        }

        public void StartGame(Action<int> drawInGameMenu, Action<bool> endGame, Action clearScreen)
        {
            ConsoleKeyInfo enteredKey;
            clearScreen();
            
            while (true)
            {
                var prevColor = Console.ForegroundColor;
                DrawInGameMenu(drawInGameMenu, DiamondsCollected);
                Console.ForegroundColor = prevColor;
                this.Field.Draw();

                enteredKey = Console.ReadKey();

                int deltaX = 0, deltaY = 0;

                if (_directions.ContainsKey(enteredKey.Key))
                {
                    (deltaX, deltaY) = _directions[enteredKey.Key];
                }

                if (enteredKey.Key == ConsoleKey.L)
                {
                    EndGame(endGame, false);
                    return;
                }

                DiamondsCollected = MakeMove(deltaX, deltaY, DiamondsCollected);
                FallStones(deltaY);

                if (IsStoneOnPlayer())
                {
                    EndGame(endGame, false);
                    return;
                }

                if (DiamondsCollected == DiamondList.Count)
                {
                    EndGame(endGame, true);
                    return;
                }
                
                this.ClearScreen(clearScreen);
            }
        }

        private void ClearScreen(Action clearScreen)
        {
            clearScreen();
        }

        private int MakeMove(int deltaX, int deltaY, int diamondsCollected)
        {
            if (this.IsInside(deltaX, deltaY))
            {
                if (Field[_player.X + deltaX, _player.Y + deltaY].GetType() !=
                    typeof(Stone)) // check if stone
                {
                    if (Field[_player.X + deltaX, _player.Y + deltaY].GetType() ==
                        typeof(Diamond))
                    {
                        diamondsCollected++;
                    }

                    Field[_player.X, _player.Y] = new Emptiness();
                    _player.Y += deltaY;
                    _player.X += deltaX;
                    Field[_player.X, _player.Y] = _player;
                }
            }

            return diamondsCollected;
        }

        private bool IsInside(int deltaX, int deltaY)
        {
            var onRightAndBottomEdge = (deltaX == 0 ? _player.Y + deltaY : _player.X + deltaX) <
                                       (deltaX == 0 ? Field.Height : Field.Width);
            var onLeftAndTopEdge = (deltaX == 0 ? _player.Y + deltaY : _player.X + deltaX) >= 0;

            return onRightAndBottomEdge && onLeftAndTopEdge;
        }

        private void DrawInGameMenu(Action<int> drawInGameMenu, int diamondsCollected)
        {
            drawInGameMenu(diamondsCollected);
        }

        private bool IsStoneOnPlayer()
        {
            return this._stoneList.Any(stone => stone.X == this._player.X && stone.Y == this._player.Y);
        }

        private void FallStones(int deltaY)
        {
            if (this._stoneList.Count == 0)
            {
                return;
            }

            foreach (var stone in this._stoneList)
            {
                if (stone.Y + 1 == this.Field.Height) // check if already at the bottom
                {
                    continue;
                }

                var pressedDownAndOnEdge = Field[stone.X, stone.Y + 1].GetType() == typeof(Emptiness)
                                           || (deltaY > 0 && (_player.Y == Field.Height - 1 ||
                                                                         Field[_player.X, _player.Y + 1].GetType() ==
                                                                         typeof(Stone))
                                                                     && Field[stone.X, stone.Y + 1].GetType() ==
                                                                     typeof(Player));
                
                if (pressedDownAndOnEdge) // if moving down and has nowhere to go
                {
                    this.Field[stone.X,stone.Y] = new Emptiness();
                    stone.Fall();
                    this.Field[stone.X,stone.Y] = stone;
                }
            }
        }

        private void EndGame(Action<bool> endGame, bool victoryStatus)
        {
            endGame(victoryStatus);
        }
        
        public void LoadFromJson(string fileName)
        {
            var level = File.ReadAllText($"levels/{fileName}");
            
            var deserializedProduct = JsonConvert.DeserializeObject<LevelSerialization>(level);
            if (deserializedProduct != null)
            {
                this.Field = new Field(deserializedProduct.Width, deserializedProduct.Height);

                DiamondList = deserializedProduct.Diamonds;
                foreach (var diamond in deserializedProduct.Diamonds)
                {
                    this.Field[diamond.X,diamond.Y] = diamond;
                }

                _stoneList = deserializedProduct.Stones;
                foreach (var stone in deserializedProduct.Stones)
                {
                    this.Field[stone.X,stone.Y] = stone;
                }
                
                this._player = new Player(deserializedProduct.Player.X, deserializedProduct.Player.Y);
                this.Field[_player.X,_player.Y] = _player;
            }
        }
    }
}