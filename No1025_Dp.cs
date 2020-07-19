using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
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
    //        //int[] nums1 = new int[] { 1, 100, 1, 1, 1, 100, 1, 1, 100, 1 };                
    //        //int[] nums2 = new int[] { 10, 15, 20 };
    //        //string input = "abc";
    //        //string input2 = "ahbgdc";                
    //        var res = solution.DivisorGame(input);
    //        ConsoleX.WriteLine(res);
    //    }
    //}

    public class Solution
    {
        /// <summary>
        /// 动态规划
        /// 时间复杂度：O(n²)
        /// 空间复杂度：O(n)
        /// </summary>
        /// <param name="N"></param>
        /// <returns></returns>
        public bool DivisorGame(int N)
        {
            //解题思路：1.数字为2的时候，alice赢；数字为1的时候，alice输。
            //         2.设置一个dp数组来记录各个情况下的胜负关系。
            //         3.这个数字的约数设为x, 如果N - x在胜负关系数组里是false时，那就取走x个，让对方必输。
            if (N <= 1)
                return false;

            bool[] dp = new bool[N];
            dp[1] = true;//数字2的时候赢
            for (int i = 2; i < N; i++)
            {
                //这里 j < i 是因为规则说不能拿光
                for (int j = 1; j < i; j++)
                {
                    if (N % j == 0 && !dp[i - j])
                    {
                        dp[i] = true;
                        break;
                    }
                }
            }
            return dp[N - 1];
        }

        /// 在动态规划上总结的 归纳法
        /// 时间复杂度：O(1)
        /// 空间复杂度：O(1)
        /// 1、dp[0] 默认不可能，设置为 false；
        /// 2、dp[1] 的时候已经没法减了，也是false；
        /// 3、dp[2],dp[3] 从前面的测试用例已经知道结果；
        /// 4、从DP[4] 开始 遍历从1 ~i/2的数字中 满足“i 整除 x （即i%x == 0）”的数字中只要有一个的dp[i - x] 是false的，那就可以实现dp[i] = true，即alice取走x个金币，然后剩下的金币让对方去取就是个dp[i - x] 是false，就是把失败留给了对方；
        //public bool DivisorGame(int N)
        //{
        //    return N % 2 == 0;
        //}
    }
}
