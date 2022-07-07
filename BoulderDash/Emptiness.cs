using System;

namespace BoulderDash
{
    public class Emptiness : Element
    {
        public Emptiness()
        { }
        
        public override void Draw()
        {
            Console.Write(' ');
        }
    }
}