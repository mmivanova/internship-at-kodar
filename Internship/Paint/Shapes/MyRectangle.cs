using System;
using System.Drawing;

namespace Paint.Shapes
{
    public class MyRectangle : Shape
    {
        private Point End { get; }
        public Point Middle { get; }

        private MyRectangle(Point middle)
        {
            Middle = middle;
            Start = GetRandomStartPoint();
            End = CalculateEndPoint();
            Width = End.X - Start.X;
            Height = End.Y - Start.Y;
        }

        private Point CalculateEndPoint()
        {
            var x = 2 * Middle.X - Start.X;
            var y = 2 * Middle.Y - Start.Y;
            return new Point(x, y);
        }

        private Point GetRandomStartPoint()
        {
            var random = new Random();
            var x1 = random.Next(Middle.X - 100, Middle.X - 50);
            var y1 = random.Next(Middle.Y - 100, Middle.Y - 50);
            var start = new Point(x1, y1);
            return start;
        }

        public static MyRectangle GetMyRectangle(Point middle)
        {
            var rect = new MyRectangle(middle);
            return rect;
        }

        public override void Draw(Graphics graphics)
        {
            graphics.DrawRectangle(new Pen(Color.White, 1.0f), Start.X, Start.Y, Width, Height);
        }
    }
}