using System;

namespace BoulderDash
{
    public class Stone : Element
    {
        public override int X { get; set; }
        public override int Y { get; set; }

        public Stone(int x, int y)
        {
            X = x;
            Y = y;
        }
        public override void Draw()
        {
            Console.Write('o');
        }

        public void Fall()
        {
            Y--;
        }
    }
}