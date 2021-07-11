using System;
using System.Collections.Generic;

namespace ValidParanthesis
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(IsValid("{{({})}}"));
        }

        public static bool IsValid(string s)
        {
            Stack<char> param = new Stack<char>();
            foreach(char c in s)
            {
                if (param.Count == 0)
                {
                    param.Push(c);
                }
                else
                {                  
                    char p = param.Pop();
                    if ((c == '}' && p == '{') || (c == ')' && p == '(') || (c == ']' && p == '['))
                    {
                        continue;
                    }
                    else
                    {
                        param.Push(p);
                        param.Push(c);
                    }
                }
            }
            if (param.Count == 0)
                return true;
            else
                return false;
        }
    }
}
