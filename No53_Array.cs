using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode_53
{
    class No53_Array
    {
        /// <summary>
        /// 贪心，解法一
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MaxSubArray(int[] nums)
        {
            int max = nums[0], curMax = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                curMax = Math.Max(nums[i], nums[i] + curMax);
                max = Math.Max(max, curMax);
            }
            return max;
        }

        /// <summary>
        /// 分治法，解法二
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        //public int MaxSubArray(int[] nums)
        //{
        //    int len = nums.Length;
        //    if (len == 1)
        //    {
        //        return nums[0];
        //    }
        //    return Shunting(nums, 0, len - 1);
        //}

        //public int Shunting(int[] nums, int left, int right)
        //{
        //    if (left == right) return nums[left];
        //    int leftSum = Shunting(nums, left, (left + right) / 2);
        //    int rightSum = Shunting(nums, (left + right) / 2 + 1, right);
        //    int midSum = CalculateMidSum(nums, left, right);
        //    return Math.Max(Math.Max(leftSum, rightSum), midSum);
        //}

        //public int CalculateMidSum(int[] nums, int left, int right)
        //{
        //    int midPos = (left + right) / 2;
        //    int leftMax = nums[midPos], rightMax = nums[midPos + 1];
        //    int curSum = leftMax;
        //    for (int i = midPos - 1; i >= left; i--)
        //    {
        //        curSum += nums[i];
        //        leftMax = Math.Max(curSum, leftMax);
        //    }
        //    curSum = rightMax;
        //    for (int i = midPos + 1 + 1; i <= right; i++)
        //    {
        //        curSum += nums[i];
        //        rightMax = Math.Max(curSum, rightMax);
        //    }
        //    return leftMax + rightMax;
        //}
    }
}
