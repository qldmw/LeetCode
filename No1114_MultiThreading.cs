using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace LeetCode_1114
{
    class No1114_MultiThreading
    {
        /// <summary>
        /// 使用 SpinWait 和 VolatileWrite，VolatileRead来解决
        /// 其实这里可以不用 Volatile 的方法，直接使用 int 就可以。MSDN对 Volatile 的介绍：在多处理器系统上， VolatileWrite 确保写入内存位置的值
        /// 立即对所有处理器都可见。 https://docs.microsoft.com/zh-cn/dotnet/api/system.threading.thread.volatilewrite?view=netcore-3.1
        /// </summary>
        public class Foo
        {
            /// <summary>
            /// Unsolved Question:什么时候应该使用 Volatile 方法
            /// </summary>
            private SpinWait _spinWait = new SpinWait();
            private int _continueCondition = 1;

            public Foo()
            {

            }
            public void First(Action printFirst)
            {
                printFirst();
                Thread.VolatileWrite(ref _continueCondition, 2);//写栅栏
            }

            public void Second(Action printSecond)
            {

                while (Thread.VolatileRead(ref _continueCondition) != 2)
                {
                    _spinWait.SpinOnce();
                }
                printSecond();
                Thread.VolatileWrite(ref _continueCondition, 3);//写栅栏
            }

            public void Third(Action printThird)
            {
                while (Thread.VolatileRead(ref _continueCondition) != 3)
                {
                    _spinWait.SpinOnce();
                }
                printThird();
                Thread.VolatileWrite(ref _continueCondition, 1);//写栅栏
            }
        }

        ///// <summary>
        ///// AutoResetEvent实现线程通信
        ///// </summary>
        //public class Foo
        //{
        //    private AutoResetEvent _second = new AutoResetEvent(false);
        //    private AutoResetEvent _three = new AutoResetEvent(false);

        //    public Foo()
        //    {

        //    }

        //    public void First(Action printFirst)
        //    {
        //        // printFirst() outputs "first". Do not change or remove this line.
        //        printFirst();
        //        _second.Set();
        //    }

        //    public void Second(Action printSecond)
        //    {
        //        _second.WaitOne();
        //        // printSecond() outputs "second". Do not change or remove this line.
        //        printSecond();
        //        _three.Set();
        //    }

        //    public void Third(Action printThird)
        //    {
        //        _three.WaitOne();
        //        // printThird() outputs "third". Do not change or remove this line.
        //        printThird();
        //    }
        //}

        ///// <summary>
        ///// 检查唯一变量，线程休眠
        ///// </summary>
        //public class Foo
        //{
        //    public Foo()
        //    {

        //    }

        //    //Unsolved Question:这里加了static就不能保证顺序输出了，不知道怎么回事，应该是一样的啊，不确定是不是OJ运行环境的问题。
        //    //private static int _signal = 0;
        //    private int _signal = 0;
        //    public void First(Action printFirst)
        //    {
        //        // printFirst() outputs "first". Do not change or remove this line.
        //        printFirst();
        //        _signal = 1;
        //    }

        //    public void Second(Action printSecond)
        //    {
        //        while (_signal != 1)
        //            Thread.Sleep(1);
        //        // printSecond() outputs "second". Do not change or remove this line.
        //        printSecond();
        //        _signal = 2;
        //    }

        //    public void Third(Action printThird)
        //    {
        //        while (_signal != 2)
        //            Thread.Sleep(1);
        //        // printThird() outputs "third". Do not change or remove this line.
        //        printThird();
        //    }
        //}
    }
}
