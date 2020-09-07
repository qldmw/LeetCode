using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode_169
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
    //        //string input2 = Console.ReadLine();
    //        int[] intArr = input.Split(',').Select(s => int.Parse(s)).ToArray();
    //        //int input2 = int.Parse(Console.ReadLine());
    //        var res = solution.MajorityElement(intArr);
    //        Console.WriteLine(res);
    //    }
    //}

    /// <summary>
    /// REVIEW
    /// 2020.09.07: boyer-moore投票算法简述：遇到相同的count++，遇到不同的count--，遍历完最后剩下的就是那个过半的数。
    /// </summary>
    
    public class Solution
    {
        /// <summary>
        /// boyer-moore投票算法，通过一个巧妙的方式获取到过半的数
        /// 时间复杂度:O(n),毋庸置疑的n,看起来应该比之前的遍历统计快不少才对，然而C#执行下来却和之前的遍历统计差不多，运气不好的时候还是一样的，感觉代码优化对C#不太明显，不知道为啥
        /// 空间复杂度:O(1),常数个变量，然后执行结果和遍历统计完全差不多，都分别执行三次，就有一次内存少了0.1m,其他两次都是一样的
        /// Unsolved Question：为什么C#执行效率波动那么大，有时候会波动好几十ms；而且空间复杂度明明从O(n)减少到了O(1),但是效果却不明显，是因为用例的问题么，这也差的太少了吧，还不如一个执行波动来的大
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MajorityElement(int[] nums)
        {
            int candidate = 0;
            int count = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (count == 0)
                    candidate = nums[i];

                if (nums[i] != candidate)
                    count--;
                else
                    count++;
            }
            return candidate;
        }

        /// <summary>
        /// 第一反应解优化，在加数组中去检查真没必要，虽然最优情况下可能会很好，但是不值得，最后检查一次就可以了
        /// 时间复杂度：O(n)，遍历n, 插入dictionary常数时间，最后遍历dictionary也是O(n),所以最后是O(n)
        /// 空间复杂度：O(n)，虽然肯定是小于n的，但是一定是跟n成线性关系的，所以是O(n)
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        //public int MajorityElement(int[] nums)
        //{
        //    var dic = new Dictionary<int, int>();
        //    for (int i = 0; i < nums.Length; i++)
        //    {
        //        if (dic.ContainsKey(nums[i]))
        //            dic[nums[i]]++;
        //        else
        //            dic.Add(nums[i], 1);
        //    }

        //    var marjority = dic.FirstOrDefault(s => s.Value > nums.Length / 2);
        //    if (marjority.Value != 0)
        //        return marjority.Key;
        //    return 0;
        //}

        /// <summary>
        /// 第一反应解，计数，过半的时候再开始检查是否有合适的数
        /// 时间复杂度：O(n²),dictionary中的FirstOrDefault应该是会遍历的，所以最大项应该是n²
        /// 空间复杂度：O(n)，虽然肯定是小于n的，但是一定是跟n成线性关系的，所以是O(n)
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        //public int MajorityElement(int[] nums)
        //{
        //    var dic = new Dictionary<int, int>();
        //    for (int i = 0; i < nums.Length; i++)
        //    {
        //        if (dic.ContainsKey(nums[i]))
        //            dic[nums[i]]++;
        //        else
        //            dic.Add(nums[i], 1);

        //        if (i >= nums.Length / 2)
        //        {
        //            var marjority = dic.FirstOrDefault(s => s.Value > nums.Length / 2);
        //            if (marjority.Value != 0)
        //                return marjority.Key;
        //        }
        //    }
        //    return 0;
        //}
    }
}
