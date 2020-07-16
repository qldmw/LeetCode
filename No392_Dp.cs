using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode_392
{
    //static void Main(string[] args)
    //{
    //    var solution = new Solution();
    //    while (true)
    //    {
    //        //int input = int.Parse(Console.ReadLine());
    //        //int input2 = int.Parse(Console.ReadLine());
    //        //string input = Console.ReadLine();
    //        //string input2 = Console.ReadLine();
    //        //int[] intArr = input.Split(',').Select(s => int.Parse(s)).ToArray();
    //        //int input2 = int.Parse(Console.ReadLine());
    //        //var builder = new DataStructureBuilder();
    //        //int?[] data = new int?[] { 10, 5, 15, null, null, 6, 20 };
    //        //var tree = builder.BuildTree(data);
    //        //var listNode = builder.BuildListNode(new int[] { 1, 4, 5 });
    //        //int[] nums1 = new int[] { 2, 1, 1, 2 };
    //        //int[] nums2 = new int[] { 2, 2 };
    //        //string input = "abc";
    //        //string input2 = "ahbgdc";
    //        //string input = "axc";
    //        //string input2 = "ahbgdc";
    //        string input = "acb";
    //        string input2 = "ahbgdc";
    //        var res = solution.IsSubsequence(input, input2);
    //        ConsoleX.WriteLine(res);
    //    }
    //}

    /// <summary>
    /// 后续挑战 :如果有大量输入的 S，称作S1, S2, ... , Sk 其中 k >= 10亿，你需要依次检查它们是否为 T 的子序列。在这种情况下，你会怎样改变代码？
    /// </summary>
    public class Solution
    {
        /// <summary>
        /// 动态规划，跳跃匹配
        /// 设 s 的长度为 m，t 的长度为 n。
        /// 时间复杂度：O(m)，只遍历一次 s 就可以得出结果
        /// 空间复杂度：O(n)，26 * n 的矩阵
        /// 构建矩阵会话费一些时间，如果后续有大量匹配动作，就可以抵消掉构建的时间，甚至节约时间，适合高频率匹配的场景。
        /// </summary>
        /// <param name="s"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool IsSubsequence(string s, string t)
        {
            t = " " + t;
            int[,] pos = new int[26, t.Length];
            //预处理，把每个字符的地址给记录下来
            for (int i = 0; i < 26; i++)
            {
                int position = -1;
                for (int j = t.Length - 1; j >= 0; j--)
                {
                    pos[i, j] = position;
                    if (t[j] - 'a' == i)
                        position = j;
                }
            }
            //通过跳跃匹配快速获取位置
            int p = 0;
            for (int i = 0; i < s.Length; i++)
            {
                p = pos[s[i] - 'a', p];
                if (p == -1)
                    return false;
            }
            return true;
        }

        /// <summary>
        /// 顺序匹配
        /// 设 s 的长度为 m，t 的长度为 n。
        /// 时间复杂度：O(n)
        /// 空间复杂度：O(1)
        /// </summary>
        /// <param name="s"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        //public bool IsSubsequence(string s, string t)
        //{
        //    if (string.IsNullOrEmpty(s))
        //        return true;

        //    int sindex = 0;
        //    for (int i = 0; i < t.Length; i++)
        //    {
        //        if (s[sindex] == t[i])
        //            sindex++;
        //        if (sindex == s.Length)
        //            break;
        //    }
        //    return sindex == s.Length;
        //}
    }
}
