using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode_746
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
    //        //int?[] data = new int?[] { 10, 5, 15, null, null, 6, 20 };
    //        //var tree = builder.BuildTree(data);
    //        //var listNode = builder.BuildListNode(new int[] { 1, 4, 5 });
    //        int[] nums1 = new int[] { 1, 100, 1, 1, 1, 100, 1, 1, 100, 1 };
    //        //int[] nums1 = new int[] { 10, 15, 20 };
    //        //int[] nums2 = new int[] { 10, 15, 20 };
    //        //string input = "abc";
    //        //string input2 = "ahbgdc";                
    //        var res = solution.MinCostClimbingStairs(nums1);
    //        ConsoleX.WriteLine(res);
    //    }
    //}

    public class Solution
    {
        /// <summary>
        /// 动态规划，每次都算出最少的，最后一步最少的就是解。
        /// 时间复杂度：O(n)
        /// 空间复杂度：O(1)
        /// </summary>
        /// <param name="cost"></param>
        /// <returns></returns>
        public int MinCostClimbingStairs(int[] cost)
        {
            int stepMinusTwo = 0;
            int stepMinusOne = 0;
            int minCost = 0;
            for (int step = 0; step < cost.Length; step++)
            {
                minCost = Math.Min(stepMinusTwo + cost[step], stepMinusOne + cost[step]);
                stepMinusTwo = stepMinusOne;
                stepMinusOne = minCost;
            }
            return Math.Min(stepMinusOne, stepMinusTwo);
        }
    }
}
