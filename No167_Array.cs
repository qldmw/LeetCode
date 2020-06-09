using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode_167
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
    //        int input2 = int.Parse(Console.ReadLine());
    //        var res = solution.TwoSum(intArr, input2);
    //        ConsoleX.WriteLine(res);
    //        //ConsoleX.WriteLine(res);
    //    }
    //}

    /// <summary>
    /// Experience：但凡见到有序数组的查找，就要直接想到二分法。(ps.其实也不一定啦，双指针夹逼也是可以的，不过最基本要想到二分，因为怎么也比遍历快)
    /// </summary>
    public class Solution
    {
        /// <summary>
        /// 双指针夹逼
        /// 时间复杂度：O(n)
        /// 空间复杂度：O(1)
        /// </summary>
        /// <param name="numbers"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int[] TwoSum(int[] numbers, int target)
        {
            int left = 0;
            int right = numbers.Length - 1;
            while (left < right)
            {
                int sum = numbers[left] + numbers[right];
                if (sum == target)
                    break;
                else if (sum > target)
                    right--;
                else
                    left++;
            }
            return new int[2] { left + 1, right + 1 };
        }

        /// <summary>
        /// 第一反应解，遍历 + 二分法
        /// 时间复杂度：O(nlogn),遍历是n,二分法是logn
        /// 空间复杂度：O(1)
        /// </summary>
        /// <param name="numbers"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        //public int[] TwoSum(int[] numbers, int target)
        //{
        //    int[] res = new int[2];
        //    for (int i = 0; i < numbers.Length; i++)
        //    {
        //        int targerIndex = Recursive(numbers, i + 1, numbers.Length - 1, target - numbers[i]);
        //        if (targerIndex != -1)
        //        {
        //            res[0] = i + 1;
        //            res[1] = targerIndex + 1;
        //            break;
        //        }
        //    }
        //    return res;
        //}

        //private int Recursive(int[] numbers, int left, int right, int target)
        //{
        //    int mid = (left + right) / 2;
        //    if (numbers[mid] == target)
        //        return mid;
        //    else if (left >= right)
        //        return -1;

        //    if (numbers[mid] > target)
        //        return Recursive(numbers, left, mid - 1, target);
        //    else
        //        return Recursive(numbers, mid + 1, right, target);
        //}
    }
}
