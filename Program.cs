﻿using System;
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
                //int input = int.Parse(Console.ReadLine());
                //int input2 = int.Parse(Console.ReadLine());
                //int input3 = int.Parse(Console.ReadLine());
                string input = Console.ReadLine();
                //string input2 = Console.ReadLine();
                int[] intArr = input.Split(',').Select(s => int.Parse(s)).ToArray();
                int input2 = int.Parse(Console.ReadLine());
                var res = solution.ThreeSumClosest(intArr, input2);
                Console.WriteLine(res);
            }
        }

        public class Solution
        {
            public int ThreeSumClosest(int[] nums, int target)
            {

            }
        }
    }
}