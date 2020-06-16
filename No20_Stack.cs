using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode_20
{
    //static void Main(string[] args)
    //{
    //    var solution = new Solution();
    //    while (true)
    //    {
    //        //int input = int.Parse(Console.ReadLine());
    //        //int input2 = int.Parse(Console.ReadLine());
    //        //int input3 = int.Parse(Console.ReadLine());
    //        string input = Console.ReadLine();
    //        ////string input2 = Console.ReadLine();
    //        //int[] intArr = input.Split(',').Select(s => int.Parse(s)).ToArray();
    //        //int input2 = int.Parse(Console.ReadLine());
    //        //int[] intArr = new int[] { 1, 3, 2 };
    //        //int[] intArr = new int[] { 4, 2, 1, 3, 2, 6, 3 };
    //        //int[] intArr2 = new int[] { 4, 2, 1, 3, 2, 6, 3 };
    //        var res = solution.IsValid(input);
    //        ConsoleX.WriteLine(res);
    //    }
    //}

    public class Solution
    {
        /// <summary>
        /// 犹记得以前大学的时候用的string做出来的，哈哈，也不知是怎么写的
        /// 时间复杂度：O(n)
        /// 空间复杂度：O(n)
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public bool IsValid(string s)
        {
            Stack<char> stack = new Stack<char>();
            for (int i = 0; i < s.Length; i++)
            {
                switch (s[i])
                {
                    case '(':
                    case '[':
                    case '{': stack.Push(s[i]); break;
                    case ')':
                    case ']':
                    case '}':
                        if (stack.Count == 0)
                            return false;
                        char c = stack.Pop();
                        if ((c == '(' && s[i] == ')') || (c == '[' && s[i] == ']') || (c == '{' && s[i] == '}'))
                            break;
                        else
                            return false;
                    default: break;

                }
            }
            return stack.Count == 0;
        }
    }
}
