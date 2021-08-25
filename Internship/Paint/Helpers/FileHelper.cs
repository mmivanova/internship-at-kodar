using System.IO;
using System.Windows.Forms;

namespace Paint.Helpers
{
    public static class FileHelper
    {
        public static bool IsEmptyFileName(string fileName)
        {
            return fileName == string.Empty;
        }

        public static string GetFilePath(string fileName)
        {
            return Path.GetFullPath(fileName);
        }

        public static FileDialog ConfigureFileDialog(string action)
        {
            FileDialog fileDialog;
            if (action.Equals(Constants.SaveAction))
            {
                fileDialog = new SaveFileDialog();
            }
            else
            {
                fileDialog = new OpenFileDialog();
            }

            fileDialog.Filter = Constants.JsonXmlAndBinaryFileFilter;
            fileDialog.ShowDialog();

            return fileDialog;
        }
    }
}