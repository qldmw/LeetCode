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
                //int[] nums2 = new int[] { 2, 1, 1, 5, 11, 5, 1, 7, 5, 6, 4, 3 };
                //int[] nums3 = new int[] { 10, 15, 20 };
                //int[] nums1 = new int[] { 10, 9, 2, 5, 3, 7, 101, 18 };
                IList<IList<string>> data = new List<IList<string>>()
                {
                    //new List<string>(){ "JFK","SFO" },
                    //new List<string>(){ "JFK","ATL" },
                    //new List<string>(){ "SFO","ATL" },
                    //new List<string>(){ "ATL","JFK" },
                    //new List<string>(){ "ATL","SFO" }

                    new List<string>(){ "MUC", "LHR" },
                    new List<string>(){ "JFK", "MUC" },
                    new List<string>(){ "SFO", "SJC" },
                    new List<string>(){ "LHR", "SFO" }
                };
                var res = solution.FindItinerary(data);
                ConsoleX.WriteLine(res);
            }
        }

        public class Solution
        {
            public IList<string> FindItinerary(IList<IList<string>> tickets)
            {
                IList<string> res = new List<string>();
                //出发地字典，string是出发点名
                Dictionary<string, GraphNode<string>> dic = new Dictionary<string, GraphNode<string>>();
                //把旅程图构建好
                foreach (var ticket in tickets)
                {
                    GraphNode<string> to = dic.Keys.Contains(ticket[1]) ? dic[ticket[1]] : new GraphNode<string>(ticket[1]);
                    GraphNode<string> from = dic.Keys.Contains(ticket[0]) ? dic[ticket[0]] : new GraphNode<string>(ticket[0]);
                    from.Targets.Add(to);
                    dic.TryAdd(ticket[0], from);
                    dic.TryAdd(ticket[1], to);
                }
                //对目的地排序排序
                foreach (var node in dic.Values)
                {
                    node.Targets.Sort();
                }
                //获取出发点
                var start = dic["JFK"];
                if (start == null)
                    return res;

                while (start != null)
                {
                    res.Add(start.Value);
                    GraphNode<string> next = null;
                    //如果还有下个节点
                    if (start.Targets.Count != 0)
                    {
                        next = start.Targets[0];
                        start.Targets.RemoveAt(0);
                    }
                    start = next;
                }
                return res;
            }

            private class GraphNode<T> : IComparable<GraphNode<T>>
            {
                public GraphNode(T val)
                {
                    this.Value = val;
                    this.Targets = new List<GraphNode<T>>();
                }

                public T Value { get; set; }

                public List<GraphNode<T>> Targets { get; set; }

                public int CompareTo(GraphNode<T> obj)
                {
                    return string.Compare(Value.ToString(), obj.Value.ToString());
                }
            }
        }
    }
}