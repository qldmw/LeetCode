using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode_66
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
    //        //string input2 = Console.ReadLine();
    //        int[] intArr = input.Split(',').Select(s => int.Parse(s)).ToArray();
    //        //int input = int.Parse(input2);
    //        //int[][] intArr = new int[][]
    //        //{
    //        //    new int[]{1,2,3,4},
    //        //    new int[]{5,6,7,8},
    //        //    new int[]{9,10,11,12},
    //        //};
    //        var res = solution.PlusOne(intArr);
    //        ConsoleX.WriteLine(res);
    //    }
    //}

    public class Solution
    {
        /// <summary>
        /// 第一反应解，单纯的进位
        /// 时间复杂度：O(n)
        /// 空间复杂度：O(1),嗯，实际上应该是O(n),因为原数组不能直接获得答案，怎么样也要new一个，但只考虑算法空间的话，是O(1)
        /// 有些写法很巧妙，但是我觉得但凡要让人想一下的，都不算“好”代码，所以保持简单平素的风格。
        /// </summary>
        /// <param name="digits"></param>
        /// <returns></returns>
        public int[] PlusOne(int[] digits)
        {
            bool carry = false;
            digits[digits.Length - 1]++;
            for (int i = digits.Length - 1; i >= 0; i--)
            {
                if (carry)
                {
                    digits[i]++;
                    carry = false;
                }

                if (digits[i] >= 10)
                {
                    digits[i] %= 10;
                    carry = true;
                }
                else
                    break;
            }
            if (carry)
            {
                var temp = digits.ToList();
                temp.Insert(0, 1);
                digits = temp.ToArray();
            }
            return digits;
        }
    }
}
