using System.Drawing;

namespace Paint.Shapes
{
    public static class House
    {
        public static void DrawHouse(Graphics graphics, Point mouseLocation)
        {
            var myRect = new MyRectangle(mouseLocation);
            graphics.DrawRectangle(new Pen(Color.White, 1.0f), myRect.Start.X, myRect.Start.Y, myRect.Width,
                myRect.Height);

            var triangle = new MyTriangle(myRect.Start, myRect.Width, mouseLocation.Y - myRect.Height);
            graphics.DrawPolygon(new Pen(Color.White, 1.0f), MyTriangle.GetTrianglePoints(triangle));
        }
    }
}