using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadDemo
{ 
//{
//    #region 创建无参线程
//    public class NoParameter
//    {
//        static void Main(string[] args)
//        {
//            Thread thread1 = new Thread(new ThreadStart(Thread1));
//            //调用Start方法执行线程
//            thread1.Start();

//            Console.ReadKey();
//        }

//        static void Thread1()
//        {
//            Console.WriteLine("这是无参的方法");
//        }
//    }
//    #endregion


    #region 传参线程（实例方法作为参数）
    public class ParameterThread
    {
        static void Main(string[] args)
        {
            ThreadTest test = new ThreadTest();
            Thread thread = new Thread(new ThreadStart(test.MyThread));
            //启动线程
            thread.Start();
            Console.ReadKey();
        }
    }

    public class ThreadTest
    {
        public void MyThread()
        {
            Console.WriteLine("这是一个实例方法");
        }
    }
    #endregion





    #region 演化
    public class TheEvolutionThread
    {
        static void Main(string[] args)
        {
            //通过匿名委托创建
            Thread thread1 = new Thread(delegate () { Console.WriteLine("我是通过匿名委托创建的线程"); });
            thread1.Start();


            //通过Lambda表达式创建
            Thread thread2 = new Thread(() => Console.WriteLine("我是通过Lambda表达式创建的委托"));
            thread2.Start();
            Console.ReadKey();
        }
    }
    #endregion

}
