using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode_4
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
    //        //int[] intArr = new int[] { 1, 3, 2 };
    //        int[] intArr = new int[] { 1, 3 };
    //        int[] intArr2 = new int[] { 2 };
    //        var res = solution.FindMedianSortedArrays(intArr, intArr2);
    //        ConsoleX.WriteLine(res);
    //    }
    //}

    public class Solution
    {
        /// <summary>
        /// REDO
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="nums2"></param>
        /// <returns></returns>
        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            int totalCount = nums1.Length + nums2.Length;
            bool isOdd = totalCount % 2 == 1;
            if (isOdd)
                return GetNumberFromPosition(nums1, nums2, totalCount / 2 + 1);
            else
                return (GetNumberFromPosition(nums1, nums2, totalCount / 2) + GetNumberFromPosition(nums1, nums2, totalCount / 2 + 1)) / 2.0;
        }

        public double GetNumberFromPosition(int[] nums1, int[] nums2, int pos)
        {

            int length1 = nums1.Length, length2 = nums2.Length;
            int index1 = 0, index2 = 0;

            while (true)
            {
                if (index1 == length1)
                    return nums2[index2 + pos - 1];
                if (index2 == length2)
                    return nums1[index1 + pos - 1];
                if (pos == 1)
                    return Math.Min(nums1[index1], nums2[index2]);

                int half = pos / 2;
                int newIndex1 = Math.Min(index1 + half, length1) - 1;
                int newIndex2 = Math.Min(index2 + half, length2) - 1;
                int pivot1 = nums1[newIndex1], pivot2 = nums2[newIndex2];
                if (pivot1 <= pivot2)
                {
                    pos -= (newIndex1 - index1 + 1);
                    index1 = newIndex1 + 1;
                }
                else
                {
                    pos -= (newIndex2 - index2 + 1);
                    index2 = newIndex2 + 1;
                }
            }
        }
    }
}
