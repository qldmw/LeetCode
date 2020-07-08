using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode_16_11
{
    //static void Main(string[] args)
    //{
    //    var solution = new Solution();
    //    while (true)
    //    {
    //        //int input = int.Parse(Console.ReadLine());
    //        //int input2 = int.Parse(Console.ReadLine());
    //        //string input = Console.ReadLine();
    //        //string input2 = Console.ReadLine();
    //        //int[] intArr = input.Split(',').Select(s => int.Parse(s)).ToArray();
    //        //int input2 = int.Parse(Console.ReadLine());
    //        //var builder = new DataStructureBuilder();
    //        //int?[] data = new int?[] { 10, 5, 15, null, null, 6, 20 };
    //        //int?[] data = new int?[] { -10, 9, 20, null, null, 15, 7 };
    //        //int?[] data = new int?[] { -2147483648, null, 2147483647 };
    //        //int?[] data = new int?[] { 1, 3, null, null, 2 };
    //        //var tree = builder.BuildTree(data);
    //        //var listNode = builder.BuildListNode(new int[] { 4, 2, 4, 1, 1, 1 });
    //        //var listNode2 = builder.BuildListNode(new int[] { 5, 6});
    //        //listNode2.next.next = listNode.next.next.next.next;
    //        var res = solution.DivingBoard(1, 2, 3);
    //        ConsoleX.WriteLine(res);
    //    }
    //}

    public class Solution
    {
        /// <summary>
        /// 数学
        /// 时间复杂度：O(k)
        /// 空间复杂度：O(1)
        /// </summary>
        /// <param name="shorter"></param>
        /// <param name="longer"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int[] DivingBoard(int shorter, int longer, int k)
        {
            List<int> res = new List<int>();
            if (k == 0)
                return res.ToArray();

            for (int i = k; i >= 0; i--)
            {
                int curSum = shorter * i + longer * (k - i);
                if (res.Count == 0 || res.Last() != curSum)
                    res.Add(curSum);
            }
            return res.ToArray();
        }
    }
}
