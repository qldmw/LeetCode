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
        /// ʹ�� SpinWait �� VolatileWrite��VolatileRead�����
        /// ��ʵ������Բ��� Volatile �ķ�����ֱ��ʹ�� int �Ϳ��ԡ�MSDN�� Volatile �Ľ��ܣ��ڶദ����ϵͳ�ϣ� VolatileWrite ȷ��д���ڴ�λ�õ�ֵ
        /// ���������д��������ɼ��� https://docs.microsoft.com/zh-cn/dotnet/api/system.threading.thread.volatilewrite?view=netcore-3.1
        /// </summary>
        public class Foo
        {
            /// <summary>
            /// Unsolved Question:ʲôʱ��Ӧ��ʹ�� Volatile ����
            /// </summary>
            private SpinWait _spinWait = new SpinWait();
            private int _continueCondition = 1;

            public Foo()
            {

            }
            public void First(Action printFirst)
            {
                printFirst();
                Thread.VolatileWrite(ref _continueCondition, 2);//дդ��
            }

            public void Second(Action printSecond)
            {

                while (Thread.VolatileRead(ref _continueCondition) != 2)
                {
                    _spinWait.SpinOnce();
                }
                printSecond();
                Thread.VolatileWrite(ref _continueCondition, 3);//дդ��
            }

            public void Third(Action printThird)
            {
                while (Thread.VolatileRead(ref _continueCondition) != 3)
                {
                    _spinWait.SpinOnce();
                }
                printThird();
                Thread.VolatileWrite(ref _continueCondition, 1);//дդ��
            }
        }

        ///// <summary>
        ///// AutoResetEventʵ���߳�ͨ��
        ///// </summary>
        //public class Foo
        //{
        //    private AutoResetEvent _second = new AutoResetEvent(false);
        //    private AutoResetEvent _three = new AutoResetEvent(false);

        //    public Foo()
        //    {

        //    }

        //    public void First(Action printFirst)
        //    {
        //        // printFirst() outputs "first". Do not change or remove this line.
        //        printFirst();
        //        _second.Set();
        //    }

        //    public void Second(Action printSecond)
        //    {
        //        _second.WaitOne();
        //        // printSecond() outputs "second". Do not change or remove this line.
        //        printSecond();
        //        _three.Set();
        //    }

        //    public void Third(Action printThird)
        //    {
        //        _three.WaitOne();
        //        // printThird() outputs "third". Do not change or remove this line.
        //        printThird();
        //    }
        //}

        ///// <summary>
        ///// ���Ψһ�������߳�����
        ///// </summary>
        //public class Foo
        //{
        //    public Foo()
        //    {

        //    }

        //    //Unsolved Question:�������static�Ͳ��ܱ�֤˳������ˣ���֪����ô���£�Ӧ����һ���İ�����ȷ���ǲ���OJ���л��������⡣
        //    //private static int _signal = 0;
        //    private int _signal = 0;
        //    public void First(Action printFirst)
        //    {
        //        // printFirst() outputs "first". Do not change or remove this line.
        //        printFirst();
        //        _signal = 1;
        //    }

        //    public void Second(Action printSecond)
        //    {
        //        while (_signal != 1)
        //            Thread.Sleep(1);
        //        // printSecond() outputs "second". Do not change or remove this line.
        //        printSecond();
        //        _signal = 2;
        //    }

        //    public void Third(Action printThird)
        //    {
        //        while (_signal != 2)
        //            Thread.Sleep(1);
        //        // printThird() outputs "third". Do not change or remove this line.
        //        printThird();
        //    }
        //}
    }
}