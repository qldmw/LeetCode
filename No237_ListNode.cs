using LeetCode.ExtensionFunction;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode_237
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
    //        solution.DeleteNode(listNode.next.next);
    //        //ConsoleX.WriteLine(res);
    //    }
    //}

    public class Solution
    {
        /// <summary>
        /// 题解的最优解！妈耶，没有想到直接去掉就好啊！
        /// 时间复杂度：O(1)
        /// 空间复杂度：O(1)
        /// </summary>
        /// <param name="node"></param>
        public void DeleteNode(ListNode node)
        {
            node.val = node.next.val;
            node.next = node.next.next;
        }

        /// <summary>
        /// 顺着链表去遍历，最后把末尾去掉就好
        /// 时间复杂度：O(n)
        /// 空间复杂度：O(1)
        /// </summary>
        /// <param name="node"></param>
        //public void DeleteNode(ListNode node)
        //{
        //    while (node != null)
        //    {
        //        node.val = node.next.val;

        //        if (node.next.next == null)
        //            node.next = null;

        //        node = node.next;
        //    }
        //}
    }
}
