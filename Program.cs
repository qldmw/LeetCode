using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Extension;
using LeetCode.ExtensionFunction;

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
                //string input2 = Console.ReadLine();
                //int[] intArr = input.Split(',').Select(s => int.Parse(s)).ToArray();
                //int input2 = int.Parse(Console.ReadLine());
                int?[] data = new int?[] { 6, 2, 8, 0, 4, 7, 9, null, null, 3, 5 };
                //int?[] data = new int?[] { 1, null, 2, 3 };
                //int?[] data = new int?[] { 1, 2, 2, 3, 3, null, null, 4, 4 };
                //int?[] data = new int?[] { 1, 2, null, 3 };
                //int?[] data = new int?[] { 1, 2, 2, 3, 3, 3, 3, 4, 4, 4, 4, 4, 4, null, null, 5, 5 };
                var tree = new DataStructureBuilder().BuildTree(data);
                var res = solution.InorderTraversal(tree);
                ConsoleX.WriteLine(res);
            }
        }

        /// <summary>
        /// Knowledge：线索二叉树：在二叉树的结点上加上线索的二叉树称为线索二叉树，对二叉树以某种遍历方式（如先序、中序、后序或层次等）进行遍历，
        /// 使其变为线索二叉树的过程称为对二叉树进行线索化。
        /// 优势
        /// (1)利用线索二叉树进行中序遍历时，不必采用堆栈处理，速度较一般二叉树的遍历速度快，且节约存储空间。
        /// (2)任意一个结点都能直接找到它的前驱和后继结点。
        /// 不足
        /// (1)结点的插入和删除麻烦，且速度也较慢。
        /// (2)线索子树不能共用。
        /// </summary>

        public class Solution
        {
            /// <summary>
            /// 莫里斯(morris)遍历法，使用线索二叉树来解决（其实就是一个List，通过算法把树状结构变成线性结构）
            /// 时间复杂度：O(n), 想要证明时间复杂度是 O(n)，最大的问题是找到每个节点的前驱节点的时间复杂度。乍一想，找到每个节点的前驱节点的时间复杂度
            ///     应该是 O(nlogn)，因为找到一个节点的前驱节点和树的高度有关。但事实上，找到所有节点的前驱节点只需要 O(n) 时间。一棵 n 个节点的二叉树只有
            ///     n−1 条边，每条边只可能使用2次，一次是定位节点，一次是找前驱节点。故复杂度为 O(n)。
            /// 空间复杂度：O(n),使用了长度为n的数组。
            /// </summary>
            /// <param name="root"></param>
            /// <returns></returns>
            public IList<int> InorderTraversal(TreeNode root)
            {
                /// 算法实现思想：
                /// Step 1: 将当前节点current初始化为根节点
                /// Step 2: While current不为空，
                /// 若current没有左子节点
                ///     a.将current添加到输出
                ///     b.进入右子树，亦即, current = current.right
                /// 否则
                ///     a.在current的左子树中，令current成为最右侧节点的右子节点
                ///     b.进入左子树，亦即，current = current.left
                IList<int> res = new List<int>();
                TreeNode curr = root;
                TreeNode pre;
                while (curr != null)
                {
                    if (curr.left == null)
                    {
                        res.Add(curr.val);
                        curr = curr.right; // move to next right node
                    }
                    else
                    { // has a left subtree
                        pre = curr.left;
                        while (pre.right != null)
                        { // find rightmost
                            pre = pre.right;
                        }
                        pre.right = curr; // put cur after the pre node
                        TreeNode temp = curr; // store cur node
                        curr = curr.left; // move cur to the top of the new tree
                        temp.left = null; // original cur left be null, avoid infinite loops
                    }
                }
                return res;
            }

            /// <summary>
            /// 官方给的简短的迭代解法
            /// </summary>
            /// <param name="root"></param>
            /// <returns></returns>
            //public IList<int> InorderTraversal(TreeNode root)
            //{
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
            //        res.Add(curr.val);
            //        curr = curr.right;
            //    }
            //    return res;
            //}

            /// <summary>
            /// 迭代完成中序遍历
            /// 时间复杂度：O(n)
            /// 空间复杂度：O(n)
            /// 处理的复杂了，其实可以不必记录待处理的节点还有哪些节点没有遍历。不过这样思路会清晰一些
            /// </summary>
            /// <param name="root"></param>
            /// <returns></returns>
            //public IList<int> InorderTraversal(TreeNode root)
            //{
            //    IList<int> traversal = new List<int>();
            //    List<KeyValuePair<TreeNode, int>> nodes = new List<KeyValuePair<TreeNode, int>>();
            //    //采用待处理的方式，需要处理的推入到待处理列表中。3代表需要左中右遍历，2代表需要中右遍历，1代表需要右遍历，0代表已经遍历完成
            //    nodes.Add(new KeyValuePair<TreeNode, int>(root, 3));
            //    while (nodes.Count > 0)
            //    {
            //        int curIndex = nodes.Count - 1;
            //        var node = nodes[curIndex];
            //        switch (node.Value)
            //        {
            //            case 3:
            //                {
            //                    if (node.Key != null && node.Key.left != null)
            //                        nodes.Add(new KeyValuePair<TreeNode, int>(node.Key.left, 3));
            //                    nodes[curIndex] = new KeyValuePair<TreeNode, int>(node.Key, node.Value - 1);
            //                    break;
            //                }
            //            case 2:
            //                {
            //                    if (node.Key != null)
            //                        traversal.Add(node.Key.val);
            //                    nodes[curIndex] = new KeyValuePair<TreeNode, int>(node.Key, node.Value - 1);
            //                    break;
            //                }
            //            case 1:
            //                {
            //                    if (node.Key != null && node.Key.right != null)
            //                        nodes.Add(new KeyValuePair<TreeNode, int>(node.Key.right, 3));
            //                    nodes[curIndex] = new KeyValuePair<TreeNode, int>(node.Key, node.Value - 1);
            //                    break;
            //                }
            //            case 0:
            //            default:
            //                {
            //                    nodes.RemoveAt(curIndex);
            //                    break;
            //                }
            //        }
            //    }
            //    return traversal;
            //}

            /// <summary>
            /// 递归完成中序遍历
            /// 时间复杂度：O(n)
            /// 空间复杂度：最优O(logn)，最差O(n)
            /// </summary>
            /// <param name="root"></param>
            /// <returns></returns>
            //public IList<int> InorderTraversal(TreeNode root)
            //{
            //    var res = new List<int>();
            //    if (root == null)
            //        return res;
            //    if (root.left != null)
            //        res.AddRange(InorderTraversal(root.left));
            //    res.Add(root.val);
            //    if (root.right != null)
            //        res.AddRange(InorderTraversal(root.right));
            //    return res;
            //}
        }
    }
}