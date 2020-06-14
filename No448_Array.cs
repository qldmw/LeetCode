using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode_448
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
    //        ////string input2 = Console.ReadLine();
    //        //int[] intArr = input.Split(',').Select(s => int.Parse(s)).ToArray();
    //        //int input2 = int.Parse(Console.ReadLine());
    //        int[] intArr = new int[] { 4, 3, 2, 7, 8, 2, 3, 1 };
    //        var res = solution.FindDisappearedNumbers(intArr);
    //        ConsoleX.WriteLine(res);
    //    }
    //}

    public class Solution
    {
        /// <summary>
        /// 通过负数标记已经遍历了的数来解决问题
        /// 时间复杂度：O(n)
        /// 空间复杂度：O(1)
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<int> FindDisappearedNumbers(int[] nums)
        {
            //Knowledge:快速定义一个包含默认值的数组：Enumerable.Repeat(0, nums.Length).ToArray()
            List<int> res = new List<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[Math.Abs(nums[i]) - 1] > 0)
                    nums[Math.Abs(nums[i]) - 1] *= -1;
            }
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] > 0)
                    res.Add(i + 1);
            }
            return res.ToArray();
        }

        /// <summary>
        /// hashSet解决标记
        /// 时间复杂度：O(n)
        /// 空间复杂度：O(1)
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        //public IList<int> FindDisappearedNumbers(int[] nums)
        //{
        //    HashSet<int> hs = new HashSet<int>();
        //    for (int i = 0; i < nums.Length; i++)
        //    {
        //        hs.Add(nums[i]);
        //    }
        //    List<int> res = new List<int>();
        //    for (int i = 1; i < nums.Length + 1; i++)
        //    {
        //        if (!hs.Contains(i))
        //            res.Add(i);
        //    }
        //    return res.ToArray();
        //}
    }
}
