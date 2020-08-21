using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode_15
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
    //        //////string input2 = Console.ReadLine();
    //        //int[] intArr = input.Split(',').Select(s => int.Parse(s)).ToArray();
    //        //int input2 = int.Parse(Console.ReadLine());
    //        //int[] intArr = new int[] { 0, 0, 0 };
    //        //int[] intArr = new int[] { -1, 0, 1, 2, -1, -4 };
    //        //int[] intArr = new int[] { -2, -1, -1, -1, 0, 1, 1, 1, 2 };
    //        int[] intArr = new int[] { -2, 0, 1, 1, 2 };
    //        var res = solution.ThreeSum(intArr);
    //        ConsoleX.WriteLine(res);
    //    }
    //}

    public class Solution
    {
        /// <summary>
        /// 排序之后，双指针。我一开始完全是这个路数，结果中间一个想法没有想到，就以为完全错误，结果就差了一点
        /// 时间复杂度：O(n²)，排序nlogn，循环内层n，外层n，就是n²
        /// 空间复杂度：O(1)
        /// 其实有个思路一直没有转过来，就是遍历的时候如果是和上一个相等的就continue，这个想通了就好做了
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<IList<int>> ThreeSum(int[] nums)
        {
            IList<IList<int>> res = new List<IList<int>>();
            Array.Sort(nums);
            for (int left = 0; left < nums.Length; left++)
            {
                //排序之后，左指针最小，都大于0了，那一定就没有其他答案了
                if (nums[left] > 0)
                    break;
                //去重
                if (left - 1 >= 0 && nums[left] == nums[left - 1])
                    continue;

                int mid = left + 1;
                int right = nums.Length - 1;
                while (mid < right)
                {
                    int sum = nums[left] + nums[mid] + nums[right];
                    if (sum == 0)
                    {
                        res.Add(new int[] { nums[left], nums[mid], nums[right] });
                        do { right--; } while (mid < right && nums[right + 1] == nums[right]);
                        do { mid++; } while (mid < right && nums[mid] == nums[mid - 1]);
                    }
                    else if (sum > 0)
                        right--;
                    else
                        mid++;
                }
            }
            return res;
        }


        /// <summary>
        /// 期望用Dictionary来加快速度，结果不行，哈哈哈
        /// 时间复杂度：O(n²),时间复杂度的确是n²，但是可能是999n²,所以导致了不行，可能n足够大就能拉小系数的差距吧
        /// 空间复杂度：O(n),一个dictionary
        /// Experience:引用类型想使用Linq的Distinct方法，需要一个实现IEqualityComparer接口的类，这个接口有两个方法，一个是Equals，
        /// 一个是GetHashCode，比较的时候会先调用GetHashCode方法，如果返回的int相等，它就会继续调用Equals方法，如果Equals也返回相等
        /// 就判定是相等的；如果返回的int不相等，就直接判定不相等。（所以在对比是可以GetHashCode直接返回一个固定值，省略掉前一个步骤，
        /// 直接在Equals中写相等的方法，这样就可以节省部分性能）
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        //public IList<IList<int>> ThreeSum(int[] nums)
        //{
        //    IList<IList<int>> res = new List<IList<int>>();
        //    //1.构建一个dictionary，key存数，value存个数。先把数组装进去。
        //    Dictionary<int, int> dic = new Dictionary<int, int>();
        //    for (int i = 0; i < nums.Length; i++)
        //    {
        //        if (dic.ContainsKey(nums[i]))
        //            dic[nums[i]]++;
        //        else
        //            dic.Add(nums[i], 1);
        //    }
        //    //2.遍历dictionary，两层循环，再加一个dictionary查找
        //    foreach (var i in dic.Keys.ToList())
        //    {
        //        //使用了之后就计算减一
        //        dic[i]--;
        //        foreach (var j in dic.Keys.ToList())
        //        {
        //            //有可能外层用了，就没有了
        //            if (dic[j] == 0)
        //                continue;
        //            dic[j]--;

        //            //目标差值
        //            int diff = 0 - i - j;
        //            if (dic.ContainsKey(diff) && dic[diff] > 0)
        //            {
        //                var arr = new int[] { i, j, diff };
        //                Array.Sort(arr);
        //                res.Add(arr);
        //                //如果构成的答案中有两个或以上的重复，则把重复的项抹去，只剩下一个。因为有过重复的答案后，就不可能再有了
        //                if (i == j && j == diff)
        //                    dic[i] = 1;
        //                else if (i == j || i == diff)
        //                    dic[i] = 1;
        //                else if (j == diff)
        //                    dic[j] = 1;
        //            }

        //            dic[j]++;
        //        }
        //        ////遍历完成后再加回来
        //        dic[i]++;
        //    }
        //    //去重
        //    return res.Distinct(new Comparer()).ToList();
        //}

        //private class Comparer : IEqualityComparer<IList<int>>
        //{
        //    public bool Equals(IList<int> x, IList<int> y)
        //    {
        //        return x[0] == y[0] && x[1] == y[1] && x[2] == y[2];
        //    }

        //    //先比较hashcode是否相等，如果相等就再调用Equals方法，如果不相等就直接返回
        //    public int GetHashCode(IList<int> obj)
        //    {
        //        //int code = $"{obj[0]}-{obj[1]}-{obj[2]}".GetHashCode();
        //        return 0;
        //    }
        //}
    }
}
