using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode_7
{
    //static void Main(string[] args)
    //{
    //    var solution = new Solution();
    //    while (true)
    //    {
    //        int input = int.Parse(Console.ReadLine());
    //        var res = solution.Reverse(input);
    //        Console.WriteLine(res);
    //    }
    //}
    public class Solution
    {
        public int Reverse(int x)
        {
            int res = 0;
            while (x != 0)
            {
                int pop = x % 10;
                if ((res > int.MaxValue / 10) || (res == int.MaxValue / 10 && pop > 7)) return 0;
                if ((res < int.MinValue / 10) || (res == int.MinValue / 10 && pop < -8)) return 0;
                res = res * 10 + pop;
                x /= 10;
            }
            return res;
        }
    }
}
