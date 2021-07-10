using System;
using System.Collections.Generic;

namespace FindReplaceString
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] sources = { "bn", "zzc","wxc" };
            string[] targets = { "t", "lwb", "nee" }; // "vbfrssozp"
            int[] indices = { 5, 2,7 };
            Console.WriteLine(FindReplaceString("wqzzcbnwxc",indices,sources,targets));
        }

        public static string FindReplaceString(string s, int[] indices, string[] sources, string[] targets)
        {

            SortedDictionary<int, int> str = new SortedDictionary<int, int>(); 
            for(int i = 0; i < indices.Length; i++)
            {
                if (s.Substring(indices[i], sources[i].Length).Equals(sources[i]))
                {
                    str.Add(indices[i],i);
                }
                
            }
            int offset = 0;
            foreach(KeyValuePair<int,int> st in str)
            {
                Console.WriteLine(s.Substring(st.Key, sources[st.Value].Length + offset));

                s = s.Replace(s.Substring(st.Key,sources[st.Value].Length+offset),targets[st.Value]);
                Console.WriteLine(s);
                offset = offset + targets[st.Value].Length - sources[st.Value].Length;
            }
            return s;
        }
    }
}
