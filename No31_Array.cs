using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode_31
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
    //        ////string input2 = Console.ReadLine();
    //        //int[] intArr = input.Split(',').Select(s => int.Parse(s)).ToArray();
    //        //int input2 = int.Parse(Console.ReadLine());
    //        //int[] intArr = new int[] { 1, 3, 2 };
    //        int[] intArr = new int[] { 4, 2, 1, 3, 2, 6, 3 };
    //        solution.NextPermutation(intArr);
    //        //ConsoleX.WriteLine(res);
    //    }
    //}

    public class Solution
    {
        /// <summary>
        /// 第一反应解，查找替换
        /// 时间复杂度：O(n),中间的那个sort方向要改成reverse（懒得改了，知道意思就可以了），要不然最差的情况会整个n排序，就变成了nlogn
        /// 空间复杂度：O(1)
        /// </summary>
        /// <param name="nums"></param>
        public void NextPermutation(int[] nums)
        {
            bool anySwapHappened = false;
            //获取下一个更大的，分解题意就是从后往前扫描，如果遇到前一个比后一个小，就找到这段中比前一个大一的赋值给前一个，剩余的部分排序就可以了
            for (int i = nums.Length - 1; i > 0; i--)
            {
                if (nums[i - 1] < nums[i])
                {
                    int closestBiggerNumIndex = FindClosestBiggerNumberIndex(nums, i - 1);
                    Swap(nums, closestBiggerNumIndex, i - 1);
                    //后记：这一步用reverse会更快一些
                    Array.Sort(nums, i, nums.Length - i);
                    anySwapHappened = true;
                    break;
                }
            }
            //如果遍历之后都没有遇到前一个比后一个小的，就翻转数组
            if (!anySwapHappened)
                Array.Reverse(nums);
        }

        private int FindClosestBiggerNumberIndex(int[] nums, int startIndex)
        {
            int targetIndex = -1;
            int closestNum = int.MaxValue;
            for (int i = startIndex + 1; i < nums.Length; i++)
            {
                if (nums[i] > nums[startIndex] && Math.Abs((long)(nums[i] - nums[startIndex])) < Math.Abs((long)(closestNum - nums[startIndex])))
                {
                    closestNum = nums[i];
                    targetIndex = i;
                }
            }
            return targetIndex;
        }

        private void Swap(int[] nums, int a, int b)
        {
            int temp;
            temp = nums[a];
            nums[a] = nums[b];
            nums[b] = temp;
        }
    }
}
