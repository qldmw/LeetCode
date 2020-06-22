using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode_10
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
    //        //string input = "A man, a plan, a canal: Panama";
    //        //string input2 = Console.ReadLine();
    //        //int[] intArr = input.Split(',').Select(s => int.Parse(s)).ToArray();
    //        //int input2 = int.Parse(Console.ReadLine());
    //        //int[] intArr = new int[] { 1, 3, 2 };
    //        //int[] intArr = new int[] { 1, 3 };
    //        string input = "aab";
    //        string input2 = "c*a*b";
    //        var res = solution.IsMatch(input, input2);
    //        ConsoleX.WriteLine(res);
    //    }
    //}

    /// <summary>
    /// REDO
    /// </summary>
    class Solution
    {
        /// <summary>
        /// 动态规划，要仔细分析状态，然后写好转移方程才行。而且具体编码需要注意很多细节
        /// Experience：高级方法对于低级方法来说就是降维打击，这道题有限确定状态机可以做，但是相较于动态规划而言就是刀耕火种，完全可以舍弃掉。
        /// </summary>
        /// <param name="s"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public bool IsMatch(String s, String p)
        {
            int m = s.Length;
            int n = p.Length;

            bool[,] f = new bool[m + 1, n + 1];
            f[0, 0] = true;
            for (int i = 0; i <= m; ++i)
            {
                for (int j = 1; j <= n; ++j)
                {
                    if (p[j - 1] == '*')
                    {
                        f[i, j] = f[i, j - 2];
                        if (matches(s, p, i, j - 1))
                        {
                            f[i, j] = f[i, j] || f[i - 1, j];
                        }
                    }
                    else
                    {
                        if (matches(s, p, i, j))
                        {
                            f[i, j] = f[i - 1, j - 1];
                        }
                    }
                }
            }
            return f[m, n];
        }

        public bool matches(String s, String p, int i, int j)
        {
            if (i == 0)
            {
                return false;
            }
            if (p[j - 1] == '.')
            {
                return true;
            }
            return s[i - 1] == p[j - 1];
        }
    }
}
