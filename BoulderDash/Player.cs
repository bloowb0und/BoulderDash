using System;

namespace BoulderDash
{
    public class Player : Element
    {
        public Player(int x, int y) : base(x, y)
        { }

        public override void Draw()
        {
            Console.Write('I');
        }

        public void MoveLeft()
        {
            this.X--;
        }
        
        public void MoveRight()
        {
            this.X++;
        }
        
        public void MoveUp()
        {
            this.Y--;
        }
        
        public void MoveDown()
        {
            this.Y++;
        }
    }
}