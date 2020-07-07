using LeetCode.ExtensionFunction;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode_108
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
    //        //var builder = new DataStructureBuilder();
    //        //int?[] data = new int?[] { 10, 5, 15, null, null, 6, 20 };
    //        //int?[] data = new int?[] { 6, 2, 8, 0, 4, 7, 9, null, null, 3, 5 };
    //        //int?[] data = new int?[] { -2147483648, null, 2147483647 };
    //        //int?[] data = new int?[] { 1, 3, null, null, 2 };
    //        //var tree = builder.BuildTree(data);
    //        //var listNode = builder.BuildListNode(new int[] { 1, 2, 3, 4, 7, 8 });
    //        //var listNode2 = builder.BuildListNode(new int[] { 5, 6});
    //        //listNode2.next.next = listNode.next.next.next.next;
    //        var res = solution.SortedArrayToBST(new int[] { -10, -3, 0, 5, 9 });
    //        ConsoleX.WriteLine(res);
    //    }
    //}

    public class Solution
    {
        public TreeNode SortedArrayToBST(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return null;

            return RecursivelyBuildTree(nums, 0, nums.Length - 1);
        }

        private TreeNode RecursivelyBuildTree(int[] nums, int left, int right)
        {
            //如果left指针大于right指针，则越界，直接null
            if (left > right)
                return null;
            //取中间节点作为当前的树节点
            int mid = (left + right) / 2;
            var res = new TreeNode(nums[mid]);
            //递归构建左子树
            res.left = RecursivelyBuildTree(nums, left, mid - 1);
            //递归构建右子树
            res.right = RecursivelyBuildTree(nums, mid + 1, right);
            //返回构建结果
            return res;
        }
    }
}
