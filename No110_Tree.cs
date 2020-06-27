using LeetCode.ExtensionFunction;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode_110
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
    //        int?[] data = new int?[] { 3, 9, 20, null, null, 15, 7 };
    //        //int?[] data = new int?[] { 1, 2, 2, 3, 3, null, null, 4, 4 };
    //        //int?[] data = new int?[] { 1, 2, null, 3 };
    //        //int?[] data = new int?[] { 1, 2, 2, 3, 3, 3, 3, 4, 4, 4, 4, 4, 4, null, null, 5, 5 };
    //        var tree = new DataStructureBuilder().BuildTree(data);
    //        var res = solution.IsBalanced(tree);
    //        ConsoleX.WriteLine(res);
    //    }
    //}

    public class Solution
    {
        /// <summary>
        /// 自底向上的递归
        /// 时间复杂度：O(n)，题解的方法多做了一遍，所以比题解给的快
        /// 空间复杂度：O(logn)，还是二叉树的可能性问题，最优logn，最差n
        /// 题解里还有一个自顶而下的解法，但是效率更差，我实在想不到为什么要那样递归，索性不看也罢。学个差的不合自己逻辑的，感觉也没多大意思
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public bool IsBalanced(TreeNode root)
        {
            _ = RecusiveTree(root, 1);
            return IsBalancedMark;
        }
        private bool IsBalancedMark = true;
        private int RecusiveTree(TreeNode root, int level)
        {
            //这里可以加一个优化，如果发现mark已经为false了，就直接返回了，不再递归了
            if (!IsBalancedMark)
                return -1;

            if (root == null)
                return level - 1;
            else if (root.left == null && root.right == null)
                return level;
            else
            {
                int leftLevel = RecusiveTree(root.left, level + 1);
                int rightLevel = RecusiveTree(root.right, level + 1);
                if (Math.Abs(leftLevel - rightLevel) > 1)
                    IsBalancedMark = false;
                return Math.Max(leftLevel, rightLevel);
            }
        }
    }
}
