using LeetCode.ExtensionFunction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode_111
{
    //static void Main(string[] args)
    //{
    //    var solution = new Solution();
    //    while (true)
    //    {
    //        //int input = int.Parse(Console.ReadLine());
    //        //int input2 = int.Parse(Console.ReadLine());
    //        //int input3 = int.Parse(Console.ReadLine());
    //        //string input = Console.ReadLine();
    //        //string input2 = Console.ReadLine();
    //        //int[] intArr = input.Split(',').Select(s => int.Parse(s)).ToArray();
    //        //int input2 = int.Parse(Console.ReadLine());
    //        int?[] data = new int?[] { 1, 2, 3, 4, 5 };
    //        //int?[] data = new int?[] { 1, 2, 2, 3, 3, null, null, 4, 4 };
    //        //int?[] data = new int?[] { 1, 2, null, 3 };
    //        //int?[] data = new int?[] { 1, 2, 2, 3, 3, 3, 3, 4, 4, 4, 4, 4, 4, null, null, 5, 5 };
    //        var tree = new DataStructureBuilder().BuildTree(data);
    //        var res = solution.MinDepth(tree);
    //        ConsoleX.WriteLine(res);
    //    }
    //}

    public class Solution
    {
        /// <summary>
        /// 迭代，或者说的广度优先迭代，一旦找到叶子就返回，最高效的办法了。深度优先需要获得所有之后才能比较出最小，不是好办法
        /// 时间复杂度：O(n)，虽说都是O(n)，但是即使在最差的情况下：平衡树，也只会访问n/2个节点
        /// 空间复杂度：O(n)，和时间复杂度一样的情况
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int MinDepth(TreeNode root)
        {
            int cur_level = 0;
            Queue<TreeNode> queue = new Queue<TreeNode>();
            if (root != null)
                queue.Enqueue(root);
            while (queue.Count > 0)
            {
                cur_level++;
                foreach (var node in queue.ToList())
                {
                    root = queue.Dequeue();
                    if (root == null)
                        continue;
                    else if (root.left == null && root.right == null)
                        return cur_level;

                    if (root.left != null)
                        queue.Enqueue(root.left);
                    if (root.right != null)
                        queue.Enqueue(root.right);
                }
            }
            return cur_level;
        }
    }
}
