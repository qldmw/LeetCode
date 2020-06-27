using LeetCode.ExtensionFunction;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode_112
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
    //        var res = solution.HasPathSum(tree, 1);
    //        ConsoleX.WriteLine(res);
    //    }
    //}

    public class Solution
    {
        /// <summary>
        /// 第一反应解的写法优化版本
        /// </summary>
        /// <param name="root"></param>
        /// <param name="sum"></param>
        /// <returns></returns>
        public bool HasPathSum(TreeNode root, int sum)
        {
            if (root == null)
                return false;

            int temp = sum - root.val;
            if (root.left == null && root.right == null)
                return temp == 0;
            return HasPathSum(root.left, temp) || HasPathSum(root.right, temp);
        }

        /// <summary>
        /// 递归（深度优先)，找到之后就修改标记
        /// 时间复杂度：O(n)，最差情况会都遍历一次
        /// 空间复杂度：O(n)，二叉树的特性，平衡 O(logn)，超级不平衡 O(n)
        /// 因为有逻辑运算的短路原则，所以 left || right 这种写法不会造成所有都遍历
        /// </summary>
        /// <param name="root"></param>
        /// <param name="sum"></param>
        /// <returns></returns>
        //public bool HasPathSum(TreeNode root, int sum)
        //{
        //    _targetSum = sum;
        //    RecursiveTree(root, 0);
        //    return _hasPath;
        //}

        //private int _targetSum;
        //private bool _hasPath = false;
        //private void RecursiveTree(TreeNode root, int sum)
        //{
        //    if (root == null || _hasPath)
        //        return;
        //    else if (root.left == null && root.right == null)
        //    {
        //        if (sum + root.val == _targetSum)
        //        {
        //            _hasPath = true;
        //            return;
        //        }
        //    }

        //    if (root.left != null)
        //        RecursiveTree(root.left, sum + root.val);
        //    if (root.right != null)
        //        RecursiveTree(root.right, sum + root.val);
        //}
    }
}
