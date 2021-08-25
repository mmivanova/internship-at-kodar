using System;
using System.Drawing;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Paint.Shapes
{
    [Serializable]
    public class House : Shape
    {
        [XmlIgnore] [JsonIgnore] public MyRectangle Rectangle { get; set; }

        [XmlIgnore] [JsonIgnore] public MyTriangle Roof { get; set; }

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

        public House(Point start, Point middle)
        {
            Start = start;
            Middle = middle;
            Rectangle = MyRectangle.GetMyRectangle(Start, Middle);
            Roof = MyTriangle.GetMyTriangle(Rectangle);
            Width = Rectangle.Width;
            Height = Rectangle.Height + Roof.Height;
        }

        public override void Draw(Graphics graphics)
        {
            Rectangle.Draw(graphics);
            Roof.Draw(graphics);
        }

        public override string ToString()
        {
            var json = JsonConvert.SerializeObject(this, Formatting.Indented);
            return json;
        }
    }
}