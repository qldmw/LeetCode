using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode_32
{
    //static void Main(string[] args)
    //{
    //    var solution = new Solution();
    //    while (true)
    //    {
    //        //int input = int.Parse(Console.ReadLine());
    //        //int input2 = int.Parse(Console.ReadLine());
    //        string input = Console.ReadLine();
    //        //string input2 = Console.ReadLine();
    //        //int[] intArr = input.Split(',').Select(s => int.Parse(s)).ToArray();
    //        //int input2 = int.Parse(Console.ReadLine());
    //        //var builder = new DataStructureBuilder();
    //        //int?[] data = new int?[] { 10, 5, 15, null, null, 6, 20 };
    //        //var tree = builder.BuildTree(data);
    //        //var listNode = builder.BuildListNode(new int[] { 1, 4, 5 });
    //        //int[][] arr = new int[3][] { new int[] { 1, 3, 1 }, new int[] { 1, 5, 1 }, new int[] { 4, 2, 1 } };
    //        //int[] nums1 = new int[] { 2, 3, -2, 4 };
    //        //int[] nums2 = new int[] { 10, 15, 20 };
    //        //string input = "abc";
    //        //string input2 = "ahbgdc";         
    //        //string s = "leetcode";
    //        var res = solution.LongestValidParentheses(input);
    //        ConsoleX.WriteLine(res);
    //    }
    //}

    public class Solution
    {
        /// <summary>
        /// 动态规划，利用中间的合规数目来计算获取前面的符号，很巧妙。还有一种用stack的方法，也是一个道理，都是利用中间合规数目来做的
        /// 时间复杂度：O(n)，一个点想到没想到差了这么多啊，一个 n， 一个 n³。
        /// 空间复杂度：O(n)
        /// 解题里还有一种利用左右括号计数的解法，可以把空间复杂度降到 O(1),不过感觉意思也不大，以后可以试试
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int LongestValidParentheses(string s)
        {
            int[] dp = new int[s.Length];
            int max = 0;
            for (int i = 1; i < s.Length; i++)
            {
                if (s[i] == ')')
                {
                    if (s[i - 1] == '(')
                        dp[i] = (i >= 2 ? dp[i - 2] : 0) + 2;
                    else if (i - dp[i - 1] > 0 && s[i - dp[i - 1] - 1] == '(')
                        dp[i] = dp[i - 1] + ((i - dp[i - 1] >= 2 ? dp[i - dp[i - 1] - 2] : 0)) + 2;
                }
                max = Math.Max(dp[i], max);
            }
            return max;
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
