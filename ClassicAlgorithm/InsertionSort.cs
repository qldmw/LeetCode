using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.ClassicAlgorithm
{
    class InsertionSort
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
        //        var res = solution.InsertionSort(nums1);
        //        ConsoleX.WriteLine(res);
        //    }
        //}

        public class Solution
        {
            /// <summary>
            /// 插入排序
            /// 时间复杂度：O(n²)
            /// 空间复杂度：O(1)
            /// 其实和冒泡排序一个思想，不过在做法上优化了，减少了交换次数
            /// </summary>
            /// <param name="arr"></param>
            /// <returns></returns>
            public int[] InsertionSort(int[] arr)
            {
                //注意边界，以 1 开始
                for (int i = 1; i < arr.Length; i++)
                {
                    //缓存起点的 值 和 下标，用于比较和最后的还原
                    int temp = arr[i];
                    int index = i;
                    //用 while 循环比用 for 循环语义更清晰。【容易犯错的点】，要用缓存的 值 做比较，不是用前一个比后一个
                    while (index > 0 && temp < arr[index - 1])
                    {
                        arr[index] = arr[index - 1];
                        index--;
                    }
                    //还原
                    arr[index] = temp;
                }
                return arr;
            }
        }
    }
}
