using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace LeetCode_65
{
    //static void Main(string[] args)
    //{
    //    var solution = new Solution();
    //    while (true)
    //    {
    //        //int input = int.Parse(Console.ReadLine());
    //        //int input2 = int.Parse(Console.ReadLine());
    //        string input = Console.ReadLine();
    //        //string input2 = Console.ReadLine();
    //        //int[] intArr = input.Split(',').Select(s => int.Parse(s)).ToArray();
    //        //int input = int.Parse(input2);
    //        var res = solution.IsNumber(input);
    //        Console.WriteLine(res);
    //        solution._state = Solution.State.Start;
    //    }
    //}

    /// <summary>
    /// Experience:
    /// 1.多状态的情况下，DFA是个非常好的解决办法。
    /// 2.多状态的图要正确，否则就一处错处处错。（所以业务理解非常重要）
    /// 3.状态机的设计不用前置条件也是可以的，要好好分析。（不用分遇到了\d还是前面是e的\dj,横向表头都应该是不带状态的字符，纵向管理状态）
    /// </summary>
    public class Solution
    {
        public State _state = State.Start;
        public Dictionary<State, State[]> _automaton = new Dictionary<State, State[]>()
            {
                { State.Start, new State[] { State.Start, State.Signed, State.Number, State.Dot, State.End, State.End, State.End, State.End, State.End } },
                { State.Signed, new State[] { State.End, State.End, State.Number, State.Dot, State.End, State.End, State.End, State.End, State.End } },
                { State.Number, new State[] { State.End, State.End, State.Number, State.Decimal, State.End, State.E, State.End, State.End, State.End } },
                { State.Dot, new State[] { State.End, State.End, State.Decimal, State.End, State.Decimal, State.End, State.End, State.End, State.End } },
                { State.Decimal, new State[] { State.End, State.End, State.End, State.End, State.Decimal, State.E, State.End, State.End, State.End } },
                { State.E, new State[] { State.End, State.End, State.End, State.End, State.End, State.End, State.ESigned, State.ENumber, State.End } },
                { State.ESigned, new State[] { State.End, State.End, State.End, State.End, State.End, State.End, State.End, State.ENumber, State.End } },
                { State.ENumber, new State[] { State.End, State.End, State.End, State.End, State.End, State.End, State.End, State.ENumber, State.End } },
                { State.End, new State[] { State.End, State.End, State.End, State.End, State.End, State.End, State.End, State.End, State.End } }
            };

        /// <summary>
        /// 确定有限状态机(Deterministic Finite Automaton)，编译原理中的一个知识，凡是遇到复杂的状况，这是一个非常好的解决办法，而且能保持逻辑清晰
        /// 时间复杂度：O(n),随着字符串的长度线性增长
        /// 空间复杂度：O(1),只用了固定变量
        /// </summary>
        public bool IsNumber(string s)
        {
            s = s.Trim();

            for (int i = 0; i < s.Length; i++)
            {
                if (_state == State.End)
                    break;

                _state = GetState(s, i);
            }
            return _state == State.Number
                || _state == State.Decimal
                || _state == State.ENumber;
        }

        public State GetState(string s, int i)
        {
            int index;

            if (s[i] == ' ')
                index = 0;
            else if (s[i] == '+' || s[i] == '-')
            {
                if (i > 0 && s[i - 1] == 'e')
                    index = 6;
                else
                    index = 1;
            }
            else if (s[i] >= '0' && s[i] <= '9')
            {
                char flag = ' ';
                while (i > 0)
                {
                    i--;
                    if ((s[i] < '0' || s[i] > '9') && s[i] != '+' && s[i] != '-')
                    {
                        flag = s[i];
                        break;
                    }
                }
                if (flag == '.')
                    index = 4;
                else if (flag == 'e')
                    index = 7;
                else
                    index = 2;
            }
            else if (s[i] == '.')
                index = 3;
            else if (s[i] == 'e')
                index = 5;
            else
                index = 8;

            return _automaton[_state][index];
        }

        public enum State
        {
            Start,
            Signed,
            Number,
            Dot,
            Decimal,
            E,
            ESigned,
            ENumber,
            End
        }
    }
}