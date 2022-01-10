using System;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace Logick
{
    public class FileHandler : IFileHandler
    {
        public string GetSubstring(string filePath, string separator)
        {
            if (new FileInfo(filePath).Exists == false)
            {
                throw new Exception($"{filePath}\nFile is not exist");
            }

            string substring = Path.GetFileName(filePath).Substring(0, Path.GetFileName(filePath).IndexOf(separator));
            return substring;
        }

        public async Task<List<string>> GetContentAsync(string filePath)
        {
            if (new FileInfo(filePath).Exists == false)
            {
                throw new Exception("File is not exist");
            }
            else if (new FileInfo(filePath).Length == 0)
            {
                throw new Exception("File is empty");
            }

            List<string> content = new List<string>();

            string line;

            using (StreamReader reader = new StreamReader(filePath, System.Text.Encoding.Default))
            {
                while ((line = await reader.ReadLineAsync()) != null)
                {
                    content.Add(new string(line));
                }
            }

            return content;
        }

        public List<string[]> SeparateContent(List<string> content, string separator)
        {
            if (content.Any() == false)
            {
                throw new Exception("List is empty");
            }

            List<string[]> separatedContent = new List<string[]>();

            foreach (string line in content)
            {
                separatedContent.Add(line.Split(separator));
            }

            return separatedContent;
        }
    }
}
