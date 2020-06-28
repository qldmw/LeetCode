using LeetCode.ExtensionFunction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode_257
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
    //        //int?[] data = new int?[] { 1, null, 2, 3 };
    //        //int?[] data = new int?[] { 1, 2, 2, 3, 3, null, null, 4, 4 };
    //        //int?[] data = new int?[] { 1, 2, null, 3 };
    //        //int?[] data = new int?[] { 1, 2, 2, 3, 3, 3, 3, 4, 4, 4, 4, 4, 4, null, null, 5, 5 };
    //        var res = solution.BinaryTreePaths(tree);
    //        ConsoleX.WriteLine(res);
    //    }
    //}

    public class Solution
    {
        /// <summary>
        /// 递归
        /// 时间复杂度：O(n)
        /// 空间复杂度：最优O(logn),最差O(n)
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<string> BinaryTreePaths(TreeNode root)
        {
            RecurseTree(root, new List<int>());
            IList<string> ans = new List<string>();
            foreach (var m in res)
            {
                ans.Add(string.Join("->", m));
            }
            return ans;
        }

        private IList<IList<int>> res = new List<IList<int>>();
        private void RecurseTree(TreeNode root, IList<int> path)
        {
            if (root == null)
                return;
            else
                path.Add(root.val);

            if (root.left == null && root.right == null)
                res.Add(path);

            if (root.left != null)
                RecurseTree(root.left, path.ToList());
            if (root.right != null)
                RecurseTree(root.right, path.ToList());
        }
    }
}
