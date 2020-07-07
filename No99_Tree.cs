using LeetCode.ExtensionFunction;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode_99
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
    //        //int?[] data = new int?[] { 6, 2, 8, 0, 4, 7, 9, null, null, 3, 5 };
    //        //int?[] data = new int?[] { -2147483648, null, 2147483647 };
    //        int?[] data = new int?[] { 1, 3, null, null, 2 };
    //        var tree = builder.BuildTree(data);
    //        //var listNode = builder.BuildListNode(new int[] { 1, 2, 3, 4, 7, 8 });
    //        //var listNode2 = builder.BuildListNode(new int[] { 5, 6});
    //        //listNode2.next.next = listNode.next.next.next.next;
    //        solution.RecoverTree(tree);
    //        //ConsoleX.WriteLine(res);
    //    }
    //}

    public class Solution
    {
        /// 题解里还有一个空间复杂度为 O(1) 的 morris 解法，就是那个变换树结构的算法

        /// <summary>
        /// 中序遍历找到两个需要交换的点
        /// 时间复杂度：O(n)
        /// 空间复杂度：最优O(log n),最差O(n)
        /// 若要找到交换的节点，就记录中序遍历中的最后一个节点 pred（即当前节点的前置节点），并与当前节点的值进行比较。如果当前节点的值小于前置节点 pred 的值，
        /// 说明该节点是交换节点之一。交换的节点只有两个，因此在确定了第二个交换节点以后，可以终止遍历。
        /// </summary>
        /// <param name="root"></param>
        public void RecoverTree(TreeNode root)
        {
            findTwoSwapped(root);
            swap(x, y);
        }

        TreeNode x = null, y = null, pred = null;

        public void swap(TreeNode a, TreeNode b)
        {
            int tmp = a.val;
            a.val = b.val;
            b.val = tmp;
        }

        public void findTwoSwapped(TreeNode root)
        {
            if (root == null) return;
            findTwoSwapped(root.left);
            if (pred != null && root.val < pred.val)
            {
                y = root;
                if (x == null) x = pred;
                else return;
            }
            pred = root;
            findTwoSwapped(root.right);
        }

        /// <summary>
        /// 中序遍历之后再对所有节点进行快排
        /// 时间复杂度：O(nlogn),中序遍历n,快排nlogn
        /// 空间复杂度：O(n),用了一个最长 n/2 的栈来中序遍历，用了一个 n 的数组来存中序遍历的节点集合
        /// 看漏了，题目中只有两个节点被错误地交换。。。我按若干个来做了（不过这是个通用解法，其实不差）
        /// </summary>
        /// <param name="root"></param>
        //public void RecoverTree(TreeNode root)
        //{
        //    //中序遍历之后的结点集合
        //    List<TreeNode> inorderRes = new List<TreeNode>();
        //    //中序遍历过程中需要用到的队列
        //    Stack<TreeNode> stack = new Stack<TreeNode>();
        //    TreeNode curNode = root;
        //    while (curNode != null || stack.Count > 0)
        //    {
        //        while (curNode != null)
        //        {
        //            stack.Push(curNode);
        //            curNode = curNode.left;
        //        }
        //        curNode = stack.Pop();
        //        inorderRes.Add(curNode);
        //        curNode = curNode.right;
        //    }
        //    QuickSort(inorderRes);
        //}

        //private void QuickSort(List<TreeNode> nodes)
        //{
        //    Sort(nodes, 0, nodes.Count - 1);
        //}

        //private void Sort(List<TreeNode> nodes, int left, int right)
        //{
        //    if (left >= right)
        //        return;
        //    int mid = Partition(nodes, left, right);
        //    Sort(nodes, left, mid - 1);
        //    Sort(nodes, mid + 1, right);
        //}

        //private int Partition(List<TreeNode> nodes, int left, int right)
        //{
        //    //防止越界
        //    if (left >= right)
        //        return left;

        //    MedianOfThree(nodes, left, right);
        //    //枢纽
        //    int pivot = right - 1;
        //    //左右指针，用于交换（使用了三数取中法，右指针放在右边第二个了）
        //    int l = left, r = pivot;
        //    while (l < r)
        //    {
        //        //从左往右找大于枢纽值的数
        //        while (l < r && nodes[l].val <= nodes[pivot].val)
        //            l++;
        //        //从右往左找小于枢纽值的数
        //        while (l < r && nodes[r].val >= nodes[pivot].val)
        //            r--;
        //        if (l < r)
        //            Swap(nodes, l, r);
        //    }
        //    //枢纽归位
        //    Swap(nodes, l, pivot);
        //    //返回枢纽位置
        //    return l;
        //}

        ////三数取中，交换位置
        //private void MedianOfThree(List<TreeNode> nodes, int left, int right)
        //{
        //    int mid = (left + right) / 2;
        //    if (nodes[left].val > nodes[mid].val)
        //        Swap(nodes, left, mid);
        //    if (nodes[left].val > nodes[right].val)
        //        Swap(nodes, left, right);
        //    if (nodes[mid].val > nodes[right].val)
        //        Swap(nodes, mid, right);
        //    //把枢纽放到右边第二位
        //    Swap(nodes, mid, right - 1);
        //}

        //private void Swap(List<TreeNode> nodes, int i, int j)
        //{
        //    int temp = nodes[i].val;
        //    nodes[i].val = nodes[j].val;
        //    nodes[j].val = temp;
        //}
    }
}
