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
                int input = int.Parse(Console.ReadLine());
                int input2 = int.Parse(Console.ReadLine());
                //string input = Console.ReadLine();
                //string input2 = Console.ReadLine();
                //int[] intArr = input.Split(',').Select(s => int.Parse(s)).ToArray();
                //int input2 = int.Parse(Console.ReadLine());
                //var builder = new DataStructureBuilder();
                //int?[] data = new int?[] { 10, 5, 15, null, null, 6, 20 };
                //var tree = builder.BuildTree(data);
                //var listNode = builder.BuildListNode(new int[] { 1, 4, 5 });
                //int[] nums1 = new int[] { 2, 1, 4, 5, 3, 1, 1, 3 };
                //int[] nums2 = new int[] { 10, 15, 20 };
                //string input = "abc";
                //string input2 = "ahbgdc";                
                var res = solution.UniquePaths(input, input2);
                ConsoleX.WriteLine(res);
            }
        }

        public class Solution
        {
            public int UniquePaths(int m, int n)
            {

            }
        }
    }
}