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
                string input = Console.ReadLine();
                //string input2 = Console.ReadLine();
                //int[] intArr = input.Split(',').Select(s => int.Parse(s)).ToArray();
                //int input2 = int.Parse(Console.ReadLine());
                //var builder = new DataStructureBuilder();
                //int?[] data = new int?[] { 10, 5, 15, null, null, 6, 20 };
                //var tree = builder.BuildTree(data);
                //var listNode = builder.BuildListNode(new int[] { 1, 4, 5 });
                //int[][] arr = new int[3][] { new int[] { 1, 3, 1 }, new int[] { 1, 5, 1 }, new int[] { 4, 2, 1 } };
                //int[] nums1 = new int[] { 2, 3, -2, 4 };
                //int[] nums2 = new int[] { 10, 15, 20 };
                //string input = "abc";
                //string input2 = "ahbgdc";         
                //string s = "leetcode";
                var res = solution.LongestValidParentheses(input);
                ConsoleX.WriteLine(res);
            }
        }

        public class Solution
        {
            public int LongestValidParentheses(string s)
            {
                int[] dp = new int[s.Length];
                for (int i = 0; i < s.Length; i++)
                {
                    if (s[i] == ')')
                    {
                        if (i > 0 && s[i - 1] == '(')
                            dp[i] = 
                    }
                }
            }

            /// <summary>
            /// 第一反应解，动态规划 + 栈，超时，嗯，其实算不上动态规划
            /// 时间复杂度：O(n³)
            /// 空间复杂度：O(n)
            /// 还是练习不够，一下掉进了固定的思维模板里了，用了才不久做的No139的模板思维
            /// </summary>
            /// <param name="s"></param>
            /// <returns></returns>
            //public int LongestValidParentheses(string s)
            //{
            //    if (string.IsNullOrEmpty(s) || s.Length < 2)
            //        return 0;

            //    int[] dp = new int[s.Length];
            //    for (int i = 0; i < s.Length; i++)
            //    {
            //        int max = 0;
            //        for (int j = 0; j < i; j++)
            //        {
            //            if (IsValid(s, j, i))
            //            {
            //                int cur = j > 0 ? dp[j - 1] + (i - j + 1) : (i - j + 1);
            //                max = Math.Max(cur, max);
            //            }
            //        }
            //        dp[i] = max;
            //    }
            //    return dp.Max();
            //}

            //private bool IsValid(string s, int start, int end)
            //{
            //    if (end - start < 1 || string.IsNullOrEmpty(s))
            //        return false;

            //    Stack<char> stack = new Stack<char>();
            //    while (start <= end)
            //    {
            //        if (s[start] == '(')
            //            stack.Push(s[start]);
            //        else if (s[start] == ')')
            //        {
            //            if (stack.Count == 0)
            //                return false;

            //            if (stack.Peek() != '(')
            //                break;
            //            else
            //                stack.Pop();
            //        }
            //        start++;
            //    }
            //    return stack.Count == 0;
            //}
        }
    }
}