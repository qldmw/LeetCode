using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode_121
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
    //        int[] intArr = input.Split(',').Select(s => int.Parse(s)).ToArray();
    //        //int input = int.Parse(input2);                
    //        var res = solution.MaxProfit(intArr);
    //        Console.WriteLine(res);
    //        //ConsoleX.WriteLine(res);
    //    }
    //}

    public class Solution
    {

        /// <summary>
        /// 记录当前最低价，一次便利就可以完成
        /// 时间复杂度：O(n)
        /// 空间复杂度：O(1)
        /// 多动脑，其实就是思路问题。不过这种第一秒没有想出来的思路，可能真的是天生不擅长数组题吧？
        /// </summary>
        /// <param name="prices"></param>
        /// <returns></returns>
        public int MaxProfit(int[] prices)
        {
            int curMinPrice = int.MaxValue;
            int maxProfit = 0;
            for (int i = 0; i < prices.Length; i++)
            {
                if (prices[i] < curMinPrice)
                    curMinPrice = prices[i];
                else
                {
                    int profit = prices[i] - curMinPrice;
                    if (profit > maxProfit)
                        maxProfit = profit;
                }
            }
            return maxProfit;
        }

        /// <summary>
        /// 第一反应解（暴力求解）
        /// 时间复杂度：O(n²)，还是老朋友n(n + 1)/2次
        /// 空间复杂度：O(1)
        /// 之前还是用的数组记录给的位置的最大值。。。要多想想啊老哥
        /// </summary>
        /// <param name="prices"></param>
        /// <returns></returns>
        //public int MaxProfit(int[] prices)
        //{
        //    int maxProfit = 0;
        //    for (int i = 0; i < prices.Length; i ++)
        //    {
        //        for (int j = 0; j < i; j++)
        //        {
        //            int profit = prices[i] - prices[j];
        //            if (profit > maxProfit)
        //                maxProfit = profit;
        //        }
        //    }
        //    return maxProfit;
        //}
    }
}
