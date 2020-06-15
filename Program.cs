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
                //int input = int.Parse(Console.ReadLine());
                //int input2 = int.Parse(Console.ReadLine());
                //int input3 = int.Parse(Console.ReadLine());
                //string input = Console.ReadLine();
                ////string input2 = Console.ReadLine();
                //int[] intArr = input.Split(',').Select(s => int.Parse(s)).ToArray();
                //int input2 = int.Parse(Console.ReadLine());
                //int[] intArr = new int[] { 1, 3, 2 };
                int[] intArr = new int[] { 4, 2, 1, 3, 2, 6, 3 };
                int[] intArr2 = new int[] { 4, 2, 1, 3, 2, 6, 3 };
                solution.FindMedianSortedArrays(intArr, intArr2);
                //ConsoleX.WriteLine(res);
            }
        }

        public class Solution
        {
            public double FindMedianSortedArrays(int[] nums1, int[] nums2)
            {

            }
        }
    }
}