using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Paint.Shapes;

namespace Paint.Helpers
{
    public static class Deserializer
    {
        public static List<House> Deserialize(FileDialog fileDialog, FileStream fileStream)
        {
            var fileInfo = new FileInfo(fileDialog.FileName);

            var houses = fileInfo.Extension switch
            {
                Extension.Json => DeserializeJson(fileStream),
                Extension.Xml => DeserializeXml(fileStream),
                _ => DeserializeBinary(fileStream)
            };

            return houses;
        }

        private static List<House> DeserializeJson(Stream fileStream)
        {
            using var streamReader = new StreamReader(fileStream);
            var json = streamReader.ReadToEnd();
            var parameters = JsonConvert.DeserializeObject<List<StartMiddlePair>>(json);

            var houses = Transformer.Cast(parameters);

            return houses;
        }

        private static List<House> DeserializeXml(Stream fileStream)
        {
            var houses = new List<House>();

            var serializer = new XmlSerializer(houses.GetType());
            var parameters = (List<House>) serializer.Deserialize(fileStream);

            houses = Transformer.Cast(parameters);

            return houses;
        }

        private static List<House> DeserializeBinary(Stream fileStream)
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
    }
}