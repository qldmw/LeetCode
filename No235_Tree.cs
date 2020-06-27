using LeetCode.ExtensionFunction;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode_235
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
    //        int?[] data = new int?[] { 6, 2, 8, 0, 4, 7, 9, null, null, 3, 5 };
    //        //int?[] data = new int?[] { 1, 2, 2, 3, 3, null, null, 4, 4 };
    //        //int?[] data = new int?[] { 1, 2, null, 3 };
    //        //int?[] data = new int?[] { 1, 2, 2, 3, 3, 3, 3, 4, 4, 4, 4, 4, 4, null, null, 5, 5 };
    //        var tree = new DataStructureBuilder().BuildTree(data);
    //        var p = new TreeNode(3);
    //        var q = new TreeNode(5);
    //        var res = solution.LowestCommonAncestor(tree, p, q);
    //        ConsoleX.WriteLine(res);
    //    }
    //}

    /// <summary>
    /// Knowledge：二叉搜索树（BST）：
    ///     1.节点 N 左子树上的所有节点的值都小于等于节点 N 的值
    ///     2.节点 N 右子树上的所有节点的值都大于等于节点 N 的值    
    ///     3.左子树和右子树也都是 BST
    /// </summary>

    public class Solution
    {
        /// <summary>
        /// 利用二叉搜索树的特性，快速获得答案
        /// 时间复杂度：O(n)
        /// 空间复杂度：O(1)
        /// </summary>
        /// <param name="root"></param>
        /// <param name="p"></param>
        /// <param name="q"></param>
        /// <returns></returns>
        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            if (root == null)
                return null;
            TreeNode res = root;
            while (res != null)
            {
                if (res.val < p.val && res.val < q.val)//第二个if是因为不知道p和q的大小关系
                    res = res.right;
                else if (res.val > q.val && res.val > p.val)//第二个if是因为不知道p和q的大小关系
                    res = res.left;
                else
                    break;
            }
            return res;
        }

        /// <summary>
        /// 第一反应解，递归记录两个节点的路径，再来找最小父节点
        /// 时间复杂度：O(n)，找子节点是 O(n)，但是两个路径找共同的祖先的话，就要两次遍历，因为最差的情况下，
        ///     每条路径都会是n长度，这就变成了n²。从平均情况来看，路径应该为Logn长度，因为是二叉树，所以这
        ///     里的log应该是2为底，那么查找就是log 2 n的平方，就是n。所以算下来是 O(n)
        /// 空间复杂度：O(logn),最差情况 O(n)
        /// 没有利用上二叉搜索树这个特性，单纯的当做二叉树去搜索了
        /// </summary>
        /// <param name="root"></param>
        /// <param name="p"></param>
        /// <param name="q"></param>
        /// <returns></returns>
        //public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        //{
        //    if (root == null)
        //        return null;
        //    if (p == null)
        //        return q;
        //    if (q == null)
        //        return p;
        //    var pPath = FindPath(root, p.val, new List<TreeNode>());
        //    var qPath = FindPath(root, q.val, new List<TreeNode>());
        //    return pPath.Last(s => qPath.Contains(s));
        //}

        //private List<TreeNode> FindPath(TreeNode root, int target, List<TreeNode> path)
        //{
        //    if (root == null)
        //        return null;
        //    if (root.val == target)
        //    {
        //        path.Add(root);
        //        return path;
        //    }

        //    //到了叶子节点依然没有目标，返回空
        //    if (root.left == null && root.right == null)
        //        return null;
        //    else
        //    {
        //        path.Add(root);
        //        var leftPath = FindPath(root.left, target, path.ToList());
        //        var rightPath = FindPath(root.right, target, path.ToList());
        //        return leftPath != null ? leftPath : rightPath  != null ? rightPath : null;
        //    }
        //}
    }
}
