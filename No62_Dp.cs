using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode_62
{
    //static void Main(string[] args)
    //{
    //    var solution = new Solution();
    //    while (true)
    //    {
    //        int input = int.Parse(Console.ReadLine());
    //        int input2 = int.Parse(Console.ReadLine());
    //        //string input = Console.ReadLine();
    //        //string input2 = Console.ReadLine();
    //        //int[] intArr = input.Split(',').Select(s => int.Parse(s)).ToArray();
    //        //int input2 = int.Parse(Console.ReadLine());
    //        //var builder = new DataStructureBuilder();
    //        //int?[] data = new int?[] { 10, 5, 15, null, null, 6, 20 };
    //        //var tree = builder.BuildTree(data);
    //        //var listNode = builder.BuildListNode(new int[] { 1, 4, 5 });
    //        //int[] nums1 = new int[] { 2, 1, 4, 5, 3, 1, 1, 3 };
    //        //int[] nums2 = new int[] { 10, 15, 20 };
    //        //string input = "abc";
    //        //string input2 = "ahbgdc";                
    //        var res = solution.UniquePaths(input, input2);
    //        ConsoleX.WriteLine(res);
    //    }
    //}

    public class Solution
    {
        /// <summary>
        /// 动态规划优化空间，使用滚动数组，只维护一个一维数组
        /// 时间复杂度：O(mn)
        /// 空间复杂度：O(n)
        /// 还有一种排列组合的解法，不过没有理解，就不写了
        /// </summary>
        /// <param name="m"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public int UniquePaths(int m, int n)
        {
            int[] dp = new int[n];
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i == 0 || j == 0)
                        dp[j] = 1;
                    else
                        dp[j] += dp[j - 1];
                }
            }
            return dp[n - 1];
        }

        /// <summary>
        /// 动态规划，这个矩阵的可能性就是上面和左面可能性的和，算下来最右下角的值就是答案
        /// 时间复杂度：O(mn)
        /// 空间复杂度：O(mn)
        /// </summary>
        /// <param name="m"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        //public int UniquePaths(int m, int n)
        //{
        //    int[,] dp = new int[m, n];
        //    for (int i = 0; i < m; i++)
        //    {
        //        for (int j = 0; j < n; j++)
        //        {
        //            if (i == 0 || j == 0)
        //                dp[i, j] = 1;
        //            else
        //                dp[i, j] = dp[i - 1, j] + dp[i, j - 1];
        //        }
        //    }
        //    return dp[m - 1, n - 1];
        //}

        /// 排列组合
        /// 要走到右下角一定是向右走m-1步，向下走n-1步。也就是说总共走m-1+n-1 (m+n-2) 步，其中有m-1步是向右的。
        /// 那么这就是一个组合的问题，从m+n-2步中选择m-1步向右，总共有C(m+n-2, m-1)种排列方式。C(n, m) = n!/(m!*(n-m)!)
        /// 
        /// 要出去玩儿了，不实现了，哈哈哈
        //public int UniquePaths(int m, int n)
        //{
        //    return 0;
        //}
    }
}
