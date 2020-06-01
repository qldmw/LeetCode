using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

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
                string input = Console.ReadLine();
                //string input2 = Console.ReadLine();
                var res = solution.MyAtoi(input);
                Console.WriteLine(res);                
            }
        }

        public class Solution
        {
            /// <summary>
            /// 正则解题（第一反应走了捷径）
            /// </summary>
            /// <param name="str"></param>
            /// <returns></returns>
            public int MyAtoi(string str)
            {
                str = str.Trim();                

                var match = Regex.Match(str, @"^(\+|-)?\d{1,}");
                if (!match.Success)
                    return 0;

                string matchStr = match.Value.TrimStart('0');
                if (string.IsNullOrEmpty(matchStr))
                    return 0;

                int ans = 0;
                if (!int.TryParse(matchStr, out ans))
                {
                    ans = matchStr[0] == '-' ? int.MinValue : int.MaxValue;
                }
                return ans;                
            }
        }
    }
}
