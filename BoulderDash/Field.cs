using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace BoulderDash
{
    public class Field : IField
    {
        private readonly List<List<Element>> _gameField;
        public int Width { get; }
        public int Height { get; }

        public Field(int width, int height)
        {
            this._gameField = new List<List<Element>>();

            Width = width;
            Height = height;
            
            for (var i = 0; i < Height; i++)
            {
                this._gameField.Add(new List<Element>());

                for (var j = 0; j < Width; j++)
                {
                    this._gameField[i].Add(new Sand(i, j));
                }
            }
        }

        public List<Element> this[int x]
        {
            get => this._gameField[x];
            set => this._gameField[x] = value;
        }
        
        public Element this[int x, int y]
        {
            get => this._gameField[y][x];
            set => this._gameField[y][x] = value;
        }
        
        public void Draw()
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

        public void SaveToJson(string fileName, List<Diamond> diamonds, List<Stone> stones, Player player)
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.NullValueHandling = NullValueHandling.Ignore;
            
            using (StreamWriter sw = new StreamWriter($"levels/{fileName}"))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, new LevelSerialization(Width, Height, stones, diamonds, player));
            }
        }
    }
}