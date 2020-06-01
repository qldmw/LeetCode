using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode_12
{
    //static void Main(string[] args)
    //{
    //    var solution = new Solution();
    //    while (true)
    //    {
    //        int input = int.Parse(Console.ReadLine());
    //        //string input = Console.ReadLine();
    //        //string input2 = Console.ReadLine();
    //        var res = solution.IntToRoman(input);
    //        Console.WriteLine(res);
    //    }
    //}

    public class Solution
    {
        /// <summary>
        /// 按位来求值，看了官方的解答，这个应该是更优的解
        /// 时间复杂度：O(1),由于有一组有限的罗马数字，循环可以迭代多少次有一个硬上限。因此，我们说时间复杂度是常数的，即 O(1)。
        /// 空间复杂度：O(1),使用的内存量不会随输入整数的大小而改变，因此是常数的。
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public string IntToRoman(int num)
        {
            string str = string.Empty;
            for (int i = 0; num > 0; i++)
            {
                str = str.Insert(0, ConvertToRoman(num % 10, i));
                num /= 10;
            }
            return str;
        }

        private string ConvertToRoman(int n, int pos)
        {
            Dictionary<int, string[]> dic = new Dictionary<int, string[]>()
                {
                    { 0, new string[]{ "I", "V", "X" } },
                    { 1, new string[]{ "X", "L", "C" } },
                    { 2, new string[]{ "C", "D", "M" } },
                    { 3, new string[]{ "M" } }
                };

            switch (n)
            {
                case 0: return string.Empty;
                case 4: return $"{dic[pos][0]}{dic[pos][1]}";
                case 9: return $"{dic[pos][0]}{dic[pos][2]}";
                default:
                    {
                        if (n >= 5)
                        {
                            string ans = dic[pos][1];
                            while (n - 5 > 0)
                            {
                                ans += dic[pos][0];
                                n--;
                            }
                            return ans;
                        }
                        else
                        {
                            string ans = string.Empty;
                            while (n > 0)
                            {
                                ans += dic[pos][0];
                                n--;
                            }
                            return ans;
                        }
                    }
            }
        }
    }
}
