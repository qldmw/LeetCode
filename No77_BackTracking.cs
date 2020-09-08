using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode_77
{
    //static void Main(string[] args)
    //{
    //    var solution = new Solution();
    //    while (true)
    //    {
    //        int input = int.Parse(Console.ReadLine());
    //        int input2 = int.Parse(Console.ReadLine());
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
    //        //int[] nums2 = new int[] { 2, 1, 1, 5, 11, 5, 1, 7, 5, 6, 4, 3 };
    //        //int[] nums3 = new int[] { 10, 15, 20 };
    //        //int[] nums1 = new int[] { 1, 1, 1, 2, 2, 3 };
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
    //        var res = solution.Combine(input, input2);
    //        ConsoleX.WriteLine(res);
    //    }
    //}

    public class Solution
    {
        /// <summary>
        /// 回溯法，辅以适当减枝。回溯算法的基本思想是：从一条路往前走，能进则进，不能进则退回来，换一条路再试。
        /// 时间复杂度：O(C k n),标准的组合
        /// 空间复杂度：O(k),递归深度最多为k
        /// </summary>
        /// <param name="n"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public IList<IList<int>> Combine(int n, int k)
        {
            IList<IList<int>> res = new List<IList<int>>();
            BackTracking(new List<int>(), 0);
            return res;

            void BackTracking(List<int> trace, int last)
            {
                //如果剩下的数字不足以完成组合，就直接返回
                if (n - last < k - trace.Count)
                    return;
                if (trace.Count == k)
                {
                    res.Add(trace);
                    return;
                }
                for (int i = last + 1; i <= n; i++)
                {
                    var temp = trace.ToList();
                    temp.Add(i);
                    BackTracking(temp, i);
                }
            }
        }
    }
}
