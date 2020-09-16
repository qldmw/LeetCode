using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode_L19
{
    //static void Main(string[] args)
    //{
    //    var solution = new Solution();
    //    while (true)
    //    {
    //        //int input = int.Parse(Console.ReadLine());
    //        //int input2 = int.Parse(Console.ReadLine());
    //        //int input3 = int.Parse(Console.ReadLine());
    //        string input = Console.ReadLine();
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
    //        var res = solution.MinimumOperations(input);
    //        ConsoleX.WriteLine(res);
    //    }
    //}

    public class Solution
    {
        /// <summary>
        /// 动态规划优化，压缩的状态空间。复习的时候最好还是用没有优化空间的版本，那个版本思路更容易理解，更清晰
        /// 时间复杂度：O(n)
        /// 空间复杂度：O(1)，压缩状态到了一个只需要 3 个长度的数组
        /// </summary>
        /// <param name="leaves"></param>
        /// <returns></returns>
        public int MinimumOperations(string leaves)
        {
            //压缩多维dp，因为只需要使用前一个状态
            int[] dp = new int[3];
            for (int i = 0; i < leaves.Length; i++)
            {
                int pre0 = dp[0];
                int pre1 = dp[1];
                int pre2 = dp[2];

                //维护第一维，如果为 y，就要花一步把这个 y 变为 r
                if (i == 0)
                    dp[0] = leaves[0] == 'r' ? 0 : 1;
                else
                    dp[0] = pre0 + (leaves[i] == 'r' ? 0 : 1);

                //维护第二维，要从第二个才开始
                if (i > 0)
                    if (i == 1)
                        dp[1] = pre0 + (leaves[i] == 'y' ? 0 : 1);
                    else
                        dp[1] = Math.Min(pre1, pre0) + (leaves[i] == 'y' ? 0 : 1);

                //维护第三维，要从第三个才开始
                if (i > 1)
                    if (i == 2)
                        dp[2] = pre1 + (leaves[i] == 'r' ? 0 : 1);
                    else
                        dp[2] = Math.Min(pre2, pre1) + (leaves[i] == 'r' ? 0 : 1);
            }
            return dp[2];
        }

        ///// <summary>
        ///// 多维动态规划，目前做一维简单的动态规划还可以，一复杂点就开始摸不清了 o(╥﹏╥)o
        ///// 时间复杂度：O(n)
        ///// 空间复杂度：O(n),具体来说是 3n
        ///// </summary>
        ///// <param name="leaves"></param>
        ///// <returns></returns>
        //public int MinimumOperations(string leaves)
        //{
        //    //多维dp，dp[0,]表示全部为 r 的状态，dp[1,]表示全部为 ry 的状态，dp[2,]表示全部为 ryr 的状态。
        //    int[,] dp = new int[3, leaves.Length];
        //    //针对二三维的边界，提前填充数据
        //    dp[1, 0] = dp[2, 0] = dp[2, 1] = int.MaxValue;
        //    for (int i = 0; i < leaves.Length; i++)
        //    {
        //        //维护第一维，如果为 y，就要花一步把这个 y 变为 r
        //        if (i == 0)
        //            dp[0, i] = leaves[i] == 'r' ? 0 : 1;
        //        else
        //            dp[0, i] = leaves[i] == 'r' ? dp[0, i - 1] : dp[0, i - 1] + 1;

        //        //维护第二维，要从第二个才开始
        //        if (i > 0)
        //            dp[1, i] = Math.Min(dp[1, i - 1], dp[0, i - 1]) + (leaves[i] == 'y' ? 0 : 1);

        //        //维护第三维，要从第三个才开始
        //        if (i > 1)
        //            dp[2, i] = Math.Min(dp[2, i - 1], dp[1, i - 1]) + (leaves[i] == 'r' ? 0 : 1);

        //    }
        //    return dp[2, leaves.Length - 1];
        //}
    }
}
