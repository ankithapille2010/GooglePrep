using System;
using System.Collections.Generic;

namespace BackspaceStringCompare
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "ab#c";
            string t = "ad#c";
            Console.WriteLine(BackspaceCompare(s,t));
        }
        public static bool  BackspaceCompare(string s, string t)
        {
            Stack<char> sStack = new Stack<char>();
            for (int i = 0; i < s.Length; i++)
            {
                if (sStack.Count == 0 && s[i] != '#')
                {
                    sStack.Push(s[i]);  
                }
                else if (s[i] == '#')
                {
                    if (sStack.Count != 0)
                        sStack.Pop();
                }
                else
                {
                    sStack.Push(s[i]);
                }            
            }
            

            Stack<char> tStack = new Stack<char>();
            for (int i = 0; i < t.Length; i++)
            {
                if (tStack.Count == 0 && t[i] != '#')
                    tStack.Push(t[i]);
                else if (t[i] == '#')
                {
                    if (tStack.Count != 0)
                        tStack.Pop();
                }
                else
                    tStack.Push(t[i]);

            }

            while (sStack.Count != 0)
            {
                Console.Write(sStack.Pop());
            }
            Console.Write("\n");
            while (tStack.Count != 0)
            {
                Console.Write(tStack.Pop());
            }
            Console.Write("\n");
           /* if (sStack.Count != tStack.Count)
                return false;
           while(sStack.Count!=0)
            {
                if (sStack.Pop() != tStack.Pop())
                {
                    return false;
                }
            }*/
            return sStack.Equals(tStack)? true:false;
        }
    }
}
