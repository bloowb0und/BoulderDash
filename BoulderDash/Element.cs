namespace BoulderDash
{
    public abstract class Element : IElement
    {
        public abstract int X { get; set; }
        public abstract int Y { get; set; }
        
        public abstract void Draw();
    }
}