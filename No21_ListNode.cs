using LeetCode.ExtensionFunction;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode_21
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
    //        //int?[] data = new int?[] { 6, 2, 8, 0, 4, 7, 9, null, null, 3, 5 };
    //        //var tree = new DataStructureBuilder().BuildTree(data);
    //        var builder = new DataStructureBuilder();
    //        var node1 = builder.BuildListNode(new int[] { 1, 2, 4 });
    //        var node2 = builder.BuildListNode(new int[] { 1, 3, 4 });
    //        var res = solution.MergeTwoLists(node1, node2);
    //        ConsoleX.WriteLine(res);
    //    }
    //}

    public class Solution
    {
        /// <summary>
        /// l1长度为n,l2长度为m
        /// 时间复杂度：O(n + m)
        /// 空间复杂度：O(1)
        /// 还可以用递归来做，但是只会增长空间复杂度，时间也不会快，所以就不实现了
        /// </summary>
        /// <param name="l1"></param>
        /// <param name="l2"></param>
        /// <returns></returns>
        public ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            ListNode res = new ListNode();
            ListNode temp = res;
            while (!(l1 == null && l2 == null))
            {
                if (l1 == null)
                {
                    temp = AssignAndMoveNext(temp, l2.val);
                    l2 = l2.next;
                }
                else if (l2 == null)
                {
                    temp = AssignAndMoveNext(temp, l1.val);
                    l1 = l1.next;
                }
                else
                {
                    if (l1.val > l2.val)
                    {
                        temp = AssignAndMoveNext(temp, l2.val);
                        l2 = l2.next;
                    }
                    else
                    {
                        temp = AssignAndMoveNext(temp, l1.val);
                        l1 = l1.next;
                    }
                }

            }
            return res.next;
        }

        private ListNode AssignAndMoveNext(ListNode node, int value)
        {
            node.next = new ListNode(value);
            return node.next;
        }
    }
}
