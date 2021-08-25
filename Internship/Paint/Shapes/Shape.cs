using System;
using System.Drawing;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Paint.Shapes
{
    [Serializable]
    public abstract class Shape
    {
        public Point Start { get; set; }
        public Point Middle { get; set; }

        [XmlIgnore] [JsonIgnore] public int Width { get; set; }
        [XmlIgnore] [JsonIgnore] public int Height { get; set; }

        public abstract void Draw(Graphics graphics);
    }
}