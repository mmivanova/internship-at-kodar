using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;
using Paint.Shapes;

namespace Paint.Helpers
{
    public static class LoadHelper
    {
        private const string XmlAndBinaryFileFilter = "XML file (*.xml)| *.xml|Binary file (*.bin)| *.bin";

        public static List<House> LoadFile()
        {
            var houses = new List<House>();

            var openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = XmlAndBinaryFileFilter;
            openFileDialog.ShowDialog();
            var fileName = openFileDialog.FileName;

            if (FileHelper.IsEmptyFileName(fileName))
                return new List<House>();

            var path = FileHelper.GetFilePath(fileName);
            using var fileStream = new FileStream(path, FileMode.Open);

            if (openFileDialog.FileName.EndsWith(".xml"))
            {
                var serializer = new XmlSerializer(houses.GetType());
                houses = (List<House>) serializer.Deserialize(fileStream);
            }
            else
            {
                houses = House.Deserialize(fileStream);
            }

            return houses;
        }
    }
}