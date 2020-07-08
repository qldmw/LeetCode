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
                var listNode = builder.BuildListNode(new int[] { 1, 0, 0 });
                //var listNode2 = builder.BuildListNode(new int[] { 5, 6});
                //listNode2.next.next = listNode.next.next.next.next;
                solution.DeleteNode(listNode);
                //ConsoleX.WriteLine(res);
            }
        }

        public class Solution
        {
            public void DeleteNode(ListNode node)
            {

            }
        }
    }
}