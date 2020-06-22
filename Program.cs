using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Extension;

namespace LeetCode
{
    class Program
    {
        static void Main(string[] args)
        {
            var solution = new Solution();
            while (true)
            {
                //int input = int.Parse(Console.ReadLine());
                //int input2 = int.Parse(Console.ReadLine());
                //int input3 = int.Parse(Console.ReadLine());
                //string input = Console.ReadLine();
                //string input = "A man, a plan, a canal: Panama";
                //string input2 = Console.ReadLine();
                //int[] intArr = input.Split(',').Select(s => int.Parse(s)).ToArray();
                //int input2 = int.Parse(Console.ReadLine());
                //int[] intArr = new int[] { 1, 3, 2 };
                //int[] intArr = new int[] { 1, 3 };
                TreeNode tn1 = new TreeNode(1);
                TreeNode tn2 = new TreeNode(2);
                var res = solution.IsSameTree(tn1, tn2);
                ConsoleX.WriteLine(res);
            }
        }

        public class Solution
        {
            /// <summary>
            /// 看了其他题解，简化了一下代码，思想和下面的第一反应解是一样的
            /// </summary>
            /// <param name="p"></param>
            /// <param name="q"></param>
            /// <returns></returns>
            public bool IsSameTree(TreeNode p, TreeNode q)
            {
                if (p == null && q == null)
                    return true;
                else if (p == null || q == null || p.val != q.val)
                    return false;
                else
                    return IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right);
            }

            /// <summary>
            /// 递归解决
            /// 时间复杂度：O(n)，其中 N 是树的结点数，因为每个结点都访问一次。
            /// 空间复杂度：最优情况（完全平衡二叉树）时为 O(log(n))，最坏情况下（完全不平衡二叉树）时为 O(n)，用于维护递归栈。(复杂度也就是递归的深度)
            /// 还有一个解法是通过遍历两棵树（好像是先序遍历），把节点分别放到两个记录的queue里，然后再来对比。
            /// </summary>
            /// <param name="p"></param>
            /// <param name="q"></param>
            /// <returns></returns>
            //public bool IsSameTree(TreeNode p, TreeNode q)
            //{
            //    if (p == null && q == null)
            //        return true;
            //    else if ((p == null && q != null) || (q == null && p != null))
            //        return false;

            //    if (IsTreeInSameState(p, q))
            //    {
            //        return IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right);
            //    }
            //    else
            //        return false;
            //}

            //private bool IsTreeInSameState(TreeNode p, TreeNode q)
            //{
            //    bool pLIsnull = p.left == null;
            //    bool pRIsnull = p.right == null;
            //    bool qLIsnull = q.left == null;
            //    bool qRIsnull = q.right == null;
            //    return p.val == q.val && pLIsnull == qLIsnull && pRIsnull == qRIsnull;
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
}