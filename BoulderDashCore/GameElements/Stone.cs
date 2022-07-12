using System;

namespace BoulderDash
{
    public class Stone : Element
    {
        public Stone(int x, int y) : base(x, y)
        { }

        public void Fall()
        {
            Y++;
        }
    }
}