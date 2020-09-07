using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode_347
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
    //        //int?[] data = new int?[] { 1, 2, 3, 4, 5, null, 6, null, null, 7, 8 };
    //        //var tree = builder.BuildTree(data);
    //        //var listNode = builder.BuildListNode(new int[] { 1, 4, 5 });
    //        //int[][] arr = new int[3][] { new int[] { 1, 3, 1 }, new int[] { 1, 5, 1 }, new int[] { 4, 2, 1 } };
    //        //string input = "abcbefga";
    //        //string input2 = "dbefga";
    //        //int[] nums2 = new int[] { 2, 1, 1, 5, 11, 5, 1, 7, 5, 6, 4, 3 };
    //        //int[] nums3 = new int[] { 10, 15, 20 };
    //        int[] nums1 = new int[] { 1, 1, 1, 2, 2, 3 };
    //        //IList<IList<int>> data = new List<IList<int>>()
    //        //{
    //        //    new List<int>() { 1, 3 },
    //        //    new List<int>() { 3, 0, 1 },
    //        //    new List<int>() { 2 },
    //        //    new List<int>() { 0 }

    //        //    //new List<int>() { 1 },
    //        //    //new List<int>() { 2 },
    //        //    //new List<int>() { 3 },
    //        //    //new List<int>() {  }
    //        //};
    //        var res = solution.TopKFrequent(nums1, 2);
    //        ConsoleX.WriteLine(res);
    //    }
    //}

    public class Solution
    {
        /// <summary>
        /// 第一反应解优化
        /// 时间复杂度：O(nlogn),这里虽然看起来时间复杂度下降了，但是在 k 值小（比如k = 1）的情况下，这么做也不划算的，因为需要对整个来排序
        /// 空间复杂度：O(n)
        /// 题解里还有一个类似快速选择的解法，不过不想写了，纸面上计算可以达到O(n)，我觉得实际上性能应该不高。少的情况下插入更快，多的时候全排序更快，可能中间情况下这个会更好，不过需要试试才能证明了
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int[] TopKFrequent(int[] nums, int k)
        {
            Dictionary<int, int> dic = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (dic.ContainsKey(nums[i]))
                    dic[nums[i]]++;
                else
                    dic.Add(nums[i], 1);
            }

            int[] res = new int[k];
            List<KeyValuePair<int, int>> countSortedList = dic.ToList();
            //Knowledge: List的Sort方法，return 前一个减去后一个，是倒序；return 后一个减前一个，是正序。
            countSortedList.Sort((a, b) => { return b.Value - a.Value; });
            for (int i = 0; i < k; i++)
            {
                res[i] = countSortedList[i].Key;
            }
            return res;
        }

        ///// <summary>
        ///// 第一反应解
        ///// 时间复杂度：O(n²),最后计数数组取出的部分可以整体排序，当然也可以直接这样类似插入排序的取法，重点是要看 k 的大小，小就插入，大就整体排序。
        ///// 空间复杂度：O(n)
        ///// </summary>
        ///// <param name="nums"></param>
        ///// <param name="k"></param>
        ///// <returns></returns>
        //public int[] TopKFrequent(int[] nums, int k)
        //{
        //    Dictionary<int, int> dic = new Dictionary<int, int>();
        //    for (int i = 0; i < nums.Length; i++)
        //    {
        //        if (dic.ContainsKey(nums[i]))
        //            dic[nums[i]]++;
        //        else
        //            dic.Add(nums[i], 1);
        //    }

        //    int[] res = new int[k];
        //    for (int i = 0; i < k; i++)
        //    {
        //        int maxCount = int.MinValue;
        //        int maxKey = -1;
        //        foreach (var kvp in dic)
        //        {
        //            if (kvp.Value > maxCount)
        //            {
        //                maxCount = kvp.Value;
        //                maxKey = kvp.Key;
        //            }
        //        }
        //        res[i] = maxKey;
        //        dic.Remove(maxKey);
        //    }
        //    return res;
        //}
    }
}
