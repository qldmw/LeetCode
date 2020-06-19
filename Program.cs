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
                string input = Console.ReadLine();
                //string input = "A man, a plan, a canal: Panama";
                string input2 = Console.ReadLine();
                //int[] intArr = input.Split(',').Select(s => int.Parse(s)).ToArray();
                //int input2 = int.Parse(Console.ReadLine());
                //int[] intArr = new int[] { 1, 3, 2 };
                //int[] intArr = new int[] { 1, 3 };
                var res = solution.CanConstruct(input, input2);
                ConsoleX.WriteLine(res);
            }
        }

        public class Solution
        {
            /// <summary>
            /// 优化储存空间的解法，利用26长度的array替代了HashSet，获得了124ms->96ms,27.7mb->27.2mb的优化
            /// 时间复杂度：O(m + n)
            /// 空间复杂度：O(n)
            /// </summary>
            /// <param name="ransomNote"></param>
            /// <param name="magazine"></param>
            /// <returns></returns>
            public bool CanConstruct(string ransomNote, string magazine)
            {
                int[] dic = new int[26];
                for (int i = 0; i < magazine.Length; i++)
                {
                    dic[magazine[i] - 'a']++;
                }

                for (int i = 0; i < ransomNote.Length; i++)
                {
                    dic[ransomNote[i] - 'a']--;
                    if (dic[ransomNote[i] - 'a'] < 0)
                        return false;
                }
                return true;
            }

            /// <summary>
            /// 第一反应解，利用hashset做统计，然后遍历ransomNote获取答案
            /// 时间复杂度：O(m + n)，要遍历magazine获得HashSet，然后遍历ransomNote获得答案
            /// 空间复杂度：O(n)
            /// 最优答案里用int[26]的方式来记录字符出现的次数，时间上快了很多，空间也用的小。
            /// </summary>
            /// <param name="ransomNote"></param>
            /// <param name="magazine"></param>
            /// <returns></returns>
            //public bool CanConstruct(string ransomNote, string magazine)
            //{
            //    Dictionary<char, int> dic = new Dictionary<char, int>();
            //    for (int i = 0; i < magazine.Length; i++)
            //    {
            //        if (!dic.ContainsKey(magazine[i]))
            //            dic.Add(magazine[i], 1);
            //        else
            //            dic[magazine[i]]++;
            //    }

            //    for (int i = 0; i < ransomNote.Length; i++)
            //    {
            //        if (!dic.ContainsKey(ransomNote[i]))
            //            return false;
            //        else
            //        {
            //            dic[ransomNote[i]]--;
            //            if (dic[ransomNote[i]] < 0)
            //                return false;
            //        }
            //    }
            //    return true;
            //}
        }
    }
}