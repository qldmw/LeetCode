using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Extension;
using LeetCode.ExtensionFunction;

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
                //string input = Console.ReadLine();
                //string input2 = Console.ReadLine();
                //int[] intArr = input.Split(',').Select(s => int.Parse(s)).ToArray();
                //int input2 = int.Parse(Console.ReadLine());
                //var builder = new DataStructureBuilder();
                //int?[] data = new int?[] { 1, 2, 3, 4, 5, null, 6, null, null, 7, 8 };
                //var tree = builder.BuildTree(data);
                //var listNode = builder.BuildListNode(new int[] { 1, 4, 5 });
                //int[][] arr = new int[3][] { new int[] { 1, 3, 1 }, new int[] { 1, 5, 1 }, new int[] { 4, 2, 1 } };
                //int[] nums1 = new int[] { 2, 1, 7, 5, 6, 4, 3 };
                //int[] nums1 = new int[] { 2, 1, 1, 5, 11, 5, 1, 7, 5, 6, 4, 3 };
                //int[] nums2 = new int[] { 10, 15, 20 };
                //string input = "adceb";
                //string input2 = "*a*b";
                List<string> data = new List<string>()
                {
                    "-981237498217348128378",
                    "-891237498217348128378",
                    "-89123749821734812837",
                    "-891237498217348128378",
                    "-91237498217348128378",
                    "-991237498217348128378",
                    "-91237498217348128378",
                    "-981237498217348128378"
                };
                var res = solution.FindMaxNumString(data);
                ConsoleX.WriteLine(res);
            }
        }

        public class Solution
        {
            //2.给你一组数字构成的字符串，有正有负，让你找出数字和最大的子串
            //针对合规整型数字的做法，不适用于小数和负号位后有前缀0的情况
            public string FindMaxNumString(List<string> data)
            {
                List<int> digit = new List<int>();
                //获取到字符串数字长度,负数则用负数表示
                for (int i = 0; i < data.Count; i++)
                {
                    bool sign = true;
                    string str = data[i];
                    if (str.StartsWith('-'))
                    {
                        sign = false;
                        str = str.TrimStart('-');
                    }
                    int len = str.TrimStart('0').Length;
                    digit.Add(sign ? len : -1 * len);
                }
                //根据位数获取位数最大的数组
                int maxDigit = digit.Max();
                List<int> candidatesPos = new List<int>();
                for (int i = 0; i < digit.Count; i++)
                {
                    if (digit[i] == maxDigit)
                        candidatesPos.Add(i);
                }
                var candidates = data.Where(s => candidatesPos.IndexOf(data.IndexOf(s)) != -1).ToList();
                //从最大候选人中筛选出最大的数组
                int position = 0;//遍历的位数
                while (candidates.Count > 1)
                {
                    int targerDigit = maxDigit > 0 ? candidates.Max(s => s[position] - '0') : candidates.Min(s => s[position + 1] - '0');
                    for (int i = candidates.Count - 1; i >= 0; i--)
                    {
                        if (maxDigit > 0)
                        {
                            if (candidates[i][position] - '0' != targerDigit)
                                candidates.RemoveAt(i);
                        }
                        else
                        {
                            if (candidates[i][position + 1] - '0' != targerDigit)
                                candidates.RemoveAt(i);
                        }   
                    }
                    position++;
                    //如果有多个重复最大解
                    if (candidates.Distinct().Count() == 1)
                        break;
                }
                return candidates.FirstOrDefault();
            }
        }
    }
}