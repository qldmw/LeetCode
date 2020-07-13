using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Extension;
using LeetCode.ExtensionFunction;

namespace LeetCode
{
    class Program
    {
        static void Main(string[] args)
        {
            var solution = new Solution();
            while (true)
            {
                //int input = int.Parse(Console.ReadLine());
                //int input2 = int.Parse(Console.ReadLine());
                //string input = Console.ReadLine();
                //string input2 = Console.ReadLine();
                //int[] intArr = input.Split(',').Select(s => int.Parse(s)).ToArray();
                //int input2 = int.Parse(Console.ReadLine());
                var builder = new DataStructureBuilder();
                //int?[] data = new int?[] { 10, 5, 15, null, null, 6, 20 };
                //int?[] data = new int?[] { -10, 9, 20, null, null, 15, 7 };
                //int?[] data = new int?[] { -2147483648, null, 2147483647 };
                //int?[] data = new int?[] { 1, 3, null, null, 2 };
                //var tree = builder.BuildTree(data);
                var listNode = builder.BuildListNode(new int[] { 1, 2, 3, 4, 5 });
                //var listNode2 = builder.BuildListNode(new int[] { 5, 6});
                //listNode2.next.next = listNode.next.next.next.next;
                var res = solution.ReverseKGroup(listNode, 3);
                ConsoleX.WriteLine(res);
            }
        }

        public class Solution
        {
            public ListNode ReverseKGroup(ListNode head, int k)
            {
                //建立哨兵节点
                ListNode sentinel = new ListNode(-1);
                sentinel.next = head;

                ListNode temp = sentinel;
                while (temp != null)
                {
                    ListNode KPlusOneNode = null;
                    if (IsGreaterThanOrEqualK(temp, k, out KPlusOneNode))
                        temp = ReverseList(KPlusOneNode, temp.next, temp, k);
                    else
                        break;
                }
                return sentinel.next;
            }

            private bool IsGreaterThanOrEqualK(ListNode head, int k, out ListNode KPlusOneNode)
            {
                ListNode temp = head;
                int count = 0;
                while (temp != null && count < k)
                {
                    count++;
                    temp = temp.next;
                }
                KPlusOneNode = count == k ? temp.next : null;
                return count == k;
            }

            private ListNode ReverseList(ListNode prev, ListNode head, ListNode after, int k)
            {
                ListNode curr = head;
                //翻转计数
                int count = 0;
                //开始翻转
                while (curr != null && count < k)
                {
                    count++;
                    ListNode nextTemp = curr.next;
                    curr.next = prev;
                    prev = curr;
                    curr = nextTemp;
                }
                //翻转完成后把链表接回去
                after.next = prev;
                return head;
            }
        }
    }
}