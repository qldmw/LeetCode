using LeetCode.ExtensionFunction;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode_226
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
    //        int?[] data = new int?[] { 1, 2, 3, 4, 5 };
    //        //int?[] data = new int?[] { 1, 2, 2, 3, 3, null, null, 4, 4 };
    //        //int?[] data = new int?[] { 1, 2, null, 3 };
    //        //int?[] data = new int?[] { 1, 2, 2, 3, 3, 3, 3, 4, 4, 4, 4, 4, 4, null, null, 5, 5 };
    //        var tree = new DataStructureBuilder().BuildTree(data);
    //        var res = solution.InvertTree(tree);
    //        ConsoleX.WriteLine(res);
    //    }
    //}

    /// <summary>
    /// REVIEW
    /// 2020.09.16: 每日一题，这道题反复鞭尸，翻转二叉树的梗看来是跳不过去了。
    /// </summary>

    public class Solution
    {
        /// <summary>
        /// 优化第一反应解
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public TreeNode InvertTree(TreeNode root)
        {
            if (root == null)
                return null;

            var temp = InvertTree(root.left);
            root.left = InvertTree(root.right);
            root.right = temp;

            return root;
        }

        /// <summary>
        /// 第一反应解
        /// 时间复杂度：O(n)
        /// 空间复杂度：O(n), 最优 O(logn)，最差 O(n)
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        //public TreeNode InvertTree(TreeNode root)
        //{
        //    if (root == null)
        //        return null;

        //    var temp = root.left;
        //    root.left = root.right;
        //    root.right = temp;

        //    InvertTree(root.left);
        //    InvertTree(root.right);

        //    return root;
        //}
    }
}
