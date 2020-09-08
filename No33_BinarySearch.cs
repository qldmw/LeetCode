using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode_33
{
    //static void Main(string[] args)
    //{
    //    var solution = new Solution();
    //    while (true)
    //    {
    //        //int input = int.Parse(Console.ReadLine());
    //        //int input2 = int.Parse(Console.ReadLine());
    //        //int input3 = int.Parse(Console.ReadLine());
    //        //string input = Console.ReadLine();
    //        //string input2 = Console.ReadLine();
    //        //int[] intArr = input.Split(',').Select(s => int.Parse(s)).ToArray();
    //        //int input2 = int.Parse(Console.ReadLine());
    //        //var builder = new DataStructureBuilder();
    //        //int?[] data = new int?[] { 1, 2, 3, 4, 5, null, 6, null, null, 7, 8 };
    //        //var tree = builder.BuildTree(data);
    //        //var listNode = builder.BuildListNode(new int[] { 1, 4, 5 });
    //        //int[][] arr = new int[3][] { new int[] { 1, 3, 1 }, new int[] { 1, 5, 1 }, new int[] { 4, 2, 1 } };
    //        //string input = "abcbefga";
    //        //string input2 = "dbefga";
    //        //int[] nums2 = new int[] { 2, 1, 1, 5, 11, 5, 1, 7, 5, 6, 4, 3 };
    //        //int[] nums3 = new int[] { 10, 15, 20 };
    //        int[] nums1 = new int[] { 4, 5, 6, 7, 0, 1, 2 };
    //        //IList<IList<int>> data = new List<IList<int>>()
    //        //{
    //        //    new List<int>() { 1, 3 },
    //        //    new List<int>() { 3, 0, 1 },
    //        //    new List<int>() { 2 },
    //        //    new List<int>() { 0 }

    //        //    //new List<int>() { 1 },
    //        //    //new List<int>() { 2 },
    //        //    //new List<int>() { 3 },
    //        //    //new List<int>() {  }
    //        //};
    //        var res = solution.Search(nums1, 3);
    //        ConsoleX.WriteLine(res);
    //    }
    //}

    public class Solution
    {
        /// <summary>
        /// 迭代实现二分查找
        /// 时间复杂度：O(logn)
        /// 空间复杂度：O(1),迭代的空间优势
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int Search(int[] nums, int target)
        {
            int left = 0, right = nums.Length - 1;
            while (left <= right)
            {
                //出错的点：如果这里不加一，那么始终不会定位到最后一个。例如：left = 6, right = 7, pivot就永远都是6。
                int mid = (left + right + 1) / 2;
                if (nums[mid] == target)
                    return mid;
                if (nums[left] < nums[mid])
                {
                    if (target >= nums[left] && target <= nums[mid])
                        right = mid - 1;
                    else
                        left = mid + 1;
                }
                else
                {
                    if (target >= nums[mid] && target <= nums[right])
                        left = mid + 1;
                    else
                        right = mid - 1;
                }
            }
            return -1;
        }

        ///// <summary>
        ///// 递归实现二分查找
        ///// 时间复杂度：O(logn)
        ///// 空间复杂度：O(logn)
        ///// </summary>
        ///// <param name="nums"></param>
        ///// <param name="target"></param>
        ///// <returns></returns>
        //public int Search(int[] nums, int target)
        //{
        //    return Recurse(0, nums.Length - 1);

        //    int Recurse(int left, int right)
        //    {
        //        //找完了都没有就返回
        //        if (left > right)
        //            return -1;
        //        //出错的点：如果这里不加一，那么始终不会定位到最后一个。例如：left = 6, right = 7, pivot就永远都是6。
        //        int pivot = (left + right + 1) / 2;
        //        //如果枢纽就是target，就直接答案
        //        if (nums[pivot] == target)
        //            return pivot;

        //        //如果左边是升序的，且target被包裹其中，就往左边查。否则往右边查
        //        if (pivot - 1 >= 0 && nums[left] <= nums[pivot - 1])
        //        {
        //            if (target >= nums[left] && target <= nums[pivot - 1])
        //                return Recurse(left, pivot - 1);
        //            else
        //                return Recurse(pivot + 1, right);
        //        }
        //        else
        //        {
        //            if (pivot + 1 < nums.Length && target >= nums[pivot + 1] && target <= nums[right])
        //                return Recurse(pivot + 1, right);
        //            else
        //                return Recurse(left, pivot - 1);
        //        }
        //    }
        //}
    }
}
