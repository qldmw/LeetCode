using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode_122
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
        /// 贪心算法,理解题意对编程的降维打击,另得知了一个知识：贪心算法一般来说都是线性时间复杂度，常数空间复杂度。
        /// 时间复杂度：O(n)
        /// 空间复杂度：O(1)
        /// REDO，有个题解中用到的动态规划没有非常理解，但是感觉应该是挺好的一种思路，以后重新刷一次。
        /// </summary>
        /// <param name="prices"></param>
        /// <returns></returns>
        public int MaxProfit(int[] prices)
        {
            int maxProfit = 0;
            for (int i = 1; i < prices.Length; i++)
            {
                int profit = prices[i] - prices[i - 1];
                if (profit > 0)
                    maxProfit += profit;
            }
            return maxProfit;
        }
    }
}
