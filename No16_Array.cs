using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode_16
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
    //        ////string input2 = Console.ReadLine();
    //        //int[] intArr = input.Split(',').Select(s => int.Parse(s)).ToArray();
    //        //int input2 = int.Parse(Console.ReadLine());
    //        int[] intArr = new int[] { -55, -24, -18, -11, -7, -3, 4, 5, 6, 9, 11, 23, 33 };
    //        int input2 = 0;
    //        var res = solution.ThreeSumClosest(intArr, input2);
    //        Console.WriteLine(res);
    //    }
    //}

    public class Solution
    {
        /// <summary>
        /// 排序，双指针。和上一道15题非常相似，直接用了
        /// 时间复杂度：O(n²)
        /// 空间复杂度：O(1)
        /// Knowledge: 不能使用Math.abs和Math.abs做比较，当两边都是负数时会报错，因为int.Min会转成int.Max，会损失精度，用的时候可以加一个（long）,先转成更大精度的数就不会被Math.abs损失精度了，所以也就不会报错了。
        /// Experience:当需要遍历所有情况的时候，不能break，因为单一反向的break其实就跳出了遍历的可能，具体需要好好想想，绕过那个逻辑的弯。
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int ThreeSumClosest(int[] nums, int target)
        {
            //1.先排序，使用三个指针，一个外部for循环，两个内部去while碰头
            int ans = int.MaxValue;
            Array.Sort(nums);
            for (int left = 0; left < nums.Length; left++)
            {
                //相同的值没有必要继续运算,因为相同的情况在前一个就遍历到了
                if (left - 1 >= 0 && nums[left] == nums[left - 1])
                    continue;

                int mid = left + 1;
                int right = nums.Length - 1;
                while (mid < right)
                {
                    int sum = nums[left] + nums[mid] + nums[right];
                    int diff = sum - target;
                    if (diff == 0)
                    {
                        //如果相等了，就是最接近的了，直接返回
                        return nums[left] + nums[mid] + nums[right];
                    }
                    else if (diff > 0)
                        do { right--; } while (mid < right && nums[right + 1] == nums[right]);
                    else
                        do { mid++; } while (mid < right && nums[mid] == nums[mid - 1]);

                    //如果遍历的过程不是在越来越接近就break。逻辑错误：{ -55, -24, -18, -11, -7, -3, 4, 5, 6, 9, 11, 23, 33 }，
                    //在这个例子中，三个指针对应的数分别是-11,-7,33就会跳过正确答案。因为靠近不能通过一个数来靠近，这和外层不能跳过
                    //一个道理。
                    //修改成只记录更靠近的值就行
                    if (Math.Abs((long)diff) < Math.Abs((long)(ans - target)))
                        ans = sum;
                }
            }
            return ans;
        }
    }
}
