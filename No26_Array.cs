using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode_26
{
    //static void Main(string[] args)
    //{
    //    var solution = new Solution();
    //    while (true)
    //    {
    //        //int input = int.Parse(Console.ReadLine());
    //        //int input2 = int.Parse(Console.ReadLine());
    //        //int input3 = int.Parse(Console.ReadLine());
    //        string input = Console.ReadLine();
    //        //string input2 = Console.ReadLine();
    //        int[] intArr = input.Split(',').Select(s => int.Parse(s)).ToArray();
    //        //int input = int.Parse(input2);
    //        var res = solution.RemoveDuplicates(intArr);
    //        Console.WriteLine(res);
    //    }
    //}

    /// <summary>
    /// Experience: C#的内存消耗和运行时间也太不稳定了吧，我去看了运行时间第一名的答案，没发现有多大不同。
    /// 然后直接粘贴提交，结果，您猜这么着，还比我原来的还慢，嗨，您说说。
    /// </summary>
    public class Solution
    {
        /// <summary>
        /// 第一反应解，就单纯的循环交换（原来官方还有个名字叫做快慢指针）
        /// 时间复杂度：O(n)
        /// 空间复杂度：O(1)
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int RemoveDuplicates(int[] nums)
        {
            if (nums.Length == 0)
                return 0;
            int cur_index = 0;

            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] > nums[cur_index])
                {
                    cur_index++;
                    //Swap(nums, i, cur_index);
                    nums[cur_index] = nums[i];//他不要求保留数组，直接覆盖更简单一些
                }
            }
            return cur_index + 1;
        }

        //private void Swap(int[] nums, int source, int target)
        //{
        //    int temp;
        //    temp = nums[source];
        //    nums[source] = nums[target];
        //    nums[target] = temp;
        //}
    }
}
