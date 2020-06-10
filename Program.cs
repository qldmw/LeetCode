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
                solution.MoveZeroes(intArr);
                //Console.WriteLine(res);
            }
        }

        public class Solution
        {
            /// <summary>
            /// 最优解，快慢指针，快指针一次走完，漂亮
            /// 时间复杂度：O(n)，纯粹的n
            /// 空间复杂度：O(1)，也是神奇的7.69%
            /// 每次一个一个挪动的时候，直接快指针往前找就可以了
            /// </summary>
            /// <param name="nums"></param>
            public void MoveZeroes(int[] nums)
            {
                for (int slowPointer = 0, fasterPointer = 0; fasterPointer < nums.Length; fasterPointer++)
                {
                    if (nums[fasterPointer] != 0)
                    {
                        int temp;
                        temp = nums[slowPointer];
                        nums[slowPointer] = nums[fasterPointer];
                        nums[fasterPointer] = temp;
                        slowPointer++;
                    }
                }
            }

            /// <summary>
            /// 偷过来验证第一反应解O(1)的空间复杂度为什么才7.69%，结果这个O(1)也是7.69%，看来不是算法的问题了
            /// 时间复杂度：O(n)
            /// 空间复杂度：O(1)
            /// </summary>
            /// <param name="nums"></param>
            //public void MoveZeroes(int[] nums)
            //{
            //    int lastNonZeroFoundAt = 0;
            //    // If the current element is not 0, then we need to
            //    // append it just in front of last non 0 element we found. 
            //    for (int i = 0; i < nums.Length; i++)
            //    {
            //        if (nums[i] != 0)
            //        {
            //            nums[lastNonZeroFoundAt++] = nums[i];
            //        }
            //    }
            //    // After we have finished processing new elements,
            //    // all the non-zero elements are already at beginning of array.
            //    // We just need to fill remaining array with 0's.
            //    for (int i = lastNonZeroFoundAt; i < nums.Length; i++)
            //    {
            //        nums[i] = 0;
            //    }
            //}

            /// <summary>
            /// 第一反应解，快慢指针
            /// 时间复杂度：O(n)，这个时间复杂度比较难计算。fasterPointer走过的区域slowPointer也只会走一遍，所以应该是循环2n次，也就是O(n)
            /// 空间复杂度：O(1)，我就根本没有定义变量，搞不懂为什么空间复杂度才7.69%。是因为嵌套循环吗？
            /// 后来做了个优化，不交换temp，直接覆盖，因为slowPointer指向的一定是0，结果执行一下，没有卵用，哈哈哈哈
            /// </summary>
            /// <param name="nums"></param>
            //public void MoveZeroes(int[] nums)
            //{
            //    for (int slowPointer = 0; slowPointer < nums.Length; slowPointer++)
            //    {
            //        if (nums[slowPointer] == 0)
            //        {
            //            for (int fastPointer = slowPointer + 1; fastPointer < nums.Length; fastPointer++)
            //            {
            //                if (nums[fastPointer] != 0)
            //                {
            //                    nums[slowPointer] = nums[fastPointer];
            //                    nums[fastPointer] = 0;
            //                    break;
            //                }
            //            }
            //        }
            //    }
            //}
        }
    }
}