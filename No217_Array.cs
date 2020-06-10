using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode_217
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
    //        solution.ContainsDuplicate(intArr);
    //        //Console.WriteLine(res);
    //    }
    //}

    public class Solution
    {
        /// <summary>
        /// 偷了一手内存消耗第一名的,使用更小的数据结构来获得更小的体积和更快的性能
        /// Experience:单纯的使用hashSet可以用ISet来替代，可以更快，不过似乎也不用贪这么一点性能。但是知道更多总是好的。
        /// ISet<T> : ICollection<T>, IEnumerable<T>, IEnumerable
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public bool ContainsDuplicate(int[] nums)
        {
            ISet<int> hs = new HashSet<int>();
            foreach (var num in nums)
            {
                if (!hs.Add(num))
                    return true;
            }
            return false;
        }

        /// <summary>
        /// 使用linq groupBy甚至比上一个手写的更快，快了4ms，但是多用了7m的空间
        /// 使用linq distinct更快，比groupBy又快了20ms,只比手写的打了0.9m的空间
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        //public bool ContainsDuplicate(int[] nums)
        //{
        //    return nums.Distinct().Count() != nums.Length;
        //    //return nums.GroupBy(s => s).Any(s => s.Count() > 1);
        //}

        /// <summary>
        /// 使用hashset
        /// 时间复杂度：O(n)
        /// 空间复杂度：O(1)
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        //public bool ContainsDuplicate(int[] nums)
        //{
        //    HashSet<int> hs = new HashSet<int>();
        //    for (int i = 0; i < nums.Length; i++)
        //    {
        //        if (hs.Contains(nums[i]))
        //            return false;
        //        else
        //            hs.Add(nums[i]);
        //    }
        //    return true;
        //}
    }
}
