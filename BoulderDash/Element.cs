namespace BoulderDash
{
    public abstract class Element : IElement
    {
        public int X { get; set; }
        public int Y { get; set; }

        protected Element(int x, int y)
        {
            X = x;
            Y = y;
        }

        public abstract void Draw();
    }
}