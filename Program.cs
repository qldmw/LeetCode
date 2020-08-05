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
                //int[] nums1 = new int[] { 2, 1, -2, 3 };
                //int[] nums2 = new int[] { 10, 15, 20 };
                //string input = "adceb";
                //string input2 = "*a*b";
                int[][] data = new int[][]
                {
                    new int[] {1, 0},
                    new int[] {2, 1},
                };
                var res = solution.CanFinish(2, data);
                ConsoleX.WriteLine(res);
            }
        }

        /// <summary>
        /// REDO
        /// </summary>
        public class Solution
        {
            public bool CanFinish(int numCourses, int[][] prerequisites)
            {
                //把数组转化为字典，方便后面查找。int 是起点，List<int>是终点列表
                Dictionary<int, List<int>> map = new Dictionary<int, List<int>>();
                for (int i = 0; i < prerequisites.Length; i++)
                {
                    if (prerequisites[i].Length == 0)
                        continue;

                    //弧的起点和终点
                    int start = prerequisites[i][1], end = prerequisites[i][0];
                    if (!map.ContainsKey(start))
                        map.Add(start, new List<int>() { end });
                    else
                        map[start].Add(end);
                }
                foreach (var key in map.Keys)
                {
                    if (FindCourse(map, key, numCourses))
                        return true;
                }
                return false;
            }

            private bool FindCourse(Dictionary<int, List<int>> map, int start, int numCourses)
            {

            }
        }
    }
}