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
                ////string input2 = Console.ReadLine();
                //int[] intArr = input.Split(',').Select(s => int.Parse(s)).ToArray();
                //int input2 = int.Parse(Console.ReadLine());
                string[] intArr = new string[] { "flower", "flow", "flight" };
                var res = solution.LongestCommonPrefix(intArr);
                ConsoleX.WriteLine(res);
            }
        }

        public class Solution
        {
            public string LongestCommonPrefix(string[] strs)
            {
                string res = string.Empty;
                if (strs == null || strs.Length == 0)
                    return res;

                //找出最短的字符串
                res = strs[0];
                for (int i = 1; i < strs.Length; i++)
                {
                    if (strs[i].Length < res.Length)
                        res = strs[i];
                }
                //如果最短的是空字符串，那就返回
                if (res == string.Empty)
                    return res;

                //用最短的字符串做二分法比较
                int left = 0;
                int right = res.Length - 1;
                while (left <= right)
                {
                    int mid = (left + right) / 2;
                    if (strs.All(s => s.StartsWith(res.Substring(0, mid))))
                        left = mid + 1;
                    else
                        right = mid - 1;
                }

                return res.Substring(0, left - 1);
            }
        }
    }
}