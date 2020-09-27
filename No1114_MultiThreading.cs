using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace LeetCode_1114
{
    class No1114_MultiThreading
    {
        /// <summary>
        /// CountdownEvent实现
        /// System.Threading.CountdownEvent 是在收到信号特定次数后取消阻止等待线程的同步基元。 CountdownEvent 适用于以下情况：
        /// 不得不先使用 ManualResetEvent 或 ManualResetEventSlim 并手动递减变量，然后再向事件发出信号。 例如，在分支/联接方案
        /// 中，可以只创建信号计数为 5 的 CountdownEvent，然后在线程池中启动五个工作项，并让每个工作项在完成时调用 Signal。 每
        /// 次调用 Signal 都会让信号计数递减 1。 在主线程上，Wait 调用一直阻止到信号计数为零。
        /// </summary>
        public class Foo
        {
            private CountdownEvent _second = new CountdownEvent(1);
            private CountdownEvent _third = new CountdownEvent(1);

            public Foo()
            {

            }

            public void First(Action printFirst)
            {
                // printFirst() outputs "first". Do not change or remove this line.
                printFirst();
                _second.Signal();
            }

            public void Second(Action printSecond)
            {
                _second.Wait();
                // printSecond() outputs "second". Do not change or remove this line.
                printSecond();
                _third.Signal();
            }

            public void Third(Action printThird)
            {
                _third.Wait();
                // printThird() outputs "third". Do not change or remove this line.
                printThird();
            }
        }

        ///// <summary>
        ///// Moniter实现
        ///// 这个实现可比那些 Thread.Sleep(1)的锁实现优雅多了！使用通知机制，而不是一直去轮询。
        ///// </summary>
        //public class Foo
        //{
        //    private object _locker = new object();
        //    private int _signal = 1;

        //    public Foo()
        //    {

        //    }

        //    public void First(Action printFirst)
        //    {
        //        //进入锁，锁定
        //        Monitor.Enter(_locker);
        //        //犯的错：在这里使用了 if,而不是 while，这意味着下次激活之后就直接执行下去了，忽略了信号到底正不正确。
        //        while (_signal != 1)
        //            //如果信号不对，就 wait，释放掉锁，等待其他线程使用 PulseAll唤醒，然后再次检查。
        //            Monitor.Wait(_locker);
        //        // printFirst() outputs "first". Do not change or remove this line.
        //        printFirst();
        //        _signal = 2;
        //        //通知其他线程，向等待获取该对象的锁的所有线程发出信号。 发送信号后，等待的线程会移动到就绪队列。 
        //        //如果调用的线程 PulseAll 释放锁定，则就绪队列中的下一个线程将获取该锁。
        //        Monitor.PulseAll(_locker);
        //        //释放锁，有点一个点，PulseAll必须要在 Exit之前，否则会抛错
        //        Monitor.Exit(_locker);
        //    }

        //    public void Second(Action printSecond)
        //    {
        //        Monitor.Enter(_locker);
        //        while (_signal != 2)
        //            Monitor.Wait(_locker);
        //        // printSecond() outputs "second". Do not change or remove this line.
        //        printSecond();
        //        _signal = 3;
        //        Monitor.PulseAll(_locker);
        //        Monitor.Exit(_locker);
        //    }

        //    public void Third(Action printThird)
        //    {
        //        Monitor.Enter(_locker);
        //        while (_signal != 3)
        //            Monitor.Wait(_locker);
        //        // printThird() outputs "third". Do not change or remove this line.
        //        printThird();
        //        Monitor.Exit(_locker);
        //    }
        //}

        ///// <summary>
        ///// Mutex实现
        ///// </summary>
        //public class Foo
        //{
        //    //这个 mutex 是为了使用而使用的，其实是不需要的
        //    private Mutex _mutex = new Mutex();
        //    private int _step = 1;

        //    public Foo()
        //    {

        //    }

        //    //Experience: Mutex 要 WaitOne() 和 ReleaseMutex()成对使用，WaitOne()可以理解成获得锁，然后 ReleaseMutex()可以理解是释放锁。mutex 的获得与释放都要在一个线程内，所以不能完成线程间的一个通信效果。
        //    public void First(Action printFirst)
        //    {
        //        while (_step != 1)
        //            Thread.Sleep(1);
        //        // printFirst() outputs "first". Do not change or remove this line.
        //        _mutex.WaitOne();
        //        printFirst();
        //        _step = 2;
        //        _mutex.ReleaseMutex();
        //    }

        //    public void Second(Action printSecond)
        //    {
        //        while (_step != 2)
        //            Thread.Sleep(1);
        //        // printSecond() outputs "second". Do not change or remove this line.
        //        _mutex.WaitOne();
        //        printSecond();
        //        _step = 3;
        //        _mutex.ReleaseMutex();
        //    }

        //    public void Third(Action printThird)
        //    {
        //        while (_step != 3)
        //            Thread.Sleep(1);
        //        // printThird() outputs "third". Do not change or remove this line.
        //        _mutex.WaitOne();
        //        printThird();
        //        _mutex.ReleaseMutex();
        //    }
        //}

        ///// <summary>
        ///// Barrier实现
        ///// Barrier可以认为是人满发车，要等所有巴士装满人了才会发车，否则就一直等待，所以有可能会有死锁，设计的时候可以设计加上 timeout
        ///// </summary>
        //public class Foo
        //{
        //    private Barrier _second = new Barrier(2);
        //    private Barrier _third = new Barrier(2);

        //    public Foo()
        //    {

        //    }

        //    public void First(Action printFirst)
        //    {
        //        // printFirst() outputs "first". Do not change or remove this line.
        //        printFirst();
        //        _second.SignalAndWait();
        //    }

        //    public void Second(Action printSecond)
        //    {
        //        _second.SignalAndWait();
        //        // printSecond() outputs "second". Do not change or remove this line.
        //        printSecond();
        //        _third.SignalAndWait();
        //    }

        //    public void Third(Action printThird)
        //    {
        //        _third.SignalAndWait();
        //        // printThird() outputs "third". Do not change or remove this line.
        //        printThird();
        //    }
        //}

        ///// <summary>
        ///// SemaphoreSlim实现
        ///// </summary>
        //public class Foo
        //{
        //    //信号量内部维护Int32变量CurrentCount，信号量为0的时候，在信号量等待的线程会阻塞
        //    private SemaphoreSlim _second = new SemaphoreSlim(0);
        //    private SemaphoreSlim _third = new SemaphoreSlim(0);

        //    public Foo()
        //    {

        //    }

        //    public void First(Action printFirst)
        //    {

        //        // printFirst() outputs "first". Do not change or remove this line.
        //        printFirst();
        //        //调用Release方法后，CurrentCount会自增1
        //        _second.Release();
        //    }

        //    public void Second(Action printSecond)
        //    {
        //        //线程在这里等待，等待信号量1释放后才能继续执行
        //        _second.Wait();
        //        // printSecond() outputs "second". Do not change or remove this line.
        //        printSecond();
        //        _third.Release();
        //    }

        //    public void Third(Action printThird)
        //    {
        //        _third.Wait();
        //        // printThird() outputs "third". Do not change or remove this line.
        //        printThird();
        //    }
        //}

        ///// <summary>
        ///// 使用 SpinWait 和 VolatileWrite，VolatileRead来解决
        ///// 其实这里可以不用 Volatile 的方法，直接使用 int 就可以。MSDN对 Volatile 的介绍：在多处理器系统上， VolatileWrite 确保写入内存位置的值
        ///// 立即对所有处理器都可见。 https://docs.microsoft.com/zh-cn/dotnet/api/system.threading.thread.volatilewrite?view=netcore-3.1
        ///// </summary>
        //public class Foo
        //{
        //    /// <summary>
        //    /// Unsolved Question:什么时候应该使用 Volatile 方法
        //    /// </summary>
        //    private SpinWait _spinWait = new SpinWait();
        //    private int _continueCondition = 1;

        //    public Foo()
        //    {

        //    }
        //    public void First(Action printFirst)
        //    {
        //        printFirst();
        //        Thread.VolatileWrite(ref _continueCondition, 2);//写栅栏
        //    }

        //    public void Second(Action printSecond)
        //    {

        //        while (Thread.VolatileRead(ref _continueCondition) != 2)
        //        {
        //            _spinWait.SpinOnce();
        //        }
        //        printSecond();
        //        Thread.VolatileWrite(ref _continueCondition, 3);//写栅栏
        //    }

        //    public void Third(Action printThird)
        //    {
        //        while (Thread.VolatileRead(ref _continueCondition) != 3)
        //        {
        //            _spinWait.SpinOnce();
        //        }
        //        printThird();
        //        Thread.VolatileWrite(ref _continueCondition, 1);//写栅栏
        //    }
        //}

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
        ///// ManualResetEvent实现
        ///// </summary>
        //public class Foo
        //{
        //    private ManualResetEvent _mre = new ManualResetEvent(false);
        //    private bool _isSecondExcuted = false;

        //    public Foo()
        //    {

        //    }

        //    //ManualResetEvent还没有放开，所有有等待的都会锁住，所以 first 会先执行。执行完之后放开锁定
        //    public void First(Action printFirst)
        //    {
        //        // printFirst() outputs "first". Do not change or remove this line.
        //        printFirst();
        //        _mre.Set();
        //    }

        //    //放开锁定之后 second 获得到信号，开始执行。然后把标记 second 执行过了(_isSecondExcuted = true)
        //    public void Second(Action printSecond)
        //    {
        //        _mre.WaitOne();
        //        // printSecond() outputs "second". Do not change or remove this line.
        //        printSecond();
        //        _isSecondExcuted = true;
        //        //这里的 Reset 代表再次返回锁定状态，其实这里不应该用，强行使用一下，用于学习
        //        _mre.Reset();
        //        _mre.Set();
        //    }

        //    public void Third(Action printThird)
        //    {
        //        while (!_isSecondExcuted && _mre.WaitOne())
        //            Thread.Sleep(1);
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

        //    //Solved Question:这里加了static就不能保证顺序输出了，为什么呢？找到答案了，因为 class 可以用千万个， static 字段永远只有一个，再次 new 一个 class, static字段还是原来那个。所以要在在 Third()方法里把 _signal 重置为 0才能AC（已经试验过了）。
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
