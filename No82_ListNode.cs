using LeetCode.ExtensionFunction;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode_82
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
    //        var listNode = builder.BuildListNode(new int[] { 1, 2, 3, 3, 4, 4, 4, 5 });
    //        //var listNode2 = builder.BuildListNode(new int[] { 5, 6});
    //        //listNode2.next.next = listNode.next.next.next.next;
    //        var res = solution.DeleteDuplicates(listNode);
    //        ConsoleX.WriteLine(res);
    //    }
    //}

    public class Solution
    {
        /// <summary>
        /// 循环查找重复节点
        /// 时间复杂度：O(n)
        /// 空间复杂度：O(1)
        /// 链表的题我发现就是给我锻炼思维的严谨性的，解题思路上没有太大的问题。而且这种题目，画图会让思路很清晰，一定要动笔。
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode DeleteDuplicates(ListNode head)
        {
            //创建哨兵节点
            ListNode sentinel = new ListNode(-1);
            sentinel.next = head;

            //开启循环查找重复节点
            ListNode temp = sentinel;
            while (temp.next != null)
            {
                //如果出现重复节点
                if (temp.next.next != null && temp.next.val == temp.next.next.val)
                {
                    ListNode innerTemp = temp.next;
                    int duplicatedVal = temp.next.val;
                    //循环找到所有的重复值
                    while (innerTemp.next != null && innerTemp.next.val == duplicatedVal)
                    {
                        innerTemp = innerTemp.next;
                    }
                    //删掉重复节点
                    temp.next = innerTemp.next;
                }
                else
                    temp = temp.next;
            }
            return sentinel.next;
        }
    }
}
