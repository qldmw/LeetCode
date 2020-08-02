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
                int?[] data = new int?[] { 1, 2, 5, 3, 4, null, 6 };
                var tree = builder.BuildTree(data);
                //var listNode = builder.BuildListNode(new int[] { 1, 4, 5 });
                //int[][] arr = new int[3][] { new int[] { 1, 3, 1 }, new int[] { 1, 5, 1 }, new int[] { 4, 2, 1 } };
                //int[] nums1 = new int[] { 2, 1, -2, 3 };
                //int[] nums2 = new int[] { 10, 15, 20 };
                //string input = "adceb";
                //string input2 = "*a*b";
                //var res = solution.IsMatch(input, input2);
                //ConsoleX.WriteLine(res);
                solution.Flatten(tree);
            }
        }

        public class Solution
        {
            /// <summary>
            /// 运用了迭代中序遍历的代码，先把节点都入队，然后串联成目标树就可以了
            /// 时间复杂度：O(n)
            /// 空间复杂度：O(n)
            /// </summary>
            /// <param name="root"></param>
            public void Flatten(TreeNode root)
            {
                Queue<TreeNode> queue = new Queue<TreeNode>();
                Stack<TreeNode> stack = new Stack<TreeNode>();
                TreeNode curr = root;
                while (curr != null || stack.Count > 0)
                {
                    while (curr != null)
                    {
                        queue.Enqueue(curr);
                        stack.Push(curr);
                        curr = curr.left;
                    }
                    curr = stack.Pop();
                    curr = curr.right;
                }
                if (queue.Count != 0)
                    root = queue.Dequeue();
                while (queue.Count != 0)
                {
                    //这里有一点要注意的，一定要用root.right去串联，如果用root去串联的话，其实只是变量指向的空间而已，并没有串起来
                    root.right = queue.Dequeue();
                    root.left = null;
                    root = root.right;
                }
            }
        }
        //public class Solution
        //{
        //    public bool IsMatch(string s, string p)
        //    {

        //    }
        //}
    }
}