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
                string input2 = Console.ReadLine();
                //int[] intArr = input.Split(',').Select(s => int.Parse(s)).ToArray();
                //int input2 = int.Parse(Console.ReadLine());
                //int[] intArr = new int[] { 1, 3, 2 };
                //int[] intArr = new int[] { 4, 2, 1, 3, 2, 6, 3 };
                //int[] intArr2 = new int[] { 4, 2, 1, 3, 2, 6, 3 };
                var res = solution.StrStr(input, input2);
                ConsoleX.WriteLine(res);
            }
        }

        public class Solution
        {
            public int StrStr(string haystack, string needle)
            {
                if (needle == string.Empty)
                    return 0;

                int ans = -1;
                for (int i = 0; i <= haystack.Length - needle.Length; i++)
                {
                    int j = 0;
                    for (; j < needle.Length; j++)
                    {
                        if (haystack[i + j] != needle[j])
                        {
                            //sunday算法：不匹配，则查看 待匹配字符串 的后一位字符 c：1.若c存在于Pattern中，则 idx = idx + 偏移表[c] 2.否则，idx = idx + len(pattern)
                            int nextStartIndex = needle.IndexOf(haystack[i + j]);
                            if (nextStartIndex == -1)
                                i = i + needle.Length;
                            else
                                i = i + nextStartIndex;
                            break;
                        }
                    }
                    if (j == needle.Length)
                    {
                        ans = i;
                        break;
                    }
                }
                return ans;
            }

            /// <summary>
            /// 时间复杂度：O(n)，可能这种比较好算的就要算最优和最差了吧，最优时间是O(n),最差时间是O((n-l)n)
            /// 空间复杂度：O(1)
            /// </summary>
            /// <param name="haystack"></param>
            /// <param name="needle"></param>
            /// <returns></returns>
            //public int StrStr(string haystack, string needle)
            //{
            //    if (needle == string.Empty)
            //        return 0;

            //    int ans = -1;
            //    for (int i = 0; i <= haystack.Length - needle.Length; i++)
            //    {
            //        int j = 0;
            //        for (; j < needle.Length; j++)
            //        {
            //            if (haystack[i + j] != needle[j])
            //                break;
            //        }
            //        if (j == needle.Length)
            //        {
            //            ans = i;
            //            break;
            //        }
            //    }
            //    return ans;
            //}
        }
    }
}