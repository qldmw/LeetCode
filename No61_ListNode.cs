using LeetCode.ExtensionFunction;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode_61
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
    //        var listNode = builder.BuildListNode(new int[] { 1, 2, 3, 4, 5, 6, 7 });
    //        //var listNode2 = builder.BuildListNode(new int[] { 5, 6});
    //        //listNode2.next.next = listNode.next.next.next.next;
    //        var res = solution.RotateRight(listNode, 3);
    //        ConsoleX.WriteLine(res);
    //    }
    //}

    public class Solution
    {
        /// <summary>
        /// 链表位置交换
        /// 时间复杂度：O(n)
        /// 空间复杂度：O(1)
        /// 先画图，然后总结逻辑，然后写代码。这样即使出错也很快就能解决，这是一次非常好的提交范例，思路清晰，一次通过。
        /// </summary>
        /// <param name="head"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public ListNode RotateRight(ListNode head, int k)
        {
            if (head == null)
                return head;

            ListNode lastNode = null;
            int length = 0;

            ListNode temp = head;
            //获取链表长度，记录末尾节点
            while (temp != null)
            {
                if (temp.next == null)
                    lastNode = temp;
                temp = temp.next;
                length++;
            }

            //获取真实的右移次数
            k = k % length;

            //首部加上哨兵节点
            ListNode sentinel = new ListNode(-1);
            sentinel.next = head;

            //找到新的末尾节点
            temp = sentinel.next;
            for (int i = 0; i < length - k - 1; i++)
            {
                temp = temp.next;
            }

            //重构链表
            lastNode.next = sentinel.next;
            sentinel.next = temp.next;
            temp.next = null;

            return sentinel.next;
        }
    }
}
