using LeetCode.ExtensionFunction;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode_102
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
    //        int?[] data = new int?[] { 10, 5, 15, null, null, 6, 20 };
    //        //int?[] data = new int?[] { 6, 2, 8, 0, 4, 7, 9, null, null, 3, 5 };
    //        //int?[] data = new int?[] { -2147483648, null, 2147483647 };
    //        var tree = builder.BuildTree(data);
    //        //var listNode = builder.BuildListNode(new int[] { 1, 2, 3, 4, 7, 8 });
    //        //var listNode2 = builder.BuildListNode(new int[] { 5, 6});
    //        //listNode2.next.next = listNode.next.next.next.next;
    //        var res = solution.LevelOrder(tree);
    //        ConsoleX.WriteLine(res);
    //    }
    //}

    /// <summary>
    /// Knowledge: C# 7.0，本地函数，可以在方法内申明一个函数，是私有的，不能带修饰符。具体可见本题中的深度优先解法。
    /// 还有一种等效的lambda写法，Func<int, int> sum = (number) => number + 2
    /// 具体介绍：https://docs.microsoft.com/zh-cn/dotnet/csharp/programming-guide/classes-and-structs/local-functions#local-functions-vs-lambda-expressions
    /// </summary>

    /// <summary>
    /// REVIEW
    /// 2020.08.05: 优化了广度优先方法，使用当前层节点计数的办法代替了再 new 一个 nextQueue数组。
    /// </summary>
    public class Solution
    {
        /// <summary>
        /// 深度优先解法
        /// 时间复杂度：O(n)
        /// 空间复杂度：O(n)
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<IList<int>> LevelOrder(TreeNode root)
        {
            IList<IList<int>> res = new List<IList<int>>();

            DFS(root, 0);

            void DFS(TreeNode node, int level)
            {
                if (node == null) return;
                if (res.Count == level)
                {
                    List<int> lst = new List<int>();
                    res.Add(lst);
                }

                res[level].Add(node.val);
                DFS(node.left, level + 1);
                DFS(node.right, level + 1);
            }

            return res;
        }

        /// <summary>
        /// 广度优先解法。一层一层地剥开，记录
        /// 时间复杂度：O(n)
        /// 空间复杂度：O(n)
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        //public IList<IList<int>> LevelOrder(TreeNode root)
        //{
        //    IList<IList<int>> res = new List<IList<int>>();
        //    IList<int> curRes = new List<int>();
        //    Queue<TreeNode> cur = new Queue<TreeNode>();

        //    if (root != null)
        //        cur.Enqueue(root);
        //    while (cur.Count > 0)
        //    {
        //        int currLevelNodesNum = cur.Count;
        //        for (int i = 0; i < currLevelNodesNum; i++)
        //        {
        //            var temp = cur.Dequeue();
        //            if (temp != null)
        //            {
        //                //加入到“当前行结果”
        //                curRes.Add(temp.val);
        //                //把左右子树加入到队列中
        //                if (temp.left != null)
        //                    cur.Enqueue(temp.left);
        //                if (temp.right != null)
        //                    cur.Enqueue(temp.right);
        //            }   
        //        }
        //        res.Add(curRes);
        //        //重新 new 一个内存空间给“当前行结果”
        //        curRes = new List<int>();
        //    }
        //    return res;
        //}
    }
}
