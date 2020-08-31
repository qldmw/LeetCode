using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LeetCode.Interview
{
    class Lock
    {
        public class Solution
        {
            private static int _count = 0;
            private static readonly object locker = new object();
            private static SpinLock spinLock = new SpinLock();

            private static void print()
            {
                //mutex
                //https://docs.microsoft.com/zh-cn/dotnet/api/system.threading.mutex?view=netcore-3.1

                //monitor
                //https://docs.microsoft.com/zh-cn/dotnet/api/system.threading.monitor?view=netcore-3.1

                //自旋锁
                //https://docs.microsoft.com/zh-cn/dotnet/api/system.threading.spinlock?view=netcore-3.1
                //值类型的轻量级锁，在锁的粒度较大且数量较大时(例如，链接列表中的每个节点的锁) 或锁保持时间始终极短时，自旋锁可能非常有利。
                //自旋锁会不断竞争，不像lock在竞争到一定次数后会休眠，所以不适用于长期占有锁的场景。
                bool locked = false;
                try
                {
                    spinLock.Enter(ref locked);
                    Console.WriteLine(_count++);
                }
                finally
                {
                    //证明锁的有效性
                    //if (_count % 2 == 0)
                    //    Thread.Sleep(30000);
                    if (locked)
                        spinLock.Exit();
                }

                //标准锁
                //lock (locker)
                //{
                //    Console.WriteLine(_count++);
                //}
            }
            public bool TaskSample()
            {
                Task t1 = new Task(() => { print(); });
                Task t2 = new Task(() => { print(); });
                t1.Start();
                t2.Start();

                return true;
            }
        }
    }
}
