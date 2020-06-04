using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace LeetCode_35
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
    //        int input2 = int.Parse(Console.ReadLine());
    //        var res = solution.SearchInsert(intArr, input2);
    //        Console.WriteLine(res);
    //    }
    //}

    public class Solution
    {
        /// <summary>
        /// 直接简单的循环,其中的边界判断条件可以看做是一个数组模板
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int SearchInsert(int[] nums, int target)
        {
            int left = 0, right = nums.Length - 1;
            while (left <= right)
            {
                int mid = (left + right) / 2;
                if (nums[mid] == target)
                    return mid;
                else if (nums[mid] > target)
                    right = mid - 1;
                else
                    left = mid + 1;
            }
            return left;
        }

        /// <summary>
        /// 强行写成递归
        /// 时间复杂度：O(logn)
        /// 空间复杂度：O(1)
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        //public int SearchInsert(int[] nums, int target)
        //{
        //    return Recursive(nums, 0, nums.Length - 1, target);
        //}

        //private int Recursive(int[] nums, int left, int right, int target)
        //{
        //    int mid = (left + right) / 2;
        //    if (nums[mid] == target)
        //        return mid;
        //    else if (left > right)
        //        return left;

        //    if (nums[mid] > target)
        //        return Recursive(nums, left, mid - 1, target);
        //    else 
        //        return Recursive(nums, mid + 1, right, target); 
        //}
    }
}