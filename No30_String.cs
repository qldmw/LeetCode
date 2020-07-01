using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode_30
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
    //        //int input2 = int.Parse(Console.ReadLine());
    //        //int?[] data = new int?[] { 6, 2, 8, 0, 4, 7, 9, null, null, 3, 5 };
    //        //int?[] data = new int?[] { 1, null, 2, 3 };
    //        //int?[] data = new int?[] { 1, 2, 2, 3, 3, null, null, 4, 4 };
    //        //int?[] data = new int?[] { 1, 2, null, 3 };
    //        //int?[] data = new int?[] { 1, 2, 2, 3, 3, 3, 3, 4, 4, 4, 4, 4, 4, null, null, 5, 5 };
    //        //var tree = new DataStructureBuilder().BuildTree(data);
    //        //var res = solution.FindSubstring("barfoothefoobarman", new string[] { "foo", "bar" });
    //        //var res = solution.FindSubstring("wordgoodgoodgoodbestword", new string[] { "word", "good", "best", "word" });
    //        //var res = solution.FindSubstring("", new string[] { });
    //        var res = solution.FindSubstring("barfoofoobarthefoobarman", new string[] { "bar", "foo", "the" });
    //        //var res = solution.FindSubstring("pjzkrkevzztxductzzxmxsvwjkxpvukmfjywwetvfnujhweiybwvvsrfequzkhossmootkmyxgjgfordrpapjuunmqnxxdrqrfgkrsjqbszgiqlcfnrpjlcwdrvbumtotzylshdvccdmsqoadfrpsvnwpizlwszrtyclhgilklydbmfhuywotjmktnwrfvizvnmfvvqfiokkdprznnnjycttprkxpuykhmpchiksyucbmtabiqkisgbhxngmhezrrqvayfsxauampdpxtafniiwfvdufhtwajrbkxtjzqjnfocdhekumttuqwovfjrgulhekcpjszyynadxhnttgmnxkduqmmyhzfnjhducesctufqbumxbamalqudeibljgbspeotkgvddcwgxidaiqcvgwykhbysjzlzfbupkqunuqtraxrlptivshhbihtsigtpipguhbhctcvubnhqipncyxfjebdnjyetnlnvmuxhzsdahkrscewabejifmxombiamxvauuitoltyymsarqcuuoezcbqpdaprxmsrickwpgwpsoplhugbikbkotzrtqkscekkgwjycfnvwfgdzogjzjvpcvixnsqsxacfwndzvrwrycwxrcismdhqapoojegggkocyrdtkzmiekhxoppctytvphjynrhtcvxcobxbcjjivtfjiwmduhzjokkbctweqtigwfhzorjlkpuuliaipbtfldinyetoybvugevwvhhhweejogrghllsouipabfafcxnhukcbtmxzshoyyufjhzadhrelweszbfgwpkzlwxkogyogutscvuhcllphshivnoteztpxsaoaacgxyaztuixhunrowzljqfqrahosheukhahhbiaxqzfmmwcjxountkevsvpbzjnilwpoermxrtlfroqoclexxisrdhvfsindffslyekrzwzqkpeocilatftymodgztjgybtyheqgcpwogdcjlnlesefgvimwbxcbzvaibspdjnrpqtyeilkcspknyylbwndvkffmzuriilxagyerjptbgeqgebiaqnvdubrtxibhvakcyotkfonmseszhczapxdlauexehhaireihxsplgdgmxfvaevrbadbwjbdrkfbbjjkgcztkcbwagtcnrtqryuqixtzhaakjlurnumzyovawrcjiwabuwretmdamfkxrgqgcdgbrdbnugzecbgyxxdqmisaqcyjkqrntxqmdrczxbebemcblftxplafnyoxqimkhcykwamvdsxjezkpgdpvopddptdfbprjustquhlazkjfluxrzopqdstulybnqvyknrchbphcarknnhhovweaqawdyxsqsqahkepluypwrzjegqtdoxfgzdkydeoxvrfhxusrujnmjzqrrlxglcmkiykldbiasnhrjbjekystzilrwkzhontwmehrfsrzfaqrbbxncphbzuuxeteshyrveamjsfiaharkcqxefghgceeixkdgkuboupxnwhnfigpkwnqdvzlydpidcljmflbccarbiegsmweklwngvygbqpescpeichmfidgsjmkvkofvkuehsmkkbocgejoiqcnafvuokelwuqsgkyoekaroptuvekfvmtxtqshcwsztkrzwrpabqrrhnlerxjojemcxel", new string[] { "dhvf", "sind", "ffsl", "yekr", "zwzq", "kpeo", "cila", "tfty", "modg", "ztjg", "ybty", "heqg", "cpwo", "gdcj", "lnle", "sefg", "vimw", "bxcb" });
    //        ConsoleX.WriteLine(res);
    //    }
    //}

    public class Solution
    {
        /// <summary>
        /// 滑动窗口（Sliding Window），不会退，一边进一边出，一次遍历就解决
        /// s长度为n，单词个数t
        /// 时间复杂度：O(n)
        /// 空间复杂度：O(t),维护两个dictionary用于匹配
        /// </summary>
        /// <param name="s"></param>
        /// <param name="words"></param>
        /// <returns></returns>
        public IList<int> FindSubstring(string s, string[] words)
        {
            IList<int> res = new List<int>();
            //如果长度都小于匹配数组总长度，则一定不匹配
            int tlen = words.Sum(t => t.Length);
            if (s == null || s.Length < tlen || words.Length == 0)
                return res;
            //单词和单词出现的频率
            Dictionary<string, int> dic = new Dictionary<string, int>();
            foreach (string word in words)
            {
                InsertOrAdd(dic, word);
            }
            //有一个题目上没有的隐含条件，word都是等长的
            int wordLen = words[0].Length;
            for (int i = 0; i < wordLen; i++)
            {
                Dictionary<string, int> temp = new Dictionary<string, int>();
                //其实可以不要这个参数，不过这样的话就要每次都去比对两个dictionary了，性能不好
                int validWordCount = 0;
                for (int j = i; j + wordLen <= s.Length; j += wordLen)
                {
                    //如果大于等于words总长，开始滑出（弹出一个word）
                    if (j - i >= tlen)
                    {
                        string outWord = s.Substring(j - tlen, wordLen);
                        if (dic.ContainsKey(outWord))
                        {
                            validWordCount--;
                            RemoveOrReduce(temp, outWord);
                        }
                    }
                    //滑入
                    string inWord = s.Substring(j, wordLen);
                    if (dic.ContainsKey(inWord))
                    {
                        validWordCount++;
                        InsertOrAdd(temp, inWord);
                    }
                    if (validWordCount == words.Length && CompareTwoDic(dic, temp))
                        res.Add(j + wordLen - tlen);
                }
            }
            return res;
        }

        private bool CompareTwoDic(Dictionary<string, int> dic1, Dictionary<string, int> dic2)
        {
            //Knowledge：两个dictionary的对比方法：dic1.Count == dic2.Count && !dic1.Except(dic2).Any()，key，value都会做比较。
            return dic1.Count == dic2.Count && !dic1.Except(dic2).Any();
        }

        private void InsertOrAdd(Dictionary<string, int> dic, string word)
        {
            if (!dic.ContainsKey(word))
                dic.Add(word, 1);
            else
                dic[word]++;
        }

        private void RemoveOrReduce(Dictionary<string, int> dic, string word)
        {
            if (dic[word] <= 1)
                dic.Remove(word);
            else
                dic[word]--;
        }


        /// <summary>
        /// 第一反应解，算出所有组合，然后通过带匹配字符串的hash去比对。超时，算了一下组合，数量指数级上升，故不可行
        /// s长度为n，words的个数为m
        /// 时间复杂度：O(m!),构建组合花了绝大部分时间，遍历的话只需要n，在m小的情况下这个算法是可行的
        /// 空间复杂度：O(m!)
        /// 刚看到超时，还想用滚动hash优化一下的，debug一下结果发现是在拼接组合中就超时了
        /// </summary>
        /// <param name="s"></param>
        /// <param name="words"></param>
        /// <returns></returns>
        //public IList<int> FindSubstring(string s, string[] words)
        //{
        //    IList<int> res = new List<int>();
        //    //如果长度都小于匹配数组总长度，则一定不匹配
        //    int tlen = words.Sum(t => t.Length);
        //    if (s == null || s.Length < tlen || words.Length == 0)
        //        return res;
        //    //构建所有组合的字典
        //    RecursiveDicBuild(string.Empty, words.ToList());
        //    //和所有组合逐个比对hash
        //    for (int i = 0; i <= s.Length - tlen; i++)
        //    {
        //        string cur = s.Substring(i, tlen);
        //        int curHash = cur.GetHashCode();
        //        if (_dic.ContainsKey(curHash) && _dic[curHash] == cur)
        //            res.Add(i);
        //    }
        //    return res;
        //}

        ////构建一个装所有数组匹配可能性的字典，key是组合的hashcode，string是组合内容
        //private Dictionary<int, string> _dic = new Dictionary<int, string>();
        //private void RecursiveDicBuild(string str, List<string> strList)
        //{
        //    if (strList == null || strList.Count == 0)
        //    {
        //        if (!_dic.ContainsKey(str.GetHashCode()))
        //            _dic.Add(str.GetHashCode(), str);
        //    }
        //    else
        //    {
        //        for (int i = 0; i < strList.Count; i++)
        //        {
        //            string curStr = strList[i];
        //            var restStrList = strList.ToList();
        //            restStrList.RemoveAt(i);
        //            RecursiveDicBuild(str + curStr, restStrList);
        //        }
        //    }
        //}
    }
}
