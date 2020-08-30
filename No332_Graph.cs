using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode_332
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
    //        //int?[] data = new int?[] { 1, 2, 3, 4, 5, null, 6, null, null, 7, 8 };
    //        //var tree = builder.BuildTree(data);
    //        //var listNode = builder.BuildListNode(new int[] { 1, 4, 5 });
    //        //int[][] arr = new int[3][] { new int[] { 1, 3, 1 }, new int[] { 1, 5, 1 }, new int[] { 4, 2, 1 } };
    //        //string input = "abcbefga";
    //        //string input2 = "dbefga";
    //        //int[] nums2 = new int[] { 2, 1, 1, 5, 11, 5, 1, 7, 5, 6, 4, 3 };
    //        //int[] nums3 = new int[] { 10, 15, 20 };
    //        //int[] nums1 = new int[] { 10, 9, 2, 5, 3, 7, 101, 18 };
    //        IList<IList<string>> data = new List<IList<string>>()
    //            {
    //                new List<string>(){ "JFK","SFO" },
    //                new List<string>(){ "JFK","ATL" },
    //                new List<string>(){ "SFO","ATL" },
    //                new List<string>(){ "ATL","JFK" },
    //                new List<string>(){ "ATL","SFO" }

    //                //new List<string>(){ "MUC", "LHR" },
    //                //new List<string>(){ "JFK", "MUC" },
    //                //new List<string>(){ "SFO", "SJC" },
    //                //new List<string>(){ "LHR", "SFO" }
    //            };
    //        var res = solution.FindItinerary(data);
    //        ConsoleX.WriteLine(res);
    //    }
    //}

    public class Solution
    {
        /// <summary>
        /// 希尔霍尔泽（Hierholzer）算法，解决欧拉回路问题。具体做法：深度优先遍历，如果遇到死路就把该节点放到结果中，最后把结果翻转就是正解
        /// 时间复杂度：O(nlogn)，深度优先遍历 n，排序 nlogn
        /// 空间复杂度：O(n)，深度优先栈空间 n, map n, itinerary n
        /// </summary>
        /// <param name="tickets"></param>
        /// <returns></returns>
        public IList<string> FindItinerary(IList<IList<string>> tickets)
        {
            //记录起点和终点
            Dictionary<string, List<string>> map = new Dictionary<string, List<string>>();
            //旅行路径
            List<string> itinerary = new List<string>();
            foreach (IList<string> ticket in tickets)
            {
                string src = ticket[0], dst = ticket[1];
                if (!map.ContainsKey(src))
                {
                    map.Add(src, new List<string>());
                }
                map[src].Add(dst);
            }
            //满足题意的按照起点字母顺序来优先遍历
            foreach (List<string> targets in map.Values)
            {
                targets.Sort();
            }
            Dfs("JFK");
            itinerary.Reverse();
            return itinerary;

            void Dfs(string curr)
            {
                while (map.ContainsKey(curr) && map[curr].Count() > 0)
                {
                    string tmp = map[curr].First();
                    map[curr].RemoveAt(0);
                    Dfs(tmp);
                }
                itinerary.Add(curr);
            }
        }

        ///// <summary>
        ///// 理解错误的样例，但是还是写了这么多代码，舍不得删，哈哈哈。
        ///// 题目的第一要求是求完整回路的解决方法，然后再是按照字母顺序排列。而不是先字母顺序，不管是否是完整回路
        ///// </summary>
        ///// <param name="tickets"></param>
        ///// <returns></returns>
        //public IList<string> FindItinerary(IList<IList<string>> tickets)
        //{
        //    IList<string> res = new List<string>();
        //    //出发地字典，string是出发点名
        //    Dictionary<string, GraphNode<string>> dic = new Dictionary<string, GraphNode<string>>();
        //    //把旅程图构建好
        //    foreach (var ticket in tickets)
        //    {
        //        GraphNode<string> to = dic.Keys.Contains(ticket[1]) ? dic[ticket[1]] : new GraphNode<string>(ticket[1]);
        //        GraphNode<string> from = dic.Keys.Contains(ticket[0]) ? dic[ticket[0]] : new GraphNode<string>(ticket[0]);
        //        from.Targets.Add(to);
        //        dic.TryAdd(ticket[0], from);
        //        dic.TryAdd(ticket[1], to);
        //    }
        //    //对目的地排序排序
        //    foreach (var node in dic.Values)
        //    {
        //        node.Targets.Sort();
        //    }
        //    //获取出发点
        //    var start = dic["JFK"];
        //    if (start == null)
        //        return res;

        //    while (start != null)
        //    {
        //        res.Add(start.Value);
        //        GraphNode<string> next = null;
        //        //如果还有下个节点
        //        if (start.Targets.Count != 0)
        //        {
        //            next = start.Targets[0];
        //            start.Targets.RemoveAt(0);
        //        }
        //        start = next;
        //    }
        //    return res;
        //}

        //private class GraphNode<T> : IComparable<GraphNode<T>>
        //{
        //    public GraphNode(T val)
        //    {
        //        this.Value = val;
        //        this.Targets = new List<GraphNode<T>>();
        //    }

        //    public T Value { get; set; }

        //    public List<GraphNode<T>> Targets { get; set; }

        //    public int CompareTo(GraphNode<T> obj)
        //    {
        //        return string.Compare(Value.ToString(), obj.Value.ToString());
        //    }
        //}
    }
}
