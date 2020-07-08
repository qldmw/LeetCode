using LeetCode.ExtensionFunction;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode_206
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
    //        var listNode = builder.BuildListNode(new int[] { 1, 2, 3, 4, 5 });
    //        //var listNode2 = builder.BuildListNode(new int[] { 5, 6});
    //        //listNode2.next.next = listNode.next.next.next.next;
    //        var res = solution.ReverseList(listNode);
    //        ConsoleX.WriteLine(res);
    //    }
    //}

    public class Solution
    {
        /// <summary>
        /// 题解的递归。都挺好的，就是逻辑绕，实属协作开发的下乘解法，写一个算法要写十行注释
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode ReverseList(ListNode head)
        {
            if (head == null || head.next == null) return head;
            ListNode p = ReverseList(head.next);
            head.next.next = head;
            head.next = null;
            return p;
        }

        /// <summary>
        /// 递归。写的不好看，哈哈哈
        /// 时间复杂度：O(n)
        /// 空间复杂度：O(n),由于使用递归，将会使用隐式栈空间。递归深度可能会达到 n 层。
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        //public ListNode ReverseList(ListNode head)
        //{
        //    FindNext(head);
        //    return _res;
        //}

        //private ListNode _res;
        //private ListNode FindNext(ListNode head)
        //{
        //    if (head == null)
        //        return null;

        //    var nextNode = FindNext(head.next);
        //    if (nextNode != null)
        //        nextNode.next = head;
        //    else
        //        _res = head;

        //    head.next = null;

        //    return head;
        //}

        /// <summary>
        /// 迭代
        /// 时间复杂度：O(n)
        /// 空间复杂度：O(1)，还可以用 O(n) 的来做，就不会这么绕，直接new
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        //public ListNode ReverseList(ListNode head)
        //{
        //    ListNode res = null;
        //    ListNode preNode = null;
        //    while (head != null)
        //    {
        //        //处于第一个节点的时候
        //        if (preNode != null)
        //            preNode.next = res;

        //        res = preNode;
        //        preNode = head;
        //        head = head.next;

        //        //处理最后一个节点
        //        if (head == null)
        //            preNode.next = res;
        //    }
        //    return preNode;
        //}
    }
}
