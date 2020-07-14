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
        /// TODO:通项公式

        /// TODO: 矩阵快速幂

        /// <summary>
        /// 动态规划
        /// 时间复杂度：O(n)
        /// 空间复杂度：O(1),第一反应使用一个 n 长度的list，但其实没有必要。
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int ClimbStairs(int n)
        {
            int first = 0;
            int second = 0;
            int res = 1;
            //因为最后一步可能跨了一级台阶，也可能跨了两级台阶，所以步数的组合就是前两个组合相加的和
            //动态转移方程式 f(x) = f(x-1) + f(x-2)
            for (int i = 1; i <= n; i++)
            {
                first = second;
                second = res;
                res = first + second;
            }
            return res;
        }
    }
}
