using System.Collections.Generic;
using System.IO;
using Paint.Shapes;

namespace Paint.Helpers
{
    public static class SaveHelper
    {
        public static void SaveFile(List<House> houses)
        {
            var fileDialog = FileHelper.ConfigureFileDialog(Action.Save);
            var fileName = fileDialog.FileName;

            if (FileHelper.IsEmptyFileName(fileName))
                return;

            var path = FileHelper.GetFilePath(fileName);
            using var fileStream = new FileStream(path, FileMode.OpenOrCreate);

            Serializer.Serialize(houses, fileDialog, fileStream);
        }
    }
}