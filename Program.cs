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
            public TreeNode SortedArrayToBST(int[] nums)
            {

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