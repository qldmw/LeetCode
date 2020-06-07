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
                //string input = Console.ReadLine();
                //string input2 = Console.ReadLine();
                //int[] intArr = input.Split(',').Select(s => int.Parse(s)).ToArray();
                //int input = int.Parse(input2);
                //int[][] intArr = new int[][]
                //{
                //    new int[]{1,2,3,4},
                //    new int[]{5,6,7,8},
                //    new int[]{9,10,11,12},
                //};
                //var intArr1 = new int[] { 1, 2, 3, 0, 0, 0 };
                //var intArr2 = new int[] { 2, 5, 6 };
                //int m = 3;
                //int n = 3;
                //var intArr1 = new int[1];
                //var intArr2 = new int[] { 1 };
                //int m = 0;
                //int n = 1;
                var intArr1 = new int[] { 2, 0 };
                var intArr2 = new int[] { 1 };
                int m = 1;
                int n = 1;
                solution.Merge(intArr1, m, intArr2, n);
                //ConsoleX.WriteLine(res);
            }
        }

        public class Solution
        {
            /// 优化做法，从后往前填，就直接在m数组上写，这样就不用tolist，而且少了一次之前的把数据从list的地址转到nums1的地址。
            /// 时间复杂度：O(m + n)
            /// 空间复杂度：O(1)
            public void Merge(int[] nums1, int m, int[] nums2, int n)
            {
                int p1 = m - 1;
                int p2 = n - 1;
                int index = m + n - 1;
                while (p2 >= 0)
                {
                    if (p1 >= 0 && (nums1[p1] > nums2[p2]))
                        nums1[index--] = nums1[p1--];
                    else
                        nums1[index--] = nums2[p2--];
                }                
            }

            /// <summary>
            /// 第一反应解，就是单纯的插入，唯一有点优点的就是记住了插入的下标，不用每次都从头插入
            /// 时间复杂度：O(m + n)，但是我的写法为了让leetcode检测到又多了一次 m 个的循环，可以优化的
            /// 空间复杂度：O(m + n),图方便用了list，不用的话空间复杂度能到O(1)            
            /// </summary>
            /// <param name="nums1"></param>
            /// <param name="m"></param>
            /// <param name="nums2"></param>
            /// <param name="n"></param>
            //public void Merge(int[] nums1, int m, int[] nums2, int n)
            //{
            //    var list1 = nums1.Take(m).ToList();
            //    //nums1中的插入指针
            //    int index = 0;
            //    for (int i = 0; i < n; i++)
            //    {
            //        for (int j = index; j < list1.Count; j++)
            //        {
            //            //小于等于时在原位置上插入
            //            if (nums2[i] <= list1[j])
            //            {
            //                list1.Insert(j, nums2[i]);
            //                index = j;
            //                break;
            //            }
            //            else if ((nums2[i] > list1[j] && (j < list1.Count - 1 && nums2[i] <= list1[j + 1]))
            //                || (j == list1.Count - 1))
            //            {
            //                list1.Insert(j + 1, nums2[i]);
            //                index = j + 1;
            //                break;
            //            }
            //        }
            //    }
            //    if (m == 0)
            //    {
            //        for (int i = 0; i < n; i++)
            //        {
            //            nums1[i] = nums2[i];
            //        }
            //    }
            //    else
            //    {
            //        for (int i = 0; i < m + n; i++)
            //        {
            //            nums1[i] = list1[i];
            //        }
            //    }
            //    //为什么不能这么写，因为leetcode检查的是nums1的原内存地址
            //    //nums1 = list1.ToArray();
            //}
        }
    }
}