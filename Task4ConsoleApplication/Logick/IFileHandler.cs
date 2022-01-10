using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logick
{
    interface IFileHandler
    {
        Task<List<string>> GetContentAsync(string filePath);
    }
}
