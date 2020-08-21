using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    class No322_Dp
    {
        //static void Main(string[] args)
        //{
        //    var solution = new Solution();
        //    while (true)
        //    {
        //        //int input = int.Parse(Console.ReadLine());
        //        //int input2 = int.Parse(Console.ReadLine());
        //        //string input = Console.ReadLine();
        //        //string input2 = Console.ReadLine();
        //        //int[] intArr = input.Split(',').Select(s => int.Parse(s)).ToArray();
        //        //int input2 = int.Parse(Console.ReadLine());
        //        //var builder = new DataStructureBuilder();
        //        //int?[] data = new int?[] { 1, 2, 3, 4, 5, null, 6, null, null, 7, 8 };
        //        //var tree = builder.BuildTree(data);
        //        //var listNode = builder.BuildListNode(new int[] { 1, 4, 5 });
        //        //int[][] arr = new int[3][] { new int[] { 1, 3, 1 }, new int[] { 1, 5, 1 }, new int[] { 4, 2, 1 } };
        //        //int[] nums1 = new int[] { 2, 1, 7, 5, 6, 4, 3 };
        //        //int[] nums1 = new int[] { 2, 1, 1, 5, 11, 5, 1, 7, 5, 6, 4, 3 };
        //        //int[] nums2 = new int[] { 10, 15, 20 };
        //        //string input = "adceb";
        //        //string input2 = "*a*b";
        //        //int[] coins = new int[] { 1, 2, 5 };//11
        //        int[] coins = new int[] { 186, 419, 83, 408 };//6249
        //        var res = solution.CoinChange(coins, 6249);
        //        ConsoleX.WriteLine(res);
        //    }
        //}

        public class Solution
        {
            /// <summary>
            /// 动态规划
            /// 设 coins 数组长度为 m, amount为 n
            /// 时间复杂度：O(mn)
            /// 空间复杂度：O(n)
            /// </summary>
            /// <param name="coins"></param>
            /// <param name="amount"></param>
            /// <returns></returns>
            public int CoinChange(int[] coins, int amount)
            {
                if (amount == 0)
                    return 0;

                //用 int.MaxValue 初始化之后，就不用把做 0 的判断了
                //int[] dp = Enumerable.Repeat(int.MaxValue, amount + 1).ToArray();
                //或者这个写法 Array.Fill(dp, int.MaxValue);
                int[] dp = new int[amount + 1];
                for (int i = 0; i < amount; i++)
                {
                    if (i == 0 || dp[i] != 0)
                    {
                        //用 long 隐式转换防止 int 越界
                        foreach (long coin in coins)
                        {
                            if (i + coin <= amount)
                            {
                                if (dp[i + coin] == 0)
                                    dp[i + coin] = dp[i] + 1;
                                else
                                    dp[i + coin] = Math.Min(dp[i] + 1, dp[i + coin]);
                            }
                        }
                    }
                }
                return dp[amount] == 0 ? -1 : dp[amount];
            }
        }
    }
}
