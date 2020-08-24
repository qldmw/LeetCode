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
                //string input = "abcbefga";
                //string input2 = "dbefga";
                int[] nums1 = new int[] { 2, 1, 7, 5, 6, 4, 3 };
                int[] nums2 = new int[] { 2, 1, 1, 5, 11, 5, 1, 7, 5, 6, 4, 3 };
                int[] nums3 = new int[] { 10, 15, 20 };
                var data = new int[][] { nums1, nums2, nums3 };
                var res = solution.BiggestSubset(data);
                ConsoleX.WriteLine(res);
            }
        }

        public class Solution
        {
            public int[] BiggestSubset(int[][] data)
            {
                //测试用例
                //int[] nums1 = new int[] { 2, 1, 7, 5, 6, 4, 3 };
                //int[] nums2 = new int[] { 2, 1, 1, 5, 11, 5, 1, 7, 5, 6, 4, 3 };
                //int[] nums3 = new int[] { 10, 15, 20 };
                //var data = new int[][] { nums1, nums2, nums3 };
                //var res = solution.BiggestSubset(data);
                //ConsoleX.WriteLine(res);

                int[] res = null;
                int max = int.MinValue;
                for (int i = 0; i < data.Length; i++)
                {
                    int sum = data[i].Sum();
                    if (sum > max)
                    {
                        max = sum;
                        res = data[i];
                    }
                }
                return res;
            }
        }
    }
}