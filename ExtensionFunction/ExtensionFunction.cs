using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace System.Extension
{    
    public static class ConsoleX
    {
        public static void WriteLine(bool[] arr)
        {
            string str = "[";
            for (int i = 0; i < arr.Length; i++)
            {
                str += $"{arr[i]},";
            }
            str = str.TrimEnd(',') + "]";
            Console.WriteLine(str);
        }

        public static void WriteLine(int[] arr)
        {
            string str = "[";
            for (int i = 0; i < arr.Length; i++)
            {
                str += $"{arr[i]},";
            }
            str = str.TrimEnd(',') + "]";
            Console.WriteLine(str);
        }

        public static void WriteLine(string[] arr)
        {
            string str = "[";
            for (int i = 0; i < arr.Length; i++)
            {
                str += $"{arr[i]},";
            }
            str = str.TrimEnd(',') + "]";
            Console.WriteLine(str);
        }
    }
}
