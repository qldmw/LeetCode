using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Extension;

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
                //int input = int.Parse(input2);
                int[][] intArr = new int[][]
                {
                    new int[]{1,2,3,4},
                    new int[]{5,6,7,8},
                    new int[]{9,10,11,12},
                };
                var res = solution.SpiralOrder(intArr);
                ConsoleX.WriteLine(res);
            }
        }

        public class Solution
        {
            public int[] SpiralOrder(int[][] matrix)
            {                
                int count = 0;
                foreach (var arr in matrix)
                {
                    count += arr.Length;
                }
                int[] ans = new int[count];
                //走过的足迹，0是未走的，1是走过的
                var trace = new int[matrix.Length, matrix[0].Length];
                //i横向，j纵向
                int i = 0, j = 0;
                State state = State.Right;
                int index = 0;
                while (index < count)
                {
                    switch (state)
                    {
                        case State.Right:
                            {
                                //如果未超出且还未走过
                                if (i + 1 < matrix[j].Length && trace[j,i + 1] != 1)
                                {
                                    //赋值给答案
                                    ans[index] = matrix[j][i];
                                    //代表已经走过了
                                    trace[j, i] = 1;
                                    i++;
                                    index++;
                                }
                                else
                                    state = State.Down;
                                break;
                            }
                        case State.Down:
                            {
                                //如果未超出且还未走过
                                if (j + 1 < matrix.Length && trace[j + 1,i] != 1)
                                {
                                    //赋值给答案
                                    ans[index] = matrix[j][i];
                                    //代表已经走过了
                                    trace[j, i] = 1;
                                    j++;
                                    index++;
                                }
                                else
                                    state = State.Left;
                                break;
                            }
                        case State.Left:
                            {
                                //赋值给答案
                                ans[index] = matrix[j][i];
                                //代表已经走过了
                                trace[j, i] = 1;
                                //如果未超出且还未走过
                                if (i - 1 >= 0 && trace[j,i - 1] != 1)
                                {
                                    i--;
                                    index++;
                                }
                                else
                                    state = State.Up;
                                break;
                            }
                        case State.Up:
                            {
                                //赋值给答案
                                ans[index] = matrix[j][i];
                                //代表已经走过了
                                trace[j, i] = 1;
                                //如果未超出且还未走过
                                if (j - 1 >= 0 && trace[j - 1,i] != 1)
                                {
                                    j--;
                                    index++;
                                }
                                else
                                    state = State.Right;
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
}