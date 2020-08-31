using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Extension;
using LeetCode.ExtensionFunction;
using System.Threading.Tasks;
using System.Threading;

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
                //int[] nums2 = new int[] { 2, 1, 1, 5, 11, 5, 1, 7, 5, 6, 4, 3 };
                //int[] nums3 = new int[] { 10, 15, 20 };
                //int[] nums1 = new int[] { 10, 9, 2, 5, 3, 7, 101, 18 };
                IList<IList<int>> data = new List<IList<int>>()
                {
                    new List<int>() { 1, 3 },
                    new List<int>() { 3, 0, 1 },
                    new List<int>() { 2 },
                    new List<int>() { 0 }

                    //new List<int>() { 1 },
                    //new List<int>() { 2 },
                    //new List<int>() { 3 },
                    //new List<int>() {  }
                };
                var res = solution.CanVisitAllRooms(data);
                ConsoleX.WriteLine(res);
            }
        }

        public class Solution
        {
            /// <summary>
            /// 深度优先
            /// 设 key 总数为 n, room 总数为 m
            /// 时间复杂度：O(n)，最差情况下在最后一个才找到答案
            /// 空间复杂度：O(m), 记录房间是否锁上的 hashSet 是 m 个， 递归深度最大也是 m 次
            /// </summary>
            /// <param name="rooms"></param>
            /// <returns></returns>
            public bool CanVisitAllRooms(IList<IList<int>> rooms)
            {
                HashSet<int> lockedRooms = new HashSet<int>();
                for (int i = 1; i < rooms.Count; i++)
                {
                    lockedRooms.Add(i);
                }
                Recurse(0);
                return lockedRooms.Count == 0;

                void Recurse(int roomNo)
                {
                    if (lockedRooms.Count == 0)
                        return;

                    var keys = rooms[roomNo];
                    foreach (int key in keys)
                    {
                        if (lockedRooms.Contains(key))
                        {
                            lockedRooms.Remove(key);
                            Recurse(key);
                        }
                    }
                }
            }
        }
    }
}