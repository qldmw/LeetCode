using LeetCode.ExtensionFunction;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode_98
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
    //        int?[] data = new int?[] { 10, 5, 15, null, null, 6, 20 };
    //        //int?[] data = new int?[] { 6, 2, 8, 0, 4, 7, 9, null, null, 3, 5 };
    //        //int?[] data = new int?[] { -2147483648, null, 2147483647 };
    //        var tree = builder.BuildTree(data);
    //        //var listNode = builder.BuildListNode(new int[] { 1, 2, 3, 4, 7, 8 });
    //        //var listNode2 = builder.BuildListNode(new int[] { 5, 6});
    //        //listNode2.next.next = listNode.next.next.next.next;
    //        var res = solution.IsValidBST(tree);
    //        ConsoleX.WriteLine(res);
    //    }
    //}

    public class Solution
    {
        /// <summary>
        /// 第一反应解(递归)的写法优化
        /// 后记：看了解题里还有一种很有意思的递归，它只维护一个最小值，判断条件也只有一个，大于最小值。因为是深度优先的遍历，所以这个做法是可行的
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public bool IsValidBST(TreeNode root)
        {
            return VerifyTree(root, null, null);
        }

        private bool VerifyTree(TreeNode root, int? min, int? max)
        {
            if (root == null)
                return true;
            if ((min != null && root.val <= min) || (max != null && root.val >= max))
                return false;
            return VerifyTree(root.left, min, root.val) && VerifyTree(root.right, root.val, max);
        }

        /// <summary>
        /// 递归。有个坑点，不能只关注最近节点，因为二叉搜索树要求的是所有左节点都小于根节点，所有有节点都大于根节点
        /// 时间复杂度：O(n)
        /// 空间复杂度：最优O(log n)，最差O(n)，因为return之后这个函数空间就没人用了，所以只会维持一条长链。
        /// 刚开始做的又是用变量名为 ClosestLeftRootValue 和 ClosestRightRootValue ，结果绕一下就晕了，换成 min 和 max 之后很快就理清了，所以适当抽象还是很好的，原本的描述可能反而不好。
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        //public bool IsValidBST(TreeNode root)
        //{
        //    if (root == null)
        //        return true;
        //    return VerifyLeftTree(root.left, null, root.val) && VerifyRightTree(root.right, root.val, null);
        //}

        //private bool VerifyLeftTree(TreeNode root, int? min, int max)
        //{
        //    if (root == null)
        //        return true;
        //    if (root.val >= max || (min != null && root.val <= min))
        //        return false;
        //    return VerifyLeftTree(root.left, min, root.val) && VerifyRightTree(root.right, root.val, max);
        //}

        //private bool VerifyRightTree(TreeNode root, int min, int? max)
        //{
        //    if (root == null)
        //        return true;
        //    if ((max != null && root.val >= max) || root.val <= min)
        //        return false;
        //    return VerifyLeftTree(root.left, min, root.val) && VerifyRightTree(root.right, root.val, max);
        //}

        /// <summary>
        /// 中序遍历。如果遍历过程中入队了一个不满足条件的数，则证明不是合法的二叉搜索树
        /// 时间复杂度：O(n)
        /// 空间复杂度：O(n)
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        //public bool IsValidBST(TreeNode root)
        //{
        //    bool isValid = true;
        //    IList<int> res = new List<int>();
        //    Stack<TreeNode> stack = new Stack<TreeNode>();
        //    TreeNode curr = root;
        //    while (curr != null || stack.Count > 0)
        //    {
        //        while (curr != null)
        //        {
        //            stack.Push(curr);
        //            curr = curr.left;
        //        }
        //        curr = stack.Pop();
        //        //中序遍历中加一个判断，如果大于等于最后一个，就不满足二叉搜索树条件
        //        if (res.Count != 0 && res.Last() >= curr.val)
        //        {
        //            isValid = false;
        //            break;
        //        }
        //        res.Add(curr.val);
        //        curr = curr.right;
        //    }
        //    return isValid;
        //}
    }
}
