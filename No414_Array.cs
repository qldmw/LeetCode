using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode_414
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
    //        var res = solution.ThirdMax(intArr);
    //        Console.WriteLine(res);
    //    }
    //}

    public class Solution
    {
        /// <summary>
        /// 基础SortedSet数据结构完成，SortedSet是基于树的hash set，树的查找效率应该是log n。我看这个实现里单独拉出了Max和Min，所以我这里这用了Min应该是O(1)的查找复杂度，
        /// 没有用到特定数字的查到
        /// 时间复杂度：O(n), 遍历n, SortedSet的查找最小数 O(1)，SortedSet的添加是O(logn)，但是由于给定了只找第三大的，所以这个可以看做是常数时间复杂度O(1)
        /// 空间复杂度：O(1), 一个最大容量为3的SortedSet
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int ThirdMax(int[] nums)
        {
            SortedSet<int> ts = new SortedSet<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (ts.Count < 3)
                    ts.Add(nums[i]);
                else
                {
                    if (!ts.Contains(nums[i]) && nums[i] > ts.Min)
                    {
                        ts.Remove(ts.Min);
                        ts.Add(nums[i]);
                    }
                }
            }
            return ts.Count == 3 ? ts.Min : ts.Last();
        }
    }
}
