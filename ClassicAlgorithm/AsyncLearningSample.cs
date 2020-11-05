using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LeetCode.ClassicAlgorithm
{
    class AsyncLearningSample
    {
        //static void Main(string[] args)
        //{
        //    var solution = new Solution();
        //    while (true)
        //    {
        //        //int input = int.Parse(Console.ReadLine());
        //        //int input2 = int.Parse(Console.ReadLine());
        //        //int input3 = int.Parse(Console.ReadLine());
        //        //string input = Console.ReadLine();
        //        //string input2 = Console.ReadLine();
        //        //int[] intArr = input.Split(',').Select(s => int.Parse(s)).ToArray();
        //        //int input2 = int.Parse(Console.ReadLine());
        //        //var builder = new DataStructureBuilder();
        //        //int?[] data = new int?[] { 1, 2, 3, 4, 5, null, 6, null, null, 7, 8 };
        //        //var tree = builder.BuildTree(data);
        //        //var listNode = builder.BuildListNode(new int[] { 1, 4, 5 });
        //        //int[][] arr = new int[3][] { new int[] { 1, 3, 1 }, new int[] { 1, 5, 1 }, new int[] { 4, 2, 1 } };
        //        //string input = "abcbefga";
        //        //string input2 = "dbefga";
        //        int[] nums = new int[] { 5, 7, 7, 8, 8, 10 };
        //        //int[] nums1 = new int[] { 10, 1, 2, 7, 6, 1, 5 };
        //        //IList<IList<int>> data = new List<IList<int>>()
        //        //{
        //        //    new List<int>() { 1, 3 },
        //        //    new List<int>() { 3, 0, 1 },
        //        //    new List<int>() { 2 },
        //        //    new List<int>() { 0 }

        //        //    //new List<int>() { 1 },
        //        //    //new List<int>() { 2 },
        //        //    //new List<int>() { 3 },
        //        //    //new List<int>() {  }
        //        //};
        //        var res = solution.TestForDiscardAsyncResult();
        //        ConsoleX.WriteLine(res);
        //    }
        //}

        public class Solution
        {
            public bool SyncSample()
            {
                bool res = false;
                //第一种，等待异步返回。会卡在这里等10秒。
                res = Cost().Result;
                //第二种，丢弃掉异步的返回。会卡在这里等10秒。（比较鸡肋，因为是丢弃的异步之后的结果，其实还是要等异步完成）
                _ = Cost().Result;
                //第三种，丢弃异步。会直接跳过异步返回，函数返回之后异步中的代码依然执行。
                _ = Cost();
                //第四种，同步的方式调用异步。会直接跳过异步返回，函数返回之后一部中的代码依然执行。
                Cost();
                return res;

                async Task<bool> Cost()
                {
                    bool res = await Task.Run(() => {
                        Console.WriteLine("In the task");
                        Thread.Sleep(10 * 1000);
                        Console.WriteLine("In the task, after 10 seconds");
                        return true;
                    });
                    return res;
                }
            }

            public async Task<bool> AsyncSample()
            {
                bool res = false;
                //第五种，使用 async 方法。
                //如果外层调用不使用 .Result,那么会直接返回一个 Task。
                //如果外层调用使用 .Result，就会等待结果返回。
                res = await Cost();
                //第六种，丢弃 await 方法结果。
                //如果外层调用不使用 .Result,那么会直接返回一个 Task。
                //如果外层调用使用 .Result，就会等待结果返回。
                _ = await Cost();
                //第七种，不使用 await 关键字，同步调用。
                //如果外层调用不使用 .Result，不等待，返回一个 Task<bool>，但是很奇怪我明明返回的是 bool 啊，是被包装了吗。
                //如果外层调用使用 .Result，不等待，返回一个 bool。
                Cost();
                //第八种，使用 .Result 等待内部的异步方法结果。
                //如果外层调用不使用 .Result，等待，返回一个 Task<bool>
                //如果外层调用使用 .Result，等待，返回一个 bool。
                _ = Cost().Result;
                return res;

                async Task<bool> Cost()
                {
                    bool res = await Task.Run(() => {
                        Console.WriteLine("In the task");
                        Thread.Sleep(10 * 1000);
                        Console.WriteLine("In the task, after 10 seconds");
                        return true;
                    });
                    return res;
                }
            }
        }
    }
}
