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
                string input = Console.ReadLine();
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
                var res = solution.MinimumOperations(input);
                ConsoleX.WriteLine(res);
            }
        }

        public class Solution
        {
            /// <summary>
            /// ��̬�滮�Ż���ѹ����״̬�ռ䡣��ϰ��ʱ����û�����û���Ż��ռ�İ汾���Ǹ��汾˼·��������⣬������
            /// ʱ�临�Ӷȣ�O(n)
            /// �ռ临�Ӷȣ�O(1)��ѹ��״̬����һ��ֻ��Ҫ 3 �����ȵ�����
            /// </summary>
            /// <param name="leaves"></param>
            /// <returns></returns>
            public int MinimumOperations(string leaves)
            {
                //ѹ����άdp����Ϊֻ��Ҫʹ��ǰһ��״̬
                int[] dp = new int[3];
                for (int i = 0; i < leaves.Length; i++)
                {
                    int pre0 = dp[0];
                    int pre1 = dp[1];
                    int pre2 = dp[2];

                    //ά����һά�����Ϊ y����Ҫ��һ������� y ��Ϊ r
                    if (i == 0)
                        dp[0] = leaves[0] == 'r' ? 0 : 1;
                    else
                        dp[0] = pre0 + (leaves[i] == 'r' ?  0 : 1);

                    //ά���ڶ�ά��Ҫ�ӵڶ����ſ�ʼ
                    if (i > 0)
                        if (i == 1)
                            dp[1] = pre0 + (leaves[i] == 'y' ? 0 : 1);
                        else
                            dp[1] = Math.Min(pre1, pre0) + (leaves[i] == 'y' ? 0 : 1);
                            
                    //ά������ά��Ҫ�ӵ������ſ�ʼ
                    if (i > 1)
                        if (i == 2)
                            dp[2] = pre1 + (leaves[i] == 'r' ? 0 : 1);
                        else
                            dp[2] = Math.Min(pre2, pre1) + (leaves[i] == 'r' ? 0 : 1);
                }
                return dp[2];
            }

            ///// <summary>
            ///// ��ά��̬�滮��Ŀǰ��һά�򵥵Ķ�̬�滮�����ԣ�һ���ӵ�Ϳ�ʼ�������� o(�i�n�i)o
            ///// ʱ�临�Ӷȣ�O(n)
            ///// �ռ临�Ӷȣ�O(n),������˵�� 3n
            ///// </summary>
            ///// <param name="leaves"></param>
            ///// <returns></returns>
            //public int MinimumOperations(string leaves)
            //{
            //    //��άdp��dp[0,]��ʾȫ��Ϊ r ��״̬��dp[1,]��ʾȫ��Ϊ ry ��״̬��dp[2,]��ʾȫ��Ϊ ryr ��״̬��
            //    int[,] dp = new int[3, leaves.Length];
            //    //��Զ���ά�ı߽磬��ǰ�������
            //    dp[1, 0] = dp[2, 0] = dp[2, 1] = int.MaxValue;
            //    for (int i = 0; i < leaves.Length; i++)
            //    {
            //        //ά����һά�����Ϊ y����Ҫ��һ������� y ��Ϊ r
            //        if (i == 0)
            //            dp[0, i] = leaves[i] == 'r' ? 0 : 1;
            //        else
            //            dp[0, i] = leaves[i] == 'r' ? dp[0, i - 1] : dp[0, i - 1] + 1;

            //        //ά���ڶ�ά��Ҫ�ӵڶ����ſ�ʼ
            //        if (i > 0)
            //            dp[1, i] = Math.Min(dp[1, i - 1], dp[0, i - 1]) + (leaves[i] == 'y' ? 0 : 1);

            //        //ά������ά��Ҫ�ӵ������ſ�ʼ
            //        if (i > 1)
            //            dp[2, i] = Math.Min(dp[2, i - 1], dp[1, i - 1]) + (leaves[i] == 'r' ? 0 : 1);

            //    }
            //    return dp[2, leaves.Length - 1];
            //}
        }
    }
}