using System.Threading.Tasks;
using SpecialCaseLogick;

namespace ConsoleApplication
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var logick = new MainLogick();
            //logick.RunHandler();
            while (true)
            {
                logick.Run();
            }
        }
    }
}
