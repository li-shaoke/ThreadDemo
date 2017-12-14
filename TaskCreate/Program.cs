using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskCreate
{
    class Program
    {
        /// <summary>
        /// 演示 Task的两种使用方式的状态
        /// 为什么MSDN推荐Task.Factory的写法的原因
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            var task1 = new Task(() =>
            {
                Run1();
            });

            var task2 = Task.Factory.StartNew(() =>
            {
                Run2();
            });

            Console.WriteLine("准备开始。。。");

            Console.WriteLine("task1的状态:{0}", task1.Status);
            Console.WriteLine("task2的状态:{0}", task2.Status);

            Console.WriteLine("task2的状态:{0}", task2.Status);
            task1.Start();
            Console.WriteLine("调用 start 1 之后:");
            Console.WriteLine("task1的状态:{0}", task1.Status);
            Console.WriteLine("task2的状态:{0}", task2.Status);

            Task.WaitAll(task1, task2);

            Console.WriteLine("两个Task结束之后：");
            Console.WriteLine("task1的状态:{0}", task1.Status);
            Console.WriteLine("task2的状态:{0}", task2.Status);

            Console.Read();

            //Created：默认初始化任务，“工厂创建”Task实例会直接跳过。
            //running:正在运行
            //WaitingToRun: 等待任务调度器分配线程给任务执行。
            //RanToCompletion：任务执行完毕。
        }

        static void Run1()
        {
            //Thread.Sleep(5000);
            Console.WriteLine("I am task 1 。。。");
        }

        static void Run2()
        {
            //Thread.Sleep(2000);
            Console.WriteLine("I am task 2 。。。");
        }
    }
}
