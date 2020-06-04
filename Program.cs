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
                string input = Console.ReadLine();
                //string input2 = Console.ReadLine();
                int[] intArr = input.Split(',').Select(s => int.Parse(s)).ToArray();
                //int input2 = int.Parse(Console.ReadLine());
                var res = solution.ProductExceptSelf(intArr);
                ConsoleX.WriteLine(res);
            }
        }

        public class Solution
        {
            /// <summary>
            /// 左右乘积法，算一个数组的乘积可以先慢慢算出左边乘积，在算出右边乘积，这样两次遍历就能计算出所有答案
            /// 时间复杂度：O(n)
            /// 空间复杂度：O(1)
            /// </summary>
            /// <param name="nums"></param>
            /// <returns></returns>
            public int[] ProductExceptSelf(int[] nums)
            {
                int[] ans = new int[nums.Length];
                int leftProduct = 1;
                //将左乘积填入答案数组中
                for (int i = 0; i < nums.Length; i++)
                {
                    if (i == 0)
                        ans[0] = 1;
                    else
                    {
                        leftProduct = leftProduct * nums[i - 1];
                        ans[i] = leftProduct;
                    }
                }
                //在把右乘积算出来的同时算出答案
                int rightProduct = 1;
                for (int i = nums.Length - 1; i >= 0; i--)
                {
                    if (i != nums.Length - 1)
                        rightProduct = rightProduct * nums[i + 1];
                    ans[i] = ans[i] * rightProduct;                    
                }
                return ans;
            }
        }
    }
}