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
                int input = int.Parse(Console.ReadLine());
                //int input2 = int.Parse(Console.ReadLine());
                //int input3 = int.Parse(Console.ReadLine());
                //string input = Console.ReadLine();
                //string input2 = Console.ReadLine();
                //int[] intArr = input.Split(',').Select(s => int.Parse(s)).ToArray();
                //int input2 = int.Parse(Console.ReadLine());
                //int[] intArr = new int[] { 1, 3, 2 };
                //int[] intArr = new int[] { 4, 2, 1, 3, 2, 6, 3 };
                //int[] intArr2 = new int[] { 4, 2, 1, 3, 2, 6, 3 };
                var res = solution.CountAndSay(input);
                ConsoleX.WriteLine(res);
            }
        }

        public class Solution
        {
            /// <summary>
            /// 递归解，这可太厉害了，直接把内存给用满了。相比下来迭代可太慢了，我看资源，迭代只使用了60MB内存，递归用了6GB不止，直到内存使用完。
            /// 时间复杂度：O(?)，总之比迭代快了很多很多
            /// 空间复杂度：O(?)，内存都炸了
            /// </summary>
            /// <param name="n"></param>
            /// <returns></returns>
            public string CountAndSay(int n)
            {
                if (n == 1)
                    return "1";
                string s = CountAndSay(n - 1);
                StringBuilder sb = new StringBuilder();
                int index = 0;
                while (index < s.Length)
                {
                    int count = 1;
                    char num = s[index];
                    if (index < s.Length - 1 && s[index] == s[index + 1])
                    {
                        while (index < s.Length - 1 && s[index] == s[index + 1])
                        {
                            count++;
                            index++;
                        }
                    }
                    index++;
                    sb.Append(count);
                    sb.Append(num);
                }
                return sb.ToString();
            }

            /// <summary>
            /// 第一反应解
            /// 时间复杂度：O(?),这是真不知道怎么计算了，总之大于线性，应该是指数级上升
            /// 空间复杂度：O(n)
            /// </summary>
            /// <param name="n"></param>
            /// <returns></returns>
            //public string CountAndSay(int n)
            //{
            //    StringBuilder target = new StringBuilder("1");
            //    int repeatCount;
            //    char character;
            //    //循环获取第n个数
            //    while (--n > 0)
            //    {
            //        StringBuilder cur_target = new StringBuilder();
            //        character = target[0];
            //        repeatCount = 1;
            //        //如果是第一个数
            //        if (target.Length == 1)
            //        {
            //            target = new StringBuilder("11");
            //            continue;
            //        }
            //        //遍历当前字符串，生成描述
            //        for (int i = 1; i < target.Length; i++)
            //        {
            //            if (target[i] == target[i - 1])
            //                repeatCount++;
            //            else
            //            {
            //                cur_target.Append(repeatCount);
            //                cur_target.Append(character - '0');
            //                //改写成当前的字符
            //                character = target[i];
            //                repeatCount = 1;
            //            }

            //            if (i == target.Length - 1)
            //            {
            //                cur_target.Append(repeatCount);
            //                cur_target.Append(character - '0');
            //            }
            //        }
            //        target = cur_target;
            //    }
            //    return target.ToString();
            //}
        }
    }
}