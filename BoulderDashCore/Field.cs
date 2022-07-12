using System;
using System.Collections.Generic;
using System.IO;
using BoulderDashClassLibrary;
using Newtonsoft.Json;

namespace BoulderDash
{
    public class Field : IField
    {
        public readonly List<List<Element>> GameField;
        public int Width { get; }
        public int Height { get; }

        public Field(int width, int height)
        {
            this.GameField = new List<List<Element>>();

            Width = width;
            Height = height;
            
            for (var i = 0; i < Height; i++)
            {
                this.GameField.Add(new List<Element>());

                for (var j = 0; j < Width; j++)
                {
                    this.GameField[i].Add(new Sand(j, i));
                }
            }
        }

        public List<Element> this[int x]
        {
            get => this.GameField[x];
            set => this.GameField[x] = value;
        }
        
        public Element this[int x, int y]
        {
            get => this.GameField[y][x];
            set => this.GameField[y][x] = value;
        }
        
        public void Draw()
        {
            for (var i = -1; i < this.GameField[0].Count + 1; i++)
            {
                new Wall(i, -1).OnDrawElement();
            }
            new Edge().OnDrawElement();

            for (var i = 0; i < this.GameField.Count; i++)
            {
                new Wall(-1, i).OnDrawElement();
                for (var j = 0; j < this.GameField[i].Count; j++)
                {
                    this.GameField[i][j].OnDrawElement();
                }
                new Wall(this.GameField[i].Count, i).OnDrawElement();
                new Edge().OnDrawElement();
            }
            
            for (var i = -1; i < this.GameField[0].Count + 1; i++)
            {
                new Wall(i, this.GameField.Count).OnDrawElement();
            }
        }

        public void SaveToJson(string fileName, List<Diamond> diamonds, List<Stone> stones, Player player)
        {
            var serializer = new JsonSerializer
            {
                NullValueHandling = NullValueHandling.Ignore
            };

            using (StreamWriter sw = new StreamWriter($"levels/{fileName}"))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, new LevelSerialization(Width, Height, stones, diamonds, player));
            }
        }
    }
}