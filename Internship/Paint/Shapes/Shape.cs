using System;
using System.Drawing;

namespace Paint.Shapes
{
    [Serializable]
    public abstract class Shape
    {
        public Point Start { get; set; }
        public Point Middle { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public abstract void Draw(Graphics graphics);
    }
}