using System;
using System.Collections.Generic;

namespace FindReplaceString
{
    class Program
    {
        static void Main(string[] args)
        {
           
            string[] sources = { "hvf", "vzr", "cw", "jvo", "jo", "qb", "ar", "noqf", "dv", "rh", "ri", "wt", "mx", "gux", "dc", "eic", "kz", "ct", "kidn", "lq", "ud", "odll", "vc", "tm", "qz", "no", "om", "bn", "ahm", "vra", "jeqco", "ml", "xb" };
            string[] targets = { "ajq", "zb", "r", "fai", "e", "zs", "io", "snxd", "nw", "oi", "ofb", "quq", "gj", "nsys", "dk", "sf", "muj", "ll", "hqx", "k", "n", "ptrya", "f", "qek", "u", "dhj", "e", "kr", "waj", "rvkr", "roaoeq", "mci", "djw" }; // "vbfrssozp"
            int[] indices = { 1, 31, 44, 70, 23, 73, 76, 92, 90, 86, 42, 4, 50, 17, 53, 20, 55, 15, 38, 64, 25, 9, 7, 68, 60, 88, 96, 47, 57, 34, 81, 78, 28 };
            Console.WriteLine(FindReplaceString("ehvfwtrvcodllgjctguxeicjoudmxbevzrvravkidnricwsbnxmxvdckzahmqzbrlqugtmjvoqbxarmlgjeqcorhnodvnoqfomdp", indices,sources,targets));
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
                 Console.WriteLine(s);
                 foreach(KeyValuePair<int,int> st in str)
                 {
                     int Place = st.Key + offset;
                     s = s.Remove(Place, (sources[st.Value].Length)).Insert(Place, targets[st.Value]);
                     offset = offset + targets[st.Value].Length - sources[st.Value].Length;
                 }
                return s;
        }
    }
}
