using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode_37
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
    //        //string input2 = Console.ReadLine();
    //        //int[] intArr = input.Split(',').Select(s => int.Parse(s)).ToArray();
    //        //int input2 = int.Parse(Console.ReadLine());
    //        //var builder = new DataStructureBuilder();
    //        //int?[] data = new int?[] { 1, 2, 3, 4, 5, null, 6, null, null, 7, 8 };
    //        //var tree = builder.BuildTree(data);
    //        //var listNode = builder.BuildListNode(new int[] { 1, 4, 5 });
    //        //int[][] arr = new int[3][] { new int[] { 1, 3, 1 }, new int[] { 1, 5, 1 }, new int[] { 4, 2, 1 } };
    //        //string input = "abcbefga";
    //        //string input2 = "dbefga";
    //        //int[] nums1 = new int[] { 1, 2, 3 };
    //        //int[] nums2 = new int[] { 1, 1 };
    //        //IList<IList<int>> data = new List<IList<int>>()
    //        //{
    //        //    new List<int>() { 1, 3 },
    //        //    new List<int>() { 3, 0, 1 },
    //        //    new List<int>() { 2 },
    //        //    new List<int>() { 0 }

    //        //    //new List<int>() { 1 },
    //        //    //new List<int>() { 2 },
    //        //    //new List<int>() { 3 },
    //        //    //new List<int>() {  }
    //        //};
    //        var arr = new char[][] {
    //            new char[] { '5','3','.','.','7','.','.','.','.' },
    //            new char[] { '6','.','.','1','9','5','.','.','.' },
    //            new char[] { '.','9','8','.','.','.','.','6','.' },
    //            new char[] { '8','.','.','.','6','.','.','.','3' },
    //            new char[] { '4','.','.','8','.','3','.','.','1' },
    //            new char[] { '7','.','.','.','2','.','.','.','6' },
    //            new char[] { '.','6','.','.','.','.','2','8','.' },
    //            new char[] { '.','.','.','4','1','9','.','.','5' },
    //            new char[] { '.','.','.','.','8','.','.','7','9' },
    //        };//stepbackCount = 4157
    //        var hardestSudoku = new char[][] {
    //            new char[] { '8','.','.','.','.','.','.','.','.' },
    //            new char[] { '.','.','3','6','.','.','.','.','.' },
    //            new char[] { '.','7','.','.','9','.','2','.','.' },
    //            new char[] { '.','5','.','.','.','7','.','.','.' },
    //            new char[] { '.','.','.','.','4','5','7','.','.' },
    //            new char[] { '.','.','.','1','.','.','.','3','.' },
    //            new char[] { '.','.','1','.','.','.','.','6','8' },
    //            new char[] { '.','.','8','5','.','.','.','1','.' },
    //            new char[] { '.','9','.','.','.','.','4','.','.' },
    //        };//stepbackCount = 49498
    //        solution.SolveSudoku(arr);
    //        ConsoleX.WriteLine(arr);
    //    }
    //}

    /// <summary>
    /// 这道题给我的感觉更多的是在考察工程化思想，因为原理不复杂，但怎么样写出可读性高的优雅的代码却不容易。
    /// </summary>
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
        //转存为私有属性
        private char[][] _board;

        private void _ScanForInitialData()
        {
            //快速初始化带默认值的数组
            var existBlocks = Enumerable.Range(0, 9).Select(s => new HashSet<int>()).ToList();
            var existCols = Enumerable.Range(0, 9).Select(s => new HashSet<int>()).ToList();
            var existRows = Enumerable.Range(0, 9).Select(s => new HashSet<int>()).ToList();
            for (int x = 0; x < 9; x++)
            {
                for (int y = 0; y < 9; y++)
                {
                    if (_board[x][y] == '.')
                        _candidates.Add((x, y));
                    else
                    {
                        existCols[y].Add(_board[x][y] - '0');
                        existRows[x].Add(_board[x][y] - '0');
                        int blockIndex = (y / 3) * 3 + x / 3;
                        existBlocks[blockIndex].Add(_board[x][y] - '0');
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
            _board = board;
            _ScanForInitialData();
            for (int i = 0; i < _candidates.Count; i++)
            {
                //如果是点则直接从最小的插入，如果已经有数字了，就从大于数字的最小一个开始插入
                if (!TryInsertNumber(_candidates[i].Item1, _candidates[i].Item2))
                {
                    //如果无法插入数字了，则回退到前一个
                    i -= 2;
                }
            }
        }

        private bool TryInsertNumber(int x, int y)
        {
            char value = _board[x][y];
            //通过可用的行列块数字，找到最终可用的集合
            List<int> col = _cols[y], row = _rows[x], block = _blocks[(y / 3) * 3 + x / 3];
            //如果之前这个位置就有数字，则置为 '.'，并把该数字放回到可用合集中
            if (value != '.')
            {
                _board[x][y] = '.';
                __AddNumToColRowBlock(value - '0');
            }
            //这里用到了一个 Intersect 方法，是 IEnumerable 取并集的方法。和 except 相反，except 是差集的。
            var availableNums = col.Intersect(row).Intersect(block);
            //orderBy是因为回溯加入可用集合时会乱序
            foreach (var num in availableNums.OrderBy(s => s))
            {
                if (num > value - '0')
                {
                    _board[x][y] = (char)(num + '0');
                    //使用数字之后，就从可用合集中去除该数字
                    __RemoveNumFromColRowBlock(num);
                    return true;
                }
            }
            return false;

            void __RemoveNumFromColRowBlock(int num)
            {
                col.Remove(num);
                row.Remove(num);
                block.Remove(num);
            }

            void __AddNumToColRowBlock(int num)
            {
                col.Add(num);
                row.Add(num);
                block.Add(num);
            }
        }
    }
}
