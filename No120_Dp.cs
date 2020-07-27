using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode_120
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
    //        //int[][] arr = new int[3][] { new int[] { 1, 3, 1 }, new int[] { 1, 5, 1 }, new int[] { 4, 2, 1 } };
    //        //int[] nums1 = new int[] { 2, 1, 4, 5, 3, 1, 1, 3 };
    //        //int[] nums2 = new int[] { 10, 15, 20 };
    //        //string input = "abc";
    //        //string input2 = "ahbgdc";         
    //        IList<IList<int>> triangle = new List<IList<int>>();
    //        triangle.Add(new List<int>() { 2 });
    //        triangle.Add(new List<int>() { 3, 4 });
    //        triangle.Add(new List<int>() { 6, 5, 7 });
    //        triangle.Add(new List<int>() { 4, 1, 8, 3 });
    //        var res = solution.MinimumTotal(triangle);
    //        ConsoleX.WriteLine(res);
    //    }
    //}

    /// <summary>
    /// Experience：在解决问题时试试思考反向的逻辑，普通思维的从前往后，那就从后往前想想；普通思维的自上而下，那就从下而上想想；或许能获得更好的解法。
    /// </summary>

    public class Solution
    {
        /// <summary>
        /// 动态规划，优化做法，自下而上。逻辑清晰，减少了边界判断，减小了使用空间。
        /// 时间复杂度：O(n²)
        /// 空间复杂度：O(n)，确切地说就是 n
        /// </summary>
        /// <param name="triangle"></param>
        /// <returns></returns>
        public int MinimumTotal(IList<IList<int>> triangle)
        {
            if (triangle == null || triangle.Count == 0)
                return 0;

            int[] dp = triangle[triangle.Count - 1].ToArray();
            for (int i = triangle.Count - 2; i >= 0; i--)
            {
                for (int j = 0; j <= i; j++)
                {
                    dp[j] = Math.Min(dp[j], dp[j + 1]) + triangle[i][j];
                }
            }
            return dp[0];
        }

        /// <summary>
        /// 动态规划，使用 2n 空间来存 dp 结果，计算完成再放到preDp中
        /// 时间复杂度：O(n²)
        /// 空间复杂度：O(n)，确切的说是 2n
        /// 这里逻辑惯性使用了自顶向下的解决办法，这种方法需要对两边的边界做特判。而自下而上的办法就可以不特判，而且还可以只是用 n 的空间
        /// </summary>
        /// <param name="triangle"></param>
        /// <returns></returns>
        //public int MinimumTotal(IList<IList<int>> triangle)
        //{
        //    if (triangle == null || triangle.Count == 0)
        //        return 0;

        //    int[] preDp = new int[triangle.Count];
        //    int[] dp = new int[triangle.Count];
        //    for (int i = 0; i < triangle.Count; i++)
        //    {
        //        var row = triangle[i];
        //        for (int j = 0; j <= i; j++)
        //        {
        //            //自顶而下的边界特判
        //            int leftParent = j > 0 ? preDp[j - 1] : int.MaxValue;
        //            int rightParent = j == i ? int.MaxValue : preDp[j];
        //            if (leftParent == int.MaxValue && rightParent == int.MaxValue)
        //                dp[j] = row[j];
        //            else
        //                dp[j] = Math.Min(leftParent, rightParent) + row[j];
        //        }
        //        //不能单纯的赋值，引用类型
        //        preDp = dp.ToArray();
        //    }

        //    return dp.Min();
        //}
    }
}
