using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode
{
    class No71_String
    {
        public string SimplifyPath(string path)
        {
            Stack<string> stack = new Stack<string>();
            string word = string.Empty;
            for (int i = 0; i < path.Length; i++)
            {
                if (path[i] == '/' || i == path.Length - 1)
                {
                    if (i == path.Length - 1)
                    {
                        if (path[i] != '/') word += path[i];
                    }
                    if (word == "..")
                    {
                        if (stack.Count != 0) stack.Pop();
                    }
                    else if (!string.IsNullOrEmpty(word))
                    {
                        if (word != ".")
                        {
                            stack.Push(word);
                        }
                    }
                    word = string.Empty;
                }
                else
                {
                    word += path[i];
                }
            }
            var arr = new List<int>();
            var wordList = stack.ToArray().ToList();
            wordList.Reverse();
            return "/" + string.Join("/", wordList);
        }
    }
}
