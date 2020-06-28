using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode_6
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
    //        //int?[] data = new int?[] { 6, 2, 8, 0, 4, 7, 9, null, null, 3, 5 };
    //        //int?[] data = new int?[] { 1, null, 2, 3 };
    //        //int?[] data = new int?[] { 1, 2, 2, 3, 3, null, null, 4, 4 };
    //        //int?[] data = new int?[] { 1, 2, null, 3 };
    //        //int?[] data = new int?[] { 1, 2, 2, 3, 3, 3, 3, 4, 4, 4, 4, 4, 4, null, null, 5, 5 };
    //        //var tree = new DataStructureBuilder().BuildTree(data);
    //        //var res = solution.Convert("LEETCODEISHIRING", 3);
    //        var res = solution.Convert("A", 1);
    //        //LCIRETOESIIGEDHN; answer of 3 row
    //        //LDREOEIIECIHNTSG; answer of 4 row
    //        ConsoleX.WriteLine(res);
    //    }
    //}

    /// <summary>
    /// REDO:非常好的一道考察边界判断的题目
    /// </summary>

    public class Solution
    {
        /// <summary>
        /// 找规律拼接字符串
        /// 时间复杂度：O(n)
        /// 空间复杂度：O(1),不算返回数据占用的必要空间
        /// 官方题解还提供了一种来回写到多行，最后拼接的办法，但是做法复杂了，而且性能还不如这个解法。不过多一种思想也是好的
        /// </summary>
        /// <param name="s"></param>
        /// <param name="numRows"></param>
        /// <returns></returns>
        public string Convert(string s, int numRows)
        {
            if (numRows == 1)
                return s;
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < numRows; i++)
            {
                for (int j = i; j < s.Length; j += (numRows - 1) * 2)
                {
                    //整数倍的添加
                    if (j <= s.Length - 1)
                        sb.Append(s[j]);
                    //如果下一步超过界限，就跳出
                    if (j + (numRows - 1) * 2 > s.Length - 1)
                        break;
                    //不是两端就再加入一个中间的字符
                    if (i != 0 && i != numRows - 1)
                        sb.Append(s[j + (numRows - 1 - i) * 2]);
                }
            }
            return sb.ToString();
        }
    }
}
