using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode_63
{
    public class Solution
    {
        /// <summary>
        /// 动态规划
        /// 时间复杂度：O(n²)
        /// 空间复杂度：O(n)
        /// REMARKABLE:在三亚旅游中用巧大嘿的小平台做的题，哈哈哈，真可真是太有纪念意义了。以后都可以吹牛，“你知道我有多努力吗，出去玩都还在做题”，哈哈哈
        /// </summary>
        /// <param name="obstacleGrid"></param>
        /// <returns></returns>
        public int UniquePathsWithObstacles(int[][] obstacleGrid)
        {
            if (obstacleGrid == null && obstacleGrid.Length == 0)
                return 0;

            int row = obstacleGrid.Length;
            int col = obstacleGrid[0].Length;
            int[] dp = new int[col];
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    if (obstacleGrid[i][j] == 1)
                        dp[j] = 0;
                    else if (i == 0 && j == 0)
                        dp[j] = 1;
                    else
                    {
                        int top = i > 0 ? dp[j] : 0;
                        int left = j > 0 ? dp[j - 1] : 0;
                        dp[j] = top + left;
                    }
                }
            }
            return dp[col - 1];
        }
    }
}
