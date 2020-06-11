using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode_11
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
    //        //int input2 = int.Parse(Console.ReadLine());
    //        var res = solution.MaxArea(intArr);
    //        Console.WriteLine(res);
    //    }
    //}

    public class Solution
    {
        /// <summary>
        /// 最优解，双指针。发现这种一维数组的题，很大概率双指针都能做，以后遇到一维数组先想想双指针
        /// 时间复杂度：O(n)
        /// 空间复杂度：O(1)
        /// </summary>
        /// <param name="height"></param>
        /// <returns></returns>
        public int MaxArea(int[] height)
        {
            //1.双指针，前后逼近，指针总是从较小的一遍靠近
            int left = 0;
            int right = height.Length - 1;
            int max_cap = 0;
            while (left < right)
            {
                int cur_cap = Math.Min(height[left], height[right]) * (right - left);
                if (cur_cap > max_cap)
                    max_cap = cur_cap;
                if (height[left] < height[right])
                    left++;
                else
                    right--;
            }
            return max_cap;
        }

        /// <summary>
        /// 第一反应解，暴力求解，稍微做了一点点优化，虽然没有起到质的飞跃
        /// 时间复杂度：O(n²)
        /// 空间复杂度：O(1)
        /// </summary>
        /// <param name="height"></param>
        /// <returns></returns>
        //public int MaxArea(int[] height)
        //{
        //    int max_cap = 0;
        //    //1.循环组数，计算当前最大容积，如果大于当前最大值，记录下来
        //    for (int i = 0; i < height.Length; i++)
        //    {
        //        //1.1循环起始的时候判断当前高度能获得的最大容积（到数组尾），如果小于当前最大值，continue
        //        if (height[i] * (height.Length - 1) < max_cap)
        //            continue;

        //        for (int j = i + 1; j < height.Length; j++)
        //        {
        //            int cur_cap = Math.Min(height[i], height[j]) * (j - i);
        //            if (cur_cap > max_cap)
        //                max_cap = cur_cap;
        //        }
        //    }
        //    return max_cap;
        //}
    }
}
