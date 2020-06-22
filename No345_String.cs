using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode_345
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
    //        //string input = "A man, a plan, a canal: Panama";
    //        //string input2 = Console.ReadLine();
    //        //int[] intArr = input.Split(',').Select(s => int.Parse(s)).ToArray();
    //        //int input2 = int.Parse(Console.ReadLine());
    //        //int[] intArr = new int[] { 1, 3, 2 };
    //        //int[] intArr = new int[] { 1, 3 };
    //        var res = solution.ReverseVowels(input);
    //        ConsoleX.WriteLine(res);
    //    }
    //}

    public class Solution
    {
        /// <summary>
        /// 第一反应解，简单的判断交换
        /// 时间复杂度：O(n)
        /// 空间复杂度：O(1)
        /// Knowledge：结论：char[].ToCharArray性能优于IEnumerable.ToArray, new string(char[])性能远优于string.Join("", char[]);
        /// s.ToArray改写为s.ToCharArray运行时间从144ms减少了136ms,内存从28.6mb减少到了28.4mb; 
        /// string.Join("", sArr)改写成new string(sArr)运行时间从136ms减少到了96ms,内存从28.2mb减少到了27.2mb。
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string ReverseVowels(string s)
        {
            ISet<char> hs = new HashSet<char> { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };
            int left = 0;
            int right = s.Length - 1;
            var sArr = s.ToCharArray();
            char temp;
            while (left < right)
            {
                if (!hs.Contains(sArr[left]))
                {
                    left++;
                    continue;
                }
                if (!hs.Contains(sArr[right]))
                {
                    right--;
                    continue;
                }
                temp = sArr[left];
                sArr[left] = sArr[right];
                sArr[right] = temp;

                left++;
                right--;
            }
            return new string(sArr);
        }
    }
}
