using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace LeetCode_8
{
    //static void Main(string[] args)
    //{
    //    var solution = new Solution();
    //    while (true)
    //    {
    //        //int input = int.Parse(Console.ReadLine());
    //        string input = Console.ReadLine();
    //        //string input2 = Console.ReadLine();
    //        var res = solution.MyAtoi(input);
    //        Console.WriteLine(res);
    //    }
    //}

    public class Solution
    {
        private State _state = State.Start;
        private long result;
        //true represent positive, false represent negative
        private bool sign = true;
        private Dictionary<State, State[]> Automaton = new Dictionary<State, State[]>()
        {
            { State.Start, new State[] { State.Start, State.Signed, State.Number, State.End } },
            { State.Signed, new State[] { State.End, State.End, State.Number, State.End } },
            { State.Number, new State[] { State.End, State.End, State.Number, State.End } },
            { State.End, new State[] { State.End, State.End, State.End, State.End } }
        };

        //确定有限状态机（deterministic finite automaton, DFA）
        //非常好终结无限If else的好办法
        public int MyAtoi(string str)
        {
            for (int i = 0; i < str.Length; i++)
            {
                if (_state == State.End)
                    break;

                switch (GetState(str[i]))
                {
                    case State.Start:
                        break;
                    case State.Signed:
                        {
                            _state = State.Signed;
                            sign = str[i] == '-' ? false : true;
                            break;
                        }
                    case State.Number:
                        {
                            _state = State.Number;
                            result = result * 10 + (str[i] - '0');

                            if (result > int.MaxValue)
                                _state = State.End;

                            break;
                        }
                    case State.End:
                        {
                            _state = State.End;
                            break;
                        }
                }
            }
            return sign ? (int)Math.Min(result, int.MaxValue) : (int)Math.Max(-result, int.MinValue);
        }

        private State GetState(char c)
        {
            int index;

            if (c == ' ')
                index = 0;
            else if (c == '+' || c == '-')
                index = 1;
            else if (c >= '0' && c <= '9')
                index = 2;
            else
                index = 3;
            return Automaton[_state][index];
        }

        private enum State
        {
            Start,
            Signed,
            Number,
            End
        }
    }

    //public class Solution
    //{
    //    /// <summary>
    //    /// 正则解题（第一反应走了捷径）
    //    /// </summary>
    //    /// <param name="str"></param>
    //    /// <returns></returns>
    //    public int MyAtoi(string str)
    //    {
    //        str = str.Trim();

    //        var match = Regex.Match(str, @"^(\+|-)?\d{1,}");
    //        if (!match.Success)
    //            return 0;

    //        string matchStr = match.Value.TrimStart('0');
    //        if (string.IsNullOrEmpty(matchStr))
    //            return 0;

    //        int ans = 0;
    //        if (!int.TryParse(matchStr, out ans))
    //        {
    //            ans = matchStr[0] == '-' ? int.MinValue : int.MaxValue;
    //        }
    //        return ans;
    //    }
    //}
}
