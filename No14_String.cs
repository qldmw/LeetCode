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

    /// <summary>
    /// REVIEW
    /// 2020.08.21: 更新了二分法写法，需要注意几个关键点，二分加一减一这种
    /// </summary>

    public class Solution
    {
        /// <summary>
        /// 二分法，最优解
        /// 设 strs 中最短字符串长度为 m, strs数组个数为 n
        /// 时间复杂度：O(mnlogm)
        /// 空间复杂度：O(1)
        /// </summary>
        /// <param name="strs"></param>
        /// <returns></returns>
        public string LongestCommonPrefix(string[] strs)
        {
            if (strs == null || strs.Length == 0)
                return string.Empty;

            string minStr = strs[0];
            foreach (string str in strs)
            {
                if (str.Length < minStr.Length)
                    minStr = str;
            }

            //因为这里的 right 是给 substring 方法用的，所以不用 -1
            int left = 0, right = minStr.Length;
            while (left < right)
            {
                //这里 +1 补齐除法的缺损
                int mid = (left + right + 1) / 2;
                bool isCP = strs.All(s => s.StartsWith(minStr.Substring(0, mid)));
                //出现失败要不断减少才行，避免除法缺损导致始终没有减少，所以要在失败的情况下 -1
                if (isCP)
                    left = mid;
                else
                    right = mid - 1;
            }
            return minStr.Substring(0, left);
        }

        /// <summary>
        /// 因为官方解题给的答案里，直接纵向比对会比二分法快（纵向时间复杂度O(mn),二分法O(mnLogm)），我就不解了，试了下，还是二分法快
        /// 时间复杂度：O(strs.length * min(strs))
        /// 空间复杂度：O(1)
        /// </summary>
        /// <param name="strs"></param>
        /// <returns></returns>
        //public string LongestCommonPrefix(string[] strs)
        //{
        //    string res = string.Empty;
        //    if (strs == null || strs.Length == 0)
        //        return res;

        //    if (strs.Length == 1)
        //        return strs[0];

        //    //遍历找出最长公共前缀
        //    int prefixIndex = 0;
        //    for (int i = 0; i < strs[0].Length; i++)
        //    {
        //        if (strs.All(s => s.StartsWith(strs[0].Substring(0, i + 1))))
        //            prefixIndex = i + 1;
        //    }

        //    return strs[0].Substring(0, prefixIndex);
        //}
    }
}
