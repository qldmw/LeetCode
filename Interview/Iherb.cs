using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Interview
{
    class Iherb
    {
        //1.给你10个大文件，里面每一行都是一个数字，让你找出所有数字中 最大的100个
        //（1）如果内存都读下一整个文件的话，就先读取整个文件。不能的话就设置起始点和字节数目，每次读取。
        //（2）splice换行符，先把每个文件中最大的100个取出来。最大的规则是：先获取字符串数组中长度最长的（trimStart 0），然后依次获取最高位数组，从9开始往下筛选（负数的情况需要考虑到），直到满足条件的大于100个就停止。
        // (3) 合并10个文件中的前100个字符串数组，然后再用上述最大数规则获取100个（这次是精确获得一百个，上一次大概获得大于100个就可以）。

        //2.给你一组数字构成的字符串，有正有负，让你找出数字和最大的子串
        public string FindMaxNumString(List<string> data)
        {
            ////测试用例
            //List<string> data = new List<string>()
            //    {
            //        "-981237498217348128378",
            //        "-891237498217348128378",
            //        "-89123749821734812837",
            //        "-891237498217348128378",
            //        "-91237498217348128378",
            //        "-991237498217348128378",
            //        "-91237498217348128378",
            //        "-981237498217348128378"
            //    };
            //var res = solution.FindMaxNumString(data);
            //ConsoleX.WriteLine(res);

            List<int> digit = new List<int>();
            //获取到字符串数字长度,负数则用负数表示
            for (int i = 0; i < data.Count; i++)
            {
                bool sign = true;
                string str = data[i];
                if (str.StartsWith('-'))
                {
                    sign = false;
                    str = str.TrimStart('-');
                }
                int len = str.TrimStart('0').Length;
                digit.Add(sign ? len : -1 * len);
            }
            //根据位数获取位数最大的数组
            int maxDigit = digit.Max();
            List<int> candidatesPos = new List<int>();
            for (int i = 0; i < digit.Count; i++)
            {
                if (digit[i] == maxDigit)
                    candidatesPos.Add(i);
            }
            var candidates = data.Where(s => candidatesPos.IndexOf(data.IndexOf(s)) != -1).ToList();
            //从最大候选人中筛选出最大的数组
            int position = 0;//遍历的位数
            while (candidates.Count > 1)
            {
                int targerDigit = maxDigit > 0 ? candidates.Max(s => s[position] - '0') : candidates.Min(s => s[position + 1] - '0');
                for (int i = candidates.Count - 1; i >= 0; i--)
                {
                    if (maxDigit > 0)
                    {
                        if (candidates[i][position] - '0' != targerDigit)
                            candidates.RemoveAt(i);
                    }
                    else
                    {
                        if (candidates[i][position + 1] - '0' != targerDigit)
                            candidates.RemoveAt(i);
                    }
                }
                position++;
                //如果有多个重复最大解
                if (candidates.Distinct().Count() == 1)
                    break;
            }
            return candidates.FirstOrDefault();
        }

        //3.数组里面找子数组 满足子数组求和最大

        //4.最长公共前缀

        //5.三数之和为 0

        //6.查找中位数

        //7.查找不重复字符串

        //8.找两个字符串中相同字符串的最大长度

        //9.数组最大合子集

        //10.反转数组

        //11.囚徒困境
        //单纯的应该怎么做的话，会选择都沉默，达到帕累托最优解。
        //（1）如果两个囚徒都只能做一次抉择，以后都不能后悔的话。他们会选择背叛。
        //（2）如果两个囚徒都还有再次抉择的机会的话，会先沉默，看对方情况而定，如果对方背叛我再背叛。
        // 帕累托最优：是指资源分配的一种理想状态，假定固有的一群人和可分配的资源，从一种分配状态到另一种状态的变化中，在没有使任何人境况变坏的前提下，使得至少一个人变得更好，这就是帕累托改进或帕累托最优化。
        // 纳什均衡：在一个博弈过程中，无论对方的策略选择如何，当事人一方都会选择某个确定的策略，则该策略被称作支配性策略。如果任意一位参与者在其他所有参与者的策略确定的情况下，其选择的策略是最优的，那么这个组合就被定义为纳什平衡。
        // 其他博弈论： 海盗分赃，旅行者困境

        //12.给定a、b两个文件，各存放50亿个url，每个url各占64字节，内存限制是4G，让你找出a、b文件共同的url?

        //13.最长字符串子集

        //14.Money changing problem

        //15.Longest increasing subsequence

        //16.Missing integer problem
    }
}
