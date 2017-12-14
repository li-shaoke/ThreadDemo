using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CancelTakenSourceDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //设置Task启动1s后自动取消
            CancellationTokenSource token = new CancellationTokenSource(1000);

            Task.Factory.StartNew(() => {
                for (int i = 0; i < 10000; i++)
                {
                    Console.WriteLine("running....");
                    if (token.Token.IsCancellationRequested)
                    {
                        Console.WriteLine("cancle         ...............");
                    }
                }
                
            },token.Token);

            Console.WriteLine("main         ");
            Console.ReadKey();
        }
    }
}
