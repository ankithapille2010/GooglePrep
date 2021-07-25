using System;
using System.Collections.Generic;

namespace cowAndBulls
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(GetHint("1122", "1222"));
        }
        public static string GetHint(string secret, string guess)
        {
            int numOfBulls = 0;
            int numOfCows = 0;
            Dictionary<char, SortedSet<int>> sect = new Dictionary<char, SortedSet<int>>();
            Dictionary<char, SortedSet<int>> gues = new Dictionary<char, SortedSet<int>>();
            for (int i=0;i<secret.Length;i++)
            {
                if (!sect.ContainsKey(secret[i]))
                {
                    
                    sect.Add(secret[i], new SortedSet<int> { i });
                }
                else
                    sect[secret[i]].Add(i);

            }

            for (int i = 0; i < guess.Length; i++)
            {
                if (!gues.ContainsKey(guess[i]))
                {

                    gues.Add(guess[i], new SortedSet<int> { i });
                }
                else
                    gues[guess[i]].Add(i);

            }

            //First pass for bulls
            foreach(var g in gues)
            {
                if (sect.ContainsKey(g.Key))
                {

                   foreach(int i in g.Value)
                    {
                        if (sect[g.Key].Contains(i))
                        {
                            if (sect[g.Key].Count > 1)
                                sect[g.Key].Remove(i);
                            else
                                sect.Remove(g.Key);

                            numOfBulls++;
                        }
                    }
                }
            }
            //Second pass for cows
            foreach (var g in gues)
            {
                if (sect.ContainsKey(g.Key))
                {

                    foreach (int i in g.Value)
                    {
                        //if (sect[g.Key].Contains(i))
                        //{
                            if (sect[g.Key].Count > 1)
                                sect[g.Key].Remove(i);
                            else
                                sect.Remove(g.Key);

                            numOfCows++;
                        //}
                    }
                }
            }
            return new string(numOfBulls+"A"+numOfCows+"B");
        }
    }
}
