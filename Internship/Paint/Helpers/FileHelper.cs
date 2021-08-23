using System.IO;

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
    }
}