using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode_268
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
    //        //int input2 = int.Parse(Console.ReadLine());
    //        var res = solution.MissingNumber(intArr);
    //        Console.WriteLine(res);
    //    }
    //}

    public class Solution
    {
        /// <summary>
        /// 位运算解法，通过异或来消除，最后剩下的就是缺失的。
        /// 时间复杂度：O(n)
        /// 空间复杂度：O(1)
        /// Experience：异或是一种拿来消除相同数的好方法，同样的数异或一下就消失了，很好用
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MissingNumber(int[] nums)
        {
            int missing = nums.Length;
            for (int i = 0; i < nums.Length; i++)
            {
                missing ^= nums[i] ^ i;
            }
            return missing;
        }

        /// <summary>
        /// 第一反应，数学求出
        /// 时间复杂度：O(n),高斯公式计算O(1),数组求和遍历O(n)
        /// 空间复杂度：O(1),嗯。。我其实都没有用变量存答案，是不是可以算是O(0),哈哈哈
        /// 这种解法做了没有收获，虽然是最优的。再试试其他解法，学习下
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        //public int MissingNumber(int[] nums)
        //{
        //    return (nums.Length * (nums.Length + 1)) / 2 - nums.Sum();
        //}
    }
}
