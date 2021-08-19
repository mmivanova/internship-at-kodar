using System.Drawing;

namespace Paint.Shapes
{
    public class House : Shape
    {
        private Point Middle { get; }
        private MyRectangle Rectangle { get; }
        private MyTriangle Roof { get; }

        public House(Point mouseLocation)
        {
            Middle = mouseLocation;
            Rectangle = MyRectangle.GetMyRectangle(Middle);
            Roof = MyTriangle.GetMyTriangle(Rectangle);
        }
        
        public override void Draw(Graphics graphics)
        {
            Rectangle.Draw(graphics);
            Roof.Draw(graphics);
        }
    }
}