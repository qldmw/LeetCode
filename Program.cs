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
                //string input = Console.ReadLine();
                //string input2 = Console.ReadLine();
                //int[] intArr = input.Split(',').Select(s => int.Parse(s)).ToArray();
                //int input2 = int.Parse(Console.ReadLine());
                //int?[] data = new int?[] { 6, 2, 8, 0, 4, 7, 9, null, null, 3, 5 };
                //var tree = new DataStructureBuilder().BuildTree(data);
                var res = solution.GenerateTrees(3);
                ConsoleX.WriteLine(res);
            }
        }

        public class Solution
        {
            public List<TreeNode> GenerateTrees(int n)
            {
                if (n == 0)
                {
                    return new List<TreeNode>();
                }
                return generate_trees(1, n);
            }

            public List<TreeNode> generate_trees(int start, int end)
            {
                List<TreeNode> all_trees = new List<TreeNode>();
                if (start > end)
                {
                    all_trees.Add(null);
                    return all_trees;
                }

                // pick up a root
                for (int i = start; i <= end; i++)
                {
                    // all possible left subtrees if i is choosen to be a root
                    List<TreeNode> left_trees = generate_trees(start, i - 1);

                    // all possible right subtrees if i is choosen to be a root
                    List<TreeNode> right_trees = generate_trees(i + 1, end);

                    // connect left and right trees to the root i
                    foreach (TreeNode l in left_trees)
                    {
                        foreach (TreeNode r in right_trees)
                        {
                            TreeNode current_tree = new TreeNode(i);
                            current_tree.left = l;
                            current_tree.right = r;
                            all_trees.Add(current_tree);
                        }
                    }
                }
                return all_trees;
            }
        }
    }
}