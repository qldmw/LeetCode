using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode_219
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
    //        int input2 = int.Parse(Console.ReadLine());
    //        var res = solution.ContainsNearbyDuplicate(intArr, input2);
    //        Console.WriteLine(res);
    //    }
    //}

    public class Solution
    {
        /// <summary>
        /// 使用HashSet
        /// 时间复杂度：O(n)，纯粹的一遍过，可能在遍历外还有些加HashSet的时间，但是因为HashSet的加减是O(1)的，所以还就是O(n)
        /// 空间复杂度：O(1)，始终维持一个k+1大小的HashSet，所以大小是常数级的
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public bool ContainsNearbyDuplicate(int[] nums, int k)
        {
            ISet<int> hs = new HashSet<int>(k);
            for (int i = 0; i < nums.Length; i++)
            {
                if (hs.Count > k)
                    hs.Remove(nums[i - k - 1]);

                if (!hs.Add(nums[i]))
                    return true;
            }
            return false;
        }

        /// <summary>
        /// 暴力求解，超时
        /// 时间复杂度：O(n*k)
        /// 空间复杂度：O(1)
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        //public bool ContainsNearbyDuplicate(int[] nums, int k)
        //{
        //    for (int i = 0; i < nums.Length; i++)
        //    {
        //        for (int j = i + 1; j < nums.Length && j <= i + k; j++)
        //        {
        //            if (nums[j] == nums[i])
        //                return true;
        //        }
        //    }
        //    return false;
        //}
    }
}
