using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;
using Paint.Shapes;

namespace Paint.Helpers
{
    public static class SaveHelper
    {
        private const string XmlAndBinaryFileFilter = "XML file (*.xml)| *.xml|Binary file (*.bin)| *.bin";

        public static void SaveFile(List<House> houses)
        {
            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = XmlAndBinaryFileFilter;
            saveFileDialog.ShowDialog();
            var fileName = saveFileDialog.FileName;

            if (FileHelper.IsEmptyFileName(fileName))
                return;

            var path = FileHelper.GetFilePath(fileName);
            var fileStream = new FileStream(path, FileMode.OpenOrCreate);

            if (saveFileDialog.FileName.EndsWith(".xml"))
            {
                var serializer = new XmlSerializer(typeof(List<House>));
                serializer.Serialize(fileStream, houses);
            }
            else
            {
                House.Serialize(fileStream, houses);
            }

            fileStream.Close();
        }
    }
}