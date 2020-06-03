using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode_149
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
    //        int[][] intArr = new int[][]
    //        {
    //                new int[]{1,1},
    //                new int[]{3,2},
    //                new int[]{5,3},
    //                new int[]{4,1},
    //                new int[]{2,3},
    //                new int[]{1,4},
    //        };
    //        //int input = int.Parse(input2);
    //        var res = solution.MaxPoints(intArr);
    //        Console.WriteLine(res);
    //    }
    //}

    public class Solution
    {
        public int MaxPoints(int[][] points)
        {
            //Hashtable table = new Hashtable();
            Dictionary<float, HashSet<int[]>> dic = new Dictionary<float, HashSet<int[]>>();
            for (int i = 0; i < points.Length; i++)
            {
                for (int j = i + 1; j < points.Length; j++)
                {
                    float slope;
                    //水平线y为0，给一个特殊值作为斜率
                    if ((points[i][1] - points[j][1]) == 0)
                    {
                        slope = float.MinValue;
                    }
                    else
                    {
                        //计算两点的斜率
                        slope = (float)(points[i][0] - points[j][0]) / (float)(points[i][1] - points[j][1]);
                    }

                    if (!dic.ContainsKey(slope))
                        dic.Add(slope, new HashSet<int[]> { points[i], points[j] });
                    else
                    {
                        dic[slope].Add(points[i]);
                        dic[slope].Add(points[j]);
                    }
                }
            }
            int max = 0;
            foreach (var m in dic)
            {
                if (((HashSet<int[]>)m.Value).Count > max)
                {
                    max = ((HashSet<int[]>)m.Value).Count;
                }
            }
            return max;
        }
    }
}
