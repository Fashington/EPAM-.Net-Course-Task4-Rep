using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logick
{
    interface IWatcher
    {
        bool IsDirectoryExist(string path);
        string[] GetNewFiles(string extension);
    }
}
