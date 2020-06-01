using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode_13
{
    //static void Main(string[] args)
    //{
    //    var solution = new Solution();
    //    while (true)
    //    {
    //        //int input = int.Parse(Console.ReadLine());
    //        string input = Console.ReadLine();
    //        var res = solution.RomanToInt(input);
    //        Console.WriteLine(res);
    //    }
    //}

    public class Solution
    {
        /// <summary>
        /// 第一印象，遍历解（没有看到更好的做法，）
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int RomanToInt(string s)
        {
            int sum = 0;
            for (int i = 0; i < s.Length; i++)
            {
                switch (s[i])
                {
                    case 'I':
                        {
                            if (i != s.Length - 1 && s[i + 1] == 'V')
                            {
                                sum += 4;
                                i++;
                            }
                            else if (i != s.Length - 1 && s[i + 1] == 'X')
                            {
                                sum += 9;
                                i++;
                            }
                            else
                            {
                                sum += 1;
                            }
                            break;
                        }
                    case 'V':
                        sum += 5; break;
                    case 'X':
                        {
                            if (i != s.Length - 1 && s[i + 1] == 'L')
                            {
                                sum += 40;
                                i++;
                            }
                            else if (i != s.Length - 1 && s[i + 1] == 'C')
                            {
                                sum += 90;
                                i++;
                            }
                            else
                            {
                                sum += 10;
                            }
                            break;
                        }
                    case 'L':
                        sum += 50; break;
                    case 'C':
                        {
                            if (i != s.Length - 1 && s[i + 1] == 'D')
                            {
                                sum += 400;
                                i++;
                            }
                            else if (i != s.Length - 1 && s[i + 1] == 'M')
                            {
                                sum += 900;
                                i++;
                            }
                            else
                            {
                                sum += 100;
                            }
                            break;
                        }
                    case 'D':
                        sum += 500; break;
                    case 'M': sum += 1000; break;
                    default: break;
                }
            }
            return sum;
        }
    }
}
