using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Extension;
using LeetCode.ExtensionFunction;
using System.Threading.Tasks;
using System.Threading;

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
                //string input = Console.ReadLine();
                //string input2 = Console.ReadLine();
                //int[] intArr = input.Split(',').Select(s => int.Parse(s)).ToArray();
                //int input2 = int.Parse(Console.ReadLine());
                //var builder = new DataStructureBuilder();
                //int?[] data = new int?[] { 1, 2, 3, 4, 5, null, 6, null, null, 7, 8 };
                //var tree = builder.BuildTree(data);
                //var listNode = builder.BuildListNode(new int[] { 1, 4, 5 });
                //int[][] arr = new int[3][] { new int[] { 1, 3, 1 }, new int[] { 1, 5, 1 }, new int[] { 4, 2, 1 } };
                //string input = "abcbefga";
                //string input2 = "dbefga";
                //int[] nums = new int[] { 5, 7, 7, 8, 8, 10 };
                //int num = 8;
                int[] nums = new int[] { 5, 7, 7, 8, 8, 10 };
                int num = 6;
                //int[] nums1 = new int[] { 10, 1, 2, 7, 6, 1, 5 };
                //IList<IList<int>> data = new List<IList<int>>()
                //{
                //    new List<int>() { 1, 3 },
                //    new List<int>() { 3, 0, 1 },
                //    new List<int>() { 2 },
                //    new List<int>() { 0 }

                //    //new List<int>() { 1 },
                //    //new List<int>() { 2 },
                //    //new List<int>() { 3 },
                //    //new List<int>() {  }
                //};
                var res = solution.SearchRange(nums, num);
                ConsoleX.WriteLine(res);
            }
        }

        public class Solution
        {
            /// <summary>
            /// 二分法
            /// 时间复杂度：O(logn)
            /// 空间复杂度：O(1)，虽然使用了递归，但是只会有一层，不会保存状态，只有一个栈空间
            /// </summary>
            /// <param name="nums"></param>
            /// <param name="target"></param>
            /// <returns></returns>
            public int[] SearchRange(int[] nums, int target)
            {
                var res = new int[2] { -1, -1 };
                if (nums == null || nums.Length == 0)
                    return res;
                //1.先二分法找到 start
                Recurse(0, nums.Length - 1);
                //2.1如果没有找到 target 值那就 return [-1, -1]
                return res;
                //2.2当找到 target 值之后开始执行找 end


                void Recurse(int left, int right)
                {
                    //没有找到
                    if (left > right)
                        return;
                    //二分法
                    int mid = (left + right) / 2;
                    if (nums[mid] == target)
                        FindStartAndEnd(mid);
                    else if (nums[mid] > target)
                        Recurse(left, mid - 1);
                    else
                        Recurse(mid + 1, right);
                }

                void FindStartAndEnd(int mid)
                {
                    //找到起点
                    int left = 0, right = mid;
                    while (left <= right)
                    {
                        int pivot = (left + right) / 2;
                        if (nums[pivot] >= target)
                            right = pivot - 1;
                        else
                            left = pivot + 1;
                    }
                    res[0] = left;
                    //找到终点
                    left = mid; right = nums.Length - 1;
                    while (left <= right)
                    {
                        int pivot = (left + right) / 2;
                        if (nums[pivot] <= target)
                            left = pivot + 1;
                        else
                            right = pivot - 1;
                    }
                    res[1] = right;
                }
            }
        }
    }
}