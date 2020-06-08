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
                var res = solution.GetRow(input);
                ConsoleX.WriteLine(res);
            }
        }

        public class Solution
        {
            /// <summary>
            /// 一层一层的算出来，这样就避免了真·纯递归导致层数很高之后还要一点一点的算回来
            /// 时间复杂度：O(n²)
            /// 空间复杂度：O(n)
            /// 数组赋值的时候会是引用传递，这个时候不要一想到引用传值就深拷贝，重新new一个就刷新了空间
            /// </summary>
            /// <param name="rowIndex"></param>
            /// <returns></returns>
            public IList<int> GetRow(int rowIndex)
            {
                var cur = new int[rowIndex + 1];
                var pre = new int[rowIndex + 1];
                for (int i = 0; i <= rowIndex; i++)
                {
                    cur = new int[rowIndex + 1];
                    for (int j = 0; j <= i; j++)
                    {
                        //两边都是1
                        if (j == 0 || j == i)
                            cur[j] = 1;
                        else
                            cur[j] = pre[j - 1] + pre[j];
                    }
                    //前两次的时候就给到了pre值
                    pre = cur;
                }
                return cur;
            }

            /// <summary>
            /// 第一反应解（为满足题目的空间复杂度O(k),纯粹的递归，铁超时）
            /// </summary>
            /// <param name="rowIndex"></param>
            /// <returns></returns>
            //public IList<int> GetRow(int rowIndex)
            //{
            //    rowIndex++;
            //    var res = new int[rowIndex];
            //    for (int i = 0; i < rowIndex; i++)
            //    {
            //        res[i] = Recursive(rowIndex, i);
            //    }
            //    return res;
            //}

            //private int Recursive(int row, int position)
            //{
            //    if (row <= 2 || position == 0 || position == row - 1)
            //        return 1;
            //    else if (position < 0 || position > row - 1)
            //        return 0;
            //    else
            //    {
            //        return Recursive(row - 1, position - 1) + Recursive(row - 1, position);
            //    }
            //}
        }
    }
}