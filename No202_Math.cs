using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode_202
{
    //static void Main(string[] args)
    //{
    //    var solution = new Solution();
    //    while (true)
    //    {
    //        int input = int.Parse(Console.ReadLine());
    //        //string input = Console.ReadLine();
    //        //string input2 = Console.ReadLine();
    //        var res = solution.IsHappy(input);
    //        Console.WriteLine(res);
    //    }
    //}

    public class Solution
    {

        public int GetNextNum(int n)
        {
            int num = 0;
            while (n > 0)
            {
                num += (int)Math.Pow(n % 10, 2);
                n /= 10;
            }
            return num;
        }

        /// <summary>
        /// 快慢指针来查看是否有循环，这样就不用存走过的路途了（弗洛伊德循环查找算法）
        /// 时间复杂度O(log n)
        /// 空间复杂度O(1)，因为不用存走过的路径，只需要不断计算就可以了
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public bool IsHappy(int n)
        {
            int rabbit = n;
            int tortoise = n;
            do
            {
                rabbit = GetNextNum(GetNextNum(rabbit));
                tortoise = GetNextNum(tortoise);
            }
            while (rabbit != 1 && rabbit != tortoise);//&& tortoise != 1

            //如果没有循环兔子会最先到达
            return rabbit == 1;// || tortoise == 1;
        }

        /// <summary>
        ///hash set记录已经走过的路径，如果有已经走过的，就一定不是happy number
        ///时间复杂度:O(log n)
        ///空间复杂度:O(log n)
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        //public bool IsHappy(int n)
        //{
        //    HashSet<int> hs = new HashSet<int>();
        //    while (n != 1 && !hs.Contains(n))
        //    {
        //        hs.Add(n);
        //        n = GetNextNum(n);
        //    }
        //    return n == 1;
        //}
    }
}
