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
                var arr = new char[][] { 
                    new char[] { '5','3','.','.','7','.','.','.','.' },
                    new char[] { '6','.','.','1','9','5','.','.','.' },
                    new char[] { '.','9','8','.','.','.','.','6','.' },
                    new char[] { '8','.','.','.','6','.','.','.','3' },
                    new char[] { '4','.','.','8','.','3','.','.','1' },
                    new char[] { '7','.','.','.','2','.','.','.','6' },
                    new char[] { '.','6','.','.','.','.','2','8','.' },
                    new char[] { '.','.','.','4','1','9','.','.','5' },
                    new char[] { '.','.','.','.','8','.','.','7','9' },
                };
                solution.SolveSudoku(arr);
                ConsoleX.WriteLine(arr);
            }
        }

        public class Solution
        {
            //九宫格的可用数字
            private List<List<int>> _blocks = new List<List<int>>();
            //列的可用数字
            private List<List<int>> _cols = new List<List<int>>();
            //行的可用数字
            private List<List<int>> _rows = new List<List<int>>();
            //可填的空格,第一个代表 x,第二个代表 y
            private List<(int, int)> _candidates = new List<(int, int)>();

            private void _ScanForInitialData(char[][] board)
            {
                //快速初始化带默认值的数组
                var existBlocks = Enumerable.Range(0, 9).Select(s => new HashSet<int>()).ToList();
                var existCols = Enumerable.Range(0, 9).Select(s => new HashSet<int>()).ToList();
                var existRows = Enumerable.Range(0, 9).Select(s => new HashSet<int>()).ToList();
                for (int x = 0; x < 9; x++)
                {
                    for (int y = 0; y < 9; y++)
                    {
                        if (board[x][y] == '.')
                            _candidates.Add((x, y));
                        else
                        {
                            existCols[y].Add(board[x][y] - '0');
                            existRows[x].Add(board[x][y] - '0');
                            int blockIndex = (y / 3) * 3 + x / 3;
                            existBlocks[blockIndex].Add(board[x][y] - '0');
                        }
                    }
                }
                //通过已经存在的，反选出可用的数字
                foreach (var block in existBlocks)
                {
                    var temp = new List<int>();
                    for (int i = 1; i <= 9; i++)
                    {
                        if (!block.Contains(i))
                            temp.Add(i);
                    }
                    _blocks.Add(temp);
                }
                foreach (var col in existCols)
                {
                    var temp = new List<int>();
                    for (int i = 1; i <= 9; i++)
                    {
                        if (!col.Contains(i))
                            temp.Add(i);
                    }
                    _cols.Add(temp);
                }
                foreach (var row in existRows)
                {
                    var temp = new List<int>();
                    for (int i = 1; i <= 9; i++)
                    {
                        if (!row.Contains(i))
                            temp.Add(i);
                    }
                    _rows.Add(temp);
                }
            }

            public void SolveSudoku(char[][] board)
            {
                _ScanForInitialData(board);
                for (int i = 0; i < _candidates.Count; i++)
                {
                    if (!StepForeward(_candidates[i].Item1, _candidates[i].Item2))
                    {

                    }
                }
            }

            private void InsertNumber()
            {

            }

            private bool StepForeward(int x, int y)
            {

            }

            private bool StepBack(int x, int y)
            {

            }
        }
    }
}