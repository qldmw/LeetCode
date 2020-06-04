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
                var res = solution.SearchInsert(intArr, input2);
                Console.WriteLine(res);
            }
        }

        public class Solution
        {
            public int SearchInsert(int[] nums, int target)
            {                
                int left = 0;
                int right = nums.Length;
                while (true)
                {
                    int mid = (left + right) / 2;
                    if (nums[mid] == target)
                        return mid;                    
                    else if (nums[mid] > target)
                        right = mid;
                    else if (nums[mid] < target)
                        left = mid;
                }                
            }

            private int Recursive(int[] nums, int left, int right, int target)
            {
                int mid = (left + right) / 2;
                if (nums[mid] == target)
                    return mid;
                if (nums[mid] > target)
                    return Recursive(nums, mid, right, target);
                else if (nums[mid] < target)
                    return Recursive(nums, left, mid, target);
            }
        }
    }
}