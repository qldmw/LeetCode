using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode_64
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
    //        int[][] arr = new int[3][] { new int[] { 1, 3, 1 }, new int[] { 1, 5, 1 }, new int[] { 4, 2, 1 } };
    //        //int[] nums1 = new int[] { 2, 1, 4, 5, 3, 1, 1, 3 };
    //        //int[] nums2 = new int[] { 10, 15, 20 };
    //        //string input = "abc";
    //        //string input2 = "ahbgdc";                
    //        var res = solution.MinPathSum(arr);
    //        ConsoleX.WriteLine(res);
    //    }
    //}

    public class Solution
    {
        /// <summary>
        /// 动态规划
        /// 时间复杂度：O(n²)
        /// 空间复杂度：O(n)
        /// 又是一个题目系列的变种，62-64本质都是一个题，不过改变了些变量。难点还是在分析动态规划的前后关系，像这种已经接触过的题目就很容易解决啦
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int MinPathSum(int[][] grid)
        {
            if (grid == null && grid.Length == 0)
                return 0;

            int row = grid.Length;
            int col = grid[0].Length;
            int[] dp = new int[col];
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    if (i == 0)
                    {
                        if (j == 0)
                            dp[j] = grid[i][j];
                        else
                            dp[j] = dp[j - 1] + grid[i][j];
                    }
                    else
                    {
                        int top = i > 0 ? dp[j] : int.MaxValue;
                        int left = j > 0 ? dp[j - 1] : int.MaxValue;
                        dp[j] = Math.Min(top, left) + grid[i][j];
                    }
                }
            }
            return dp[col - 1];
        }
    }
}
