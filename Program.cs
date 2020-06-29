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
                //int input3 = int.Parse(Console.ReadLine());
                //string input = Console.ReadLine();
                //string input2 = Console.ReadLine();
                //int[] intArr = input.Split(',').Select(s => int.Parse(s)).ToArray();
                //int input2 = int.Parse(Console.ReadLine());
                //int?[] data = new int?[] { 6, 2, 8, 0, 4, 7, 9, null, null, 3, 5 };
                //int?[] data = new int?[] { 1, null, 2, 3 };
                //int?[] data = new int?[] { 1, 2, 2, 3, 3, null, null, 4, 4 };
                //int?[] data = new int?[] { 1, 2, null, 3 };
                //int?[] data = new int?[] { 1, 2, 2, 3, 3, 3, 3, 4, 4, 4, 4, 4, 4, null, null, 5, 5 };
                //var tree = new DataStructureBuilder().BuildTree(data);
                var res = solution.FindKthLargest(new int[] { 3, 4, 5, 1, 2, 2 }, 3);
                ConsoleX.WriteLine(res);
            }
        }

        public class Solution
        {
            /// <summary>
            /// 小根堆获取第K大的元素
            /// 时间复杂度：O(nlogn)，建堆的时间代价是 O(n)，删除的总代价是 O(klogn)，因为 k < n，故渐进时间复杂为 O(n + k log n) = O(n log n)
            /// 空间复杂度：O(logn)，即递归使用栈空间的空间代价。
            /// </summary>
            /// <param name="nums"></param>
            /// <param name="k"></param>
            /// <returns></returns>
            public int FindKthLargest(int[] nums, int k)
            {
                var minHeap = new MinHeap(k);
                for (int i = 0; i < nums.Length; i++)
                {
                    if (i < k)
                    {
                        minHeap.Add(nums[i]);
                        continue;
                    }
                    if (nums[i] > minHeap.Peek())
                    {
                        minHeap.Pop();
                        minHeap.Add(nums[i]);
                    }
                }
                return minHeap.Peek();
            }

            public class MinHeap
            {
                private readonly int[] _elements;
                private int _size;

                public MinHeap(int size)
                {
                    _elements = new int[size];
                }

                private int GetLeftChildIndex(int elementIndex) => 2 * elementIndex + 1;
                private int GetRightChildIndex(int elementIndex) => 2 * elementIndex + 2;
                private int GetParentIndex(int elementIndex) => (elementIndex - 1) / 2;

                private bool HasLeftChild(int elementIndex) => GetLeftChildIndex(elementIndex) < _size;
                private bool HasRightChild(int elementIndex) => GetRightChildIndex(elementIndex) < _size;
                private bool IsRoot(int elementIndex) => elementIndex == 0;

                private int GetLeftChild(int elementIndex) => _elements[GetLeftChildIndex(elementIndex)];
                private int GetRightChild(int elementIndex) => _elements[GetRightChildIndex(elementIndex)];
                private int GetParent(int elementIndex) => _elements[GetParentIndex(elementIndex)];

                private void Swap(int firstIndex, int secondIndex)
                {
                    var temp = _elements[firstIndex];
                    _elements[firstIndex] = _elements[secondIndex];
                    _elements[secondIndex] = temp;
                }

                public bool IsEmpty()
                {
                    return _size == 0;
                }

                public int Peek()
                {
                    if (_size == 0)
                        throw new IndexOutOfRangeException();

                    return _elements[0];
                }

                public int Pop()
                {
                    if (_size == 0)
                        throw new IndexOutOfRangeException();

                    var result = _elements[0];
                    _elements[0] = _elements[_size - 1];
                    _size--;

                    ReCalculateDown();

                    return result;
                }

                public void Add(int element)
                {
                    if (_size == _elements.Length)
                        throw new IndexOutOfRangeException();

                    _elements[_size] = element;
                    _size++;

                    ReCalculateUp();
                }

                private void ReCalculateDown()
                {
                    int index = 0;
                    while (HasLeftChild(index))
                    {
                        var smallerIndex = GetLeftChildIndex(index);
                        if (HasRightChild(index) && GetRightChild(index) < GetLeftChild(index))
                        {
                            smallerIndex = GetRightChildIndex(index);
                        }

                        if (_elements[smallerIndex] >= _elements[index])
                        {
                            break;
                        }

                        Swap(smallerIndex, index);
                        index = smallerIndex;
                    }
                }

                private void ReCalculateUp()
                {
                    var index = _size - 1;
                    while (!IsRoot(index) && _elements[index] < GetParent(index))
                    {
                        var parentIndex = GetParentIndex(index);
                        Swap(parentIndex, index);
                        index = parentIndex;
                    }
                }
            }
        }
    }
}