using System.Collections.Generic;
using System.IO;
using BoulderDashClassLibrary.GameElements;
using BoulderDashClassLibrary.Interfaces;
using BoulderDashClassLibrary.Serialization;
using Newtonsoft.Json;

namespace BoulderDashClassLibrary
{
    public class Field : IField
    {
        private readonly List<List<Element>> _gameField;
        public int Width { get; }
        public int Height { get; }

        public Field(int width, int height)
        {
            _gameField = new List<List<Element>>();

            Width = width;
            Height = height;
            
            for (var i = 0; i < Height; i++)
            {
                _gameField.Add(new List<Element>());

                for (var j = 0; j < Width; j++)
                {
                    _gameField[i].Add(new Sand(j, i));
                }
            }
        }

        public List<Element> this[int x]
        {
            get => _gameField[x];
            set => _gameField[x] = value;
        }
        
        public Element this[int x, int y]
        {
            get => _gameField[y][x];
            set => _gameField[y][x] = value;
        }
        
        public void Draw()
        {
            for (var i = -1; i < _gameField[0].Count + 1; i++)
            {
                new Wall(i, -1).OnDrawElement();
            }
            new Edge().OnDrawElement();

            for (var i = 0; i < _gameField.Count; i++)
            {
                new Wall(-1, i).OnDrawElement();
                for (var j = 0; j < _gameField[i].Count; j++)
                {
                    _gameField[i][j].OnDrawElement();
                }
                new Wall(_gameField[i].Count, i).OnDrawElement();
                new Edge().OnDrawElement();
            }
            
            for (var i = -1; i < _gameField[0].Count + 1; i++)
            {
                new Wall(i, _gameField.Count).OnDrawElement();
            }
        }

        public void SaveToJson(string fileName, List<Diamond> diamonds, List<Stone> stones, Player player)
        {
            var serializer = new JsonSerializer
            {
                NullValueHandling = NullValueHandling.Ignore
            };

            using var sw = new StreamWriter($"levels/{fileName}");
            using JsonWriter writer = new JsonTextWriter(sw);
            serializer.Serialize(writer, new LevelSerialization(Width, Height, stones, diamonds, player));
        }
    }
}