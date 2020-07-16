using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode_303
{
    //static void Main(string[] args)
    //{
    //    //var solution = new Solution();
    //    var solution = new NumArray(new int[] { -2, 0, 3, -5, 2, -1 });
    //    while (true)
    //    {
    //        int input = int.Parse(Console.ReadLine());
    //        int input2 = int.Parse(Console.ReadLine());
    //        //string input = Console.ReadLine();
    //        //string input2 = Console.ReadLine();
    //        //int[] intArr = input.Split(',').Select(s => int.Parse(s)).ToArray();
    //        //int input2 = int.Parse(Console.ReadLine());
    //        //var builder = new DataStructureBuilder();
    //        //int?[] data = new int?[] { 10, 5, 15, null, null, 6, 20 };
    //        //var tree = builder.BuildTree(data);
    //        //var listNode = builder.BuildListNode(new int[] { 1, 4, 5 });
    //        //int[] nums1 = new int[] { 2, 1, 1, 2 };
    //        //int[] nums2 = new int[] { 2, 2 };
    //        var res = solution.SumRange(input, input2);
    //        ConsoleX.WriteLine(res);
    //    }
    //}

    public class NumArray
    {
        private int[] _nums;
        private int[] _sums;
        public NumArray(int[] nums)
        {
            _nums = nums;
            _sums = CaculateSum(nums);
        }

        /// <summary>
        /// 动态规划。一次 O(n) 算出总和的集合，然后之后每次计算都是 O(1)
        /// 时间复杂度：构造 O(n)，使用 O(1)
        /// 空间复杂度：构造 O(n)，使用 O(1)
        /// 如果不是在刷 动态规划 tag，我可能不会想到这么做，顺便一说，这个题的形式也很不一样，第一次遇到这个长相的题目。
        /// 后记：似乎这个解法还有个名称叫做“前缀和”
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <returns></returns>
        public int SumRange(int i, int j)
        {
            return _sums[j] - (i - 1 < 0 ? 0 : _sums[i - 1]);
        }

        private int[] CaculateSum(int[] nums)
        {
            int[] sums = new int[nums.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                if (i == 0)
                    sums[i] = nums[i];
                else
                    sums[i] = sums[i - 1] + nums[i];
            }
            return sums;
        }
    }

    /**
     * Your NumArray object will be instantiated and called as such:
     * NumArray obj = new NumArray(nums);
     * int param_1 = obj.SumRange(i,j);
     */
}
