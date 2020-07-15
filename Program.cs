using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Extension;
using LeetCode.ExtensionFunction;

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
                //string input = Console.ReadLine();
                //string input2 = Console.ReadLine();
                //int[] intArr = input.Split(',').Select(s => int.Parse(s)).ToArray();
                //int input2 = int.Parse(Console.ReadLine());
                //var builder = new DataStructureBuilder();
                //int?[] data = new int?[] { 10, 5, 15, null, null, 6, 20 };
                //var tree = builder.BuildTree(data);
                //var listNode = builder.BuildListNode(new int[] { 1, 4, 5 });
                int[] nums1 = new int[] { 2, 1, 1, 2 };
                //int[] nums2 = new int[] { 2, 2 };
                var res = solution.Rob(nums1);
                ConsoleX.WriteLine(res);
            }
        }

        public class Solution
        {
            /// <summary>
            /// 动态规划
            /// 时间复杂度：O(n)
            /// 空间复杂度：O(1)
            /// 这个状态转移方程式分析可真是有点难想，但是只要想通了也简单，感觉和递归思想有点类似，只要找到所有小问题的解，大问题也就被剖开了
            /// </summary>
            /// <param name="nums"></param>
            /// <returns></returns>
            public int Rob(int[] nums)
            {
                int KMinusTwo = 0;
                int KMinusOne = 0;
                int res = 0;
                //状态转移方程式：
                //1.偷窃第 n 间房时，就不能偷窃第 n - 1 间房，所以偷窃最大值就是 f(n - 2) + n
                //2.不偷窃第 n 间房时，就可以偷窃第 n - 1 间房，所以偷窃的最大值就是 f(n - 1)
                //上面两个情况中的最大值，就是 n 间房的解
                for (int i = 0; i < nums.Length; i++)
                {
                    res = Math.Max(KMinusTwo + nums[i], KMinusOne);

                    KMinusTwo = KMinusOne;
                    KMinusOne = res;
                }
                return res;
            }
        }
    }
}