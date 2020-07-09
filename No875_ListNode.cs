using LeetCode.ExtensionFunction;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode_875
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
    //        var listNode = builder.BuildListNode(new int[] { 1, 2, 3, 4, 5, 6 });
    //        //var listNode2 = builder.BuildListNode(new int[] { 5, 6});
    //        //listNode2.next.next = listNode.next.next.next.next;
    //        var res = solution.MiddleNode(listNode);
    //        ConsoleX.WriteLine(res);
    //    }
    //}

    public class Solution
    {
        /// <summary>
        /// 题解更简洁的写法。直接把break的条件放到while里，只是这样不是我的第一思维。
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode MiddleNode(ListNode head)
        {
            ListNode fast = head;
            ListNode slow = head;
            while (fast != null && fast.next != null)
            {
                fast = fast.next.next;
                slow = slow.next;
            }
            return slow;
        }

        /// <summary>
        /// 快慢指针获取中间
        /// 时间复杂度：O(n),具体时间是 n / 2
        /// 空间复杂度：O(1)
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        //public ListNode MiddleNode(ListNode head)
        //{
        //    ListNode fast = head;
        //    ListNode slow = head;
        //    while (fast != null)
        //    {
        //        if (fast.next == null)
        //            break;

        //        fast = fast.next.next;
        //        slow = slow.next;
        //    }
        //    return slow;
        //}
    }
}
