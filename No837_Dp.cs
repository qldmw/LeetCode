using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode_837
{
    //static void Main(string[] args)
    //{
    //    var solution = new Solution();
    //    while (true)
    //    {
    //        int input = int.Parse(Console.ReadLine());
    //        int input2 = int.Parse(Console.ReadLine());
    //        int input3 = int.Parse(Console.ReadLine());
    //        //string input = Console.ReadLine();
    //        //string input2 = Console.ReadLine();
    //        //int[] intArr = input.Split(',').Select(s => int.Parse(s)).ToArray();
    //        //int input = int.Parse(input2);
    //        var res = solution.New21Game(input, input2, input3);
    //        Console.WriteLine(res);
    //    }
    //}

    /// <summary>
    /// TODO:欠这个题解一个赞
    /// https://leetcode-cn.com/problems/new-21-game/solution/javani-xiang-dong-tai-gui-hua-jie-jue-shuang-100-b/
    /// 言简意赅，非常清晰的思路，堪称满分题解！
    /// </summary>
    public class Solution
    {
        /// <summary>
        /// 优化后的动态规划，不用循环来计算，每次移动到下一个的时候只需要入一个出一个就行了
        /// 时间复杂度：O(K + W)
        /// 空间复杂度：O(K + W)
        /// </summary>
        /// <param name="N"></param>
        /// <param name="K"></param>
        /// <param name="W"></param>
        /// <returns></returns>
        public double New21Game(int N, int K, int W)
        {
            double[] points = new double[K + W];
            double probabilitySum = 0;
            //算出不变的获胜概率，以此为锚点，反推之前的获胜概率
            for (int i = K; i < K + W; i++)
            {
                points[i] = i <= N ? 1.0 : 0.0;//直接写成带小数点的，避免执行的时候再隐式类型转换
                probabilitySum += points[i];
            }

            for (int i = K - 1; i >= 0; i--)
            {
                points[i] = probabilitySum / W;
                probabilitySum = probabilitySum + points[i] - points[i + W];
            }
            return points[0];
        }

        /// <summary>
        /// 由不变作为锚点，然后一步一步推算出变化的
        /// 由于双循环会导致超时，所以要优化一下做法
        /// </summary>
        /// <param name="N"></param>
        /// <param name="K"></param>
        /// <param name="W"></param>
        /// <returns></returns>
        //public double New21Game(int N, int K, int W)
        //{
        //    double[] points = new double[K + W];
        //    //算出不变的获胜概率，以此为锚点，反推之前的获胜概率
        //    for (int i = K; i < K + W; i++)
        //        points[i] = i <= N ? 1.0 : 0.0;//直接写成带小数点的，避免执行的时候再隐式类型转换
        //    for (int i = K - 1; i >= 0; i--)
        //    {
        //        double possibleSum = 0;
        //        for (int j = 1; j <= W; j++)
        //        {
        //            possibleSum += points[i + j];
        //        }
        //        points[i] = possibleSum / W;
        //    }
        //    return points[0];
        //}
    }
}
