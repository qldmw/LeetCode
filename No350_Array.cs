using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode_350
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
    //        int[] nums1 = new int[] { 1, 2, 2, 1 };
    //        int[] nums2 = new int[] { 2, 2 };
    //        var res = solution.Intersect(nums1, nums2);
    //        ConsoleX.WriteLine(res);
    //    }
    //}

    public class Solution
    {
        /// <summary>
        /// hash表减少查找
        /// 设 nums1 长度为 n, nums2 长度为 m。
        /// 时间复杂度：O(n + m)
        /// 空间复杂度：O(n)
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="nums2"></param>
        /// <returns></returns>
        public int[] Intersect(int[] nums1, int[] nums2)
        {
            Dictionary<int, int> dic = new Dictionary<int, int>();
            List<int> res = new List<int>();

            for (int i = 0; i < nums1.Length; i++)
            {
                if (dic.ContainsKey(nums1[i]))
                    dic[nums1[i]]++;
                else
                    dic.Add(nums1[i], 1);
            }

            for (int i = 0; i < nums2.Length; i++)
            {
                if (dic.ContainsKey(nums2[i]) && dic[nums2[i]] > 0)
                {
                    res.Add(nums2[i]);
                    dic[nums2[i]]--;
                }
            }

            return res.ToArray();
        }
    }
}
