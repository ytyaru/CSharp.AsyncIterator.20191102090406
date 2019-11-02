using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncIterator
{
    public class Code1
    {
        public async Task Run()
        {
            var cts = new CancellationTokenSource();
     
            var enumerable = GenerateAsync();
     
            var enumerator = enumerable.GetAsyncEnumerator(cts.Token);
     
            // キャンセル前なので値が取れる
            await enumerator.MoveNextAsync();
            Console.WriteLine(enumerator.Current);
     
            cts.Cancel();
     
            // キャンセルしたので止まる
            if (!await enumerator.MoveNextAsync())
                Console.WriteLine("終了");
        }
     
        // キャンセルするまで1秒ごとに値を生成する
        private async IAsyncEnumerable<int> GenerateAsync([EnumeratorCancellation] CancellationToken ct = default)
        {
            var i = 0;
            while (!ct.IsCancellationRequested)
            {
                yield return i;
                await Task.Delay(TimeSpan.FromSeconds(1));
                ++i;
            }
        }
    }
}
