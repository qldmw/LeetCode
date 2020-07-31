using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode_08_01
{
    //static void Main(string[] args)
    //{
    //    var solution = new Solution();
    //    while (true)
    //    {
    //        int input = int.Parse(Console.ReadLine());
    //        //int input2 = int.Parse(Console.ReadLine());
    //        //string input = Console.ReadLine();
    //        //string input2 = Console.ReadLine();
    //        //int[] intArr = input.Split(',').Select(s => int.Parse(s)).ToArray();
    //        //int input2 = int.Parse(Console.ReadLine());
    //        //var builder = new DataStructureBuilder();
    //        //int?[] data = new int?[] { 10, 5, 15, null, null, 6, 20 };
    //        //var tree = builder.BuildTree(data);
    //        //var listNode = builder.BuildListNode(new int[] { 1, 4, 5 });
    //        //int[] nums1 = new int[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 };
    //        //int[] nums2 = new int[] { 10, 15, 20 };
    //        //string input = "abc";
    //        //string input2 = "ahbgdc";                
    //        var res = solution.WaysToStep(input);
    //        ConsoleX.WriteLine(res);
    //    }
    //}

    /// <summary>
    /// REVIEW
    /// 2020.07.31: 典型的动态规划，上的台阶由三种可能性构成，所以就可以推出当前的解就是前三步的和值。要注意的就是有可能会超过int最大值，需要使用long。
    /// </summary>

    public class Solution
    {
        /// <summary>
        /// 动态规划
        /// 时间复杂度：O(n)
        /// 空间复杂度：O(1)
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int WaysToStep(int n)
        {
            long[] dp = new long[3] { 1, 2, 4 };
            if (n <= 3)
                return (int)dp[n - 1];

            for (int i = 3; i < n; i++)
            {
                long sum = (dp[0] + dp[1] + dp[2]) % 1000000007;
                dp[0] = dp[1];
                dp[1] = dp[2];
                dp[2] = sum;
            }
            return (int)dp[2];
        }
    }
}
