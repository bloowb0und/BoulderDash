using System.Collections.Generic;

namespace BoulderDash
{
    public class LevelSerialization
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public List<Stone> Stones { get; set; }
        public List<Diamond> Diamonds { get; set; }
        public Player Player { get; set; }

        public LevelSerialization(int width, int height, List<Stone> stones, List<Diamond> diamonds, Player player)
        {
            Width = width;
            Height = height;
            Stones = stones;
            Diamonds = diamonds;
            Player = player;
        }
    }
}