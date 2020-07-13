using LeetCode.ExtensionFunction;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode_23
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
    //        var listNode = builder.BuildListNode(new int[] { 1, 4, 5 });
    //        var listNode2 = builder.BuildListNode(new int[] { 1, 3, 4 });
    //        var listNode3 = builder.BuildListNode(new int[] { 2, 6 });
    //        var listNode4 = builder.BuildListNode(new int[] { });
    //        var listNodeList = new ListNode[] { listNode, listNode2, listNode3, listNode4 };
    //        //listNode2.next.next = listNode.next.next.next.next;
    //        var res = solution.MergeKLists(listNodeList);
    //        ConsoleX.WriteLine(res);
    //    }
    //}

    public class Solution
    {
        /// <summary>
        /// 把所有节点放在一起，然后排序，串连起来即可
        /// 设总共有 n 个节点
        /// 时间复杂度：O(nlogn),获取所有的节点值耗时 O(n), 排序耗时 O(nlogn), 串连耗时 O(n)
        /// 空间复杂度：O(n)
        /// 不一定精妙的算法就是好的算法，有些时候简单的反而是更好的。而且这个算法看似空间复杂度比之前的大了一个量级，但其实测试反应出来的空间差异在0.1m内。速度是最重要的！
        /// </summary>
        /// <param name="lists"></param>
        /// <returns></returns>
        public ListNode MergeKLists(ListNode[] lists)
        {
            //所有节点值的集合。只保存所有值，可以缩小空间占用
            List<int> values = new List<int>();
            //把所有的节点值都放到一起
            foreach (var node in lists)
            {
                var temp = node;
                while (temp != null)
                {
                    values.Add(temp.val);
                    temp = temp.next;
                }
            }
            values.Sort();
            ListNode sentinel = new ListNode(-1);
            var temp2 = sentinel;
            //把排序之后的值串联起来
            foreach (int val in values)
            {
                temp2.next = new ListNode(val);
                temp2 = temp2.next;
            }
            return sentinel.next;
        }

        /// <summary>
        /// 每次循环找到最小的节点，然后连接到主串上
        /// 设 lists.length 为 m，平均每个子串长度为 n。
        /// 时间复杂度：O(nm²),每连接一个节点要循环m次来找到最小节点，一共要连接mn次
        /// 空间复杂度：O(1)
        /// 常数级空间复杂度解法。我这里用的竖向的合并，如果改成横向的合并（就是链表两两合并）的话，可以使用分治法来优化，但是那样空间复杂度就不是O(1)了。
        /// </summary>
        /// <param name="lists"></param>
        /// <returns></returns>
        //public ListNode MergeKLists(ListNode[] lists)
        //{
        //    //给每个链表加上一个哨兵，为之后的链表移动做准备
        //    for (int i = 0; i < lists.Length; i++)
        //    {
        //        ListNode colSentinel = new ListNode(-1);
        //        colSentinel.next = lists[i];
        //        lists[i] = colSentinel;
        //    }

        //    //建立一个整体的哨兵，之后每次都从lists里拿一个最小节点出来，加在这个上面，类似于串珠子
        //    ListNode sentinel = new ListNode(-1);
        //    var temp = sentinel;


        //    //单次循环最小的节点
        //    ListNode minNode = new ListNode(int.MaxValue);
        //    //最小节点的行数
        //    int minCol = -1;
        //    //遍历lists，获取最小的节点
        //    for (int i = 0; i < lists.Length; i++)
        //    {
        //        //因为每行都用了哨兵，所以这里是next
        //        if (lists[i].next != null && lists[i].next.val < minNode.val)
        //        {
        //            minNode = lists[i].next;
        //            minCol = i;
        //        }
        //        //最后一个节点时，串联最小节点到主串，然后 把取出最小节点的行后移
        //        if (i == lists.Length - 1)
        //        {
        //            if (minCol == -1)
        //                continue;
        //            else
        //            {
        //                //串联到主串
        //                temp.next = minNode;
        //                temp = temp.next;

        //                //行后移
        //                lists[minCol].next = lists[minCol].next.next;

        //                //继续重头开始循环(因为循环结束之后 i 再 ++，所以这里要设置成 -1)
        //                i = -1;

        //                //最小节点 和 最小节点行数 重置
        //                minNode = new ListNode(int.MaxValue);
        //                minCol = -1;
        //            }
        //        }
        //    }
        //    return sentinel.next;
        //}
    }
}
