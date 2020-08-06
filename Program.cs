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
                //int?[] data = new int?[] { 1, 2, 5, 3, 4, null, 6 };
                //var tree = builder.BuildTree(data);
                //var listNode = builder.BuildListNode(new int[] { 1, 4, 5 });
                //int[][] arr = new int[3][] { new int[] { 1, 3, 1 }, new int[] { 1, 5, 1 }, new int[] { 4, 2, 1 } };
                //int[] nums1 = new int[] { 2, 1, -2, 3 };
                //int[] nums2 = new int[] { 10, 15, 20 };
                //string input = "adceb";
                //string input2 = "*a*b";
                int[][] data = new int[][]
                {
                    //new int[] {1, 0},
                    //new int[] {2, 1},

                    //new int[] {1, 0},
                    //new int[] {0, 1},

                    //new int[] {1, 0},
                    //new int[] {1, 2},
                    //new int[] {0, 1},

                    new int[] {1, 0},
                    new int[] {2, 6},
                    new int[] {1, 7},
                    new int[] {5, 1},
                    new int[] {6, 4},
                    new int[] {7, 0},
                    new int[] {0, 5},
                };
                var res = solution.CanFinish(8, data);
                ConsoleX.WriteLine(res);
            }
        }

        
    }
}