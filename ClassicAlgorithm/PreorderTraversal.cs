using LeetCode.ExtensionFunction;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.ClassicAlgorithm
{
    class PreorderTraversal
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
        //        int?[] data = new int?[] { 1, 2, 3, 4, 5, null, 6, null, null, 7, 8 };
        //        var tree = builder.BuildTree(data);
        //        //var listNode = builder.BuildListNode(new int[] { 1, 4, 5 });
        //        //int[][] arr = new int[3][] { new int[] { 1, 3, 1 }, new int[] { 1, 5, 1 }, new int[] { 4, 2, 1 } };
        //        //int[] nums1 = new int[] { 2, 1, 7, 5, 6, 4, 3 };
        //        //int[] nums1 = new int[] { 2, 1, 1, 5, 11, 5, 1, 7, 5, 6, 4, 3 };
        //        //int[] nums2 = new int[] { 10, 15, 20 };
        //        //string input = "adceb";
        //        //string input2 = "*a*b";
        //        var res = solution.PreorderTraversal(tree);
        //        ConsoleX.WriteLine(res);
        //    }
        //}

        public class Solution
        {
            /// <summary>
            /// 先序遍历（根左右）
            /// </summary>
            /// <param name="tree"></param>
            /// <returns></returns>
            public int[] PreorderTraversal(TreeNode tree)
            {
                if (tree == null)
                    return new int[0];

                List<int> res = new List<int>();
                //Recurse(tree, res);
                //return res.ToArray();
                return Iterate(tree).ToArray();
            }

            /// <summary>
            /// 递归实现
            /// 时间复杂度：O(n)
            /// 空间复杂度：O(logn)。最差跌落到 O(n)，既一条链的树的情况下
            /// </summary>
            /// <param name="tree"></param>
            /// <param name="res"></param>
            private void Recurse(TreeNode tree, List<int> res)
            {
                //存入根节点
                res.Add(tree.val);
                //递归左子树
                if (tree.left != null)
                    Recurse(tree.left, res);
                if (tree.right != null)
                    Recurse(tree.right, res);
            }

            /// <summary>
            /// 迭代实现
            /// 时间复杂度：O(n)
            /// 空间复杂度：O(logn),最差 O(n)
            /// </summary>
            /// <param name="tree"></param>
            /// <returns></returns>
            private List<int> Iterate(TreeNode tree)
            {
                List<int> res = new List<int>();
                Stack<TreeNode> stack = new Stack<TreeNode>();
                if (tree != null)
                    stack.Push(tree);
                while (stack.Count > 0)
                {
                    var cur = stack.Pop();
                    //把根节点加入到结果
                    res.Add(cur.val);
                    //先加入右子树，再加入左子树，这样就可以保证遍历顺序是左然后再是右
                    if (cur.right != null)
                        stack.Push(cur.right);
                    if (cur.left != null)
                        stack.Push(cur.left);
                }
                return res;
            }
        }
    }
}
