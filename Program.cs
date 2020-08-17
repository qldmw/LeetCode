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
                var res = solution.MergeSort(nums1);
                ConsoleX.WriteLine(res);
            }
        }

        public class Solution
        {
            /// <summary>
            /// 合并排序，典型分治(divide and conquer)
            /// </summary>
            /// <param name="arr"></param>
            /// <returns></returns>
            public int[] MergeSort(int[] arr)
            {
                Divide(arr, 0, arr.Length - 1);
                return arr;
            }

            private void Divide(int[] arr, int left, int right)
            {
                //长度大于1
                if (left < right)
                {
                    int mid = (left + right) / 2;
                    Divide(arr, left, mid);
                    Divide(arr, mid + 1, right);
                    Conquer(arr, left, mid, right);
                }
            }

            private void Conquer(int[] arr, int left, int mid, int right)
            {
                int[] temp = new int[right - left + 1];
                //临时数组的指针
                int tempIndex = 0;
                //两部分的指针
                int index1 = left, index2 = mid + 1;
                //把已经排序的两部分合并起来
                while (index1 <= mid || index2 <= right)
                {
                    if (index1 > mid)
                    {
                        temp[tempIndex] = arr[index2];
                        index2++;
                        tempIndex++;
                    }
                    else if (index2 > right)
                    {
                        temp[tempIndex] = arr[index1];
                        index1++;
                        tempIndex++;
                    }
                    else
                    {
                        if (arr[index1] < arr[index2])
                        {
                            temp[tempIndex] = arr[index1];
                            index1++;
                        }
                        else
                        {
                            temp[tempIndex] = arr[index2];
                            index2++;
                        }
                        tempIndex++;
                    }
                }
                //把临时数组中排好序的数组赋值回原数组
                for (int i = left; i <= right; i++)
                {
                    arr[i] = temp[i - left];
                }
            }
        }
    }
}