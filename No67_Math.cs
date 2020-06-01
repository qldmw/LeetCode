using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode_67
{
    //static void Main(string[] args)
    //{
    //    var solution = new Solution();
    //    while (true)
    //    {
    //        //int input = int.Parse(Console.ReadLine());
    //        string input = Console.ReadLine();
    //        string input2 = Console.ReadLine();
    //        var res = solution.AddBinary(input, input2);
    //        Console.WriteLine(res);
    //    }
    //}
    public class Solution
    {
        /// <summary>
        /// 位运算，先通过异或算出不进位的答案，在通过按位与，左移一位算出进位(未通过！因为例子太大，然而C#又没有bigInt这种东西)
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public string AddBinary(string a, string b)
        {
            int numA = Convert.ToInt32(a, 2);
            int numB = Convert.ToInt32(b, 2);
            int resNum = numA;
            int carry;
            while (numB != 0)
            {
                resNum = numA ^ numB;
                carry = (numA & numB) << 1;
                numA = resNum;
                numB = carry;
            }
            return Convert.ToString(resNum, 2);
        }

        /// <summary>
        /// 现成函数,不过会受到int取值范围的影响，且大数的时候效率低(未通过！因为例子太大，然而C#又没有bigInt这种东西)
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        //public string AddBinary(string a, string b)
        //{            
        //    return Convert.ToString(Convert.ToInt32(a, 2) + Convert.ToInt32(b, 2), 2);
        //}

        /// <summary>
        /// 第一印象解（单纯的进位来算）
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        //public string AddBinary(string a, string b)
        //{            
        //int maxLength = Math.Max(a.Length, b.Length);
        ////用0补全位数差异
        //a = a.PadLeft(maxLength, '0');
        //b = b.PadLeft(maxLength, '0');
        ////结果字符串
        //var charList = new char[maxLength];
        ////是否进位
        //bool isCarry = false;
        //for (int i = maxLength - 1; i >= 0; i--)
        //{
        //    //运算
        //    int sum = (a[i] - '0') + (b[i] - '0') + Convert.ToInt32(isCarry);
        //    //运算之后重置进位符
        //    isCarry = false;
        //    //大于进位
        //    if (sum >= 2)
        //    {
        //        sum -= 2;
        //        isCarry = true;
        //    }
        //    if (sum == 1) charList[i] = '1';
        //    else charList[i] = '0';
        //}
        //return isCarry ? "1" + new string(charList) : new string(charList);
        //}
    }
}
