using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode_91
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
    //        //int?[] data = new int?[] { 10, 5, 15, null, null, 6, 20 };
    //        //var tree = builder.BuildTree(data);
    //        //var listNode = builder.BuildListNode(new int[] { 1, 4, 5 });
    //        //int[][] arr = new int[3][] { new int[] { 1, 3, 1 }, new int[] { 1, 5, 1 }, new int[] { 4, 2, 1 } };
    //        //int[] nums1 = new int[] { 2, 1, 4, 5, 3, 1, 1, 3 };
    //        //int[] nums2 = new int[] { 10, 15, 20 };
    //        //string input = "abc";
    //        //string input2 = "ahbgdc";                
    //        var res = solution.NumDecodings(input);
    //        ConsoleX.WriteLine(res);
    //    }
    //}

    public class Solution
    {
        /// <summary>
        /// 动态规划，分析找到 f(x) 和 f(x-1), f(x-2)的关系
        /// 时间复杂度：O(n)
        /// 空间复杂度：O(1)
        /// 这道题其实开始走偏了，没有分析对，但是通过几个示例反推找到了类似菲波列切数组的关系，然后分析出了关系。也算是一种方法吧
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int NumDecodings(string s)
        {
            if (string.IsNullOrEmpty(s) || s[0] == '0')
                return 0;

            int resMinusTwo = 1;
            int resMinusOne = 1;
            for (int i = 1; i < s.Length; i++)
            {
                int cur_res = 0;
                if (s[i - 1] != '0' && (s[i - 1] - '0') * 10 + (s[i] - '0') <= 26)
                    cur_res += resMinusTwo;
                if (s[i] != '0')
                    cur_res += resMinusOne;

                resMinusTwo = resMinusOne;
                resMinusOne = cur_res;
            }
            return resMinusOne;
        }
    }
}
