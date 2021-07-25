using System;
using System.Collections.Generic;

namespace IsomorphicStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(IsomorphicStrings("paper", "title"));
        }

        private static bool IsomorphicStrings(string s, string t)
        {
            Dictionary<char, char> str = new Dictionary<char, char>();
            Dictionary<char, char> strV = new Dictionary<char, char>();
            for (int i=0; i< s.Length; i++)
            {

                if (!str.ContainsKey(s[i]))
                {
                    if (!strV.ContainsKey(t[i]))
                    {
                        str.Add(s[i], t[i]);
                        strV.Add(t[i], s[i]);
                    }
                    else
                        return false;
                    
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
