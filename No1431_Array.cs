using System;
using System.Collections.Generic;
using System.Extension;
using System.Linq;
using System.Text;

namespace LeetCode_1431
{
    //static void Main(string[] args)
    //{
    //    var solution = new Solution();
    //    while (true)
    //    {
    //        //int input = int.Parse(Console.ReadLine());
    //        string input = Console.ReadLine();
    //        string input2 = Console.ReadLine();
    //        int[] candies = input.Split(',').Select(s => int.Parse(s)).ToArray();
    //        int extraCandies = int.Parse(input2);

    //        var res = solution.KidsWithCandies(candies, extraCandies);
    //        ConsoleX.WriteLine(res.ToArray());
    //    }
    //}

    public class Solution
    {
        /// <summary>
        /// 单纯的算一下加起来是不是最大值
        /// 时间复杂度：O(n),我们首先使用 O(n)O(n) 的时间预处理出所有小朋友拥有的糖果数目最大值。对于每一个小朋友，我们需要 O(1) 的时间判断这个小朋友
        /// 是否可以拥有最多的糖果，故渐进时间复杂度为 O(n)
        /// 空间复杂度：O(1),这里只用了常数个变量作为辅助空间，与 nn 的规模无关，故渐进空间复杂度为 O(1)。
        /// </summary>
        /// <param name="candies"></param>
        /// <param name="extraCandies"></param>
        /// <returns></returns>
        public IList<bool> KidsWithCandies(int[] candies, int extraCandies)
        {
            int maxNum = candies.Max();
            bool[] res = new bool[candies.Length];
            for (int i = 0; i < candies.Length; i++)
            {
                res[i] = candies[i] + extraCandies >= maxNum;
            }
            return res;
        }
    }
}
