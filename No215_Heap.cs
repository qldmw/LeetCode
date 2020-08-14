using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode_215
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
    //        //int?[] data = new int?[] { 6, 2, 8, 0, 4, 7, 9, null, null, 3, 5 };
    //        //int?[] data = new int?[] { 1, null, 2, 3 };
    //        //int?[] data = new int?[] { 1, 2, 2, 3, 3, null, null, 4, 4 };
    //        //int?[] data = new int?[] { 1, 2, null, 3 };
    //        //int?[] data = new int?[] { 1, 2, 2, 3, 3, 3, 3, 4, 4, 4, 4, 4, 4, null, null, 5, 5 };
    //        //var tree = new DataStructureBuilder().BuildTree(data);
    //        var res = solution.FindKthLargest(new int[] { 5, 2, 4, 1, 3, 6, 0 }, 4);
    //        ConsoleX.WriteLine(res);
    //    }
    //}

    public class Solution
    {
        /// <summary>
        /// 快排三数取中法
        /// 时间复杂度：O(n),证明过程可以参考「《算法导论》9.2：期望为线性的选择算法」。
        /// 空间复杂度：O(logn),递归使用栈空间的空间代价的期望为 O(\log n)O(logn)。
        /// 三数取中快排 https://www.cnblogs.com/chengxiao/p/6262208.html
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int FindKthLargest(int[] nums, int k)
        {
            return QuickSelect(nums, 0, nums.Length - 1, k);
        }

        private int QuickSelect(int[] nums, int left, int right, int k)
        {
            int pivot = Partition(nums, left, right);
            if (pivot == nums.Length - k)
                return nums[pivot];
            else if (pivot < nums.Length - k)
                return QuickSelect(nums, pivot + 1, right, k);
            else
                return QuickSelect(nums, left, pivot - 1, k);
        }

        private int Partition(int[] nums, int left, int right)
        {
            //防止越界
            if (left >= right)
                return left;

            MedianOfThree(nums, left, right);
            //枢纽
            int pivot = left + 1;
            //左右指针，用于交换（使用了三数取中法，右指针放在右边第二个了）
            int l = left, r = pivot;
            while (l < r)
            {
                //从左往右找大于枢纽值的数
                while (l < r && nums[l] <= nums[pivot])
                    l++;
                //从右往左找小于枢纽值的数
                while (l < r && nums[r] >= nums[pivot])
                    r--;
                if (l < r)
                    Swap(nums, l, r);
            }
            //枢纽归位
            Swap(nums, l, pivot);
            //返回枢纽位置
            return l;
        }

        //三数取中，交换位置
        private void MedianOfThree(int[] nums, int left, int right)
        {
            int mid = (left + right) / 2;
            if (nums[left] > nums[mid])
                Swap(nums, left, mid);
            if (nums[left] > nums[right])
                Swap(nums, left, right);
            if (nums[mid] > nums[right])
                Swap(nums, mid, right);
            //把枢纽放到右边第二位
            Swap(nums, mid, right - 1);
        }

        private void Swap(int[] nums, int i, int j)
        {
            int temp = nums[i];
            nums[i] = nums[j];
            nums[j] = temp;
        }

        /// <summary>
        /// 小根堆获取第K大的元素
        /// 时间复杂度：O(nlogn)，建堆的时间代价是 O(n)，删除的总代价是 O(klogn)，因为 k < n，故渐进时间复杂为 O(n + k log n) = O(n log n)
        /// 空间复杂度：O(logn)，即递归使用栈空间的空间代价。
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        //public int FindKthLargest(int[] nums, int k)
        //{
        //    var minHeap = new MinHeap(k);
        //    for (int i = 0; i < nums.Length; i++)
        //    {
        //        if (i < k)
        //        {
        //            minHeap.Add(nums[i]);
        //            continue;
        //        }
        //        if (nums[i] > minHeap.Peek())
        //        {
        //            minHeap.Pop();
        //            minHeap.Add(nums[i]);
        //        }
        //    }
        //    return minHeap.Peek();
        //}

        //public class MinHeap
        //{
        //    private readonly int[] _elements;
        //    private int _size;

        //    public MinHeap(int size)
        //    {
        //        _elements = new int[size];
        //    }

        //    private int GetLeftChildIndex(int elementIndex) => 2 * elementIndex + 1;
        //    private int GetRightChildIndex(int elementIndex) => 2 * elementIndex + 2;
        //    private int GetParentIndex(int elementIndex) => (elementIndex - 1) / 2;

        //    private bool HasLeftChild(int elementIndex) => GetLeftChildIndex(elementIndex) < _size;
        //    private bool HasRightChild(int elementIndex) => GetRightChildIndex(elementIndex) < _size;
        //    private bool IsRoot(int elementIndex) => elementIndex == 0;

        //    private int GetLeftChild(int elementIndex) => _elements[GetLeftChildIndex(elementIndex)];
        //    private int GetRightChild(int elementIndex) => _elements[GetRightChildIndex(elementIndex)];
        //    private int GetParent(int elementIndex) => _elements[GetParentIndex(elementIndex)];

        //    private void Swap(int firstIndex, int secondIndex)
        //    {
        //        var temp = _elements[firstIndex];
        //        _elements[firstIndex] = _elements[secondIndex];
        //        _elements[secondIndex] = temp;
        //    }

        //    public bool IsEmpty()
        //    {
        //        return _size == 0;
        //    }

        //    public int Peek()
        //    {
        //        if (_size == 0)
        //            throw new IndexOutOfRangeException();

        //        return _elements[0];
        //    }

        //    public int Pop()
        //    {
        //        if (_size == 0)
        //            throw new IndexOutOfRangeException();

        //        var result = _elements[0];
        //        _elements[0] = _elements[_size - 1];
        //        _size--;

        //        ReCalculateDown();

        //        return result;
        //    }

        //    public void Add(int element)
        //    {
        //        if (_size == _elements.Length)
        //            throw new IndexOutOfRangeException();

        //        _elements[_size] = element;
        //        _size++;

        //        ReCalculateUp();
        //    }

        //    private void ReCalculateDown()
        //    {
        //        int index = 0;
        //        while (HasLeftChild(index))
        //        {
        //            var smallerIndex = GetLeftChildIndex(index);
        //            if (HasRightChild(index) && GetRightChild(index) < GetLeftChild(index))
        //            {
        //                smallerIndex = GetRightChildIndex(index);
        //            }

        //            if (_elements[smallerIndex] >= _elements[index])
        //            {
        //                break;
        //            }

        //            Swap(smallerIndex, index);
        //            index = smallerIndex;
        //        }
        //    }

        //    private void ReCalculateUp()
        //    {
        //        var index = _size - 1;
        //        while (!IsRoot(index) && _elements[index] < GetParent(index))
        //        {
        //            var parentIndex = GetParentIndex(index);
        //            Swap(parentIndex, index);
        //            index = parentIndex;
        //        }
        //    }
        //}
    }

    public static class TraditionalQuickSortSample
    {
        /// <summary>
        /// 传统快排
        /// 传统Partition的slow指针和我第一思路有点冲突，而且其实做法也不如夹逼指针来的好，所以还是尽量使用夹逼Partition
        /// </summary>
        /// <param name="arr"></param>
        public static void QuickSort(this int[] arr)
        {
            Sort(arr, 0, arr.Length - 1);
        }

        private static void Sort(int[] arr, int left, int right)
        {
            if (left >= right)
                return;
            int mid = Partition(arr, left, right);
            Sort(arr, left, mid - 1);
            Sort(arr, mid + 1, right);
        }

        /// <summary>
        /// 这里使用快慢指针的方法，试试传统的做法（前后夹逼的做法更优一些）
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        private static int Partition(int[] arr, int left, int right)
        {
            int pivot = arr[right];
            int slow = left;
            for (int fast = left; fast < right; fast++)
            {
                if (arr[fast] < pivot)
                {
                    Swap(arr, fast, slow);
                    slow++;
                }
            }
            Swap(arr, slow, right);
            return slow;
        }

        private static void Swap(int[] arr, int i, int j)
        {
            //针对快慢指针常出现原地换位的优化
            if (i == j)
                return;
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
    }
}
