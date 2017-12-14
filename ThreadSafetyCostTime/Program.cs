using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadSafetyCostTime
{
    /// <summary>
    /// 使用线程安全集合  和 不使用线程安全集合的 耗费时间比较
    /// </summary>
    class Program
    {
        static int maxNum = 10000000;

        static List<long> list = new List<long>();

        static ConcurrentQueue<long> safeList = new ConcurrentQueue<long>();

        static void Main(string[] args)
        {
            Thread.Sleep(3000);

            Stopwatch sp = new Stopwatch();
            sp.Start();
            ParallelCompute_1();
            sp.Stop();
            Console.WriteLine(String.Format("耗时：{0}", sp.ElapsedMilliseconds));

            Console.WriteLine("-----------------------------");

            sp.Restart();
            NormalCompute();
            sp.Stop();
            Console.WriteLine(String.Format("耗时：{0}", sp.ElapsedMilliseconds));

            Console.Read();

        }

        private static void NormalCompute()
        {

            Parallel.For(0, maxNum, (i) => {
                lock (list)
                {
                    list.Add(i);
                }
            });

        }

        private static void ParallelCompute_1()
        {
            Parallel.For(0, maxNum, (i) =>
            {
                safeList.Enqueue(i);
            });

        }

    }
}
