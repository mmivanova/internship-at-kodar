using System.Collections.Generic;
using System.IO;
using Paint.Shapes;

namespace Paint.Helpers
{
    public static class LoadHelper
    {
        public static List<House> LoadFile()
        {
            var fileDialog = FileHelper.ConfigureFileDialog(Constants.LoadAction);
            var fileName = fileDialog.FileName;

            if (FileHelper.IsEmptyFileName(fileName))
                return new List<House>();

            var path = FileHelper.GetFilePath(fileName);
            using var fileStream = new FileStream(path, FileMode.Open);

            var houses = Deserializer.Deserialize(fileDialog, fileStream);

            return houses;
        }
    }
}