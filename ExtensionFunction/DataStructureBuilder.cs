using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.ExtensionFunction
{
    public class DataStructureBuilder
    {
        /// <summary>
        /// 构建树
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public TreeNode BuildTree<T>(T data) where T : IList<int?>
        {
            if (data == null || data.Count == 0)
                return null;

            //构建一个根节点，之后添加的添加的节点都以传引用地址的方式接在根老爷的腿上
            TreeNode root = new TreeNode(data[0] ?? 0);
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            for (int i = 1; i < data.Count; i++)
            {
                var temp = queue.Dequeue();
                temp.left = data[i] != null ? new TreeNode(data[i] ?? 0) : null;
                //为空就不加入到队列中了，否则会导致下一次连接空引用
                if (temp.left != null)
                    queue.Enqueue(temp.left);
                if (i + 1 < data.Count)
                {
                    temp.right = data[i + 1] != null ? new TreeNode(data[i + 1] ?? 0) : null;
                    i++;
                    //为空就不加入到队列中了，否则会导致下一次连接空引用
                    if (temp.right != null)
                        queue.Enqueue(temp.right);
                }
            }
            return root;
        }

        /// <summary>
        /// 构建链表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        public ListNode BuildListNode<T>(T data) where T : IList<int>
        {
            if (data == null || data.Count == 0)
                return null;

            ListNode node = new ListNode(data[0]);
            ListNode temp = node;
            for (int i = 1; i < data.Count; i++)
            {
                temp.next = new ListNode(data[i]);
                temp = temp.next;
            }
            return node;
        }
    }

    /// <summary>
    /// 树结构
    /// </summary>
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }

    /// <summary>
    /// 链表结构
    /// </summary>
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }
}
