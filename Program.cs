using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Extension;
using LeetCode.ExtensionFunction;
using System.Threading.Tasks;
using System.Threading;

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
                //var builder = new DataStructureBuilder();
                //int?[] data = new int?[] { 1, 2, 3, 4, 5, null, 6, null, null, 7, 8 };
                //var tree = builder.BuildTree(data);
                //var listNode = builder.BuildListNode(new int[] { 1, 4, 5 });
                //int[][] arr = new int[3][] { new int[] { 1, 3, 1 }, new int[] { 1, 5, 1 }, new int[] { 4, 2, 1 } };
                //string input = "abcbefga";
                //string input2 = "dbefga";
                //int[] nums2 = new int[] { 2, 1, 1, 5, 11, 5, 1, 7, 5, 6, 4, 3 };
                //int[] nums3 = new int[] { 10, 15, 20 };
                //int[] nums1 = new int[] { 10, 1, 2, 7, 6, 1, 5 };
                //IList<IList<int>> data = new List<IList<int>>()
                //{
                //    new List<int>() { 1, 3 },
                //    new List<int>() { 3, 0, 1 },
                //    new List<int>() { 2 },
                //    new List<int>() { 0 }

                //    //new List<int>() { 1 },
                //    //new List<int>() { 2 },
                //    //new List<int>() { 3 },
                //    //new List<int>() {  }
                //};
                //var res = solution.MinimumOperations(input);
                //ConsoleX.WriteLine(res);
            }
        }

        /// <summary>
        /// ʹ�� SpinWait �������Ϊֻ�Ǵ�ӡ���֣�����������ʵ��һ���˷ѡ�����������Ӧ�ó����������Ͼ���Ϊ��ѧϰ��
        /// </summary>
        public class ZeroEvenOdd
        {
            private int n;
            //0 ��ʾ�Ѿ����� zero �Ĵ�ӡ��
            //1 ��ʾ�Ѿ����� odd �Ĵ�ӡ��
            //2 ��ʾ�Ѿ������� odd ֮��� zero �Ĵ�ӡ��
            //3 ��ʾ�Ѿ����� even �Ĵ�ӡ��
            //��ʼ��ʱ���������㿪ʼ�������� 3��
            private int _signal = 3;
            private int _count = 0;
            private SpinWait _spinWait = new SpinWait();

            public ZeroEvenOdd(int n)
            {
                this.n = n;
            }

            // printNumber(x) outputs "x", where x is an integer.
            public void Zero(Action<int> printNumber)
            {
                while (_count < n)
                {
                    while (!(_signal == 1 || _signal == 3))
                    {
                        _spinWait.SpinOnce();
                        if (_count >= n) return;
                    }
                    printNumber(0);
                    _signal = (_signal + 1) % 4;
                }
            }

            public void Even(Action<int> printNumber)
            {
                while (_count < n)
                {
                    while (_signal != 2)
                    {
                        _spinWait.SpinOnce();
                        if (_count >= n) return;
                    }
                    printNumber(++_count);
                    _signal = (_signal + 1) % 4;
                }
            }

            public void Odd(Action<int> printNumber)
            {
                while (_count < n)
                {
                    if (_count >= n) return;
                    while (_signal != 0)
                    {
                        _spinWait.SpinOnce();
                        if (_count >= n) return;
                    }
                    printNumber(++_count);
                    _signal = (_signal + 1) % 4;
                }
            }
        }
    }
}