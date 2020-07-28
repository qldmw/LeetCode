using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode_152
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
    //        //int[][] arr = new int[3][] { new int[] { 1, 3, 1 }, new int[] { 1, 5, 1 }, new int[] { 4, 2, 1 } };
    //        int[] nums1 = new int[] { 2, 3, -2, 4 };
    //        //int[] nums2 = new int[] { 10, 15, 20 };
    //        //string input = "abc";
    //        //string input2 = "ahbgdc";         
    //        //string s = "leetcode";

    //        var res = solution.MaxProduct(nums1);
    //        ConsoleX.WriteLine(res);
    //    }
    //}

    public class Solution
    {
        /// <summary>
        /// 动态规划优化，滚动变量。因为最大最小值计算只依赖上一个变量，是故可以对此做优化
        /// 时间复杂度：O(n)
        /// 空间复杂度：O(1)
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MaxProduct(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return 0;

            int preMax = nums[0];
            int preMin = nums[0];
            int res = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                int curMax = Math.Max(Math.Max(preMax * nums[i], preMin * nums[i]), nums[i]);
                int curMin = Math.Min(Math.Min(preMax * nums[i], preMin * nums[i]), nums[i]);
                preMax = curMax;
                preMin = curMin;
                res = Math.Max(curMax, res);
            }
            return res;
        }

        /// <summary>
        /// 动态规划。因为有负负得正，所以要把最小值存起来，说不好下一个是负值，要用最小值来乘起来试试。
        /// 时间复杂度：O(n)
        /// 空间复杂度：O(n)
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        //public int MaxProduct(int[] nums)
        //{
        //    if (nums == null || nums.Length == 0)
        //        return 0;

        //    int[] max = new int[nums.Length];
        //    int[] min = new int[nums.Length];

        //    max[0] = nums[0];
        //    min[0] = nums[0];
        //    for (int i = 1; i < nums.Length; i++)
        //    {
        //        if (nums[i - 1] == 0)
        //        {
        //            max[i] = Math.Max(0, nums[i]);
        //            min[i] = Math.Min(0, nums[i]);
        //        }
        //        else
        //        {
        //            max[i] = Math.Max(Math.Max(max[i - 1] * nums[i], min[i - 1] * nums[i]), nums[i]);
        //            min[i] = Math.Min(Math.Min(max[i - 1] * nums[i], min[i - 1] * nums[i]), nums[i]);
        //        }
        //    }
        //    return max.Max();
        //}
    }
}
