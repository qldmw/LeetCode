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
                int[] nums1 = new int[] { 8, 7, 4, 3 };
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
                var res = solution.CombinationSum(nums1, 11);
                ConsoleX.WriteLine(res);
            }
        }

        /// <summary>
        /// Experience: 深度优先的时候我喜欢直接对递归的数组分配一个新的空间（即直接ToList()），这是一个坏习惯，显著浪费空间，而且性能也有损失。既然是深度优先，可以在递归出来之后删掉最后一个加入的就好。
        /// </summary>

        public class Solution
        {
            /// <summary>
            /// 回溯法。先排序，然后再开始回溯
            /// 时间复杂度：时间复杂度：O(S)，其中 S 为所有可行解的长度之和。从分析给出的搜索树我们可以看出时间复杂度取决于搜索树所有叶子节点的深度之和，即所有可行解的长度之和。
            ///            在这题中，我们很难给出一个比较紧的上界，我们知道 O(n * 2^n) 是一个比较松的上界，即在这份代码中，n 个位置每次考虑选或者不选，如果符合条件，就加入答案的时间代价。
            ///            但是实际运行的时候，因为不可能所有的解都满足条件，递归的时候我们还会用 target - candidates[idx] >= 0 进行剪枝，所以实际运行情况是远远小于这个上界的。
            /// 空间复杂度：O(target)。除答案数组外，空间复杂度取决于递归的栈深度，在最差情况下需要递归 O(target) 层。
            /// 回溯的时间空间复杂度一般都不太好计算呐。
            /// </summary>
            /// <param name="candidates"></param>
            /// <param name="target"></param>
            /// <returns></returns>
            public IList<IList<int>> CombinationSum(int[] candidates, int target)
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

                    for (;left < candidates.Length; left++)
                    {
                        if (candidates[left] <= remain)
                        {
                            //var temp = addends.ToList();
                            //temp.Add(candidates[left]);
                            addends.Add(candidates[left]);
                            BackTracking(addends, left, remain - candidates[left]);
                            addends.RemoveAt(addends.Count - 1);
                        }
                        else
                            break;
                    }
                }
            }
        }
    }
}