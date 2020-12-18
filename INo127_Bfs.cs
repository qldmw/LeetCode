using System;
using System.Collections.Generic;
using System.Extension;
using System.Linq;
using System.Text;

namespace LeetCode
{
    class INo127_Bfs
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
        //        //var builder = new DataStructureBuilder();
        //        //int?[] data = new int?[] { 1, 2, 3, 4, 5, null, 6, null, null, 7, 8 };
        //        //var tree = builder.BuildTree(data);
        //        //var listNode = builder.BuildListNode(new int[] { 1, 4, 5 });
        //        //int[][] arr = new int[3][] { new int[] { 1, 3, 1 }, new int[] { 1, 5, 1 }, new int[] { 4, 2, 1 } };
        //        //string input = "abcbefga";
        //        //string input2 = "dbefga";
        //        //int[] nums1 = new int[] { 10, 1, 2, 7, 6, 1, 5 };
        //        //IList<IList<int>> data = new List<IList<int>>()
        //        //{
        //        //    new List<int>() { 1, 3 },
        //        //    new List<int>() { 3, 0, 1 },
        //        //    new List<int>() { 2 },
        //        //    new List<int>() { 0 }

        //        //    //new List<int>() { 1 },
        //        //    //new List<int>() { 2 },
        //        //    //new List<int>() { 3 },
        //        //    //new List<int>() {  }
        //        //};
        //        string str1 = "hit";
        //        string str2 = "cog";
        //        IList<string> strList = new List<string>() { "hot", "dot", "dog", "lot", "log", "cog" };
        //        var res = solution.LadderLength(str1, str2, strList);
        //        ConsoleX.WriteLine(res);
        //    }
        //}

        public class Solution
        {
            /// <summary>
            /// 主动的广度优先搜索
            /// 时间复杂度：O(n * wordLen)
            /// 空间复杂度：O(n)
            /// 还可以双向搜索，大幅减小时间。不过一直搞烦了，留待以后来做。。。 99.999999%不会再做了
            /// </summary>
            /// <param name="beginWord"></param>
            /// <param name="endWord"></param>
            /// <param name="wordList"></param>
            /// <returns></returns>
            public int LadderLength(string beginWord, string endWord, IList<string> wordList)
            {
                HashSet<string> hash = wordList.ToHashSet();
                //所有满足条件的候选单词
                Queue<string> candidate = new Queue<string>();
                //当前的代数中有多少个候选单词
                int currentGenerationCount;
                //广度优先的代数
                int generation = 1;
                candidate.Enqueue(beginWord);
                //始终有候选人，而且没有超出整个wordList的长度，因为超出了的话一定成环了。
                while (candidate.Count > 0)
                {
                    currentGenerationCount = candidate.Count;
                    while (currentGenerationCount-- > 0)
                    {
                        var curr = candidate.Dequeue();
                        //标记当前string已经走过了
                        hash.Remove(curr);
                        if (curr == endWord)
                            return generation;
                        //相较于第一反应的被动DFS，改为主动DFS
                        for (int i = 0; i < curr.Length; i++)
                        {
                            PositiveSearch(curr, i);
                        }
                    }
                    generation++;
                }
                return 0;

                void PositiveSearch(string source, int index)
                {
                    for (char j = 'a'; j <= 'z'; j++)
                    {
                        var temp = source.ToArray();
                        temp[index] = j;
                        string tempStr = new string(temp);
                        //主动找到了就入队
                        if (hash.Contains(tempStr))
                        {
                            hash.Remove(tempStr);
                            candidate.Enqueue(tempStr);
                        }
                    }
                }
            }


            ///// <summary>
            ///// 第一反应解，广度优先，但是是通过每个单词对比实现的，感觉是一种被动的搜索，所以超时了
            ///// 时间复杂度：O(n * wordLen)
            ///// 空间复杂度：O(n)
            ///// </summary>
            ///// <param name="beginWord"></param>
            ///// <param name="endWord"></param>
            ///// <param name="wordList"></param>
            ///// <returns></returns>
            //public int LadderLength(string beginWord, string endWord, IList<string> wordList)
            //{
            //    HashSet<string> hash = wordList.ToHashSet();
            //    //所有满足条件的候选单词
            //    Queue<string> candidate = new Queue<string>();
            //    //当前的代数中有多少个候选单词
            //    int currentGenerationCount;
            //    //广度优先的代数
            //    int generation = 1;
            //    candidate.Enqueue(beginWord);
            //    //始终有候选人，而且没有超出整个wordList的长度，因为超出了的话一定成环了。
            //    while (candidate.Count > 0)
            //    {
            //        currentGenerationCount = candidate.Count;
            //        while (currentGenerationCount-- > 0)
            //        {
            //            var curr = candidate.Dequeue();
            //            //标记当前string已经走过了
            //            hash.Remove(curr);
            //            if (curr == endWord)
            //                return generation;
            //            foreach (string m in hash)
            //            {
            //                //只相差一个字符，而且没有走过
            //                if (IsOnlyOneCharacterDifferent(curr, m))
            //                    candidate.Enqueue(m);
            //            }
            //        }
            //        generation++;
            //    }
            //    return 0;
            //}

            //private bool IsOnlyOneCharacterDifferent(string target, string source)
            //{
            //    int diffCount = 0;
            //    for (int i = 0; i < target.Length; i++)
            //    {
            //        if (target[i] == source[i])
            //            continue;
            //        else
            //            diffCount++;

            //        if (diffCount > 1)
            //            break;
            //    }
            //    return diffCount == 1;
            //}
        }
    }
}
