using System;

namespace BoulderDash
{
    public class Sand : Element
    {
        public Sand()
        { }

        public override void Draw()
        {
            Console.Write('·');
        }
    }
}