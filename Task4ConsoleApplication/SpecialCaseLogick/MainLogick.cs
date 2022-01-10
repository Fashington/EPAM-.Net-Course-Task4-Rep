using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using DataAccess;
using DataAccess.DataOperations;
using Logick;
using System.Configuration;
using System.IO;
using System.Reflection;

namespace SpecialCaseLogick
{
    public class MainLogick : ILogick
    {
        static private string _path = $"{AppDomain.CurrentDomain.BaseDirectory}{ConfigurationManager.AppSettings.Get("InputDirectory")}";
        private CatalogWatcher _watcher = new CatalogWatcher(_path);
        private FileHandler _handler = new FileHandler();
        private DataOperations _operations = new DataOperations();

        public async Task Run()
        {
            string[] newFiles = _watcher.GetNewFiles(ConfigurationManager.AppSettings.Get("Extension"));

            if (newFiles.Length > 0)
            {
                var tasks = new List<Task>();

                foreach (var file in newFiles)
                {
                    string substring = _handler.GetSubstring(file, ConfigurationManager.AppSettings.Get("NameSeparator"));

                    var manager = _operations.AddManagerAsync(substring).Result;

                    tasks.Add(Task.Run(() =>
                    {

                        List<string[]> content = _handler.SeparateContent(_handler.GetContentAsync(file).Result, ConfigurationManager.AppSettings.Get("ContentSeparator"));

                        var ongoingTasks = new List<Task>();
                        foreach (var item in content)
                        {
                            ongoingTasks.Add(Task.Run(() => _operations.AddSaleAsync(manager, Convert.ToDateTime(item[0]).Date, item[1], item[2], Convert.ToDouble(item[3]))));
                        }

                        Task.WaitAll(ongoingTasks.ToArray());

                        File.Delete(file);
                    }));
                }

                Task.WaitAll(tasks.ToArray());
            }
        }
    }
}
