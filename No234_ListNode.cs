using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode_234
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
    //        var listNode = builder.BuildListNode(new int[] { 1, 0, 0 });
    //        //var listNode2 = builder.BuildListNode(new int[] { 5, 6});
    //        //listNode2.next.next = listNode.next.next.next.next;
    //        var res = solution.IsPalindrome(listNode);
    //        ConsoleX.WriteLine(res);
    //    }
    //}

    public class Solution
    {
        /// <summary>
        /// 题解给的解法，最后还恢复了链表
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public bool IsPalindrome(ListNode head)
        {

            if (head == null) return true;

            // Find the end of first half and reverse second half.
            ListNode firstHalfEnd = endOfFirstHalf(head);
            ListNode secondHalfStart = reverseList(firstHalfEnd.next);

            // Check whether or not there is a palindrome.
            ListNode p1 = head;
            ListNode p2 = secondHalfStart;
            bool result = true;
            while (result && p2 != null)
            {
                if (p1.val != p2.val) result = false;
                p1 = p1.next;
                p2 = p2.next;
            }

            // Restore the list and return the result.
            firstHalfEnd.next = reverseList(secondHalfStart);
            return result;
        }

        // Taken from https://leetcode.com/problems/reverse-linked-list/solution/
        private ListNode reverseList(ListNode head)
        {
            ListNode prev = null;
            ListNode curr = head;
            while (curr != null)
            {
                ListNode nextTemp = curr.next;
                curr.next = prev;
                prev = curr;
                curr = nextTemp;
            }
            return prev;
        }

        private ListNode endOfFirstHalf(ListNode head)
        {
            ListNode fast = head;
            ListNode slow = head;
            while (fast.next != null && fast.next.next != null)
            {
                fast = fast.next.next;
                slow = slow.next;
            }
            return slow;
        }

        /// <summary>
        /// 翻转一半链表，然后前后对比
        /// 时间复杂度：O(n)
        /// 空间复杂度：O(1)，为了这个 O(1) 的复杂度花了太多功夫，其实 O(n) 的转化为一般回文就简单多了，前后指针快速解决。
        /// 该方法的缺点是，在并发环境下，函数运行时需要锁定其他线程或进程对链表的访问，因为在函数执执行过程中链表暂时断开。
        /// 
        /// 写的不好看，这种写完应该要好好整理下才行，逻辑有点乱
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        //public bool IsPalindrome(ListNode head)
        //{
        //    //链表长度
        //    int count = 0;
        //    var temp = head;
        //    while (temp != null)
        //    {
        //        count++;
        //        temp = temp.next;
        //    }
        //    if (count == 0 || count == 1)
        //        return true;

        //    //翻转的半程对比链表
        //    ListNode reverse = null;
        //    ListNode secondHalf = null;
        //    //反转到中间位置
        //    reverse = ReverseList(head, count, out secondHalf);

        //    //开始比对
        //    while (reverse != null && secondHalf != null)
        //    {
        //        if (reverse.val != secondHalf.val)
        //            return false;

        //        reverse = reverse.next;
        //        secondHalf = secondHalf.next;
        //    }
        //    return true;
        //}

        //private ListNode ReverseList(ListNode head, int count, out ListNode secondHalf)
        //{
        //    //中间位置
        //    int mid = count % 2 == 0 ? count / 2 : count / 2 + 1;

        //    ListNode res = null;
        //    ListNode preNode = null;
        //    while (--mid >= 0)
        //    {
        //        //处于第一个节点的时候
        //        if (preNode != null)
        //            preNode.next = res;

        //        res = preNode;
        //        preNode = head;
        //        head = head.next;

        //        //处理最后一个节点
        //        if (mid == 0)
        //            preNode.next = res;
        //    }
        //    secondHalf = head;
        //    return count % 2 == 0 ? preNode : preNode.next;
        //}
    }
}
