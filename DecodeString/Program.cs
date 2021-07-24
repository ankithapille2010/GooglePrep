using System;
using System.Collections.Generic;

namespace DecodeString
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "100[leetcode]";
            Console.WriteLine(DecodeString(s));
        }

        public static string DecodeString(string s)
        {
            string resultString = "";
            Stack<char> s1 = new Stack<char>();
            Stack<int> n1 = new Stack<int>();
            string countS = "";
            foreach (char c in s)
            {

                if (c == ']')
                {
                    string decodedStringPart = "";
                    char dStr = (char)s1.Pop();
                    while (dStr != '[')
                    {
                        decodedStringPart = dStr + decodedStringPart;
                        dStr = (char)s1.Pop();
                    }

                    // while (n1.Count != 0)
                    // {
                    //countS = n1.Pop() + countS;
                    //}

                    int count = n1.Pop();// Convert.ToInt32(countS);
                    for (int i = 0; i < count; i++)
                        foreach (char c1 in decodedStringPart)
                            s1.Push(c1);

                }
                else if (char.IsDigit(c))
                {
                    countS = countS+c;
                    //n1.Push(c);
                }
                else
                {
                    if (!countS.Equals("")) {
                        n1.Push(Convert.ToInt32(countS));
                        countS = "";
                    }
                    s1.Push(c);
                }
            }

            while(s1.Count!=0)
            {
                resultString = s1.Pop()+resultString;           
            }
            
            return resultString;
        }
    }
}
