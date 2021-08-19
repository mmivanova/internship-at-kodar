using System.Drawing;

namespace Paint.Shapes
{
    public class MyTriangle : Shape
    {
        public MyTriangle(Point start, int width, int height)
        {
            Start = start;
            Width = width;
            Height = height;
        }

        private Point GetApex()
        {
            var x = Start.X + (Width / 2);
            var y = Height;

            return new Point(x, y);
        }

        public static Point[] GetTrianglePoints(MyTriangle triangle)
        {
            var endPoint = new Point(triangle.Start.X + triangle.Width, triangle.Start.Y);
            var points = new[]
            {
                triangle.Start, triangle.GetApex(), endPoint
            };

            return points;
        }
    }
}