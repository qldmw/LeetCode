using LeetCode.ExtensionFunction;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode_19
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
    //        var listNode = builder.BuildListNode(new int[] { 1 });
    //        //var listNode2 = builder.BuildListNode(new int[] { 5, 6});
    //        //listNode2.next.next = listNode.next.next.next.next;
    //        var res = solution.RemoveNthFromEnd(listNode, 1);
    //        ConsoleX.WriteLine(res);
    //    }
    //}

    public class Solution
    {
        /// <summary>
        /// 快慢指针
        /// 时间复杂度：O(n)
        /// 空间复杂度：O(1)
        /// Experience: ListNode有需要删除第一个节点的情况下，多数情况需要使用sentinel节点，加一个在前面
        /// </summary>
        /// <param name="head"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            if (head == null)
                return null;
            //使用sentinel是为了用来删除第一个的
            ListNode sentinel = new ListNode(-1);
            sentinel.next = head;

            ListNode fast = sentinel;
            ListNode slow = sentinel;
            //先让fast先走，这样fast到末尾的时候，slow就刚好到目标位置。
            while (--n > 0)
            {
                fast = fast.next;
            }
            //fast slow共同前进
            while (fast.next != null)
            {
                if (fast.next.next == null)
                {
                    slow.next = slow.next.next;
                    break;
                }
                fast = fast.next;
                slow = slow.next;
            }
            return sentinel.next;
        }
    }
}
