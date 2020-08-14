using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.ClassicAlgorithm
{
    class SectionSort
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
        //        //int?[] data = new int?[] { 1, 2, 5, 3, 4, null, 6 };
        //        //var tree = builder.BuildTree(data);
        //        //var listNode = builder.BuildListNode(new int[] { 1, 4, 5 });
        //        //int[][] arr = new int[3][] { new int[] { 1, 3, 1 }, new int[] { 1, 5, 1 }, new int[] { 4, 2, 1 } };
        //        int[] nums1 = new int[] { 2, 1, 7, 5, 6, 4, 3 };
        //        //int[] nums2 = new int[] { 10, 15, 20 };
        //        //string input = "adceb";
        //        //string input2 = "*a*b";
        //        var res = solution.SectionSort(nums1);
        //        ConsoleX.WriteLine(res);
        //    }
        //}

        public class Solution
        {
            /// <summary>
            /// 选择排序
            /// 时间复杂度：O(n²)
            /// 空间复杂度：O(1)
            /// </summary>
            /// <param name="arr"></param>
            /// <returns></returns>
            public int[] SectionSort(int[] arr)
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    //最小数下标
                    int minIndex = i;
                    //循环找到当前最小数
                    for (int j = i + 1; j < arr.Length; j++)
                    {
                        if (arr[j] < arr[minIndex])
                            minIndex = j;
                    }

                    //和当前最小数交换位置
                    int temp = arr[i];
                    arr[i] = arr[minIndex];
                    arr[minIndex] = temp;
                }
                return arr;
            }
        }
    }
}
