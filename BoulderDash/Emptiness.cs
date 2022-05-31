using System;

namespace BoulderDash
{
    public class Emptiness : Element
    {
        public Emptiness(int x, int y) : base(x, y)
        { }
        
        public override void Draw()
        {
            Console.Write(' ');
        }
    }
}