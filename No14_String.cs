using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode_14
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
    //        //string[] intArr = new string[] { "flower", "flow", "flight" };
    //        //string[] intArr = new string[] { "dog", "racecar", "car" };
    //        //string[] intArr = new string[] { "a" };
    //        string[] intArr = new string[] { "c", "c" };
    //        var res = solution.LongestCommonPrefix(intArr);
    //        ConsoleX.WriteLine(res);
    //    }
    //}

    public class Solution
    {
        /// <summary>
        /// 因为官方解题给的答案里，直接纵向比对会比二分法快（纵向时间复杂度O(mn),二分法O(mnLogm)），我就不解了，试了下，还是二分法快
        /// 时间复杂度：O(strs.length * min(strs))
        /// 空间复杂度：O(1)
        /// </summary>
        /// <param name="strs"></param>
        /// <returns></returns>
        public string LongestCommonPrefix(string[] strs)
        {
            string res = string.Empty;
            if (strs == null || strs.Length == 0)
                return res;

            if (strs.Length == 1)
                return strs[0];

            //遍历找出最长公共前缀
            int prefixIndex = 0;
            for (int i = 0; i < strs[0].Length; i++)
            {
                if (strs.All(s => s.StartsWith(strs[0].Substring(0, i + 1))))
                    prefixIndex = i + 1;
            }

            return strs[0].Substring(0, prefixIndex);
        }

        /// <summary>
        /// 找最短的字符串来纵向对比，对比使用二分法
        /// 时间复杂度：O(strs.length * log Min(strs))
        /// 空间复杂度：O(1)
        /// </summary>
        /// <param name="strs"></param>
        /// <returns></returns>
        //public string LongestCommonPrefix(string[] strs)
        //{
        //    string res = string.Empty;
        //    if (strs == null || strs.Length == 0)
        //        return res;

        //    //找出最短的字符串
        //    res = strs[0];
        //    for (int i = 1; i < strs.Length; i++)
        //    {
        //        if (strs[i].Length < res.Length)
        //            res = strs[i];
        //    }
        //    //如果最短的是空字符串，那就返回
        //    if (res == string.Empty)
        //        return res;

        //    //用最短的字符串做二分法比较
        //    int left = 0;
        //    int right = res.Length - 1;
        //    while (left <= right)
        //    {
        //        int mid = (left + right) / 2;
        //        if (strs.All(s => s.StartsWith(res.Substring(0, mid + 1))))
        //            left = mid + 1;
        //        else
        //            right = mid - 1;
        //    }

        //    return res.Substring(0, left);
        //}
    }
}
