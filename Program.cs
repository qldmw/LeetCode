using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Extension;
using LeetCode.ExtensionFunction;
using System.Threading.Tasks;
using System.Threading;

namespace LeetCode
{
    class Program
    {
        static void Main(string[] args)
        {
            var solution = new Solution();
            while (true)
            {
                //int input = int.Parse(Console.ReadLine());
                //int input2 = int.Parse(Console.ReadLine());
                //string input = Console.ReadLine();
                //string input2 = Console.ReadLine();
                //int[] intArr = input.Split(',').Select(s => int.Parse(s)).ToArray();
                //int input2 = int.Parse(Console.ReadLine());
                //var builder = new DataStructureBuilder();
                //int?[] data = new int?[] { 1, 2, 3, 4, 5, null, 6, null, null, 7, 8 };
                //var tree = builder.BuildTree(data);
                //var listNode = builder.BuildListNode(new int[] { 1, 4, 5 });
                //int[][] arr = new int[3][] { new int[] { 1, 3, 1 }, new int[] { 1, 5, 1 }, new int[] { 4, 2, 1 } };
                //string input = "abcbefga";
                //string input2 = "dbefga";
                //int[] nums2 = new int[] { 2, 1, 1, 5, 11, 5, 1, 7, 5, 6, 4, 3 };
                //int[] nums3 = new int[] { 10, 15, 20 };
                //int[] nums1 = new int[] { 10, 9, 2, 5, 3, 7, 101, 18 };
                var res = solution.TaskSample();
                //ConsoleX.WriteLine(res);
            }
        }

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