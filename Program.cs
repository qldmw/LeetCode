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
                var res = solution.IsValidSudoku();
                ConsoleX.WriteLine(res);
            }
        }

        public class Solution
        {
            /// <summary>
            /// 数组代替hashset完成，巧妙利用下标
            /// 时间复杂度：O(1)，常数
            /// 空间复杂度：O(1)，常数
            /// 其实考察的是HashSet，不过可以利用数组的特性来解决，更节省空间。
            /// </summary>
            /// <param name="board"></param>
            /// <returns></returns>
            public bool IsValidSudoku(char[][] board)
            {
                //记录是否来过
                bool[,] cols = new bool[9, 9];
                bool[,] rows = new bool[9, 9];
                bool[,] boxs = new bool[9, 9];
                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        if (board[i][j] == '.')
                            continue;

                        int num = board[i][j] - '0' - 1;
                        //校验行
                        if (!cols[i, num])
                            cols[i, num] = true; 
                        else
                            return false;
                        //校验列
                        if (!rows[j, num])
                            rows[j, num] = true;
                        else
                            return false;
                        //校验区
                        //这里是这道题最难的一点，计算出当前的box序号。其实 i 和 j 无关顺序，因为这个矩形是对称的
                        int boxIndex = (i / 3) * 3 + j / 3;
                        if (!boxs[boxIndex, num])
                            boxs[boxIndex, num] = true;
                        else
                            return false;
                    }
                }
                return true;
            }
        }
    }
}