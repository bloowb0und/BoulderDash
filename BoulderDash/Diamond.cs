using System;

namespace BoulderDash
{
    public class Diamond : Element
    {
        public override int X { get; set; }
        public override int Y { get; set; }

        public Diamond(int x, int y)
        {
            X = x;
            Y = y;
        }
        public override void Draw()
        {
            Console.Write('D');
        }
    }
}