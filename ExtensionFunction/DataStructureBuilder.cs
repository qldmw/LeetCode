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
            if (data == null)
                return null;
            
            //构建一个根节点，之后添加的添加的节点都以传引用地址的方式接在根老爷的腿上
            TreeNode root = new TreeNode(data[0] ?? 0);
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            for (int i = 1; i < data.Count; i++)
            {
                var temp = queue.Dequeue();
                temp.left = data[i] != null ? new TreeNode(data[i] ?? 0) : null;
                queue.Enqueue(temp.left);
                if (i + 1 < data.Count)
                {
                    temp.right = data[i + 1] != null ? new TreeNode(data[i + 1] ?? 0) : null;
                    i++;
                    queue.Enqueue(temp.right);
                }
            }
            return root;
        }
    }

    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }
}
