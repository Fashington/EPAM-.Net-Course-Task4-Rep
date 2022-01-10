using System;
using System.IO;

namespace Logick
{
    public class CatalogWatcher : IWatcher
    {
        private string _path { get; set; }

        public CatalogWatcher(string path)
        {
            _path = path;
        }

        public bool IsDirectoryExist(string path)
        {
            if (Directory.Exists(path) == false)
                return false;
            else return true;
        }

        public string[] GetNewFiles(string extension)
        {
            if (IsDirectoryExist(_path) == false)
            {
                throw new Exception("Directory is not exist");
            }

            string[] files = Directory.GetFiles(_path, $"*{extension}");
            return files;
        }
    }
}
