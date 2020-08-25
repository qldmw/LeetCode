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
                //string input = Console.ReadLine();
                //string input2 = Console.ReadLine();
                //int[] intArr = input.Split(',').Select(s => int.Parse(s)).ToArray();
                //int input2 = int.Parse(Console.ReadLine());
                //var builder = new DataStructureBuilder();
                //int?[] data = new int?[] { 1, 2, 3, 4, 5, null, 6, null, null, 7, 8 };
                //var tree = builder.BuildTree(data);
                //var listNode = builder.BuildListNode(new int[] { 1, 4, 5 });
                //int[][] arr = new int[3][] { new int[] { 1, 3, 1 }, new int[] { 1, 5, 1 }, new int[] { 4, 2, 1 } };
                //string input = "abcbefga";
                //string input2 = "dbefga";
                //int[] nums2 = new int[] { 2, 1, 1, 5, 11, 5, 1, 7, 5, 6, 4, 3 };
                //int[] nums3 = new int[] { 10, 15, 20 };
                //int[] nums1 = new int[] { 10, 9, 2, 5, 3, 7, 101, 18 };
                var res = solution.AddStrings("111111111111111111111111111111111","222222222222222222222222222222222222222");
                ConsoleX.WriteLine(res);
            }
        }

        public class Solution
        {
            public string AddStrings(string num1, string num2)
            {
                int len1 = num1.Length;
                int len2 = num2.Length;
                int loop = Math.Max(len1, len2);
                char[] res = new char[loop];
                int carry = 0;
                for (int i = 0; i < loop; i++)
                {
                    int digit1 = len1 - 1 - i < 0 ? 0 : num1[len1 - 1 - i] - '0';
                    int digit2 = len2 - 1 - i < 0 ? 0 : num2[len2 - 1 - i] - '0';
                    int num = digit1 + digit2 + carry;

                    carry = num / 10;
                    res[loop - 1 - i] = (char)(num % 10 + '0');
                }
                return carry == 0 ? new string(res) : "1" + new string(res);
            }
        }
    }
}