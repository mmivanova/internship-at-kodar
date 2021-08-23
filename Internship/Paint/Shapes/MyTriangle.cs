using System;
using System.Drawing;

namespace Paint.Shapes
{
    [Serializable]
    public class MyTriangle : Shape
    {
        public MyTriangle()
        {
        }

        private MyTriangle(MyRectangle rect)
        {
            Start = rect.Start;
            Width = rect.Width;
            Height = rect.Middle.Y - rect.Height;
        }

        private Point GetApex()
        {
            var x = Start.X + (Width / 2);
            var y = Height;

            return new Point(x, y);
        }

        internal static Point[] GetTrianglePoints(MyTriangle triangle)
        {
            var endPoint = new Point(triangle.Start.X + triangle.Width, triangle.Start.Y);
            var points = new[]
            {
                triangle.Start, triangle.GetApex(), endPoint
            };

            return points;
        }

        public static MyTriangle GetMyTriangle(MyRectangle rect)
        {
            var triangle = new MyTriangle(rect);
            return triangle;
        }

        public override void Draw(Graphics graphics)
        {
            graphics.DrawPolygon(new Pen(Color.White, 1.0f), GetTrianglePoints(this));
        }
    }
}