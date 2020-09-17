using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace LeetCode_1114
{
    class No1114_MultiThreading
    {
        /// <summary>
        /// 检查唯一变量，线程休眠
        /// </summary>
        public class Foo
        {

            public Foo()
            {

            }

            //Unsolved Question:这里加了static就不能保证顺序输出了，不知道怎么回事，应该是一样的啊，不确定是不是OJ运行环境的问题。
            //private static int _signal = 0;
            private int _signal = 0;
            public void First(Action printFirst)
            {
                // printFirst() outputs "first". Do not change or remove this line.
                printFirst();
                _signal = 1;
            }

            public void Second(Action printSecond)
            {
                while (_signal != 1)
                    Thread.Sleep(1);
                // printSecond() outputs "second". Do not change or remove this line.
                printSecond();
                _signal = 2;
            }

            public void Third(Action printThird)
            {
                while (_signal != 2)
                    Thread.Sleep(1);
                // printThird() outputs "third". Do not change or remove this line.
                printThird();
            }
        }
    }
}
