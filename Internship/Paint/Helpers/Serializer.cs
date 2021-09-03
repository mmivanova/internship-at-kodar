using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;
using Paint.Shapes;

namespace Paint.Helpers
{
    public static class Serializer
    {
        public static void Serialize(List<House> houses, FileDialog fileDialog, FileStream fileStream)
        {
            var fileInfo = new FileInfo(fileDialog.FileName);

            switch (fileInfo.Extension)
            {
                case Extension.Json:
                    SerializeJson(fileStream, houses);
                    break;
                case Extension.Xml:
                    SerializeXml(fileStream, houses);
                    break;
                default:
                    SerializeBinary(fileStream, houses);
                    break;
            }
        }

        private static void SerializeJson(Stream fileStream, List<House> houses)
        {
            using var streamWriter = new StreamWriter(fileStream);
            streamWriter.Write("[");
            foreach (var house in houses)
            {
                streamWriter.Write(house + ",");
            }

            streamWriter.Write("]");
        }

        private static void SerializeXml(Stream fileStream, IReadOnlyCollection<House> houses)
        {
            var serializer = new XmlSerializer(typeof(List<House>));
            serializer.Serialize(fileStream, houses);
        }

        private static void SerializeBinary(Stream fileStream, List<House> houses)
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
    }
}