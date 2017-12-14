using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadAbort
{
    class Program
    {
        /// <summary>
        /// 古老写法，但是貌似多语言通用
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            var thread = new Thread(
                new ThreadStart(() =>
                {

                    while (true)
                    {
                        Thread.Sleep(100);
                    }
                }));

            thread.IsBackground = true;
            thread.Start();


            thread.Abort();//调用Thread.Abort方法试图强制终止thread线程

            Console.WriteLine("线程状态是：" + thread.ThreadState.ToString());

            //在这里写了个循环来做检查，看线程thread是否已经真正停止。
            while (thread.ThreadState != ThreadState.Aborted)
            {
                //当调用Abort方法后，如果thread线程的状态不为Aborted，主线程就一直在这里做循环，直到thread线程的状态变为Aborted为止
                Thread.Sleep(100);
            }

            //阻塞主线程直到thread线程终止为止
            //thread.Join();

            Console.WriteLine("线程状态是：" + thread.ThreadState.ToString());

            //当跳出上面的循环后就表示我们启动的线程thread已经完全终止了
            Console.ReadKey();
        }
    }
}
