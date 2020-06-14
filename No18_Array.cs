using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode_18
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
    //        int[] intArr = new int[] { 1, -2, -5, -4, -3, 3, 3, 5 };
    //        int target = -11;
    //        var res = solution.FourSum(intArr, target);
    //        ConsoleX.WriteLine(res);
    //    }
    //}

    public class Solution
    {
        /// <summary>
        /// threeSum的无脑升级版，我以为会有什么更好的办法解决呢，结果就是单纯的加一遍循环而已，枉费想了半天
        /// 时间复杂度：O(n³)，就是在threeSum上多了一次循环，如果fiveSum就是n的四次方，以此类推
        /// 空间复杂度：O(1)
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public IList<IList<int>> FourSum(int[] nums, int target)
        {
            IList<IList<int>> res = new List<IList<int>>();
            Array.Sort(nums);
            for (int i = 0; i < nums.Length; i++)
            {
                //排序之后，左指针最小，都大于0了，那一定就没有其他答案了
                if (target > 0 && nums[i] > target)
                    break;
                //去重
                if (i > 0 && nums[i] == nums[i - 1])
                    continue;

                for (int j = i + 1; j < nums.Length; j++)
                {
                    //排序之后，左指针最小，都大于0了，那一定就没有其他答案了
                    if (target > 0 && nums[i] + nums[j] > target)
                        break;
                    //去重
                    if (j - 1 != i && nums[j] == nums[j - 1])
                        continue;

                    int left = j + 1;
                    int right = nums.Length - 1;
                    while (left < right)
                    {
                        int sum = nums[i] + nums[j] + nums[left] + nums[right];
                        if (sum == target)
                        {
                            res.Add(new int[] { nums[i], nums[j], nums[left], nums[right] });
                            do { right--; } while (left < right && nums[right + 1] == nums[right]);
                            do { left++; } while (left < right && nums[left] == nums[left - 1]);
                        }
                        else if (sum > target)
                            right--;
                        else
                            left++;
                    }
                }
            }
            return res;
        }
    }
}
