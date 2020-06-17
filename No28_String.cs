using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode_28
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
    //        string input2 = Console.ReadLine();
    //        //int[] intArr = input.Split(',').Select(s => int.Parse(s)).ToArray();
    //        //int input2 = int.Parse(Console.ReadLine());
    //        //int[] intArr = new int[] { 1, 3, 2 };
    //        //int[] intArr = new int[] { 4, 2, 1, 3, 2, 6, 3 };
    //        //int[] intArr2 = new int[] { 4, 2, 1, 3, 2, 6, 3 };
    //        var res = solution.StrStr(input, input2);
    //        ConsoleX.WriteLine(res);
    //    }
    //}

    public class Solution
    {
        /// <summary>
        /// KMP(Knuth-Morris-Pratt)算法
        /// TODO:完成KMP算法
        /// </summary>
        /// <param name="haystack"></param>
        /// <param name="needle"></param>
        /// <returns></returns>
        //public int StrStr(string haystack, string needle)
        //{

        //}

        /// <summary>
        /// BM(Boyer-Moore)字符串搜索算法，坏字符和好后缀原则
        /// TODO:完成BM算法
        /// </summary>
        /// <param name="haystack"></param>
        /// <param name="needle"></param>
        /// <returns></returns>
        //public int StrStr(string haystack, string needle)
        //{

        //}

        /// <summary>
        /// RK(Rabin Karp)算法
        /// 时间复杂度：O(n),每次使用hash比较的子串和模式串,耗时为O(1)，这也是RK算法优秀的地方
        /// 空间复杂度：O(1)
        /// 利用Hash减少子串的循环，使得算法耗时稳定在O(n)
        /// </summary>
        /// <param name="haystack"></param>
        /// <param name="needle"></param>
        /// <returns></returns>
        //public int StrStr(string haystack, string needle)
        //{
        //    if (needle == string.Empty)
        //        return 0;
        //    if (needle.Length > haystack.Length)
        //        return -1;

        //    //rolling hash的基础数, 因为这里是26个字符
        //    int BASE = 26;
        //    //取模的数
        //    int MODULUS = int.MaxValue;
        //    //用于rolling hash置换出最高位的系数
        //    int HIGHEST_SHIFT_DIGIT = 1;
        //    for (int i = 0; i < needle.Length - 1; i++)
        //    {
        //        HIGHEST_SHIFT_DIGIT = HIGHEST_SHIFT_DIGIT * BASE % MODULUS;
        //    }

        //    //获取模式串的hash值
        //    int needleHash = 0;
        //    for (int i = 0; i < needle.Length; i++)
        //    {
        //        needleHash = (needleHash * BASE + needle[i]) % MODULUS;
        //    }

        //    int haystackHash = 0;
        //    int index = 0;
        //    for (int i = 0; i < haystack.Length; i++)
        //    {
        //        //如果长度大于模式串，就弹出一位hash值
        //        if (i >= needle.Length)
        //        {
        //            haystackHash -= (haystack[i - needle.Length] * HIGHEST_SHIFT_DIGIT) % MODULUS;
        //            index++;
        //        }

        //        haystackHash = (haystackHash * BASE + haystack[i]) % MODULUS;

        //        if (needleHash == haystackHash)
        //            break;
        //    }
        //    //防止可能产生的hash碰撞
        //    if (needleHash == haystackHash && string.Compare(haystack, index, needle, 0, needle.Length) == 0)
        //        return index;
        //    else
        //        return -1;
        //}

        /// <summary>
        /// Sunday算法
        /// 时间复杂度：O(n),最坏O(mn),平均O(n)
        /// 空间复杂度：O(1),因为字符串的种类是有限的，可以看做是常数个。虽然说起来是常数，但是还是会是一个很大的dictionary
        /// 比BF算法优秀一些，以为有大量重复的字符串时，不会变BF一样完全回退从头开始，二是直接通过偏移表找到下一个“合适”的位置
        /// </summary>
        /// <param name="haystack"></param>
        /// <param name="needle"></param>
        /// <returns></returns>
        //public int StrStr(string haystack, string needle)
        //{
        //    if (needle == string.Empty)
        //        return 0;

        //    //生成偏移表
        //    Dictionary<char, int> dic = new Dictionary<char, int>();
        //    for (int i = 0; i < needle.Length; i++)
        //    {
        //        if (dic.ContainsKey(needle[i]))
        //            dic[needle[i]] = needle.Length - i;
        //        else
        //            dic.Add(needle[i], needle.Length - i);
        //    }

        //    //sunday算法：不匹配，则查看 待匹配字符串 的后一位字符 c：1.若c存在于Pattern中，则 idx = idx + 偏移表[c] 2.否则，idx = idx + len(pattern)
        //    int index = 0;
        //    while (index <= haystack.Length - needle.Length)
        //    {
        //        if (string.Compare(haystack, index, needle, 0, needle.Length) == 0)
        //            break;
        //        else
        //        {
        //            if (index + needle.Length < haystack.Length && dic.ContainsKey(haystack[index + needle.Length]))
        //                index += dic[haystack[index + needle.Length]];
        //            else
        //                index += needle.Length;
        //        }
        //    }
        //    return index > haystack.Length - needle.Length ? -1 : index;
        //}

        /// <summary>
        /// BF算法（BruteForce）
        /// 时间复杂度：O(n)，可能这种比较好算的就要算最优和最差了吧，最优时间是O(n),最差时间是O((n-l)n)
        /// 空间复杂度：O(1)
        /// </summary>
        /// <param name="haystack"></param>
        /// <param name="needle"></param>
        /// <returns></returns>
        //public int StrStr(string haystack, string needle)
        //{
        //    if (needle == string.Empty)
        //        return 0;

        //    int ans = -1;
        //    for (int i = 0; i <= haystack.Length - needle.Length; i++)
        //    {
        //        int j = 0;
        //        for (; j < needle.Length; j++)
        //        {
        //            if (haystack[i + j] != needle[j])
        //                break;
        //        }
        //        if (j == needle.Length)
        //        {
        //            ans = i;
        //            break;
        //        }
        //    }
        //    return ans;
        //}
    }
}
