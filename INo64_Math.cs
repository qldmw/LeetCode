using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode_I64
{
    //static void Main(string[] args)
    //{
    //    var solution = new Solution();
    //    while (true)
    //    {
    //        int input = int.Parse(Console.ReadLine());
    //        //int input2 = int.Parse(Console.ReadLine());
    //        //string input = Console.ReadLine();
    //        //string input2 = Console.ReadLine();
    //        //int[] intArr = input.Split(',').Select(s => int.Parse(s)).ToArray();
    //        //int input = int.Parse(input2);
    //        var res = solution.SumNums(input);
    //        Console.WriteLine(res);
    //    }
    //}

    /// <summary>
    /// REVIEW
    /// 2020.08.03: 要求的难点就是不能使用if等关键字，但是其实也是用了，只不过是用了另外的方法躲开了检测而已。
    /// </summary>

    /// <summary>
    /// Unsolved Question: 为什么使用了类中全局的变量，避免了递归每次申请变量，反而内存消耗变大了。这个递归应该会申请很多个bool才对啊
    /// </summary>
    public class Solution
    {
        /// 这个变量放在外面内存消耗会大一些,大了0.1-0.2MB,没有搞懂
        private bool _uselessTemp;
        /// <summary>
        /// 递归获取
        /// 时间复杂度：O(n)。递归函数递归 nn 次，每次递归中计算时间复杂度为 O(1)，因此总时间复杂度为 O(n)。
        /// 空间复杂度：O(n)。递归函数的空间复杂度取决于递归调用栈的深度，这里递归函数调用栈深度为 O(n)，因此空间复杂度为 O(n)。
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int SumNums(int n)
        {
            _uselessTemp = (n > 0) && (n += SumNums(n - 1)) > 0;
            return n;
        }

        /// <summary>
        /// 俄罗斯农民乘法（和我第一反应很相似），主要使用等差数列求和公式1+2+⋯+n 等价于(n(n+1))/2。
        /// 时间复杂度：O(logn)。快速乘需要的时间复杂度为 O(logn)。因为是位移操作，是指数级下降
        /// 空间复杂度：O(1)。只需要常数空间存放若干变量。
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        //public int SumNums(int n)
        //{
        //    int m = n + 1;
        //    int res = 0;
        //    bool uselessTemp;
        //    //1 <= n <= 10000,第十五位代表的是16384,那么十四位就可以代表（16383）包含10000,所以左移14次就可以获得答案
        //    uselessTemp = (m & 1) == 1 && (res += n) > 0;
        //    n <<= 1;
        //    m >>= 1;

        //    uselessTemp = (m & 1) == 1 && (res += n) > 0;
        //    n <<= 1;
        //    m >>= 1;

        //    uselessTemp = (m & 1) == 1 && (res += n) > 0;
        //    n <<= 1;
        //    m >>= 1;

        //    uselessTemp = (m & 1) == 1 && (res += n) > 0;
        //    n <<= 1;
        //    m >>= 1;

        //    uselessTemp = (m & 1) == 1 && (res += n) > 0;
        //    n <<= 1;
        //    m >>= 1;

        //    uselessTemp = (m & 1) == 1 && (res += n) > 0;
        //    n <<= 1;
        //    m >>= 1;

        //    uselessTemp = (m & 1) == 1 && (res += n) > 0;
        //    n <<= 1;
        //    m >>= 1;

        //    uselessTemp = (m & 1) == 1 && (res += n) > 0;
        //    n <<= 1;
        //    m >>= 1;

        //    uselessTemp = (m & 1) == 1 && (res += n) > 0;
        //    n <<= 1;
        //    m >>= 1;

        //    uselessTemp = (m & 1) == 1 && (res += n) > 0;
        //    n <<= 1;
        //    m >>= 1;

        //    uselessTemp = (m & 1) == 1 && (res += n) > 0;
        //    n <<= 1;
        //    m >>= 1;

        //    uselessTemp = (m & 1) == 1 && (res += n) > 0;
        //    n <<= 1;
        //    m >>= 1;

        //    uselessTemp = (m & 1) == 1 && (res += n) > 0;
        //    n <<= 1;
        //    m >>= 1;

        //    uselessTemp = (m & 1) == 1 && (res += n) > 0;
        //    n <<= 1;
        //    m >>= 1;

        //    return res >> 1;
        //}
    }
}
