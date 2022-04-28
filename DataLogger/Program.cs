using System;
using System.Threading.Tasks;

namespace DataLogger
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Logger log = new Logger();
            while (true) 
            {

                await log.ProcessMessages();
            }

        }
    }
}
