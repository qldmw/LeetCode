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
                string input = Console.ReadLine();
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
                //int[] nums2 = new int[] { 2, 1, 1, 5, 11, 5, 1, 7, 5, 6, 4, 3 };
                //int[] nums3 = new int[] { 10, 15, 20 };
                //int[] nums1 = new int[] { 10, 9, 2, 5, 3, 7, 101, 18 };
                var res = solution.LetterCombinations(input);
                ConsoleX.WriteLine(res);
            }
        }

        public class Solution
        {
            /// <summary>
            /// 深度优先
            /// 设 digits 长度为 n，假设数字对应的字符串长度都为 3
            /// 时间复杂度：O(3ⁿ)
            /// 空间复杂度：O(n)，dictionary对应表是固定的，所以视为常数。变量在于递归深度，深度是 n，所以空间复杂度是 O(n)
            /// </summary>
            /// <param name="digits"></param>
            /// <returns></returns>
            public IList<string> LetterCombinations(string digits)
            {
                IList<string> res = new List<string>();

                if (string.IsNullOrEmpty(digits))
                    return res;
                //手机按键的对应表
                Dictionary<char, string> dic = new Dictionary<char, string>()
                {
                    { '2', "abc" },{ '3', "def" },{ '4', "ghi" },{ '5', "jkl" },{ '6', "mno" },{ '7', "pqrs" },{ '8', "tuv" },{ '9', "wxyz" }
                };
                Recurse(digits, 0, new char[digits.Length]);
                return res;

                //递归串联组合
                void Recurse(string input, int pos, char[] combinations)
                {
                    //组合遍历完后，对结果进行拼接
                    if (pos == input.Length)
                    {
                        res.Add(new string(combinations));
                        return;
                    }
                    //查找到数字按钮的对应字符串
                    string reference = dic[input[pos]];
                    //深度优先递归
                    for (int i = 0; i < reference.Length; i++)
                    {
                        var temp = combinations;
                        temp[pos] = reference[i];
                        Recurse(input, pos + 1, temp);
                    }
                }
            }
        }
    }
}