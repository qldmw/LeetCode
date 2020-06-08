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
                int input = int.Parse(Console.ReadLine());
                //int input2 = int.Parse(Console.ReadLine());
                //int input3 = int.Parse(Console.ReadLine());
                //string input = Console.ReadLine();
                //string input2 = Console.ReadLine();
                //int[] intArr = input.Split(',').Select(s => int.Parse(s)).ToArray();
                //int input = int.Parse(input2);                
                var res = solution.Generate(input);
                ConsoleX.WriteLine(res);
            }
        }

        public class Solution
        {
            /// <summary>
            /// 第一反应解，单纯的构建出来就好了
            /// 时间复杂度：O(n²)，1 + 2 + 3 + ... + n = n(n + 1)/2 = 1/2n² + 1/2n，省略项，得O(n²)
            /// 空间复杂度：O(n²)，计算步骤和时间复杂度同理
            /// </summary>
            /// <param name="numRows"></param>
            /// <returns></returns>
            public IList<IList<int>> Generate(int numRows)
            {
                var triangle = new List<IList<int>>();
                for (int i = 0; i < numRows; i++)
                {
                    if (i == 0)
                        triangle.Add(new int[1] { 1 });
                    else if (i == 1)
                        triangle.Add(new int[2] { 1, 1 });
                    else
                    {
                        int[] row = new int[i + 1];
                        row[0] = row[i] = 1;
                        for (int j = 1; j < i; j++)
                        {
                            row[j] = triangle[i - 1][j - 1] + triangle[i - 1][j];
                        }
                        triangle.Add(row);
                    }
                }
                return triangle;
            }
        }
    }
}