using LeetCode.ExtensionFunction;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode_24
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
    //        var builder = new DataStructureBuilder();
    //        //int?[] data = new int?[] { 10, 5, 15, null, null, 6, 20 };
    //        //int?[] data = new int?[] { -10, 9, 20, null, null, 15, 7 };
    //        //int?[] data = new int?[] { -2147483648, null, 2147483647 };
    //        //int?[] data = new int?[] { 1, 3, null, null, 2 };
    //        //var tree = builder.BuildTree(data);
    //        var listNode = builder.BuildListNode(new int[] { });
    //        //var listNode2 = builder.BuildListNode(new int[] { 5, 6});
    //        //listNode2.next.next = listNode.next.next.next.next;
    //        var res = solution.SwapPairs(listNode);
    //        ConsoleX.WriteLine(res);
    //    }
    //}

    public class Solution
    {
        /// <summary>
        /// 哨兵，链表交换
        /// 时间复杂度：O(n)
        /// 空间复杂度：O(1)
        /// Experience：凡是链表第一个节点会该表指向的，都需要一个哨兵节点接在前面
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode SwapPairs(ListNode head)
        {
            ListNode sentinel = new ListNode(-1);
            sentinel.next = head;

            ListNode res = sentinel;

            while (sentinel.next != null && sentinel.next.next != null)
            {
                ListNode temp = sentinel.next.next.next;
                sentinel.next.next.next = sentinel.next;
                sentinel.next = sentinel.next.next;
                sentinel.next.next.next = temp;

                sentinel = sentinel.next.next;
            }
            return res.next;
        }
    }
}
