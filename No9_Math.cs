using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode_9
{
    //static void Main(string[] args)
    //{
    //    var solution = new Solution();
    //    while (true)
    //    {
    //        int input = int.Parse(Console.ReadLine());
    //        var res = solution.IsPalindrome(input);
    //        Console.WriteLine(res);
    //    }
    //}
    
    public class Solution
    {
        /// <summary>
        /// 翻转数解法
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public bool IsPalindrome(int x)
        {
            if (x < 0 || (x % 10 == 0 && x != 0)) return false;

            int revertNum = 0;
            while (x > revertNum)
            {
                revertNum = revertNum * 10 + x % 10;
                x /= 10;
            }
            return x == revertNum || x == revertNum / 10;
        }

        /// <summary>
        /// 第一反应解法
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        //public bool IsPalindrome(int x)
        //{
        //    //为负数时一定不是回文
        //    if (x < 0) return false;
        //    //int[] list = new int[x.ToString().Length];
        //    //将x转化为一个整型数组
        //    var list = new List<int>();
        //    int temp = x;
        //    while (temp != 0)
        //    {
        //        list.Add(temp % 10);
        //        temp /= 10;
        //    }
        //    //判断
        //    bool isPalindorme = true;
        //    for (int i = 0; i < list.Count - 1; i++)
        //    {
        //        if (i > list.Count - 1 - i) break;
        //        if (list[i] == list[list.Count - 1 - i]) continue;
        //        else
        //        {
        //            isPalindorme = false;
        //            break;
        //        }
        //    }
        //    return isPalindorme;
        //}
    }
}
