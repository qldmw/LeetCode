using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Extension;
using LeetCode.ExtensionFunction;

namespace LeetCode
{
    class Program
    {
        static void Main(string[] args)
        {
            var solution = new Solution();
            while (true)
            {
                //int input = int.Parse(Console.ReadLine());
                //int input2 = int.Parse(Console.ReadLine());
                //string input = Console.ReadLine();
                //string input2 = Console.ReadLine();
                //int[] intArr = input.Split(',').Select(s => int.Parse(s)).ToArray();
                //int input2 = int.Parse(Console.ReadLine());
                //var builder = new DataStructureBuilder();
                //int?[] data = new int?[] { 1, 2, 3, 4, 5, null, 6, null, null, 7, 8 };
                //var tree = builder.BuildTree(data);
                //var listNode = builder.BuildListNode(new int[] { 1, 4, 5 });
                //int[][] arr = new int[3][] { new int[] { 1, 3, 1 }, new int[] { 1, 5, 1 }, new int[] { 4, 2, 1 } };
                //string input = "abcbefga";
                //string input2 = "dbefga";
                //int[] nums2 = new int[] { 2, 1, 1, 5, 11, 5, 1, 7, 5, 6, 4, 3 };
                //int[] nums3 = new int[] { 10, 15, 20 };
                int[] nums1 = new int[] { 10, 9, 2, 5, 3, 7, 101, 18 };
                var res = solution.LengthOfLIS(nums1);
                ConsoleX.WriteLine(res);
            }
        }

        public class Solution
        {
            public int LengthOfLIS(int[] nums)
            {
                if (nums == null || nums.Length == 0)
                    return 0;

                //又要有一个数，那么最长子序列也最小是1
                int[] dp = Enumerable.Repeat(1, nums.Length).ToArray();
                // 1. 往前找比当前数字小的数字，如果找到则比较该dp值+1是否大于最大值，大于则赋值
                for (int i = 0; i < nums.Length; i++)
                {
                    for (int j = i - 1; j >= 0; j--)
                    {
                        if (nums[i] > nums[j])
                            dp[i] = Math.Max(dp[j] + 1, dp[i]);
                    }
                }
                return dp.Max();
            }
        }
    }
}