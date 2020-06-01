using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode_69
{
    //static void Main(string[] args)
    //{
    //    var solution = new Solution();
    //    while (true)
    //    {
    //        int input = int.Parse(Console.ReadLine());
    //        //string input = Console.ReadLine();
    //        //string input2 = Console.ReadLine();
    //        var res = solution.MySqrt(input);
    //        Console.WriteLine(res);
    //    }
    //}
    public class Solution
    {
        /// <summary>
        /// 二分法
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public int MySqrt(int x)
        {
            if (x == 0 || x == 1)
            {
                return x;
            }
            //左标点
            int left = 0;
            //右标点
            int right = x;
            while (right - left != 1)
            {
                int mid = (left + right) / 2;
                if (Math.Pow(mid, 2) > x)
                    right = mid;
                else
                    left = mid;
            }
            return left;
        }

        /// <summary>
        /// 数学公式替换绕过不让使用sqrt的限制，换底，高等数学
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        //public int MySqrt(int x)
        //{
        //    if (x == 0)
        //    {
        //        return 0;
        //    }
        //    int ans = (int)Math.Exp(0.5 * Math.Log(x));
        //    return (long)(ans + 1) * (ans + 1) <= x ? ans + 1 : ans;
        //}

        /// <summary>
        /// 第一反应解，直接使用函数，不过面试一般不会让用的啦，要不考函数调用有什么意义
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        //public int MySqrt(int x)
        //{                
        //    return (int)Math.Floor(Math.Sqrt(x));
        //}
    }
}
