using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode_27
{
    public class Solution
    {
        /// <summary>
        /// 快慢指针，可能性能看起来相差不大，但是更巧妙，更简洁
        /// 时间复杂度：O(n)
        /// 空间复杂度：O(1)
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="val"></param>
        /// <returns></returns>
        public int RemoveElement(int[] nums, int val)
        {
            int cur_index = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != val)
                {
                    nums[cur_index] = nums[i];
                    cur_index++;
                }
            }
            return cur_index;
        }

        /// <summary>
        /// 另一种快慢指针，优化了不必要的赋值，也很巧妙，不过不如第一个好理解，有点绕
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="val"></param>
        /// <returns></returns>
        //public int RemoveElement(int[] nums, int val)
        //{
        //    int i = 0;
        //    int n = nums.Length;
        //    while (i < n)
        //    {
        //        if (nums[i] == val)
        //        {
        //            nums[i] = nums[n - 1];
        //            // reduce array size by one
        //            n--;
        //        }
        //        else
        //        {
        //            i++;
        //        }
        //    }
        //    return n;
        //}

        /// <summary>
        /// 第一反应解，然而代码却很丑陋。之前才用过的快慢指针又不知道用了
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="val"></param>
        /// <returns></returns>
        //public int RemoveElement(int[] nums, int val)
        //{
        //    int res = 0;
        //    for (int i = 0; i < nums.Length; i++)
        //    {
        //        if (nums[i] == val)
        //        {
        //            for (int j = i + 1; j < nums.Length; j++)
        //            {
        //                if (nums[j] != val)
        //                {
        //                    Swap(nums, i, j);
        //                    res++;
        //                    break;
        //                }
        //            }
        //        }
        //        else                    
        //            res++;                    
        //    }
        //    return res;
        //}

        //private void Swap(int[] nums, int source, int target)
        //{
        //    int temp;
        //    temp = nums[source];
        //    nums[source] = nums[target];
        //    nums[target] = temp;
        //}
    }
}
