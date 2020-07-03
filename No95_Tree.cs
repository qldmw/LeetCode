using LeetCode.ExtensionFunction;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode_95
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
    //        //int?[] data = new int?[] { 6, 2, 8, 0, 4, 7, 9, null, null, 3, 5 };
    //        //var tree = new DataStructureBuilder().BuildTree(data);
    //        var res = solution.GenerateTrees(3);
    //        ConsoleX.WriteLine(res);
    //    }
    //}

    /// <summary>
    /// Knowledge：卡特兰数：卡特兰数是组合数学中一个常出现在各种计数问题中的数列。
    /// 以比利时的数学家欧仁·查理·卡塔兰 (1814–1894)的名字来命名，其前几项为（从第零项开始） : 
    /// 1, 1, 2, 5, 14, 42, 132, 429, 1430, 4862, 16796, 58786, 208012, 742900, 2674440, 9694845, 35357670, 129644790, 477638700, 1767263190, 6564120420, 24466267020, 91482563640, 343059613650, 1289904147324, 4861946401452, ...
    /// </summary>

    public class Solution
    {
        /// <summary>
        /// 基于两边结果组合的递归
        /// 时间复杂度：O(4ⁿ/n 1/2)，主要的计算开销在于构建给定根的全部可能树，也就是卡特兰数 Gn 。该过程重复了 n 次，也就是 nGn 。卡特兰数以 4ⁿ/n 3/2增长。
        /// 空间复杂度：O(4ⁿ/n 3/2)
        /// 很有趣的一个递归思路，可以多做参考
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public List<TreeNode> GenerateTrees(int n)
        {
            if (n == 0)
                return new List<TreeNode>();
            return RecursivelyBuildTree(1, n);
        }

        private List<TreeNode> RecursivelyBuildTree(int start, int end)
        {
            List<TreeNode> allNodes = new List<TreeNode>();
            if (start > end)
            {
                allNodes.Add(null);
                return allNodes;
            }
            for (int i = start; i <= end; i++)
            {
                var leftTree = RecursivelyBuildTree(start, i - 1);
                var rightTree = RecursivelyBuildTree(i + 1, end);

                //这里是这道理的题眼，一般的递归解题都是单独的解，不会有这种基于另一边递归结果返回的情况。这里需要通过左右搭配才能获得答案
                foreach (var leftNode in leftTree)
                {
                    foreach (var rightNode in rightTree)
                    {
                        var node = new TreeNode(i);
                        node.left = leftNode;
                        node.right = rightNode;
                        allNodes.Add(node);
                    }
                }
            }
            return allNodes;
        }
    }
}
