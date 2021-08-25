using System.IO;
using System.Windows.Forms;

namespace Paint.Helpers
{
    public static class FileHelper
    {
        private const string JsonXmlAndBinaryFileFilter =
            "Json file (*.json)| *.json|XML file (*.xml)| *.xml|Binary file (*.bin)| *.bin";

        public static bool IsEmptyFileName(string fileName)
        {
            return fileName == string.Empty;
        }

        public static string GetFilePath(string fileName)
        {
            return Path.GetFullPath(fileName);
        }

        public static FileDialog ConfigureFileDialog(Action action)
        {
            FileDialog fileDialog;
            if (action.Equals(Action.Save))
            {
                fileDialog = new SaveFileDialog();
            }
            else
            {
                fileDialog = new OpenFileDialog();
            }

            fileDialog.Filter = JsonXmlAndBinaryFileFilter;
            fileDialog.ShowDialog();

            return fileDialog;
        }
    }
}