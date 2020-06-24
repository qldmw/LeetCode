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
                //int?[] data = new int?[] { 3, 9, 20, null, null, 15, 7 };
                //int?[] data = new int?[] { 1, 2, 2, 3, 3, null, null, 4, 4 };
                //int?[] data = new int?[] { 1, 2, null, 3 };
                int?[] data = new int?[] { 1, 2, 2, 3, 3, 3, 3, 4, 4, 4, 4, 4, 4, null, null, 5, 5 };
                var tree = new DataStructureBuilder().BuildTree(data);
                var res = solution.IsBalanced(tree);
                ConsoleX.WriteLine(res);
            }
        }

        public class Solution
        {
            public bool IsBalanced(TreeNode root)
            {
                if (root == null)
                    return true;

                int noChildLevel = int.MaxValue;
                int curLevle = 0;
                Queue<TreeNode> queue = new Queue<TreeNode>();
                queue.Enqueue(root);
                while (queue.Count > 0)
                {
                    curLevle++;
                    foreach (var tree in queue.ToList())
                    {
                        root = queue.Dequeue();
                        if (!(root.left != null && root.right != null))
                            noChildLevel = Math.Min(curLevle, noChildLevel);

                        if (root.left != null)
                            queue.Enqueue(root.left);
                        if (root.right != null)
                            queue.Enqueue(root.right);
                    }
                }
                return curLevle - noChildLevel <= 1;
            }
        }
    }
}