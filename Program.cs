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
                //string input = "A man, a plan, a canal: Panama";
                //string input2 = Console.ReadLine();
                int[] intArr = input.Split(',').Select(s => int.Parse(s)).ToArray();
                //int input2 = int.Parse(Console.ReadLine());
                //int[] intArr = new int[] { 1, 3, 2 };
                //int[] intArr = new int[] { 1, 3 };
                var res = solution.FirstMissingPositive(intArr);
                ConsoleX.WriteLine(res);
            }
        }

        public class Solution
        {
            public int FirstMissingPositive(int[] nums)
            {
                bool isIncludeOne = false;
                for (int i = 0; i < nums.Length; i++)
                {
                    if (nums[i] == 1)
                        isIncludeOne = true;
                    if (nums[i] < 1 || nums[i] > nums.Length)
                        nums[i] = 1;
                }
                if (!isIncludeOne)
                    return 1;

                for (int i = 0; i < nums.Length; i++)
                {
                    if (nums[Math.Abs(nums[i]) - 1] > 0)
                        nums[Math.Abs(nums[i]) - 1] *= -1;
                }

                for (int i = 0; i < nums.Length; i++)
                {
                    if (nums[i] > 0)
                        return i + 1;
                }
                return nums.Length + 1;
            }
        }
    }
}