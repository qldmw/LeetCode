using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode_547
{
    //static void Main(string[] args)
    //{
    //    var solution = new Solution();
    //    while (true)
    //    {
    //        //int input = int.Parse(Console.ReadLine());
    //        //int input2 = int.Parse(Console.ReadLine());
    //        //int input3 = int.Parse(Console.ReadLine());
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
    //        //int[] nums1 = new int[] { 1, 2, 3 };
    //        //int[] nums2 = new int[] { 1, 1 };
    //        //IList<IList<int>> data = new List<IList<int>>()
    //        //{
    //        //    new List<int>() { 1, 3 },
    //        //    new List<int>() { 3, 0, 1 },
    //        //    new List<int>() { 2 },
    //        //    new List<int>() { 0 }

    //        //    //new List<int>() { 1 },
    //        //    //new List<int>() { 2 },
    //        //    //new List<int>() { 3 },
    //        //    //new List<int>() {  }
    //        //};
    //        int[][] arr = new int[4][] { new int[] { 1, 0, 0, 1 }, new int[] { 0, 1, 1, 0 }, new int[] { 0, 1, 1, 1 }, new int[] { 1, 0, 1, 1 } };
    //        var res = solution.FindCircleNum(arr);
    //        ConsoleX.WriteLine(res);
    //    }
    //}

    public class Solution
    {
        /// <summary>
        /// 深度优先搜索
        /// 设 isConnected.Length 为 n
        /// 时间复杂度：O(n²), 所有的点走一遍就可以了
        /// 空间复杂度：O(n), 路径的记录是 n, 然后递归的栈空间最大 n,最小 1。
        /// </summary>
        /// <param name="isConnected"></param>
        /// <returns></returns>
        public int FindCircleNum(int[][] isConnected)
        {
            //所有走过的路径
            var visited = new HashSet<int>();
            int res = 0;
            for (int i = 0; i < isConnected.Length; i++)
            {
                if (DFS(i))
                    res++;
            }
            return res;

            //一直往后找。（错误思想！比如 1 连到 4，然后 4 又连到 3，3又连到其他。这种情况是要向前的）
            bool DFS(int index)
            {
                //如果已经连接过了则返回，否则加入到走过的路径中
                if (visited.Contains(index))
                    return false;
                else
                    visited.Add(index);
                //搜索该点能连接的所有点
                for (int i = 0; i < isConnected.Length; i++)
                {
                    int isConnect = isConnected[index][i];
                    if (isConnect == 1)
                        DFS(i);
                }
                return true;
            }
        }
    }
}
