using System;
using System.Collections.Generic;
using System.Extension;
using System.Linq;
using System.Text;

namespace LeetCode_207
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
    //        //int[] nums1 = new int[] { 2, 1, -2, 3 };
    //        //int[] nums2 = new int[] { 10, 15, 20 };
    //        //string input = "adceb";
    //        //string input2 = "*a*b";
    //        int[][] data = new int[][]
    //        {
    //                //new int[] {1, 0},
    //                //new int[] {2, 1},

    //                //new int[] {1, 0},
    //                //new int[] {0, 1},

    //                //new int[] {1, 0},
    //                //new int[] {1, 2},
    //                //new int[] {0, 1},

    //                new int[] {1, 0},
    //                new int[] {2, 6},
    //                new int[] {1, 7},
    //                new int[] {5, 1},
    //                new int[] {6, 4},
    //                new int[] {7, 0},
    //                new int[] {0, 5},
    //        };
    //        var res = solution.CanFinish(8, data);
    //        ConsoleX.WriteLine(res);
    //    }
    //}

    public class Solution
    {
        /// <summary>
        /// 深度优先，在第一反应解的基础上加了闭环立即退出的机制，而不是之前那样超出课程总数才退出。还通过判断状态决定是否进入DFS
        /// 设 n 为课程数，m 为先修课程的要求数
        /// 时间复杂度：O(m + n)
        /// 空间复杂度：O(m + n)，为了美观使用了 Tuple 元组，如果为了节省空间，可以单纯再存一个 dictionary 记录状态，因为元组不允许 set，导致 new 了多个元组来更新状态
        /// 就是这么小一个改动，执行结果的反差相当之大
        /// </summary>
        /// <param name="numCourses"></param>
        /// <param name="prerequisites"></param>
        /// <returns></returns>
        public bool CanFinish(int numCourses, int[][] prerequisites)
        {
            //把数组转化为字典，方便后面查找。int 是起点，state是起点的状态, List<int>是终点列表
            Dictionary<int, (State, List<int>)> map = new Dictionary<int, (State, List<int>)>();
            for (int i = 0; i < prerequisites.Length; i++)
            {
                if (prerequisites[i].Length == 0)
                    continue;

                //弧的起点和终点
                int start = prerequisites[i][1], end = prerequisites[i][0];
                if (!map.ContainsKey(start))
                    map.Add(start, (State.Initial, new List<int>() { end }));
                else
                    map[start].Item2.Add(end);
            }
            foreach (var start in map.Keys.ToList())
            {
                if (map[start].Item1 == State.Initial && !Dfs(map, start))
                    return false;
            }
            return true;
        }

        private bool Dfs(Dictionary<int, (State, List<int>)> map, int start)
        {
            if (!map.ContainsKey(start))
            {
                map[start] = (State.Searched, map[start].Item2);
                return true;
            }
            foreach (var end in map[start].Item2)
            {
                if (!map.ContainsKey(end))
                    continue;

                if (map[end].Item1 == State.Initial)
                {
                    map[end] = (State.Searching, map[end].Item2);
                    if (!Dfs(map, end))
                        return false;
                }
                else if (map[end].Item1 == State.Searching)
                    return false;
            }
            map[start] = (State.Searched, map[start].Item2);
            return true;
        }

        private enum State
        {
            Initial,
            Searching,
            Searched
        }

        /// <summary>
        /// 广度优先，利用计算各节点的入度来获得结果，（入度，就是被依赖的个数），不断从入度为 0 的点开始遍历，遍历完成后入度表中还有入度不为 0 的，则有环。
        /// 设 n 为课程数，m 为先修课程的要求数
        /// 时间复杂度：O(m + n)
        /// 空间复杂度：O(m + n)
        /// </summary>
        /// <param name="numCourses"></param>
        /// <param name="prerequisites"></param>
        /// <returns></returns>
        //public bool CanFinish(int numCourses, int[][] prerequisites)
        //{
        //    if (prerequisites == null || prerequisites.Length == 0)
        //        return true;

        //    //把数组转化为字典，方便后面查找。int 是起点，List<int>是终点列表
        //    Dictionary<int, List<int>> map = new Dictionary<int, List<int>>();
        //    //入度统计，第一个 int 是节点，第二个 int 是入度数值
        //    Dictionary<int, int> indeg = new Dictionary<int, int>();
        //    for (int i = 0; i < prerequisites.Length; i++)
        //    {
        //        if (prerequisites[i].Length == 0)
        //            continue;

        //        //弧的起点和终点
        //        int start = prerequisites[i][1], end = prerequisites[i][0];
        //        if (!map.ContainsKey(start))
        //            map.Add(start, new List<int>() { end });
        //        else
        //            map[start].Add(end);

        //        //入度统计
        //        if (!indeg.ContainsKey(start))
        //            indeg.Add(start, 0);
        //        if (!indeg.ContainsKey(end))
        //            indeg.Add(end, 1);
        //        else
        //            indeg[end]++;
        //    }
        //    //把入度为 0 的节点加入到队列
        //    Queue<int> queue = new Queue<int>();
        //    foreach (int node in indeg.Keys)
        //    {
        //        if (indeg[node] == 0)
        //            queue.Enqueue(node);
        //    }
        //    //典型广度优先的入队出队
        //    while (queue.Count != 0)
        //    {
        //        int start = queue.Dequeue();
        //        if (!map.ContainsKey(start))
        //            continue;
        //        foreach (int end in map[start])
        //        {
        //            if (indeg.ContainsKey(end) && --indeg[end] == 0)
        //                queue.Enqueue(end);
        //        }
        //    }
        //    return !indeg.Values.Any(s => s > 0);
        //}

        /// <summary>
        /// 第一反应解。通过遍历各点，发现深度没有大于课程总数的路径，则证明通过。否则就是有环的，不通过
        /// 设课程总数为 m, 约束条件为 n
        /// 时间复杂度：最优 O(mn),最差 O(mn²)
        /// 空间复杂度：O(m)
        /// </summary>
        /// <param name="numCourses"></param>
        /// <param name="prerequisites"></param>
        /// <returns></returns>
        //public bool CanFinish(int numCourses, int[][] prerequisites)
        //{
        //    //把数组转化为字典，方便后面查找。int 是起点，List<int>是终点列表
        //    Dictionary<int, List<int>> map = new Dictionary<int, List<int>>();
        //    for (int i = 0; i < prerequisites.Length; i++)
        //    {
        //        if (prerequisites[i].Length == 0)
        //            continue;

        //        //弧的起点和终点
        //        int start = prerequisites[i][1], end = prerequisites[i][0];
        //        if (!map.ContainsKey(start))
        //            map.Add(start, new List<int>() { end });
        //        else
        //            map[start].Add(end);
        //    }
        //    //遍历各个点，如果没有深度大于课程总数的，那就证明没有成环的
        //    foreach (var key in map.Keys)
        //    {
        //        if (!FindCourse(map, key, numCourses))
        //            return false;
        //    }
        //    return true;
        //}

        //private bool FindCourse(Dictionary<int, List<int>> map, int start, int numCourses)
        //{
        //    if (!map.ContainsKey(start))
        //        return numCourses >= 1;
        //    if (numCourses < 1)
        //        return false;

        //    foreach (var end in map[start])
        //    {
        //        if (!FindCourse(map, end, numCourses - 1))
        //            return false;
        //    }
        //    return true;
        //}
    }
}
