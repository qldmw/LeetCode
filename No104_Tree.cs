using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode_104
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
    //        //int[] intArr = new int[] { 1, 3, 2 };
    //        //int[] intArr = new int[] { 1, 3 };
    //        TreeNode tn1 = new TreeNode(1);
    //        TreeNode tn2 = new TreeNode(2);
    //        TreeNode tn3 = new TreeNode(3);
    //        tn1.left = tn2;
    //        tn2.left = tn3;
    //        var res = solution.MaxDepth(tn1);
    //        ConsoleX.WriteLine(res);
    //    }
    //}

    public class Solution
    {
        /// <summary>
        /// 迭代，相比而言还是递归更优雅
        /// 时间复杂度：O(n)
        /// 空间复杂度：O(n)
        /// 用到了一个新的数据结构KeyValuePair，struct，readonly
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int MaxDepth(TreeNode root)
        {
            Queue<KeyValuePair<TreeNode, int>> queue = new Queue<KeyValuePair<TreeNode, int>>();
            int maxDepth = 0;
            queue.Enqueue(new KeyValuePair<TreeNode, int>(root, 0));
            while (queue.Count > 0)
            {
                var cur_tree = queue.Dequeue();
                if (cur_tree.Key != null)
                {
                    maxDepth = Math.Max(maxDepth, cur_tree.Value + 1);
                    queue.Enqueue(new KeyValuePair<TreeNode, int>(cur_tree.Key.left, cur_tree.Value + 1));
                    queue.Enqueue(new KeyValuePair<TreeNode, int>(cur_tree.Key.right, cur_tree.Value + 1));
                }
            }
            return maxDepth;
        }

        /// <summary>
        /// 递归
        /// 时间复杂度：我们每个结点只访问一次，因此时间复杂度为 O(n)
        /// 空间复杂度：在最糟糕的情况下，树是完全不平衡的，例如每个结点只剩下左子结点，递归将会被调用 n 次（树的高度），
        /// 因此保持调用栈的存储将是 O(n)。但在最好的情况下（树是完全平衡的），树的高度将是 log(n)。因此，在这种情况下的空间复杂度将是 O(log(n))。
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        //public int MaxDepth(TreeNode root)
        //{
        //    return SearchTree(root, 0);
        //}

        //private int SearchTree(TreeNode tree, int curDepth)
        //{
        //    if (tree == null)
        //        return curDepth;
        //    else
        //        return Math.Max(SearchTree(tree.left, curDepth + 1), SearchTree(tree.right, curDepth + 1));
        //}
    }

    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }
}
