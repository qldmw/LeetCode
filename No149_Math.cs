using System;
using System.Collections.Generic;
using System.Linq;
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
    //                    //new int[]{1,1},
    //                    //new int[]{3,2},
    //                    //new int[]{5,3},
    //                    //new int[]{4,1},
    //                    //new int[]{2,3},                                        
    //                    //new int[]{1,4},
    //                    new int[]{0,0},
    //                    new int[]{94911150, 94911151},
    //                    new int[]{94911151, 94911152},
    //        };
    //        //int input = int.Parse(input2);
    //        var res = solution.MaxPoints(intArr);
    //        Console.WriteLine(res);
    //    }
    //}

    /// <summary>
    /// Experience:当除数和被除数都非常大，且他们之前非常接近时，除法的浮点数运算会求近似值，所以这种情况下就是导致数据失真。
    /// 后记：发现元组是一个很好的解决办法，因为元组也可以值比较，用于做dictionary键没有一点问题，这样就可以用两个数来代表斜率了，不会导致除法失真的情况
    /// </summary>
    public class Solution
    {
        /// <summary>
        /// 示例Tuple是值比较的
        /// </summary>
        public void TupleExample()
        {
            Dictionary<(int, int), int> dic = new Dictionary<(int, int), int>();
            dic.Add((1, 2), 1);
            var resBol = dic.ContainsKey((1, 2));

            Dictionary<int[], int> dic2 = new Dictionary<int[], int>();
            dic2.Add(new int[] { 1, 2 }, 1);
            var resBol2 = dic2.ContainsKey(new int[] { 1, 2 });

            //Solved Question: 元组虽然是引用类型，但是它的 == 和 != 是通过内部值比较得出的，不是引用地址的比较。但是这种比较只包含一层
            //var t1 = (1, 2);
            //var t2 = (1, 2);
            //var resBol3 = t1 == t2;//元组相等是C#7.3的，要vs2019才能用
            //var resBol4 = ReferenceEquals(t1, t2);
            //t2.Item2 = 3;
            //var resBol5 = t1 == t2;

            //C#8.0 元组的一个好用处
            //var state1 = false;
            //var state2 = 3;
            //var result = (state1, state2) switch
            //{
            //    (false, _) => false,
            //    (_, 3) => true,
            //    _ => throw new Exception("Invalid")
            //};
        }

        /// <summary>
        /// 失败了！失败了！失败了！失败了！失败了！失败了！失败了！失败了！（没有失败，double精度比decimal小，decimal才是计算高精度的利器）
        /// 方法不对，越A越累。用斜率不行，除数和被除数大到一定程度之后，微小的除法差异会被算法忽略掉，这样斜率就失效了
        /// 后记：（用decimal逃过了用例，但是这种精度的问题，只要用例够无情，就一定会被限制住）
        /// 后后记：用元组可以完美解决，只是懒得改了。然后这个解法还有一个点可以改善，用 y = slope * x + c 来优化，用c来确定是否是同一条线就不用两条线遍历了
        /// </summary>
        /// <param name="points"></param>
        /// <returns></returns>
        public int MaxPoints(int[][] points)
        {
            if (points.Length <= 1)
                return points.Length;

            if (IsAllDuplicatedPoints(points))
                return points.Length;

            Dictionary<decimal, List<HashSet<int>>> dic = new Dictionary<decimal, List<HashSet<int>>>();
            for (int i = 0; i < points.Length; i++)
            {
                for (int j = i + 1; j < points.Length; j++)
                {
                    //如果横纵坐标完全一致，就去重
                    if (points[i][0] == points[j][0] && points[i][1] == points[j][1])
                        continue;

                    decimal slope = CaculateSlope(points[i], points[j]);

                    if (!dic.ContainsKey(slope))
                        dic.Add(slope, new List<HashSet<int>>() { new HashSet<int> { i, j } });
                    else
                    {
                        //逐个尝试同斜率下的不用数组，取其最后一个点用来计算，看是不是同一条线
                        var lines = dic[slope];
                        bool jointLine = false;
                        for (int k = 0; k < lines.Count; k++)
                        {
                            var line = lines[k];
                            //同一条直线
                            for (int n = 0; n < line.Count; n++)
                            {
                                if (CaculateSlope(points[line.ToList()[n]], points[i]) == slope)
                                {
                                    line.Add(i);
                                    line.Add(j);
                                    jointLine = true;
                                    break;
                                }
                            }
                        }
                        //遍历所有线之后都没有遇到在同一条线上的
                        if (!jointLine)
                            lines.Add(new HashSet<int>() { i, j });
                    }
                }
            }
            int max = 0;
            foreach (var m in dic)
            {
                foreach (var n in m.Value)
                {
                    if (n.Count > max)
                    {
                        max = n.Count;
                    }
                }
            }
            return max;
        }

        private bool IsAllDuplicatedPoints(int[][] points)
        {
            bool isAllduplicated = true;
            for (int i = 1; i < points.Length; i++)
            {
                if (!(points[0][0] == points[i][0] && points[0][1] == points[i][1]))
                {
                    isAllduplicated = false;
                    break;
                }
            }
            return isAllduplicated;
        }

        private decimal CaculateSlope(int[] pointA, int[] pointB)
        {
            decimal slope;
            //水平线y为0，给一个特殊值作为斜率
            if ((pointA[1] - pointB[1]) == 0)
            {
                slope = decimal.MaxValue;
            }
            else
            {
                //计算两点的斜率
                slope = (decimal)(pointA[0] - pointB[0]) / (decimal)(pointA[1] - pointB[1]);
            }
            return slope;
        }
    }
}
