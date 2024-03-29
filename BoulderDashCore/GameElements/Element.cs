using System;
using BoulderDashClassLibrary.Interfaces;

namespace BoulderDashClassLibrary.GameElements
{
    public abstract class Element : IElement
    {
        public int X { get; set; }
        public int Y { get; set; }

        protected Element()
        {
        }

        protected Element(int x, int y)
        {
            X = x;
            Y = y;
        }
        
        public static event EventHandler DrawElement;

        public void OnDrawElement()
        {
            DrawElement?.Invoke(this, EventArgs.Empty);
        }
    }
}