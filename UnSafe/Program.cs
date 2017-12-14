using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnSafe
{

    /// <summary>
    /// 演示 List<T> 不是线程安全集合
    /// </summary>
    class Program
    {
        static int maxNum = 1000000;

        static List<long> list = new List<long>();
        static void Main(string[] args)
        {
            NormalCompute();
            Console.Read();

        }

        private static void NormalCompute()
        {

            Parallel.For(0, maxNum, (i) => {
                //Console.WriteLine(i);
                list.Add(i);
            });

        }
    }
}
