using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode_I29
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
    //        //string input2 = Console.ReadLine();
    //        //int[] intArr = input.Split(',').Select(s => int.Parse(s)).ToArray();                
    //        //int input = int.Parse(input2);
    //        int[][] intArr = new int[][]
    //        {
    //            //new int[]{1,2,3,4},
    //            //new int[]{5,6,7,8},
    //            //new int[]{9,10,11,12},
    //        };
    //        var res = solution.SpiralOrder(intArr);
    //        ConsoleX.WriteLine(res);
    //    }
    //}

    /// <summary>
    /// Experience：代码不提前画好细节和边界，最后就会有一堆恶心的if来补漏，太丑陋了
    /// int[][] 是交错数组，一维空间不一定等长，所以也就不能定义定长的，二维数组是这样子的int[2,2]
    /// </summary>
    public class Solution2
    {
        /// <summary>
        /// REVIEW改进
        /// 时间复杂度：O(n)
        /// 空间复杂度：O(n)
        /// 相同的思想，但是用更简洁的代码实现。
        /// 有两个点要注意：
        /// 1.对应到数组访问中的x，y的应该是反过来的，应该是 matrix[y][x]。
        /// 2.走到下一步时，应该使用预测的方式，而不是直接走，应该如果走错了还要退出来才行，麻烦了
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public int[] SpiralOrder(int[][] matrix)
        {
            if (matrix == null || matrix.Length == 0 || matrix[0].Length == 0)
                return new int[0];

            int rows = matrix.Length;
            int cols = matrix[0].Length;
            int total = rows * cols;
            int[] res = new int[total];
            bool[,] visited = new bool[rows, cols];
            int[,] directions = new int[,] { { 1, 0 }, { 0, 1 }, { -1, 0 }, { 0, -1 } };
            int curDirection = 0;
            //用x,y当坐标更容易理解
            int x = 0, y = 0;
            for (int i = 0; i < total; i++)
            {
                //写入到答案数组中，标记已经走过
                res[i] = matrix[y][x];
                visited[y, x] = true;
                //通过下一步来判断是否已经出界，出界则换方向
                int nextX = x + directions[curDirection, 0];
                int nextY = y + directions[curDirection, 1];
                if (nextX < 0 || nextX >= cols || nextY < 0 || nextY >= rows || visited[nextY, nextX])
                    curDirection = (curDirection + 1) % 4;
                //走到下一步
                x = x + directions[curDirection, 0];
                y = y + directions[curDirection, 1];
            }
            return res;
        }
    }

    /// <summary>
    /// REVIEW
    /// 2020.07.31: 题解里用0，1来代表方向，可以省不少代码。应该用visited代替trace作为访问路径数组名称。
    /// </summary>
    public class Solution
    {
        /// <summary>
        /// 第一反应解，通过足迹来确认走没走过，思路没错，就是代码没有组织好，有点丑，还是要先想好再写。
        /// 时间复杂度：O(n)
        /// 空间复杂度：O(n)
        /// 还有一个常数空间复杂度的方法，把矩阵看做是多层的关系，然后一层一层剥洋葱，具体做法就是4个方向都用int存起来，一层完了，四个方向都向内缩一格，最后如果左右相等就结束
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public int[] SpiralOrder(int[][] matrix)
        {
            int count = 0;
            foreach (var arr in matrix)
            {
                count += arr.Length;
            }
            int[] ans = new int[count];
            if (matrix == null || matrix.Length == 0)
                return ans;
            //走过的足迹，0是未走的，1是走过的
            var trace = new int[matrix.Length, matrix[0].Length];
            //i横向，j纵向
            int i = 0, j = 0;
            State state = State.Right;
            int index = 0;
            while (index < count)
            {
                //赋值给答案
                ans[index] = matrix[j][i];
                //代表已经走过了
                trace[j, i] = 1;
                switch (state)
                {
                    case State.Right:
                        {
                            //如果未超出且还未走过
                            if (i + 1 < matrix[j].Length && trace[j, i + 1] != 1)
                            {
                                i++;
                                index++;
                            }
                            else
                            {
                                state = State.Down;
                                if (index + 1 == count)
                                    index++;
                            }
                            break;
                        }
                    case State.Down:
                        {
                            //如果未超出且还未走过
                            if (j + 1 < matrix.Length && trace[j + 1, i] != 1)
                            {
                                j++;
                                index++;
                            }
                            else
                            {
                                state = State.Left;
                                if (index + 1 == count)
                                    index++;
                            }
                            break;
                        }
                    case State.Left:
                        {
                            if (i - 1 >= 0 && trace[j, i - 1] != 1)
                            {
                                //如果未超出且还未走过
                                i--;
                                index++;
                            }
                            else
                            {
                                state = State.Up;
                                if (index + 1 == count)
                                    index++;
                            }
                            break;
                        }
                    case State.Up:
                        {
                            if (j - 1 >= 0 && trace[j - 1, i] != 1)
                            {
                                //如果未超出且还未走过
                                j--;
                                index++;
                            }
                            else
                            {
                                state = State.Right;
                                if (index + 1 == count)
                                    index++;
                            }
                            break;
                        }
                    default: break;
                }
            }
            return ans;
        }

        private enum State
        {
            Right,
            Down,
            Left,
            Up
        }
    }
}
