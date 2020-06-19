using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode_41
{
    //static void Main(string[] args)
    //{
    //    var solution = new Solution();
    //    while (true)
    //    {
    //        //int input = int.Parse(Console.ReadLine());
    //        //int input2 = int.Parse(Console.ReadLine());
    //        //int input3 = int.Parse(Console.ReadLine());
    //        string input = Console.ReadLine();
    //        //string input = "A man, a plan, a canal: Panama";
    //        //string input2 = Console.ReadLine();
    //        int[] intArr = input.Split(',').Select(s => int.Parse(s)).ToArray();
    //        //int input2 = int.Parse(Console.ReadLine());
    //        //int[] intArr = new int[] { 1, 3, 2 };
    //        //int[] intArr = new int[] { 1, 3 };
    //        var res = solution.FirstMissingPositive(intArr);
    //        ConsoleX.WriteLine(res);
    //    }
    //}

    public class Solution
    {
        /// <summary>
        /// 在原数组基础上利用正负号储存信息，而且不影响本身的信息
        /// 时间复杂度：O(n)
        /// 空间复杂度：O(1),其实完全可以用一个O(n)的dictionary来做，这道题的关键就在于如果不开辟新空间，存贮老信息。
        /// Experience：定长的数组问题可以使用正负号来储存额外信息
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
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
