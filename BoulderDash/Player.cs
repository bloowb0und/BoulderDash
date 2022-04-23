using System;

namespace BoulderDash
{
    public class Player : Element
    {
        public override int X { get; set; }
        public override int Y { get; set; }

        public Player(int x, int y)
        {
            X = x;
            Y = y;
        }

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