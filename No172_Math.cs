using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode_172
{
    //static void Main(string[] args)
    //{
    //    var solution = new Solution();
    //    while (true)
    //    {
    //        int input = int.Parse(Console.ReadLine());
    //        //string input = Console.ReadLine();
    //        //string input2 = Console.ReadLine();
    //        var res = solution.TrailingZeroes(input);
    //        Console.WriteLine(res);
    //    }
    //}
    public class Solution
    {
        /// <summary>
        /// 更高维度拆解分式，通过数学推出，大概思路就是分解25就是分解两次5，往上也是一样，所以通过不断分解5就可以得到答案
        /// 时间复杂度O(log n),因为是不断除以5，所以是5的幂，即为O(log 5 n),循环内的除法是32位整形内的，所以是O(1),忽略
        /// 空间复杂度O(1),只用了一个zeroCount计算。
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int TrailingZeroes(int n)
        {
            int zeroCount = 0;
            while (n > 0)
            {
                n /= 5;
                zeroCount += n;
            }
            return zeroCount;
        }

        /// <summary>
        /// 尾数的零一定是由2乘以5构成的，所以可以分解成有多少个2和5的组合就能获得答案，因为分解出来的2是远多于5的，
        /// 所以忽略掉2，只考虑5。5还有一种特殊情况就是，例如25这种，可以分解出不只一个5，这种就要特殊考虑。
        /// 时间复杂度O(n)，循环步长为5，所以是1/5n，还有部分进入计算的也可以忽略不计
        /// 空间复杂度O(1)，只用了一个zeroCount计数。
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        //public int TrailingZeroes(int n)
        //{
        //    //写到一半突然觉得不对，笔记本上写了一下，发现了规律。降维打击成就达成（然而并没有，哈哈哈）
        //    int zeroCount = 0;
        //    for (int i = 5; i <= n; i += 5)
        //    {                    
        //        int powerOfFive = 5;
        //        while (i % powerOfFive == 0)
        //        {                        
        //            zeroCount++;
        //            powerOfFive *= 5;
        //        }
        //    }
        //    return zeroCount;
        //}
    }
}
