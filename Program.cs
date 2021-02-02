using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Extension;
using LeetCode.ExtensionFunction;
using System.Threading.Tasks;
using System.Threading;

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
                //var builder = new DataStructureBuilder();
                //int?[] data = new int?[] { 1, 2, 3, 4, 5, null, 6, null, null, 7, 8 };
                //var tree = builder.BuildTree(data);
                //var listNode = builder.BuildListNode(new int[] { 1, 4, 5 });
                //int[][] arr = new int[3][] { new int[] { 1, 3, 1 }, new int[] { 1, 5, 1 }, new int[] { 4, 2, 1 } };
                //string input = "abcbefga";
                //string input2 = "dbefga";
                //int[] nums1 = new int[] { 1, 2, 3 };
                //int[] nums2 = new int[] { 1, 1 };
                //IList<IList<int>> data = new List<IList<int>>()
                //{
                //    new List<int>() { 1, 3 },
                //    new List<int>() { 3, 0, 1 },
                //    new List<int>() { 2 },
                //    new List<int>() { 0 }

                //    //new List<int>() { 1 },
                //    //new List<int>() { 2 },
                //    //new List<int>() { 3 },
                //    //new List<int>() {  }
                //};

                string str = "ABAB";
                var res = solution.CharacterReplacement(str, 2);
                ConsoleX.WriteLine(res);
            }
        }

        /// <summary>
        /// REDO
        /// </summary>
        public class Solution
        {
            /// <summary>
            /// 滑动窗口
            /// 时间复杂度：O(n)
            /// 空间复杂度：O(1),实际就是一个26字符长度的数组
            /// </summary>
            /// <param name="s"></param>
            /// <param name="k"></param>
            /// <returns></returns>
            public int CharacterReplacement(string s, int k)
            {
                //题眼，维护一个历史最长字符数
                int historyCharMax = 0;
                //滑动窗口中的各个字符出现次数
                int[] freq = new int[26];
                int left = 0, right = 0;
                //右指针滑到末尾结束
                while (right < s.Length)
                {
                    freq[s[right] - 'A']++;
                    historyCharMax = Math.Max(historyCharMax, freq[s[right] - 'A']);
                    //经典小学数树题目，序数减法要加一，记住了吗小朋友们
                    if ((right - left + 1) - historyCharMax > k)
                    {
                        //当出现窗口长度大于可容纳量的时候，左指针右移，整体向前滑
                        freq[s[left] - 'A']--;
                        left++;
                    }
                    //右指针，星辉月夜，日夜兼程
                    right++;
                }
                return right - left;
            }
        }
    }
}