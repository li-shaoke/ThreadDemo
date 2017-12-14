using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ParallelOptionsDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            ParallelOptions options = new ParallelOptions
            {
                MaxDegreeOfParallelism = 2
            };

            ParallelFor(options);
            Console.WriteLine("--------------------");
            ParallelForeach(options);


            Console.WriteLine("--------------------");
            ParallelInvoke(options);

            //Console.WriteLine("--------------------");
            //CancellationToken();
            CancellationToken();
            Console.ReadKey();
        }


        #region 对固定数目的任务提供循环迭代并行开发

        public static void ParallelFor(ParallelOptions options)
        {
            Parallel.For(0, 5, options, (i) =>
            {
                Console.WriteLine(i);
            });
        }

        public static void ParallelForeach(ParallelOptions options)
        {
            List<int> listInt = new List<int>
            {
                1,2,3,4,5
            };
            Parallel.ForEach(listInt, options, f =>
            {
                Console.WriteLine(f);
            });
        }
        #endregion


        #region 对给定任务实现并行开发
        public static void ParallelInvoke(ParallelOptions options)
        {
            Parallel.Invoke(options, () =>
             {
                 Console.WriteLine("我是TaskA!");
             }, () =>
             {
                 Console.WriteLine("我是TaskB!");
             });
        }
        #endregion


        #region 取消线程

        ///// <summary>
        ///// 使用CancellationToken取消多线程执行，线程会取消，但是报异常
        ///// </summary>
        //public static void CancellationToken()
        //{
        //    var token = new CancellationTokenSource();
        //    ParallelOptions options = new ParallelOptions
        //    {
        //        CancellationToken = token.Token,
        //        MaxDegreeOfParallelism = System.Environment.ProcessorCount
        //    };
        //    Parallel.For(0, 1000000, options, (i) =>
        //    {

        //        if (options.CancellationToken.IsCancellationRequested)
        //        {
        //            Console.WriteLine("已知其已取消");
        //            return;
        //        }

        //        Console.WriteLine(i);
        //        if (i == 8888)
        //        {
        //            token.Cancel();
        //        }

        //    });

        //}

        /// <summary>
        /// 使用ParallelLoopState真正取消多线程执行，并且不报异常
        /// </summary>
        public static void CancellationToken()
        {
            var token = new CancellationTokenSource();
            ParallelOptions options = new ParallelOptions
            {
                CancellationToken = token.Token,
                MaxDegreeOfParallelism = System.Environment.ProcessorCount
            };
            Parallel.For(0, 1000000, options, (int i, ParallelLoopState loopState) =>
            {

                if (options.CancellationToken.IsCancellationRequested)
                {
                    Console.WriteLine("已知其已取消");
                    return;
                }

                Console.WriteLine(i);
                if (i == 8888)
                {
                    //token.Cancel();
                    loopState.Stop();
                }

            });





            //public static void CancellationToken()
            //{
            //    var token = new CancellationTokenSource();

            //    //异步执行condition的计算过程
            //    Task.Factory.StartNew(() =>
            //    {
            //        Thread.Sleep(3000);
            //        token.Cancel();
            //    });
            //    ParallelOptions options = new ParallelOptions
            //    {
            //        CancellationToken = token.Token,
            //        MaxDegreeOfParallelism = System.Environment.ProcessorCount
            //    };
            //    Task.Factory.StartNew(() => {

            //        Parallel.For(0, 1000000, options, (i) =>
            //        {

            //            if (options.CancellationToken.IsCancellationRequested)
            //            {
            //                Console.WriteLine("已知其已取消");
            //                return;
            //            }

            //            Console.WriteLine(i);
            //            //if (i == 8888)
            //            //{
            //            //    token.Cancel();
            //            //}

            //        });
            //    });



            //}
            #endregion
        }
    }
}
