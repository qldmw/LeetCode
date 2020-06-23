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
                //string input2 = Console.ReadLine();
                //int[] intArr = input.Split(',').Select(s => int.Parse(s)).ToArray();
                //int input2 = int.Parse(Console.ReadLine());
                int[] intArr = new int[] { 1, 3, 2 };
                //int[] intArr = new int[] { 1, 3 };
                //TreeNode tn1 = new TreeNode(1);
                //TreeNode tn2 = new TreeNode(2);
                //TreeNode tn3 = new TreeNode(3);
                //tn1.left = tn2;
                //tn2.left = tn3;
                var res = solution.SortedArrayToBST(intArr);
                ConsoleX.WriteLine(res);
            }
        }

        public class Solution
        {
            /// <summary>
            /// 递归构建树
            /// 时间复杂度：O(n)
            /// 空间复杂度：O(n),二叉搜索树空间 O(n)，递归栈深度 O(logn)
            /// 递归构建树可以用引用传递去构建，也可以像这样去return TreeNode去构建，不要拘泥于一个方式了
            /// </summary>
            /// <param name="nums"></param>
            /// <returns></returns>
            public TreeNode SortedArrayToBST(int[] nums)
            {
                return BuildTree(nums, 0, nums.Length - 1);
            }

            public TreeNode BuildTree(int[] nums, int left, int right)
            {
                if (left > right) return null;

                int mid = (left + right) / 2;

                TreeNode root = new TreeNode(nums[mid]);
                root.left = BuildTree(nums, left, mid - 1);
                root.right = BuildTree(nums, mid + 1, right);
                return root;
            }
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