using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode_861
{
    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        Console.WriteLine("Hello World!");

    //        int[][] A = new int[3][]{
    //        new int[4]{ 0, 0, 1, 1 },
    //        new int[4]{ 1, 0, 1, 0 },
    //        new int[4]{ 1, 1, 0, 0 }
    //    };
    //        Console.WriteLine("max score is:" + new Solution().MatrixScore(A));
    //        Console.ReadKey();
    //    }
    //}

    public class Solution
    {
        public int MatrixScore(int[][] A)
        {
            while (true)
            {
                if (Algorithm(A, out int[][] cbm))
                    A = cbm;
                else
                    break;
            }
            return CalculateCurrentValue(A);
        }

        //int[][] 是引用传递
        public bool Algorithm(int[][] A, out int[][] cbm)
        {
            cbm = DeepClone(A);
            A = DeepClone(A);
            var recover = DeepClone(A);
            int CurrentSum = CalculateCurrentValue(A);
            for (int i = 0; i < A.Length; i++)
            {
                FlipX(A, i);
                if (CalculateCurrentValue(A) > CurrentSum)
                {
                    cbm = A;
                    return true;
                }
                else
                    A = DeepClone(recover);
            }
            for (int i = 0; i < A[0].Length; i++)
            {
                FlipY(A, i);
                if (CalculateCurrentValue(A) > CurrentSum)
                {
                    cbm = A;
                    return true;
                }
                else
                    A = DeepClone(recover);
            }
            return false;
        }

        public int[][] DeepClone(int[][] A)
        {
            int[][] recover = new int[A.Length][];
            for (int i = 0; i < A.Length; i++)
            {
                recover[i] = new int[A[i].Length];
                for (int j = 0; j < A[i].Length; j++)
                {
                    recover[i][j] = A[i][j];
                }
            }
            return recover;
        }

        public int[][] FlipY(int[][] y, int index)
        {
            for (int i = 0; i < y.Length; i++)
            {
                y[i][index] = 1 - y[i][index];
            }
            return y;
        }

        public int[][] FlipX(int[][] x, int index)
        {
            for (int i = 0; i < x[index].Length; i++)
            {
                x[index][i] = 1 - x[index][i];
            }
            return x;
        }

        public int CalculateCurrentValue(int[][] matrix)
        {
            int sum = 0;
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (matrix[i][j] != 0)
                        sum += (int)Math.Pow(2, matrix[i].Length - j - 1);
                }
            }
            return sum;
        }
    }
}
