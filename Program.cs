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
                var res = solution.ThreeSum(intArr);
                ConsoleX.WriteLine(res);
            }
        }

        public class Solution
        {
            public IList<IList<int>> ThreeSum(int[] nums)
            {
                IList<IList<int>> res = new List<IList<int>>();
                //1.先排序，然后左右指针向内夹逼。最大值和最小值相加，如果小于0，则左指针向右走；如果大于0，则右指针向左走（每一步都跳到下一个不同的数字，不是单纯加一）
                Array.Sort(nums);
                int left = 0;
                int right = nums.Length - 1;
                int direction;
                while (left < right)
                {
                    direction = nums[left] + nums[right] > 0 ? -1 : 1;
                    int mid;
                    //1.1 while循环内：最大最小值相加，如果大于0，内部指针则为左指针加一位置，如果小于0，内部指针则为右指针减一位置。
                    if (direction < 0)
                        mid = right - 1;
                    else
                        mid = left + 1;

                    while (mid < right && mid > left)
                    {
                        //1.2 左中右三个指针指向的数相加，内部指针向对向移动，如果三值和等于0，加入答案，跳出内部循环；如果内部指针行进中或者行进完错过了答案，就跳出内部循环
                        int sum = nums[left] + nums[right] + nums[mid];
                        if (sum == 0)
                        {
                            res.Add(new int[3] { left, mid, right });
                            break;
                        }
                        if ((direction > 0 && sum > 0) || (direction < 0 && sum < 0))
                            break;

                        mid += direction;
                    }


                    if (direction < 0)
                        left = GetNextDiffNumPos(nums, left, direction);
                    else
                        right = GetNextDiffNumPos(nums, right, direction);
                }
                return res;
            }

            private int GetNextDiffNumPos(int[] nums, int pointer, int direction)
            {
                int num = nums[pointer];
                do
                {
                    pointer += direction;
                    if ((pointer <= nums.Length - 1 && pointer >= 0) && nums[pointer] != num)
                        break;
                }
                while (pointer <= nums.Length - 1 && pointer >= 0);
                return pointer;
            }
        }
    }
}