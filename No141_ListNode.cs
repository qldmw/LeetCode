using LeetCode.ExtensionFunction;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode_141
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
    //        var listNode = new DataStructureBuilder().BuildListNode(new int[] { 1, 2, 3, 4, 5 });
    //        //listNode.next.next.next.next.next = listNode;
    //        var res = solution.HasCycle(listNode);
    //        ConsoleX.WriteLine(res);
    //    }
    //}

    public class Solution
    {
        /// <summary>
        /// 弗洛伊德循环查找法
        /// 时间复杂度：O(n)
        /// 空间复杂度：O(1)
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public bool HasCycle(ListNode head)
        {
            var rabbit = head;
            var tortoise = head;
            do
            {
                rabbit = MoveToNext(rabbit, 2);
                tortoise = MoveToNext(tortoise, 1);
            }
            while (rabbit != tortoise && rabbit != null);
            return rabbit != null;
        }

        private ListNode MoveToNext(ListNode node, int step)
        {
            while (step > 0 && node != null)
            {
                node = node.next;
                step--;
            }
            return node;
        }
    }
}
