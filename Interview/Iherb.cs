using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Interview
{
    class Iherb
    {
        //1.给你10个大文件，里面每一行都是一个数字，让你找出所有数字中 最大的100个
        //（1）如果内存都读下一整个文件的话，就先读取整个文件。不能的话就设置起始点和字节数目，每次读取。
        //（2）splice换行符，先把每个文件中最大的100个取出来。最大的规则是：先获取字符串数组中长度最长的（trimStart 0），然后依次获取最高位数组，从9开始往下筛选（负数的情况需要考虑到），直到满足条件的大于100个就停止。
        // (3) 合并10个文件中的前100个字符串数组，然后再用上述最大数规则获取100个（这次是精确获得一百个，上一次大概获得大于100个就可以）。

        //2.给你一组数字构成的字符串，有正有负，让你找出数字和最大的子串
        public string FindMaxNumString(List<string> data)
        {
            ////测试用例
            //List<string> data = new List<string>()
            //    {
            //        "-981237498217348128378",
            //        "-891237498217348128378",
            //        "-89123749821734812837",
            //        "-891237498217348128378",
            //        "-91237498217348128378",
            //        "-991237498217348128378",
            //        "-91237498217348128378",
            //        "-981237498217348128378"
            //    };
            //var res = solution.FindMaxNumString(data);
            //ConsoleX.WriteLine(res);

            List<int> digit = new List<int>();
            //获取到字符串数字长度,负数则用负数表示
            for (int i = 0; i < data.Count; i++)
            {
                bool sign = true;
                string str = data[i];
                if (str.StartsWith('-'))
                {
                    sign = false;
                    str = str.TrimStart('-');
                }
                int len = str.TrimStart('0').Length;
                digit.Add(sign ? len : -1 * len);
            }
            //根据位数获取位数最大的数组
            int maxDigit = digit.Max();
            List<int> candidatesPos = new List<int>();
            for (int i = 0; i < digit.Count; i++)
            {
                if (digit[i] == maxDigit)
                    candidatesPos.Add(i);
            }
            var candidates = data.Where(s => candidatesPos.IndexOf(data.IndexOf(s)) != -1).ToList();
            //从最大候选人中筛选出最大的数组
            int position = 0;//遍历的位数
            while (candidates.Count > 1)
            {
                int targerDigit = maxDigit > 0 ? candidates.Max(s => s[position] - '0') : candidates.Min(s => s[position + 1] - '0');
                for (int i = candidates.Count - 1; i >= 0; i--)
                {
                    if (maxDigit > 0)
                    {
                        if (candidates[i][position] - '0' != targerDigit)
                            candidates.RemoveAt(i);
                    }
                    else
                    {
                        if (candidates[i][position + 1] - '0' != targerDigit)
                            candidates.RemoveAt(i);
                    }
                }
                position++;
                //如果有多个重复最大解
                if (candidates.Distinct().Count() == 1)
                    break;
            }
            return candidates.FirstOrDefault();
        }

        //3.数组里面找子数组 满足子数组求和最大
        public List<int> GetMaxSumIntList(List<List<int>> data)
        {
            ////测试用例
            //List<List<int>> data = new List<List<int>>()
            //    {
            //        new List<int>(){ 1,2,3,4,5,6,5 },
            //        new List<int>(){ 1,2,3,4,5,6,6 },
            //        new List<int>(){ 1,2,3,4,5,6,7 },
            //        new List<int>(){ 1,2,3,4,5,6,4 },
            //        new List<int>(){ 1,2,3,4,5,6,3 }
            //    };
            //var res = solution.GetMaxSumIntList(data);
            //ConsoleX.WriteLine(res);
            List<int> sumList = data.Select(s => s.Sum()).ToList();

            int max = int.MinValue;
            int maxIndex = -1;
            for (int i = 0; i < sumList.Count; i++)
            {
                if (sumList[i] > max)
                {
                    max = sumList[i];
                    maxIndex = i;
                }
            }
            return data[maxIndex];
        }

        //4.最长公共前缀
        public string LongestCommonPrefix(string[] strs)
        {
            ////测试用例
            //string[] data = new string[] { "flower", "flow", "flight" };
            //var res = solution.LongestCommonPrefix(data);
            //ConsoleX.WriteLine(res);

            if (strs == null || strs.Length == 0)
                return string.Empty;

            string minStr = strs[0];
            foreach (string str in strs)
            {
                if (str.Length < minStr.Length)
                    minStr = str;
            }

            //因为这里的 right 是给 substring 方法用的，所以不用 -1
            int left = 0, right = minStr.Length;
            while (left < right)
            {
                //这里 +1 补齐除法的缺损
                int mid = (left + right + 1) / 2;
                bool isCP = strs.All(s => s.StartsWith(minStr.Substring(0, mid)));
                //出现失败要不断减少才行，避免除法缺损导致始终没有减少，所以要在失败的情况下 -1
                if (isCP)
                    left = mid;
                else
                    right = mid - 1;
            }
            return minStr.Substring(0, left);
        }

        //5.三数之和为 0
        public IList<IList<int>> ThreeSum(int[] nums)
        {
            //测试用例
            ////int[] intArr = new int[] { 0, 0, 0 };
            ////int[] intArr = new int[] { -1, 0, 1, 2, -1, -4 };
            ////int[] intArr = new int[] { -2, -1, -1, -1, 0, 1, 1, 1, 2 };
            //int[] intArr = new int[] { -2, 0, 1, 1, 2 };
            //var res = solution.ThreeSum(intArr);
            //ConsoleX.WriteLine(res);

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

        //6.查找中位数
        public int FindMedian(int[] nums)
        {
            ////测试用例
            //var res = solution.FindMedian(new int[] { 5, 2, 4, 1, 3 });
            //ConsoleX.WriteLine(res);

            int arrLen = nums.Length;
            if (arrLen % 2 == 0)
                return QuickSelect(nums, 0, arrLen - 1, arrLen / 2);
            else
                return QuickSelect(nums, 0, arrLen - 1, arrLen / 2 + 1);
        }

        private int QuickSelect(int[] nums, int left, int right, int k)
        {
            int pivot = Partition(nums, left, right);
            //长度对应到数组时，需要 -1 对应
            if (pivot == k - 1)
                return nums[pivot];
            if (pivot > k - 1)
                return QuickSelect(nums, left, pivot - 1, k);
            else
                return QuickSelect(nums, pivot + 1, right, k);
        }

        private int Partition(int[] nums, int left, int right)
        {
            if (left >= right)
                return left;
            //三数取中，避免出现传统方法会遇到的极端情况（已排序），沦为冒泡
            MedianOfThree(nums, left, right);
            //以右边第二位作为枢纽
            int pivot = right - 1;
            //排除掉最右边的数
            right--;
            while (left < right)
            {
                while (left < right && nums[left] <= nums[pivot])
                    left++;
                while (left < right && nums[right] >= nums[pivot])
                    right--;
                Swap(nums, left, right);
            }
            Swap(nums, left, pivot);
            return left;
        }

        private void MedianOfThree(int[] nums, int left, int right)
        {
            int mid = (left + right) / 2;
            //交换三个数，先用左边比较两次，确保左边最小，然后再把中间和右边一比，齐活
            if (nums[left] > nums[mid])
                Swap(nums, left, mid);
            if (nums[left] > nums[right])
                Swap(nums, left, right);
            if (nums[mid] > nums[right])
                Swap(nums, mid, right);
            //把中位数放到右边第二位，为之后备用
            Swap(nums, mid, right - 1);
        }

        private void Swap(int[] nums, int a, int b)
        {
            int temp = nums[a];
            nums[a] = nums[b];
            nums[b] = temp;
        }

        //7.查找不重复字符串
        public int LengthOfLongestSubstring(string s)
        {
            int maxLen = 0;
            int left = 0;
            //char 是字符，int 是字符出现的最后位置
            Dictionary<char, int> dic = new Dictionary<char, int>();
            for (int i = 0; i < s.Length; i++)
            {
                if (dic.ContainsKey(s[i]))
                {
                    left = Math.Max(dic[s[i]] + 1, left);// 为了不让left往回走，参考该用例：abba
                }
                dic[s[i]] = i;
                maxLen = Math.Max(i - left + 1, maxLen);
            }
            return maxLen;
        }

        //8.找两个字符串中相同字符串的最大长度

        //9.数组最大合子集

        //10.反转数组
        public int[] ReverseArray(int[] arr)
        {
            //测试用例
            //int[] data = new int[] { 1, 2, 3, 4, 5, 6, 7 };
            //var res = solution.ReverseArray(data);
            //ConsoleX.WriteLine(res);

            int len = arr.Length;
            for (int i = 0; i < len / 2; i++)
            {
                int temp = arr[i];
                //需要注意这里要 len - 1，因为是总长度
                arr[i] = arr[len - 1 - i];
                arr[len - 1 - i] = temp;
            }
            return arr;
        }

        //11.囚徒困境
        //单纯的应该怎么做的话，会选择都沉默，达到帕累托最优解。
        //（1）如果两个囚徒都只能做一次抉择，以后都不能后悔的话。他们会选择背叛。
        //（2）如果两个囚徒都还有再次抉择的机会的话，会先沉默，看对方情况而定，如果对方背叛我再背叛。
        // 帕累托最优：是指资源分配的一种理想状态，假定固有的一群人和可分配的资源，从一种分配状态到另一种状态的变化中，在没有使任何人境况变坏的前提下，使得至少一个人变得更好，这就是帕累托改进或帕累托最优化。
        // 纳什均衡：在一个博弈过程中，无论对方的策略选择如何，当事人一方都会选择某个确定的策略，则该策略被称作支配性策略。如果任意一位参与者在其他所有参与者的策略确定的情况下，其选择的策略是最优的，那么这个组合就被定义为纳什平衡。
        // 其他博弈论： 海盗分赃，旅行者困境

        //12.给定a、b两个文件，各存放50亿个url，每个url各占64字节，内存限制是4G，让你找出a、b文件共同的url?
        // 分治法（divide and conquer)
        // Step1：遍历文件a，对每个url求取hash(url)%1000，然后根据所取得的值将url分别存储到1000个小文件(记为a0,a1,...,a999，每个小文件约300M);
        // Step2:遍历文件b，采取和a相同的方式将url分别存储到1000个小文件(记为b0,b1,...,b999);
        // Step3：求每对小文件ai和bi中相同的url时，可以把ai的url存储到hash_set/hash_map中。然后遍历bi的每个url，看其是否在刚才构建的hash_set中，如果是，那么就是共同的url，存到文件里面就可以了。

        //13.最长字符串子集

        //14.Money changing problem
        public int CoinChange(int[] coins, int amount)
        {
            //测试用例
            ////int[] coins = new int[] { 1, 2, 5 };//11
            //int[] coins = new int[] { 186, 419, 83, 408 };//6249
            //var res = solution.CoinChange(coins, 6249);
            //ConsoleX.WriteLine(res);
            if (amount == 0)
                return 0;

            //用 int.MaxValue 初始化之后，就不用把做 0 的判断了
            //int[] dp = Enumerable.Repeat(int.MaxValue, amount + 1).ToArray();
            //或者这个写法 Array.Fill(dp, int.MaxValue);
            int[] dp = new int[amount + 1];
            for (int i = 0; i < amount; i++)
            {
                if (i == 0 || dp[i] != 0)
                {
                    //用 long 隐式转换防止 int 越界
                    foreach (long coin in coins)
                    {
                        if (i + coin <= amount)
                        {
                            if (dp[i + coin] == 0)
                                dp[i + coin] = dp[i] + 1;
                            else
                                dp[i + coin] = Math.Min(dp[i] + 1, dp[i + coin]);
                        }
                    }
                }
            }
            return dp[amount] == 0 ? -1 : dp[amount];
        }

        //15.Longest increasing subsequence

        //16.Missing integer problem
    }
}
