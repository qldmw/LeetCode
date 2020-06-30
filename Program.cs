using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Extension;
using LeetCode.ExtensionFunction;

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
                //string input2 = Console.ReadLine();
                //int[] intArr = input.Split(',').Select(s => int.Parse(s)).ToArray();
                //int input2 = int.Parse(Console.ReadLine());
                //int?[] data = new int?[] { 6, 2, 8, 0, 4, 7, 9, null, null, 3, 5 };
                //int?[] data = new int?[] { 1, null, 2, 3 };
                //int?[] data = new int?[] { 1, 2, 2, 3, 3, null, null, 4, 4 };
                //int?[] data = new int?[] { 1, 2, null, 3 };
                //int?[] data = new int?[] { 1, 2, 2, 3, 3, 3, 3, 4, 4, 4, 4, 4, 4, null, null, 5, 5 };
                //var tree = new DataStructureBuilder().BuildTree(data);
                var res = solution.QuickSort(new int[] { 5, 2, 4, 1, 3, 6, 0 }, 4);
                ConsoleX.WriteLine(res);
            }
        }

        public class Solution
        {

        }
    }
}