using LeetCode.ExtensionFunction;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode_160
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
    //        var listNode = builder.BuildListNode(new int[] { 1, 2, 3, 4, 7, 8 });
    //        var listNode2 = builder.BuildListNode(new int[] { 5, 6 });
    //        listNode2.next.next = listNode.next.next.next.next;
    //        var res = solution.GetIntersectionNode(listNode, listNode2);
    //        ConsoleX.WriteLine(res);
    //    }
    //}

    public class Solution
    {
        /// <summary>
        /// 逻辑构造出一个环，然后使用弗洛伊德查找法（快慢指针），这里是链表的长度差来充当了快慢指针的作用。退出条件是末尾值不相等，但是其实有缺陷
        /// 时间复杂度：O(n)
        /// 空间复杂度：O(1)
        /// </summary>
        /// <param name="headA"></param>
        /// <param name="headB"></param>
        /// <returns></returns>
        public ListNode GetIntersectionNode(ListNode headA, ListNode headB)
        {
            if (headA == null || headB == null)
                return null;

            ListNode AStart = headA;
            ListNode BStart = headB;
            int? ATailValue = null;
            int? BTailValue = null;
            while (true)
            {
                //如果相交，则返回交点
                if (headA == headB)
                    return headA;

                //A和B移到末尾之后，记录末尾值
                if (headA.next == null)
                    ATailValue = headA.val;
                if (headB.next == null)
                    BTailValue = headB.val;

                //如果末尾的值不相同，那一定没有交点。（其实也有缺陷，问题描述里没有说相交之后就不能分开了）
                if (ATailValue != null && BTailValue != null && ATailValue != BTailValue)
                    return null;

                headA = headA.next == null ? BStart : headA.next;
                headB = headB.next == null ? AStart : headB.next;
            }
        }

        /// <summary>
        /// 通过负号标记走过的节点,然后找到走过的路径。但是其实有缺陷的,如果用例里面有负号，那这个算法就完全失效
        /// 时间复杂度：O(n)
        /// 空间复杂度：O(1)
        /// </summary>
        /// <param name="headA"></param>
        /// <param name="headB"></param>
        /// <returns></returns>
        //public ListNode GetIntersectionNode(ListNode headA, ListNode headB)
        //{
        //    //先把A的路径都用负号标记
        //    TogglePathMark(headA);
        //    while (headB != null)
        //    {
        //        if (headB.val < 0)
        //        {
        //            //复原
        //            TogglePathMark(headA);
        //            return headB;
        //        }
        //        headB = headB.next;
        //    }
        //    //复原
        //    TogglePathMark(headA);
        //    return null;
        //}

        //private void TogglePathMark(ListNode node)
        //{
        //    while (node != null)
        //    {
        //        node.val *= -1;
        //        node = node.next;
        //    }
        //}
    }
}
