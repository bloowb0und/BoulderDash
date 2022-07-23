namespace BoulderDashClassLibrary.GameElements
{
    public class Player : Element
    {
        public Player(int x, int y) : base(x, y)
        { }

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