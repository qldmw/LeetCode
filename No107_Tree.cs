using LeetCode.ExtensionFunction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode_107
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
    //        var res = solution.LevelOrderBottom(tn1);
    //        ConsoleX.WriteLine(res);
    //    }
    //}

    public class Solution
    {
        /// <summary>
        /// 迭代。递归解法就不写了，感觉写起来会稍微比迭代麻烦些
        /// 时间复杂度：O(n)，没有节点都遍历一次
        /// 空间复杂度：O(n)，一个节点一个int，所以是n
        /// Experience：树普遍来说都要两种解法，一种递归，一种遍历。多数情况下递归都更好，但是在这道题下，迭代是更方便的解法。
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<IList<int>> LevelOrderBottom(TreeNode root)
        {
            IList<IList<int>> res = new List<IList<int>>();
            if (root == null)
                return res;

            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                var levelRes = new List<int>();
                foreach (var tree in queue.ToList())
                {
                    queue.Dequeue();
                    levelRes.Add(tree.val);
                    if (tree.left != null)
                        queue.Enqueue(tree.left);
                    if (tree.right != null)
                        queue.Enqueue(tree.right);
                }
                res.Add(levelRes);
            }
            return res.Reverse().ToList();
        }
    }
}
