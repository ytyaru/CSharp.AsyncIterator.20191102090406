using System;
using System.Threading.Tasks;

namespace AsyncIterator
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await new Code0().Run();
            await new Code1().Run();
        }
    }
}
