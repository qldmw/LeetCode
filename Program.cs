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
                string input = Console.ReadLine();
                //string input2 = Console.ReadLine();
                int[] intArr = input.Split(',').Select(s => int.Parse(s)).ToArray();
                int input2 = int.Parse(Console.ReadLine());
                var res = solution.TwoSum(intArr, input2);
                ConsoleX.WriteLine(res);
                //ConsoleX.WriteLine(res);
            }
        }

        /// <summary>
        /// Experience：但凡见到有序数组的查找，就要直接想到二分法
        /// </summary>
        public class Solution
        {
            /// <summary>
            /// 第一反应解，遍历 + 二分法
            /// </summary>
            /// <param name="numbers"></param>
            /// <param name="target"></param>
            /// <returns></returns>
            public int[] TwoSum(int[] numbers, int target)
            {
                int[] res = new int[2];
                for (int i = 0; i < numbers.Length; i++)
                {
                    int targerIndex = Recursive(numbers, i + 1, numbers.Length - 1, target - numbers[i]);
                    if (targerIndex != -1)
                    {
                        res[0] = i + 1;
                        res[1] = targerIndex + 1;
                        break;
                    }
                }
                return res;
            }

            private int Recursive(int[] numbers, int left, int right, int target)
            {
                int mid = (left + right) / 2;
                if (numbers[mid] == target)
                    return mid;
                else if (left >= right)
                    return -1;
                
                if (numbers[mid] > target)
                    return Recursive(numbers, left, mid - 1, target);
                else
                    return Recursive(numbers, mid + 1, right, target);
            }
        }
    }
}