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
                int input = int.Parse(Console.ReadLine());
                //int input2 = int.Parse(Console.ReadLine());
                //string input = Console.ReadLine();
                //string input2 = Console.ReadLine();
                //int[] intArr = input.Split(',').Select(s => int.Parse(s)).ToArray();
                //int input2 = int.Parse(Console.ReadLine());
                //int?[] data = new int?[] { 6, 2, 8, 0, 4, 7, 9, null, null, 3, 5 };
                //var tree = new DataStructureBuilder().BuildTree(data);
                var listNode = new DataStructureBuilder().BuildListNode(new int[] { 1, 1, 2, 3, 3 });
                var res = solution.NumTrees(input);
                ConsoleX.WriteLine(res);
            }
        }

        /// <summary>
        /// Knowledge：卡特兰数公式：h(n)=h(n-1)*(4*n-2)/(n+1);
        /// </summary>

        public class Solution
        {
            /// <summary>
            /// 动态规划，通过推论获得下一步，通过左右笛卡尔积退出公式 F(i,n)=G(i−1)⋅G(n−i)
            /// 时间复杂度：O(n²）
            /// 空间复杂度：O(n)
            /// </summary>
            /// <param name="n"></param>
            /// <returns></returns>
            public int NumTrees(int n)
            {
                int[] G = new int[n + 1];
                G[0] = 1;
                G[1] = 1;

                for (int i = 2; i <= n; ++i)
                {
                    for (int j = 1; j <= i; ++j)
                    {
                        G[i] += G[j - 1] * G[i - j];
                    }
                }
                return G[n];
            }

            /// <summary>
            /// 使用卡特兰数公式
            /// 时间复杂度：O(n)
            /// 空间复杂度：O(n)
            /// 其实可以用迭代来算，这样就可就能到O(1)了
            /// </summary>
            /// <param name="n"></param>
            /// <returns></returns>
            //public int NumTrees(int n)
            //{
            //    if (n <= 1)
            //        return 1;
            //    return (int)((long)NumTrees(n - 1) * (4 * n - 2) / (n + 1));
            //}

            /// <summary>
            /// 皮一下，哈哈哈
            /// </summary>
            /// <param name="n"></param>
            /// <returns></returns>
            //public int NumTrees(int n)
            //{
            //    int[] ans = new int[] { 1, 1, 2, 5, 14, 42, 132, 429, 1430, 4862, 16796, 58786, 208012, 742900, 2674440, 9694845, 35357670, 129644790, 477638700, 1767263190 };
            //    return ans[n];
            //}
        }
    }
}