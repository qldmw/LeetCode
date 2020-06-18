using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode_125
{
    //static void Main(string[] args)
    //{
    //    var solution = new Solution();
    //    while (true)
    //    {
    //        //int input = int.Parse(Console.ReadLine());
    //        //int input2 = int.Parse(Console.ReadLine());
    //        //int input3 = int.Parse(Console.ReadLine());
    //        //string input = Console.ReadLine();
    //        //string input = "A man, a plan, a canal: Panama";
    //        string input = "race a car";
    //        //string input2 = Console.ReadLine();
    //        //int[] intArr = input.Split(',').Select(s => int.Parse(s)).ToArray();
    //        //int input2 = int.Parse(Console.ReadLine());
    //        //int[] intArr = new int[] { 1, 3, 2 };
    //        //int[] intArr = new int[] { 1, 3 };
    //        var res = solution.IsPalindrome(input);
    //        ConsoleX.WriteLine(res);
    //    }
    //}

    public class Solution
    {
        /// <summary>
        /// 第一反应解，左右指针。char.IsLetterOrDigit可以替换手动写的那个判断，而且会更优雅一些，但是不知道为什么运行之后会比手动写的方法慢。
        /// 时间复杂度：O(n)
        /// 空间复杂度：O(n),ToLower()的时候是产生了一个新的字符串的，也可以用代码去做大小写对比（达到O(1)的空间复杂度），但是感觉没有多大意义。
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public bool IsPalindrome(string s)
        {
            int left = 0, right = s.Length - 1;
            s = s.ToLower();
            while (left < right)
            {
                if (!IsVaild(s[left]))
                {
                    left++;
                    continue;
                }
                if (!IsVaild(s[right]))
                {
                    right--;
                    continue;
                }
                if (s[left] == s[right])
                {
                    left++;
                    right--;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }

        private bool IsVaild(char c)
        {
            return (c >= '0' && c <= '9') || (c >= 'a' && c <= 'z');
        }
    }
}
