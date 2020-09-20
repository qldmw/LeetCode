using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LeetCode.Interview
{
    class Lock
    {
        /// <summary>
        /// Knowledge:
        /// 1.对于互斥锁，如果资源已经被占用，资源申请者只能进入睡眠状态。但是自旋锁不会引起调用者睡眠，如果自旋锁已经被别的执行单元保持，调用者
        ///     就一直循环在那里看是否该自旋锁的保持者已经释放了锁，“自旋”一词就是因此而得名。https://www.cnblogs.com/kuliuheng/p/4064680.html
        /// </summary>
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
                //自旋锁会保持线程，不会释放，所以当 运算时间 < 上下文切换时间 时，自旋锁就可以节省性能。

                //自旋锁还有一个优化，SpinWait,它会交出线程控制，避免CPU被耗尽。
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
