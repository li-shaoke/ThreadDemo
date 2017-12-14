using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallelDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            ParallelFor();
            Console.WriteLine("--------------------");
            ParallelForeach();


            Console.WriteLine("--------------------");
            ParallelInvoke();

            Console.ReadKey();
        }


        #region 对固定数目的任务提供循环迭代并行开发

        public static void ParallelFor()
        {
            Parallel.For(0, 10000, (i) => {
                
                Console.WriteLine(i);
            });
        }

        public static void ParallelForeach()
        {
            List<int> listInt = new List<int>
            {
                1,2,3,4,5
            };
            Parallel.ForEach(listInt,f => {
                Console.WriteLine(f);
            });
        }
        #endregion


        #region 对给定任务实现并行开发
        public static void ParallelInvoke()
        {
            Parallel.Invoke(() =>
            {
                Console.WriteLine("我是TaskA!");
            }, () =>
            {
                Console.WriteLine("我是TaskB!");
            });
        }
       
        #endregion
    }


}
