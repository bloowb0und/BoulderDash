using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using BoulderDashClassLibrary.GameElements;
using BoulderDashClassLibrary.Serialization;
using Newtonsoft.Json;

namespace BoulderDashClassLibrary
{
    public class Game
    {
        private Field _field;
        private Player _player;
        private List<Stone> _stoneList;
        public List<Diamond> DiamondList;
        public int DiamondsCollected;
        private int _curLevel = 1;

        private Action<bool> _endGame;
        private Action _clearScreen;
        private Action<int> _drawInGameMenu;

        private readonly Dictionary<string, (int, int)> _directions = new()
        {
            {"right", (1, 0)},
            {"left", (-1, 0)},
            {"up", (0, -1)},
            {"down", (0, 1)},
        };

        public Game()
        {
            // this._field.SaveToJson("lvl1.json", _diamondList, _stoneList, _player);
            LoadFromJson($"lvl{_curLevel}.json");
        }

        public void StartGame(Action<int> drawInGameMenu, Action<bool> endGame, Action clearScreen)
        {
            clearScreen();
            
            DrawInGameMenu(drawInGameMenu, DiamondsCollected);
            this._field.Draw();

            this._endGame = endGame;
            this._clearScreen = clearScreen;
            this._drawInGameMenu = drawInGameMenu;
        }

        public bool OnPressedButton(string key)
        {
            int deltaX = 0, deltaY = 0;

            key = key.ToLower().Replace("arrow", ""); // cut "arrow" part

            if (_directions.ContainsKey(key))
            {
                (deltaX, deltaY) = _directions[key];
            }

            if (key == "l")
            {
                EndGame(_endGame, false);
                return true;
            }

            DiamondsCollected = MakeMove(deltaX, deltaY, DiamondsCollected);
            FallStones(deltaY);

            if (IsStoneOnPlayer())
            {
                EndGame(_endGame, false);
                return true;
            }

            if (DiamondsCollected == DiamondList.Count)
            {
                EndGame(_endGame, true);
                return true;
            }
                
            this.ClearScreen(_clearScreen);
            
            DrawInGameMenu(_drawInGameMenu, DiamondsCollected);
            this._field.Draw();
            return false;
        }

        private void ClearScreen(Action clearScreen)
        {
            clearScreen();
        }

        private int MakeMove(int deltaX, int deltaY, int diamondsCollected)
        {
            if (this.IsInside(deltaX, deltaY))
            {
                if (_field[_player.X + deltaX, _player.Y + deltaY].GetType() !=
                    typeof(Stone)) // check if stone
                {
                    if (_field[_player.X + deltaX, _player.Y + deltaY].GetType() ==
                        typeof(Diamond))
                    {
                        diamondsCollected++;
                    }

                    _field[_player.X, _player.Y] = new Emptiness();
                    _player.Y += deltaY;
                    _player.X += deltaX;
                    _field[_player.X, _player.Y] = _player;
                }
            }

            return diamondsCollected;
        }

        private bool IsInside(int deltaX, int deltaY)
        {
            var onRightAndBottomEdge = (deltaX == 0 ? _player.Y + deltaY : _player.X + deltaX) <
                                       (deltaX == 0 ? _field.Height : _field.Width);
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
                if (stone.Y + 1 == this._field.Height) // check if already at the bottom
                {
                    continue;
                }

                var pressedDownAndOnEdge = _field[stone.X, stone.Y + 1].GetType() == typeof(Emptiness)
                                           || (deltaY > 0 && (_player.Y == _field.Height - 1 ||
                                                                         _field[_player.X, _player.Y + 1].GetType() ==
                                                                         typeof(Stone))
                                                                     && _field[stone.X, stone.Y + 1].GetType() ==
                                                                     typeof(Player));
                
                if (pressedDownAndOnEdge) // if moving down and has nowhere to go
                {
                    this._field[stone.X,stone.Y] = new Emptiness();
                    stone.Fall();
                    this._field[stone.X,stone.Y] = stone;
                }
            }
        }

        private void EndGame(Action<bool> endGame, bool victoryStatus)
        {
            endGame(victoryStatus);
        }

        private void LoadFromJson(string fileName)
        {
            var level = File.ReadAllText($"levels/{fileName}");
            
            var deserializedProduct = JsonConvert.DeserializeObject<LevelSerialization>(level);
            if (deserializedProduct != null)
            {
                this._field = new Field(deserializedProduct.Width, deserializedProduct.Height);

                DiamondList = deserializedProduct.Diamonds;
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