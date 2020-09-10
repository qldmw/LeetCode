using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Extension;
using LeetCode.ExtensionFunction;
using System.Threading.Tasks;
using System.Threading;

namespace LeetCode
{
    class Program
    {
        static void Main(string[] args)
        {
            var solution = new Solution();
            while (true)
            {
                //int input = int.Parse(Console.ReadLine());
                //int input2 = int.Parse(Console.ReadLine());
                //int input3 = int.Parse(Console.ReadLine());
                //string input = Console.ReadLine();
                //string input2 = Console.ReadLine();
                //int[] intArr = input.Split(',').Select(s => int.Parse(s)).ToArray();
                //int input2 = int.Parse(Console.ReadLine());
                //var builder = new DataStructureBuilder();
                //int?[] data = new int?[] { 1, 2, 3, 4, 5, null, 6, null, null, 7, 8 };
                //var tree = builder.BuildTree(data);
                //var listNode = builder.BuildListNode(new int[] { 1, 4, 5 });
                //int[][] arr = new int[3][] { new int[] { 1, 3, 1 }, new int[] { 1, 5, 1 }, new int[] { 4, 2, 1 } };
                //string input = "abcbefga";
                //string input2 = "dbefga";
                //int[] nums2 = new int[] { 2, 1, 1, 5, 11, 5, 1, 7, 5, 6, 4, 3 };
                //int[] nums3 = new int[] { 10, 15, 20 };
                int[] nums1 = new int[] { 10, 1, 2, 7, 6, 1, 5 };
                //IList<IList<int>> data = new List<IList<int>>()
                //{
                //    new List<int>() { 1, 3 },
                //    new List<int>() { 3, 0, 1 },
                //    new List<int>() { 2 },
                //    new List<int>() { 0 }

                //    //new List<int>() { 1 },
                //    //new List<int>() { 2 },
                //    //new List<int>() { 3 },
                //    //new List<int>() {  }
                //};
                var res = solution.CombinationSum2(nums1, 8);
                ConsoleX.WriteLine(res);
            }
        }

        public class Solution
        {
            /// <summary>
            /// 回溯法优化，用逻辑代替 HashSet。
            /// </summary>
            /// <param name="candidates"></param>
            /// <param name="target"></param>
            /// <returns></returns>
            public IList<IList<int>> CombinationSum2(int[] candidates, int target)
            {
                IList<IList<int>> res = new List<IList<int>>();
                Array.Sort(candidates);
                BackTracking(new List<int>(), 0, target);
                return res;

                void BackTracking(List<int> addends, int left, int remain)
                {
                    if (remain == 0)
                    {
                        res.Add(addends.ToList());
                        return;
                    }

                    for (int i = left; i < candidates.Length; i++)
                    {
                        if (candidates[i] <= remain)
                        {
                            //这一步是优化的题眼。如果接下来的数和前一个是重复的，那么他的解一定已经出现过了。但是又不能回溯到这一步之前。又因为初始化是 i = left,所以不用对 i - 1进行判断是否越界。
                            if (i > left && candidates[i] == candidates[i - 1])
                                continue;
                            addends.Add(candidates[i]);
                            BackTracking(addends, i + 1, remain - candidates[i]);
                            addends.RemoveAt(addends.Count - 1);
                        }
                        else
                            break;
                    }
                }
            }

            ///// <summary>
            ///// 回溯法。用最简单的方式去重，把答案放到 HashSet 中，不过数据多了浪费空间还是挺大的。
            ///// </summary>
            ///// <param name="candidates"></param>
            ///// <param name="target"></param>
            ///// <returns></returns>
            //public IList<IList<int>> CombinationSum2(int[] candidates, int target)
            //{
            //    IList<IList<int>> res = new List<IList<int>>();
            //    HashSet<string> hash = new HashSet<string>();
            //    Array.Sort(candidates);
            //    BackTracking(new List<int>(), 0, target);
            //    return res;

            //    void BackTracking(List<int> addends, int left, int remain)
            //    {
            //        if (remain == 0)
            //        {
            //            string id = string.Join(',', addends);
            //            if (!hash.Contains(id))
            //            {
            //                hash.Add(id);
            //                res.Add(addends.ToList());
            //            }
            //            return;
            //        }

            //        for (; left < candidates.Length; left++)
            //        {
            //            if (candidates[left] <= remain)
            //            {
            //                addends.Add(candidates[left]);
            //                BackTracking(addends, left + 1, remain - candidates[left]);
            //                addends.RemoveAt(addends.Count - 1);
            //            }
            //            else
            //                break;
            //        }
            //    }
            //}
        }
    }
}