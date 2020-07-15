using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode_70
{
    //static void Main(string[] args)
    //{
    //    var solution = new Solution();
    //    while (true)
    //    {
    //        //int input = int.Parse(Console.ReadLine());
    //        //int input2 = int.Parse(Console.ReadLine());
    //        //string input = Console.ReadLine();
    //        //string input2 = Console.ReadLine();
    //        //int[] intArr = input.Split(',').Select(s => int.Parse(s)).ToArray();
    //        //int input2 = int.Parse(Console.ReadLine());
    //        //var builder = new DataStructureBuilder();
    //        //int?[] data = new int?[] { 10, 5, 15, null, null, 6, 20 };
    //        //var tree = builder.BuildTree(data);
    //        //var listNode = builder.BuildListNode(new int[] { 1, 4, 5 });
    //        //int[] nums1 = new int[] { 1, 2, 2, 1 };
    //        //int[] nums2 = new int[] { 2, 2 };
    //        var res = solution.ClimbStairs(7);
    //        ConsoleX.WriteLine(res);
    //    }
    //}

    public class Solution
    {
        /// <summary>
        /// 通项公式。通过总结可得 f(x) = f(x-1) + f(x-2), 然后退出特征方程 x² = x + 1(说实话，我没搞懂这个怎么推出来的)，再利用求根
        /// 公式（2a分之负b加减根号下b平方减4ac）求得 x₁，x₂，设通解为 f(x) = c₁x₁ⁿ + c₂x₂ⁿ， 带入初始条件f(1) = 1, f(2) = 2 推出通项公式
        /// 时间复杂度：O(logn)
        /// 空间复杂度：O(1)
        /// 这个又可以叫做菲波列切数列第n项求解
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int ClimbStairs(int n)
        {
            double sqrt5 = Math.Sqrt(5);
            double fibn = Math.Pow((1 + sqrt5) / 2, n + 1) - Math.Pow((1 - sqrt5) / 2, n + 1);
            return (int)(fibn / sqrt5);
        }

        /// TODO: 矩阵快速幂

        /// <summary>
        /// 动态规划
        /// 时间复杂度：O(n)
        /// 空间复杂度：O(1),第一反应使用一个 n 长度的list，但其实没有必要。
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        //public int ClimbStairs(int n)
        //{
        //    int first = 0;
        //    int second = 0;
        //    int res = 1;
        //    //因为最后一步可能跨了一级台阶，也可能跨了两级台阶，所以步数的组合就是前两个组合相加的和
        //    //动态转移方程式 f(x) = f(x-1) + f(x-2)
        //    for (int i = 1; i <= n; i++)
        //    {
        //        first = second;
        //        second = res;
        //        res = first + second;
        //    }
        //    return res;
        //}
    }
}
