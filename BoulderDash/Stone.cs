using System;

namespace BoulderDash
{
    public class Stone : Element
    {
        public Stone(int x, int y) : base(x, y)
        { }
        
        public override void Draw()
        {
            Console.Write('o');
        }

        public void Fall()
        {
            Y++;
        }
    }
}