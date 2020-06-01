using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode_168
{
    //static void Main(string[] args)
    //{
    //    var solution = new Solution();
    //    while (true)
    //    {
    //        int input = int.Parse(Console.ReadLine());
    //        //string input = Console.ReadLine();
    //        //string input2 = Console.ReadLine();
    //        var res = solution.ConvertToTitle(input);
    //        Console.WriteLine(res);
    //    }
    //}
    public class Solution
    {
        public string ConvertToTitle(int n)
        {
            int len = (int)Math.Log(n, 26) + 1;
            char[] res = new char[len];
            //A的ASCII码为65
            for (int i = 0; n > 0; i++)
            {
                int reminder = n % 26;
                n /= 26;

                if (reminder == 0)
                {
                    res[i] = (char)(64 + 26);
                    //此题重点：因为没有0的表示形态，所以当整除的时候要-1，因为后面的Z已经代表了26
                    n -= 1;
                }
                else
                    res[i] = (char)(64 + reminder);
            }
            Array.Reverse(res);
            return new string(res).Trim('\0');
        }
    }
}
