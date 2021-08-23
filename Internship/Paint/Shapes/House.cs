using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

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

        public House(Point start, Point middle)
        {
            Start = start;
            Middle = middle;
            Rectangle = MyRectangle.GetMyRectangle(Start, Middle);
            Roof = MyTriangle.GetMyTriangle(Rectangle);
            Width = Rectangle.Width;
            Height = Rectangle.Height + Roof.Height;
        }

        public static void Serialize(Stream fileStream, List<House> houses)
        {
            using var ms = new MemoryStream();
            using var writer = new BinaryWriter(ms);
            foreach (var house in houses)
            {
                writer.Write(house.Start.X);
                writer.Write(house.Start.Y);
                writer.Write(house.Middle.X);
                writer.Write(house.Middle.Y);
            }

            ms.WriteTo(fileStream);
        }

        public static List<House> Deserialize(Stream fileStream)
        {
            var houses = new List<House>();

            using var reader = new BinaryReader(fileStream);
            while (fileStream.Position < fileStream.Length)
            {
                var houseStartX = reader.ReadInt32();
                var houseStartY = reader.ReadInt32();
                var houseMiddleX = reader.ReadInt32();
                var houseMiddleY = reader.ReadInt32();

                var house = new House(new Point(houseStartX, houseStartY),
                    new Point(houseMiddleX, houseMiddleY));
                houses.Add(house);
            }

            return houses;
        }

        public override void Draw(Graphics graphics)
        {
            Rectangle.Draw(graphics);
            Roof.Draw(graphics);
        }
    }
}