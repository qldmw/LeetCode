using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode_58
{
    //static void Main(string[] args)
    //{
    //    var solution = new Solution();
    //    while (true)
    //    {
    //        //int input = int.Parse(Console.ReadLine());
    //        //int input2 = int.Parse(Console.ReadLine());
    //        //int input3 = int.Parse(Console.ReadLine());
    //        string input = Console.ReadLine();
    //        //string input2 = Console.ReadLine();
    //        //int[] intArr = input.Split(',').Select(s => int.Parse(s)).ToArray();
    //        //int input2 = int.Parse(Console.ReadLine());
    //        //int[] intArr = new int[] { 1, 3, 2 };
    //        //int[] intArr = new int[] { 1, 3 };
    //        var res = solution.LengthOfLastWord(input);
    //        ConsoleX.WriteLine(res);
    //    }
    //}

    public class Solution
    {
        /// <summary>
        /// 第一反应解，挨个读就可以了。有个优化策略，从右往左读，因为是读取最后一个，所以前面的都不重要
        /// 时间复杂度：O(n)
        /// 空间复杂度：O(1)
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int LengthOfLastWord(string s)
        {
            int len = 0;
            s = s.Trim();
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] != ' ')
                    len++;
                else
                    len = 0;
            }
            return len;
        }
    }
}
