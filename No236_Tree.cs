using LeetCode.ExtensionFunction;
using System;
using System.Collections.Generic;
using System.Extension;
using System.Text;

namespace LeetCode_236
{
    class No236_Tree
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
        //        var builder = new DataStructureBuilder();
        //        int?[] data = new int?[] { 3, 5, 1, 6, 2, 0, 8, null, null, 7, 4 };
        //        var tree = builder.BuildTree(data);
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

        //        var res = solution.LowestCommonAncestor(tree, new TreeNode(5), new TreeNode(1));
        //        ConsoleX.WriteLine(res);
        //    }
        //}

        public class Solution
        {
            //best answer(most readable), copy from record chart
            public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
            {
                if (root == p || root == q || root == null) return root;

                TreeNode left = LowestCommonAncestor(root.left, p, q);
                TreeNode right = LowestCommonAncestor(root.right, p, q);

                if (left != null && right == null) return left;
                else if (right != null && left == null) return right;
                else if (right != null && left != null) return root;
                else return null;

            }
        }

        //public class Solution
        //{
        //    private TreeNode _answer;

        //    /// <summary>
        //    /// 递归解决
        //    /// 时间复杂度：O(n)
        //    /// 空间复杂度：O(n)
        //    /// </summary>
        //    /// <param name="root"></param>
        //    /// <param name="p"></param>
        //    /// <param name="q"></param>
        //    /// <returns></returns>
        //    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        //    {
        //        Recurse(root);
        //        return _answer;

        //        bool Recurse(TreeNode node)
        //        {
        //            //如果节点为空，或者已经找到答案了，返回
        //            if (node == null || _answer != null)
        //                return false;
        //            //当前节点是否等于 p 或者 q
        //            bool isNodeValEqual = node.val == p.val || node.val == q.val;
        //            //如果当前节点是叶子节点，而且等于 p 或者 q，那么返回 true
        //            if (isNodeValEqual && node.left == null && node.right == null)
        //                return true;
        //            //递归左右子树
        //            bool leftRes = Recurse(node.left);
        //            bool rightRes = Recurse(node.right);
        //            //如果左右子树都找到了目标；或者当前节点是其中一个，而且左右子树中有一个找到了目标，那么就已经找到了答案
        //            if ((leftRes && rightRes) || (isNodeValEqual && (leftRes || rightRes)))
        //                _answer = node;
        //            //左右子树和当前节点，任意一个为 true 就返回 true
        //            return leftRes || rightRes || isNodeValEqual;
        //        }
        //    }
        //}
    }
}