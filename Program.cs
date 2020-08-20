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
                List<List<int>> data = new List<List<int>>()
                {
                    new List<int>(){ 1,2,3,4,5,6,5 },
                    new List<int>(){ 1,2,3,4,5,6,6 },
                    new List<int>(){ 1,2,3,4,5,6,7 },
                    new List<int>(){ 1,2,3,4,5,6,4 },
                    new List<int>(){ 1,2,3,4,5,6,3 }
                };
                var res = solution.GetMaxSumIntList(data);
                ConsoleX.WriteLine(res);
            }
        }

        public class Solution
        {
            public List<int> GetMaxSumIntList(List<List<int>> data)
            {
                List<int> sumList = data.Select(s => s.Sum()).ToList();

                int max = int.MinValue;
                int maxIndex = -1;
                for (int i = 0; i < sumList.Count; i++)
                {
                    if (sumList[i] > max)
                    {
                        max = sumList[i];
                        maxIndex = i;
                    }
                }
                return data[maxIndex];
            }
        }
    }
}