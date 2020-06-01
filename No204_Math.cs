using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode_204
{
    //static void Main(string[] args)
    //{
    //    var solution = new Solution();
    //    while (true)
    //    {
    //        int input = int.Parse(Console.ReadLine());
    //        //string input = Console.ReadLine();
    //        //string input2 = Console.ReadLine();
    //        var res = solution.CountPrimes(input);
    //        Console.WriteLine(res);
    //    }
    //}

    public class Solution
    {
        /// <summary>
        /// 厄拉多塞筛法,直接列出所有非质数，剩下的质数一次性就可以获得总和
        /// 时间复杂度：O(n/2 + n/3 + n/5 + ... == n*(1/2 + 1/3 + 1/5 + ...) == O(n * loglog n))
        /// 空间复杂度：O(n)
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int CountPrimes(int n)
        {
            int primeCount = 0;
            //npList == not prime list
            bool[] npList = new bool[n];
            for (int i = 2; i < n; i++)
            {
                if (!npList[i])
                {
                    primeCount++;
                    for (int j = i + i; j < n; j += i)
                    {
                        npList[j] = true;
                    }
                }
            }
            return primeCount;
        }

        /// <summary>
        /// 第一反应解，去遍历，这样算过的还要再算一次
        /// 时间复杂度：O(n²)
        /// 空间复杂度：O(1)
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        //public int CountPrimes(int n)
        //{
        //    int primeCount = 0;
        //    for (int i = 1; i < n; i++)
        //    {
        //        if (IsPrime(i))
        //            primeCount++;
        //    }
        //    return primeCount;
        //}
        //public bool IsPrime(int n)
        //{
        //    if (n <= 1)
        //        return false;

        //    bool isPrime = true;
        //    //为什么是i * i <= n,因为因式分解是对称翻转的，过半了没有那就说明是质数了
        //    for (int i = 3; i * i <= n; i += 2)
        //    {
        //        if (n % i == 0)
        //        {
        //            isPrime = false;
        //            break;
        //        }
        //    }
        //    return isPrime;
        //}
    }
}
