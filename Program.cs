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
                int input2 = int.Parse(Console.ReadLine());
                //string input = Console.ReadLine();
                //string input2 = Console.ReadLine();
                //int[] intArr = input.Split(',').Select(s => int.Parse(s)).ToArray();
                //int input = int.Parse(input2);
                var res = solution.Divide(input, input2);
                Console.WriteLine(res);
            }
        }

        public class Solution
        {
            public int Divide(int dividend, int divisor)
            {
                int did = Math.Abs(dividend);
                int dis = Math.Abs(divisor);
                //最后的符号位,
                bool sign = !((did == divisor) ^ (dis == divisor));

            }
        }
    }
}
