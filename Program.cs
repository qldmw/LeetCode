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
                //var builder = new DataStructureBuilder();
                //int?[] data = new int?[] { 10, 5, 15, null, null, 6, 20 };
                //var tree = builder.BuildTree(data);
                //var listNode = builder.BuildListNode(new int[] { 1, 4, 5 });
                //int[][] arr = new int[3][] { new int[] { 1, 3, 1 }, new int[] { 1, 5, 1 }, new int[] { 4, 2, 1 } };
                //int[] nums1 = new int[] { 2, 1, 4, 5, 3, 1, 1, 3 };
                //int[] nums2 = new int[] { 10, 15, 20 };
                //string input = "abc";
                //string input2 = "ahbgdc";         
                //string s = "leetcode";
                //IList<string> wordDict = new List<string>() { "leet", "code" };
                //string s = "applepenapple";
                //IList<string> wordDict = new List<string>() { "apple", "pen" };
                string s = "catsandog";
                IList<string> wordDict = new List<string>() { "cats", "dog", "sand", "and", "cat" };

                var res = solution.WordBreak(s, wordDict);
                ConsoleX.WriteLine(res);
            }
        }

        public class Solution
        {
            /// <summary>
            /// 第一反应解，递归，然而超时
            /// 时间复杂度：O(真不知道怎么算 OTL )
            /// 空间复杂度：O(真不知道怎么算 OTL )
            /// </summary>
            /// <param name="s"></param>
            /// <param name="wordDict"></param>
            /// <returns></returns>
            public bool WordBreak(string s, IList<string> wordDict)
            {
                _dic = new HashSet<string>(wordDict);
                _maxWordLength = wordDict.Count != 0 ? wordDict.Max(t => t.Length) : 0;
                Recurse(s);
                return _res;
            }

            private HashSet<string> _dic;
            private bool _res;
            private int _maxWordLength;

            private void Recurse(string str)
            {
                if (_res)
                    return;

                if (_dic.Contains(str))
                {
                    _res = true;
                    return;
                }

                for (int i = 0; i < str.Length && i < _maxWordLength; i++)
                {
                    if (_dic.Contains(str.Substring(0, i + 1)))
                        Recurse(str.Substring(i + 1));
                }
            }
        }
    }
}