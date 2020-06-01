using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace LeetCode_29
{
    //static void Main(string[] args)
    //{
    //    var solution = new Solution();
    //    while (true)
    //    {
    //        int input = int.Parse(Console.ReadLine());
    //        int input2 = int.Parse(Console.ReadLine());
    //        //string input = Console.ReadLine();
    //        //string input2 = Console.ReadLine();
    //        //int[] intArr = input.Split(',').Select(s => int.Parse(s)).ToArray();
    //        //int input = int.Parse(input2);
    //        var res = solution.Divide(input, input2);
    //        Console.WriteLine(res);
    //    }
    //}

    public class Solution
    {
        ///还看到一种解法是，通过位移，比如16/2，2左移3位变成16,然后它的商就等于2的3次方，答案就是8。
        ///也有用递归做的，但其本质也是我第一反应的自加翻倍，只是换了个写法。

        /// <summary>
        /// 第一反应解，不能使用除法，那就用减法替代，其实cpu的除法也是多次加减。但是问题在于一次一次减太慢，所以要通过自己加自己实现*2的效果
        /// 这样就能快速的运算完成了。
        /// 时间复杂度：O(1),因为即使是最大值，也能在常数次循环下解出来
        /// 空间复杂度：O(1),只会申请到常数个数组，所以也是O(1)
        /// 有个小瑕疵，使用了long,因为int.Min换到正数会超过int范围，可以转化到负数来操作，这样就不用转long了;list使用了自定义指针，可以用stack来替换掉
        /// </summary>
        /// <param name="dividend"></param>
        /// <param name="divisor"></param>
        /// <returns></returns>
        public int Divide(int dividend, int divisor)
        {
            if (dividend == int.MinValue && divisor == -1)
                return int.MaxValue;

            long did = Math.Abs((long)dividend);
            long dis = Math.Abs((long)divisor);
            //商
            long quotient = 0;
            //当前除数的倍数
            List<long> timeList = new List<long>() { 1 };
            //除数的集合（二倍递增）
            List<long> disList = new List<long>() { dis };
            //除数集合的指针
            int index = 0;
            //结果符号位。原值和绝对值不相等代表负数,通过异或获得最后符号位
            bool sign = !((did == dividend) ^ (dis == divisor));

            while (did >= dis)
            {
                if (did > disList[index])
                {
                    index++;
                    //如果除数集合还没有下一个倍数的值
                    if (index + 1 > timeList.Count)
                    {
                        //增加下一位的倍数和除数
                        timeList.Add(timeList[index - 1] + timeList[index - 1]);
                        disList.Add(disList[index - 1] + disList[index - 1]);
                    }
                }
                else if (did < disList[index])
                {
                    index--;
                }

                if (did >= disList[index])
                {
                    quotient += timeList[index];
                    did -= disList[index];
                }
            }

            return sign ? (int)quotient : (int)-quotient;
        }
    }
}