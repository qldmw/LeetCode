using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode_3
{
    class No3_SlidingWindow
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
        //        //var builder = new DataStructureBuilder();
        //        //int?[] data = new int?[] { 1, 2, 3, 4, 5, null, 6, null, null, 7, 8 };
        //        //var tree = builder.BuildTree(data);
        //        //var listNode = builder.BuildListNode(new int[] { 1, 4, 5 });
        //        //int[][] arr = new int[3][] { new int[] { 1, 3, 1 }, new int[] { 1, 5, 1 }, new int[] { 4, 2, 1 } };
        //        //int[] nums1 = new int[] { 2, 1, 7, 5, 6, 4, 3 };
        //        //int[] nums1 = new int[] { 2, 1, 1, 5, 11, 5, 1, 7, 5, 6, 4, 3 };
        //        //int[] nums2 = new int[] { 10, 15, 20 };
        //        string input = "abccabcbb";
        //        //string input2 = "*a*b";
        //        var res = solution.LengthOfLongestSubstring(input);
        //        ConsoleX.WriteLine(res);
        //    }
        //}

        public class Solution
        {
            /// <summary>
            /// 滑动窗口，出现重复字符之后从头开始删除hashSet，直到不出现重复
            /// 时间复杂度：O(n)
            /// 空间复杂度：O(1)
            /// </summary>
            /// <param name="s"></param>
            /// <returns></returns>
            public int LengthOfLongestSubstring(string s)
            {
                // 哈希集合，记录每个字符是否出现过
                HashSet<char> occ = new HashSet<char>();
                int n = s.Length;
                // 右指针，初始值为 -1，相当于我们在字符串的左边界的左侧，还没有开始移动
                int rk = -1, ans = 0;
                for (int i = 0; i < n; ++i)
                {
                    if (i != 0)
                    {
                        // 左指针向右移动一格，移除一个字符
                        occ.Remove(s[i - 1]);
                    }
                    while (rk + 1 < n && !occ.Contains(s[rk + 1]))
                    {
                        // 不断地移动右指针
                        occ.Add(s[rk + 1]);
                        ++rk;
                    }
                    // 第 i 到 rk 个字符是一个极长的无重复字符子串
                    ans = Math.Max(ans, rk - i + 1);
                }
                return ans;
            }

            ///// <summary>
            ///// 第一反应解，dictionary记录每次重复的最新位置
            ///// 时间复杂度：O(n)
            ///// 空间复杂度：O(1),因为字符串是固定数目个的，所以可以认为是常数级
            ///// </summary>
            ///// <param name="s"></param>
            ///// <returns></returns>
            //public int LengthOfLongestSubstring(string s)
            //{
            //    int maxLen = 0;
            //    int left = 0;
            //    //char 是字符，int 是字符出现的最后位置
            //    Dictionary<char, int> dic = new Dictionary<char, int>();
            //    for (int i = 0; i < s.Length; i++)
            //    {
            //        if (dic.ContainsKey(s[i]))
            //        {
            //            left = Math.Max(dic[s[i]] + 1, left);// 为了不让left往回走，参考该用例：abba
            //        }
            //        dic[s[i]] = i;
            //        maxLen = Math.Max(i - left + 1, maxLen);
            //    }
            //    return maxLen;
            //}
        }
    }
}
