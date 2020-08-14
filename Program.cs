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
                //int?[] data = new int?[] { 1, 2, 5, 3, 4, null, 6 };
                //var tree = builder.BuildTree(data);
                //var listNode = builder.BuildListNode(new int[] { 1, 4, 5 });
                //int[][] arr = new int[3][] { new int[] { 1, 3, 1 }, new int[] { 1, 5, 1 }, new int[] { 4, 2, 1 } };
                //int[] nums1 = new int[] { 2, 1, 7, 5, 6, 4, 3 };
                int[] nums1 = new int[] { 2, 1, 1, 5, 11, 5, 1, 7, 5, 6, 4, 3 };
                //int[] nums2 = new int[] { 10, 15, 20 };
                //string input = "adceb";
                //string input2 = "*a*b";
                var res = solution.QuickSort(nums1);
                ConsoleX.WriteLine(res);
            }
        }

        public class Solution
        {
            public int[] QuickSort(int[] arr)
            {
                QuickSort(arr, 0, arr.Length - 1);
                return arr;
            }

            private void QuickSort(int[] arr, int left, int right)
            {
                if (left >= right)
                    return;

                int mid = Partition(arr, left, right);
                QuickSort(arr, left, mid - 1);
                QuickSort(arr, mid + 1, right);
            }

            /// <summary>
            /// 传统 partition 做法
            /// </summary>
            /// <param name="arr"></param>
            /// <param name="left"></param>
            /// <param name="right"></param>
            /// <returns></returns>
            //private int Partition(int[] arr, int left, int right)
            //{
            //    int pivot = arr[right];
            //    int slow = left;
            //    for (int fast = left; fast < right; fast++)
            //    {
            //        if (arr[fast] < pivot)
            //        {
            //            Swap(arr, fast, slow);
            //            slow++;
            //        }
            //    }
            //    Swap(arr, slow, right);
            //    return slow;
            //}

            //private int Partition(int[] nums, int left, int right)
            //{
            //    //防止越界
            //    if (left >= right)
            //        return left;

            //    MedianOfThree(nums, left, right);
            //    //枢纽
            //    int pivot = left + 1;
            //    //左右指针，用于交换（使用了三数取中法，右指针放在右边第二个了）
            //    int l = left, r = pivot;
            //    while (l < r)
            //    {
            //        //从左往右找大于枢纽值的数
            //        while (l < r && nums[l] <= nums[pivot])
            //            l++;
            //        //从右往左找小于枢纽值的数
            //        while (l < r && nums[r] >= nums[pivot])
            //            r--;
            //        if (l < r)
            //            Swap(nums, l, r);
            //    }
            //    //枢纽归位
            //    Swap(nums, l, pivot);
            //    //返回枢纽位置
            //    return l;
            //}

            ////三数取中，交换位置
            //private void MedianOfThree(int[] nums, int left, int right)
            //{
            //    int mid = (left + right) / 2;
            //    if (nums[left] > nums[mid])
            //        Swap(nums, left, mid);
            //    if (nums[left] > nums[right])
            //        Swap(nums, left, right);
            //    if (nums[mid] > nums[right])
            //        Swap(nums, mid, right);
            //    //把枢纽放到右边第二位
            //    Swap(nums, mid, right - 1);
            //}

            private int Partition(int[] arr, int left, int right)
            {
                if (left >= right)
                    return left;

                int pivot = right;
                right--;
                while (left < right)
                {
                    while (left < right && arr[left] <= arr[pivot])
                        left++;
                    while (left < right && arr[right] >= arr[pivot])
                        right--;
                    if (left < right)
                        Swap(arr, left, right);
                }
                Swap(arr, pivot, left);
                return left;
            }

            private void Swap(int[] arr, int a, int b)
            {
                int temp = arr[a];
                arr[a] = arr[b];
                arr[b] = temp;
            }
        }
    }
}