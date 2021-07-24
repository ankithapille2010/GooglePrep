using System;
using System.Collections.Generic;

namespace IsomorphicStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(IsomorphicStrings("ab", "aa"));
        }

        private static bool IsomorphicStrings(string s, string t)
        {
            Dictionary<char, char> str = new Dictionary<char, char>();
           // Dictionary<char, char> strR = new Dictionary<char, char>();
            if (str.Count == 1)
            {
                str.Add(s[0], t[0]);
                str.Add(t[0], s[0]);
             //   strR.Add(t[0], s[0]);
            }
            
            for(int i=1; i< s.Length; i++)
            {
                if (!str.ContainsKey(s[i]))
                {
                   
                    if (strR.ContainsKey(t[i]))
                        return false;
                    else
                    {
                        str.Add(s[i], t[i]);
                        strR.Add(t[i], s[i]);
                    }
                    
                }
                else {
                    if (str[s[i]] != t[i])
                        return false;

                }
            }
            return true;
        }

        
    }
}
