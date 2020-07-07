using LeetCode.ExtensionFunction;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode_124
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
    //        var builder = new DataStructureBuilder();
    //        //int?[] data = new int?[] { 10, 5, 15, null, null, 6, 20 };
    //        int?[] data = new int?[] { -10, 9, 20, null, null, 15, 7 };
    //        //int?[] data = new int?[] { -2147483648, null, 2147483647 };
    //        //int?[] data = new int?[] { 1, 3, null, null, 2 };
    //        var tree = builder.BuildTree(data);
    //        //var listNode = builder.BuildListNode(new int[] { 4, 2, 4, 1, 1, 1 });
    //        //var listNode2 = builder.BuildListNode(new int[] { 5, 6});
    //        //listNode2.next.next = listNode.next.next.next.next;
    //        var res = solution.MaxPathSum(tree);
    //        ConsoleX.WriteLine(res);
    //    }
    //}

    public class Solution
    {
        /// <summary>
        /// 递归。和以前一道math题差不多，求子串中最大和，一道给信心的hard题
        /// 时间复杂度：O(n)
        /// 空间复杂度：O(n), 其中 N 是二叉树中的节点个数。空间复杂度主要取决于递归调用层数，最大层数等于二叉树的高度，最坏情况下，二叉树的高度等于二叉树中的节点个数。
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int MaxPathSum(TreeNode root)
        {
            _ = FindMaxValue(root);
            return _max;
        }

        private int _max = int.MinValue;
        private int FindMaxValue(TreeNode root)
        {
            //如果为空返回0，不影响计算
            if (root == null)
                return 0;

            int nodeVal = root.val;
            int leftVal = FindMaxValue(root.left);
            int rightVal = FindMaxValue(root.right);

            //三条路径中取最大的路径
            int cur_max = Math.Max(Math.Max(nodeVal, nodeVal + leftVal), nodeVal + rightVal);

            //当前路径和大于当前最大值时，赋值
            if (cur_max > _max)
                _max = cur_max;

            //当以当前节点作为连接时（这是一个特别情况）
            if (leftVal + rightVal + nodeVal > _max)
                _max = leftVal + rightVal + nodeVal;

            return cur_max > 0 ? cur_max : 0;
        }
    }
}
