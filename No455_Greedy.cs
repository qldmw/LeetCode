using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode_455
{
    class No455_Greedy
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
        //        //string input2 = Console.ReadLine();
        //        //int[] intArr = input.Split(',').Select(s => int.Parse(s)).ToArray();
        //        //int input2 = int.Parse(Console.ReadLine());
        //        //var builder = new DataStructureBuilder();
        //        //int?[] data = new int?[] { 1, 2, 3, 4, 5, null, 6, null, null, 7, 8 };
        //        //var tree = builder.BuildTree(data);
        //        //var listNode = builder.BuildListNode(new int[] { 1, 4, 5 });
        //        //int[][] arr = new int[3][] { new int[] { 1, 3, 1 }, new int[] { 1, 5, 1 }, new int[] { 4, 2, 1 } };
        //        //string input = "abcbefga";
        //        //string input2 = "dbefga";
        //        //int[] nums1 = new int[] { 1, 2, 3 };
        //        //int[] nums2 = new int[] { 1, 1 };
        //        //IList<IList<int>> data = new List<IList<int>>()
        //        //{
        //        //    new List<int>() { 1, 3 },
        //        //    new List<int>() { 3, 0, 1 },
        //        //    new List<int>() { 2 },
        //        //    new List<int>() { 0 }

        //        //    //new List<int>() { 1 },
        //        //    //new List<int>() { 2 },
        //        //    //new List<int>() { 3 },
        //        //    //new List<int>() {  }
        //        //};

        //        int[] nums1 = new int[] { 10, 9, 8, 7, 10, 9, 8, 7 };
        //        int[] nums2 = new int[] { 10, 9, 8, 7 };
        //        var res = solution.FindContentChildren(nums1, nums2);
        //        ConsoleX.WriteLine(res);
        //    }
        //}

        public class Solution
        {
            /// <summary>
            /// 贪心思路+二分查找实现(哦，不对，其实不用做二分，二分反而会耗时更久，因为正常一个一个找，遍历一次就解决了！干！)
            /// 时间复杂度：O(nlogn)，sort是nlogn，二分查找是logn。
            /// 空间复杂度：O(logn)，Array.Sort应该是使用的快排，那就是堆深度，logn。
            /// </summary>
            /// <param name="g"></param>
            /// <param name="s"></param>
            /// <returns></returns>
            public int FindContentChildren(int[] g, int[] s)
            {
                Array.Sort(g);
                Array.Sort(s);
                int satisfiedCount = 0;
                int sIndex = 0;
                foreach (int m in g)
                {
                    //二分法是排序后的最优解，比一个一个遍历在理论上快，当然要数目大了之后才能显现
                    if (!BinarySearch(m, s, sIndex, s.Length - 1))
                        break;
                }
                return satisfiedCount;

                bool BinarySearch(int target, int[] str, int left, int right)
                {
                    while (left <= right)
                    {
                        int mid = (left + right) / 2;
                        //这里的判断很细节，要判断是否刚好比上一个小，然后又要比这个大，然后还要考虑上次的边界值
                        if (str[mid] >= target && (mid - 1 < sIndex || str[mid - 1] < target))
                        {
                            satisfiedCount++;
                            sIndex = mid + 1;
                            return true;
                        }

                        if (str[mid] >= target)
                            right = mid - 1;
                        else
                            left = mid + 1;
                    }
                    return false;
                }
            }
        }
    }
}
