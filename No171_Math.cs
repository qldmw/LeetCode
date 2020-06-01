using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode_171
{
    //static void Main(string[] args)
    //{
    //    var solution = new Solution();
    //    while (true)
    //    {
    //        //int input = int.Parse(Console.ReadLine());
    //        string input = Console.ReadLine();
    //        //string input2 = Console.ReadLine();
    //        var res = solution.TitleToNumber(input);
    //        Console.WriteLine(res);
    //    }
    //}
    public class Solution
    {        
        public int TitleToNumber(string s)
        {
            int sum = 0;
            for (int i = s.Length - 1; i >= 0; i--)
            {
                sum += (s[i] - ('A' - 1)) * (int)Math.Pow(26, s.Length - 1 - i);
            }
            return sum;
        }
    }
}
