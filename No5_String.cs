using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode_5
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
    //        //int?[] data = new int?[] { 6, 2, 8, 0, 4, 7, 9, null, null, 3, 5 };
    //        //int?[] data = new int?[] { 1, null, 2, 3 };
    //        //int?[] data = new int?[] { 1, 2, 2, 3, 3, null, null, 4, 4 };
    //        //int?[] data = new int?[] { 1, 2, null, 3 };
    //        //int?[] data = new int?[] { 1, 2, 2, 3, 3, 3, 3, 4, 4, 4, 4, 4, 4, null, null, 5, 5 };
    //        //var tree = new DataStructureBuilder().BuildTree(data);
    //        var res = solution.LongestPalindrome("cacbssbcDaSca");
    //        ConsoleX.WriteLine(res);
    //    }
    //}

    public class Solution
    {
        //TODO: Manacher算法，据说和KMP类似，又称为马拉车算法

        /// <summary>
        /// 中心扩展算法。找到问题的题眼，没有使用特别的方法，不想动态规划这种是一套思想
        /// 时间复杂度：O(n²)
        /// 空间复杂度：O(1)
        /// 测试执行效率远高于动态规划，112ms, 23.1mb; dp 324ms, 41.8mb
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string LongestPalindrome(string s)
        {
            if (s == null || s.Length < 1)
                return string.Empty; ;
            int start = 0, end = 0;
            for (int i = 0; i < s.Length; i++)
            {
                int len1 = ExpandAroundCenter(s, i, i);
                int len2 = ExpandAroundCenter(s, i, i + 1);
                int len = Math.Max(len1, len2);
                if (len > end - start)
                {
                    //这里需要好好思考下，这个边界的确定不太好想
                    start = i - (len - 1) / 2;
                    end = i + len / 2;
                }
            }
            return s.Substring(start, end - start + 1);
        }

        private int ExpandAroundCenter(string s, int left, int right)
        {
            while (left >= 0 && right < s.Length && s[left] == s[right])
            {
                left--;
                right++;
            }
            return right - left - 1;
        }

        /// <summary>
        /// 动态规划
        /// 时间复杂度：O(n²)
        /// 空间复杂度：O(n²)
        /// 花了我好些世界，是一道经典的动态规划思想锻炼题
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        //public string LongestPalindrome(string s)
        //{
        //    bool[,] dp = new bool[s.Length, s.Length + 1];//Experience:定义二维数组时这样定义： T[,]，这样定义带初始值，不用再去填充。T[][]其实是交错数组，是没有初始值的，也不是定长的
        //    string res = string.Empty;
        //    //外层len表示length，内层i表示index (先用length作为循环，我这个思路好些时候倒不过来，要多练习)
        //    for (int len = 1; len <= s.Length; len++)//因为是以1为初始值，所以上限要加一，对应的数组也要多放出一位
        //    {
        //        for (int i = 0; i < s.Length; i++)
        //        {
        //            //长度越界，跳过
        //            if (i + len > s.Length)
        //                break;
        //            //只有一个字符的时候，当然是回文了
        //            if (len == 1)
        //                dp[i, len] = true;
        //            //两个字符的时候，前后相等即为回文
        //            else if (len == 2)
        //                dp[i, len] = s[i] == s[i + len - 1];
        //            //多个字符的时候，中间是回文，然后收尾字符是相等的即为回文
        //            else
        //                dp[i, len] = dp[i + 1, len - 2] && s[i] == s[i + len - 1];

        //            if (dp[i, len] && len > res.Length)
        //                res = s.Substring(i, len);
        //        }
        //    }
        //    return res;
        //}

        /// <summary>
        /// 暴力法
        /// 时间复杂度：O(n³）
        /// 空间复杂度：O(1)
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        //public string LongestPalindrome(string s)
        //{
        //    int len = s.Length;
        //    if (len < 2)
        //    {
        //        return s;
        //    }

        //    int maxLen = 1;
        //    int begin = 0;
        //    // s.charAt(i) 每次都会检查数组下标越界，因此先转换成字符数组
        //    char[] charArray = s.ToArray();

        //    // 枚举所有长度大于 1 的子串 charArray[i..j]
        //    for (int i = 0; i < len - 1; i++)
        //    {
        //        for (int j = i + 1; j < len; j++)
        //        {
        //            if (j - i + 1 > maxLen && validPalindromic(charArray, i, j))
        //            {
        //                maxLen = j - i + 1;
        //                begin = i;
        //            }
        //        }
        //    }
        //    return s.Substring(begin, maxLen);
        //}

        ///**
        // * 验证子串 s[left..right] 是否为回文串
        // */
        //private bool validPalindromic(char[] charArray, int left, int right)
        //{
        //    while (left < right)
        //    {
        //        if (charArray[left] != charArray[right])
        //        {
        //            return false;
        //        }
        //        left++;
        //        right--;
        //    }
        //    return true;
        //}
    }
}
