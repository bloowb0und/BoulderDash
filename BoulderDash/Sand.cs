using System;

namespace BoulderDash
{
    public class Sand : Element
    {
        public Sand(int x, int y) : base(x, y)
        { }

        public override void Draw()
        {
            Console.Write('·');
        }
    }
}