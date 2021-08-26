using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Extension;
using LeetCode.ExtensionFunction;
using System.Threading.Tasks;
using System.Threading;

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
                //var builder = new DataStructureBuilder();
                //int?[] data = new int?[] { 3, 5, 1, 6, 2, 0, 8, null, null, 7, 4 };
                //var tree = builder.BuildTree(data);
                //var listNode = builder.BuildListNode(new int[] { 1, 4, 5 });
                //int[][] arr = new int[3][] { new int[] { 1, 3, 1 }, new int[] { 1, 5, 1 }, new int[] { 4, 2, 1 } };
                //string input = "abcbefga";
                //string input2 = "dbefga";
                int[] nums1 = new int[] { 1, 3, 5, 7, 9, 11, 15, 19 };
                //int[] nums2 = new int[] { 1, 1 };
                //IList<IList<int>> data = new List<IList<int>>()
                //{
                //    new List<int>() { 1, 3 },
                //    new List<int>() { 3, 0, 1 },
                //    new List<int>() { 2 },
                //    new List<int>() { 0 }

                //    //new List<int>() { 1 },
                //    //new List<int>() { 2 },
                //    //new List<int>() { 3 },
                //    //new List<int>() {  }
                //};

                var res = solution.NumberOfArithmeticSlices(nums1);
                ConsoleX.WriteLine(res);
            }
        }

        public class Solution
        {
            /// <summary>
            /// 一次遍历
            /// 时间复杂度：O(n), 看起来是两层循环，其实就只会是一次
            /// 空间复杂度：O(1)
            /// </summary>
            /// <param name="nums"></param>
            /// <returns></returns>
            public int NumberOfArithmeticSlices(int[] nums)
            {
                int res = 0;
                for (int i = 0; i < nums.Length - 2; i++)
                {
                    //等差数列长度
                    int arithmeticCount = 0;
                    //既定差值
                    int difference = nums[i + 1] - nums[i];
                    int prevNum = nums[i + 1];
                    for (int j = i + 1; j < nums.Length - 1; j++)
                    {
                        if (nums[j + 1] - prevNum == difference)
                        {
                            prevNum = nums[j + 1];
                            arithmeticCount = arithmeticCount >= 3 ? arithmeticCount + 1 : 3;
                        }
                        else
                            break;
                    }
                    if (arithmeticCount != 0)
                    {
                        res += CalculateTriangularNumber(arithmeticCount - 2);
                        i = i + arithmeticCount - 2;
                    }
                }
                return res;

                int CalculateTriangularNumber(int count)
                {
                    if (count <= 0)
                        return 0;
                    int res = 0;
                    for (int i = 1; i <= count; i++)
                    {
                        res += i;
                    }
                    return res;
                }
            }
        }
    }
}