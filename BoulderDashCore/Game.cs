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
            // _field.SaveToJson("lvl1.json", _diamondList, _stoneList, _player);
            LoadFromJson($"lvl{_curLevel}.json");
        }

        public void StartGame(Action<int> drawInGameMenu, Action<bool> endGame, Action clearScreen)
        {
            _endGame = endGame;
            _clearScreen = clearScreen;
            _drawInGameMenu = drawInGameMenu;

            ClearScreen();
            
            DrawInGameMenu(DiamondsCollected);
            _field.Draw();
        }

        public bool OnPressedButton(string key)
        {
            int deltaX = 0, deltaY = 0;

            if (_directions.ContainsKey(key))
            {
                (deltaX, deltaY) = _directions[key];
            }

            if (key == "l")
            {
                EndGame(false);
                return true;
            }

            DiamondsCollected = MakeMove(deltaX, deltaY, DiamondsCollected);
            FallStones(deltaY);

            if (IsStoneOnPlayer())
            {
                EndGame(false);
                return true;
            }

            if (DiamondsCollected == DiamondList.Count)
            {
                EndGame(true);
                return true;
            }
            
            ClearScreen();
            
            DrawInGameMenu(DiamondsCollected);
            _field.Draw();
            return false;
        }

        private void ClearScreen()
        {
            _clearScreen();
        }

        private int MakeMove(int deltaX, int deltaY, int diamondsCollected)
        {
            if (IsInside(deltaX, deltaY))
            {
                var movedPlayer = _field[_player.X + deltaX, _player.Y + deltaY];
                
                if (movedPlayer is not Stone) // check if stone
                {
                    if (movedPlayer is Diamond)
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
            var py = _player.Y + deltaY;
            var px = _player.X + deltaX;
            
            var onRightAndBottomEdge = (deltaX == 0 ? py : px) < (deltaX == 0 ? _field.Height : _field.Width);
            var onLeftAndTopEdge = (deltaX == 0 ? py : px) >= 0;

            return onRightAndBottomEdge && onLeftAndTopEdge;
        }

        private void DrawInGameMenu(int diamondsCollected)
        {
            _drawInGameMenu(diamondsCollected);
        }

        private bool IsStoneOnPlayer()
        {
            return _stoneList.Any(stone => stone.X == _player.X && stone.Y == _player.Y);
        }

        private void FallStones(int deltaY)
        {
            if (_stoneList.Count == 0)
            {
                return;
            }

            foreach (var stone in _stoneList)
            {
                if (stone.Y + 1 == _field.Height) // check if already at the bottom
                {
                    continue;
                }

                var elemUnderStone = _field[stone.X, stone.Y + 1];
                var playerIsOnBottom = _player.Y == _field.Height - 1;
                var playerIsUnderStone = _field[_player.X, _player.Y + 1] is Stone;

                var pressedDownAndOnEdge = elemUnderStone is Emptiness 
                                           || (deltaY > 0 && (playerIsOnBottom || playerIsUnderStone) 
                                                          && elemUnderStone is Player);
                
                if (pressedDownAndOnEdge) // if moving down and has nowhere to go
                {
                    _field[stone.X,stone.Y] = new Emptiness();
                    stone.Fall();
                    _field[stone.X,stone.Y] = stone;
                }
            }
        }

        private void EndGame(bool victoryStatus)
        {
            _endGame(victoryStatus);
        }

        private void LoadFromJson(string fileName)
        {
            var level = File.ReadAllText($"levels/{fileName}");
            
            var deserializedProduct = JsonConvert.DeserializeObject<LevelSerialization>(level);
            if (deserializedProduct != null)
            {
                _field = new Field(deserializedProduct.Width, deserializedProduct.Height);

                DiamondList = deserializedProduct.Diamonds;
                foreach (var diamond in deserializedProduct.Diamonds)
                {
                    _field[diamond.X,diamond.Y] = diamond;
                }

                _stoneList = deserializedProduct.Stones;
                foreach (var stone in deserializedProduct.Stones)
                {
                    _field[stone.X,stone.Y] = stone;
                }
                
                _player = new Player(deserializedProduct.Player.X, deserializedProduct.Player.Y);
                _field[_player.X,_player.Y] = _player;
            }
        }
    }
}