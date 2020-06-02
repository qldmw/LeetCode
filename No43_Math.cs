using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode_43
{
    //static void Main(string[] args)
    //{
    //    var solution = new Solution();
    //    while (true)
    //    {
    //        //int input = int.Parse(Console.ReadLine());
    //        //int input2 = int.Parse(Console.ReadLine());
    //        string input = Console.ReadLine();
    //        string input2 = Console.ReadLine();
    //        //int[] intArr = input.Split(',').Select(s => int.Parse(s)).ToArray();
    //        //int input = int.Parse(input2);
    //        var res = solution.Multiply(input, input2);
    //        Console.WriteLine(res);
    //    }
    //}

    /// <summary>
    /// Experience: 
    /// 1.用数组来进行加减时，改变向左进位的思维，向右进位，因为数组利用【0】的位置来对齐是更方便的做法，否则要把短的数据用零补齐。
    /// 2.数组加减之后小心进位，整个数组循环完之后应该判断一次进位符是否为零，不为零就加在数组后面。
    /// </summary>

    public class Solution
    {
        private List<int> _res = new List<int>();

        /// <summary>
        /// 使用小学竖式乘法来计算，算法其实不难，主要是实现中遇到的各种细节。这种就应该先写好，详细到遍历顺序，否则后来会疯狂debug
        /// 时间复杂度：O(mn),因为两个string输入多长，就要计算多少次
        /// 空间复杂度：O(Max(m,n)),只用了一个数组来存结果。但是我看之前计算空间复杂度的有说，如果给定了长度，可以考虑成只使用了常量个。。。如果这样算的话，就是O(1)，嗯，仔细想想并不是这样的吧，哈哈哈，这尼玛也太厚脸皮了吧，还O(1)
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <returns></returns>
        public string Multiply(string num1, string num2)
        {
            if (num1 == "0" || num2 == "0")
                return "0";

            for (int i = num2.Length - 1; i >= 0; i--)
            {
                MultipleForStr(num1, num2[i], num2.Length - 1 - i);
            }
            //把整型数组转化为string
            StringBuilder sb = new StringBuilder();
            for (int i = _res.Count - 1; i >= 0; i--)
            {
                sb.Append(_res[i]);
            }
            return sb.ToString();
        }

        private void MultipleForStr(string num1, char n, int pow)
        {
            List<int> stepRes = new List<int>();
            int carry = 0;
            for (int i = num1.Length - 1; i >= 0; i--)
            {
                int cur_res = (num1[i] - '0') * (n - '0') + carry;
                stepRes.Add((cur_res) % 10);
                carry = cur_res / 10;
            }
            //如果还有要进位的
            if (carry != 0)
            {
                stepRes.Add(carry);
            }
            stepRes.InsertRange(0, new int[pow]);
            PlusAndAssignToGlobal(stepRes);
        }

        private void PlusAndAssignToGlobal(List<int> stepRes)
        {
            int carry = 0;
            int index = Math.Max(_res.Count, stepRes.Count);
            for (int i = 0; i < index; i++)
            {
                //如果全局长度不够，就给他补齐一个初始化为0的数组
                if (_res.Count < i + 1)
                {
                    _res.AddRange(new int[i + 1 - _res.Count]);
                }
                int plus_res = _res[i] + stepRes[i] + carry;
                _res[i] = plus_res % 10;
                carry = plus_res / 10;
            }
            //如果还有要进位的
            if (carry != 0)
            {
                _res.Add(carry);
            }
        }
    }
}
