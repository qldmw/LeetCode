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
                //int[] nums1 = new int[] { 2, 1, 7, 5, 6, 4, 3 };
                //int[] nums1 = new int[] { 2, 1, 1, 5, 11, 5, 1, 7, 5, 6, 4, 3 };
                //int[] nums2 = new int[] { 10, 15, 20 };
                //string input = "adceb";
                //string input2 = "*a*b";
                //int[] intArr = new int[] { 0, 0, 0 };
                //int[] intArr = new int[] { -1, 0, 1, 2, -1, -4 };
                //int[] intArr = new int[] { -2, -1, -1, -1, 0, 1, 1, 1, 2 };
                var res = solution.FindKthLargest(new int[] { 5, 2, 4, 1, 3, 6, 0 }, 4);
                ConsoleX.WriteLine(res);
            }
        }

        public class Solution
        {
            public int FindKthLargest(int[] nums, int k)
            {

            }

            private int QuickSelect(int[] nums, int left, int right, int target)
            {

            }

            private int Partition(int[] nums, int left, int right)
            {

            }

            private void MedianOfThree(int[] nums, int left, int right)
            {
                int mid = (left + right) / 2;
                //交换三个数，先用左边比较两次，确保左边最小，然后再把中间和右边一比，齐活
                if (nums[left] > nums[mid])
                    Swap(nums, left, mid);
                if (nums[left] > nums[right])
                    Swap(nums, left, right);
                if (nums[mid] > nums[right])
                    Swap(nums, mid, right);
                //把中位数放到右边第二位，为之后备用
                Swap(nums, mid, right - 1);
            }

            private void Swap(int[] nums, int a, int b)
            {
                int temp = nums[a];
                nums[a] = nums[b];
                nums[b] = temp;
            }
        }
    }
}