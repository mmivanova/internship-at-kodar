using System;
using System.Drawing;

namespace Paint.Shapes
{
    [Serializable]
    public class House : Shape
    {
        public MyRectangle Rectangle { get; set; }
        public MyTriangle Roof { get; set; }

        public House()
        {
        }
        public House(Point mouseLocation)
        {
            Middle = mouseLocation;
            Rectangle = MyRectangle.GetMyRectangle(Middle);
            Roof = MyTriangle.GetMyTriangle(Rectangle);
            Start = Rectangle.Start;
            Width = Rectangle.Width;
            Height = Rectangle.Height + Roof.Height;
        }
        
        public override void Draw(Graphics graphics)
        {
            Rectangle.Draw(graphics);
            Roof.Draw(graphics);
        }
    }
}