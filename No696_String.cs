using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode_696
{
    //static void Main(string[] args)
    //{
    //    var solution = new Solution();
    //    while (true)
    //    {
    //        //int input = int.Parse(Console.ReadLine());
    //        //int input2 = int.Parse(Console.ReadLine());
    //        string input = Console.ReadLine();
    //        //string input2 = Console.ReadLine();
    //        //int[] intArr = input.Split(',').Select(s => int.Parse(s)).ToArray();
    //        //int input2 = int.Parse(Console.ReadLine());
    //        //var builder = new DataStructureBuilder();
    //        //int?[] data = new int?[] { 1, 2, 5, 3, 4, null, 6 };
    //        //var tree = builder.BuildTree(data);
    //        //var listNode = builder.BuildListNode(new int[] { 1, 4, 5 });
    //        //int[][] arr = new int[3][] { new int[] { 1, 3, 1 }, new int[] { 1, 5, 1 }, new int[] { 4, 2, 1 } };
    //        //int[] nums1 = new int[] { 2, 1, -2, 3 };
    //        //int[] nums2 = new int[] { 10, 15, 20 };
    //        //string input = "adceb";
    //        //string input2 = "*a*b";
    //        var res = solution.CountBinarySubstrings(input);
    //        ConsoleX.WriteLine(res);
    //    }
    //}

    public class Solution
    {
        /// <summary>
        /// 第一反应解，以当前字符和上一个字符不同作为触发条件，累计计数
        /// 时间复杂度：O(n)
        /// 空间复杂度：O(1)
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int CountBinarySubstrings(string s)
        {
            int oneCount = 0;
            int zeroCount = 0;
            int res = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (i - 1 >= 0 && s[i - 1] != s[i])
                {
                    res += Math.Min(oneCount, zeroCount);
                    _ = s[i] == '0' ? zeroCount = 1 : oneCount = 1;
                }
                else
                    _ = s[i] == '0' ? zeroCount++ : oneCount++;
            }
            return res + Math.Min(oneCount, zeroCount);
        }
    }
}
