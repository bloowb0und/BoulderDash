using System;

namespace BoulderDash
{
    public class Diamond : Element
    {
        public Diamond(int x, int y) : base(x, y)
        { }
        
        public override void Draw()
        {
            Console.Write('D');
        }
    }
}