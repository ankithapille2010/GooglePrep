using System;

namespace FindReplaceString
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] sources = { "kg", "ggq","mo" };
            string[] targets = { "s", "so", "bfr" }; // "vbfrssozp"
            int[] indices = { 3, 5,1 };
            Console.WriteLine(FindReplaceString("vmokgggqzp",indices,sources,targets));
        }

        public static string FindReplaceString(string s, int[] indices, string[] sources, string[] targets)
        {
           
            int offset = 0;
            int firstShift = indices[0];
            for(int i = 0; i < indices.Length; i++)
            {
                if (s.Substring(indices[i]+offset, sources[i].Length).Equals(sources[i]))
                {
                    s = s.Replace(sources[i], targets[i]);
                    //Console.WriteLine(s);
                    if (i < indices.Length - 1 && indices[i + 1] > firstShift)
                        offset = targets[i].Length - sources[i].Length;
                    else
                        offset = 0;
                }
                else
                    offset = 0;
            }
            return s;
        }
    }
}
