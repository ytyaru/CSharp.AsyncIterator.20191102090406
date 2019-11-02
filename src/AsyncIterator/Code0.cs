using System;
using System.Threading.Tasks; // Task
using System.Collections.Generic; // IAsyncEnumerable<T>

namespace AsyncIterator
{
    class Code0
    {
        public async Task Run()
        {
            await foreach(var x in GenerateAsync()) { Console.WriteLine($"{x}"); }
        }
        private async IAsyncEnumerable<int> GenerateAsync()
        {
            for(int i=0; i<10; i++) {
                yield return i;
                await Task.Delay(TimeSpan.FromSeconds(1));
            }
        }
    }
}
