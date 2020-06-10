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
                int input2 = int.Parse(Console.ReadLine());
                solution.Rotate(intArr, input2);
                //Console.WriteLine(res);
            }
        }

        public class Solution
        {
            public void Rotate(int[] nums, int k)
            {
                int rotateCount = 0;
                int temp;
                for (int curIndex = 0; rotateCount < nums.Length; curIndex++)
                {
                    int nextIndex = curIndex;
                    do
                    {
                        temp = nums[(nextIndex + k) % nums.Length];
                        nums[(nextIndex + k) % nums.Length] = nums[nextIndex];
                        rotateCount++;
                        nextIndex = (nextIndex + k) % nums.Length;
                    }
                    while (nextIndex != curIndex);
                }
            }

            /// <summary>
            /// 巧妙的三次翻转完成右移
            /// 时间复杂度：O(n)，但是经历了三次翻转，实际执行时间应该是花了2n的时间
            /// 空间复杂度：O(1)
            /// 虽然时间复杂度都是O(n)，但是这个多消耗了60ms，应该就是多出来的一次翻转造成的
            /// </summary>
            /// <param name="nums"></param>
            /// <param name="k"></param>
            //public void Rotate(int[] nums, int k)
            //{
            //    int step = k % nums.Length;
            //    Array.Reverse(nums);
            //    Array.Reverse(nums, 0, step);
            //    Array.Reverse(nums, step, nums.Length - step);
            //}

            /// <summary>
            /// 第一反应解，要被覆盖的部分缓存起来，然后交换位置就可以了
            /// 时间复杂度：O(n)
            /// 空间复杂度：O(n)，实际空间是nums.length - k，会随着nums的变大而变大，所以说是线性的。
            /// 这种单纯考边界的，我真的就老是容易出错，真的是难受，为什么集中不了呢
            /// </summary>
            /// <param name="nums"></param>
            /// <param name="k"></param>
            //public void Rotate(int[] nums, int k)
            //{
            //    int step = k % nums.Length;
            //    int[] temps = new int[nums.Length - step];
            //    for (int i = 0; i < nums.Length; i++)
            //    {
            //        //如果是小于步长的，就放到临时组数中暂存起来
            //        if (i < nums.Length - step)
            //            temps[i] = nums[i];
            //        if (i < step)
            //            nums[i] = nums[nums.Length - step + i];
            //        else
            //            nums[i] = temps[(i - step)];
            //    }
            //}
        }
    }
}