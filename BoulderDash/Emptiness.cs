using System;

namespace BoulderDash
{
    public class Emptiness : Element
    {
        public override int X { get; set; }
        public override int Y { get; set; }

        public Emptiness(int x, int y)
        {
            X = x;
            Y = y;
        }
        
        public override void Draw()
        {
            Console.Write(' ');
        }
    }
}