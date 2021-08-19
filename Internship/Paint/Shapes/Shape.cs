using System.Drawing;

namespace Paint.Shapes
{
    public abstract class Shape
    {
        public Point Start { get; protected set; }
        public int Width { get; protected set; }
        public int Height { get; protected set; }
    }
}