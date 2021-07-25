using System;
using System.Collections;
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
            Dictionary<char, IList  <int>> sect = new Dictionary<char, IList<int>>();
            Dictionary<char, IList<int>> gues = new Dictionary<char, IList<int>>();
            for (int i=0;i<secret.Length;i++)
            {
                if (!sect.ContainsKey(secret[i]))
                {
                    
                    sect.Add(secret[i], new List<int> { i });
                }
                else
                    sect[secret[i]].Add(i);

            }

            for (int i = 0; i < guess.Length; i++)
            {
                if (!gues.ContainsKey(guess[i]))
                {

                    gues.Add(guess[i], new List<int> { i });
                }
                else
                    gues[guess[i]].Add(i);

            }
         

            //First pass for bulls
            foreach (var g in guess)
            {
                Console.WriteLine(g);
                if (sect.ContainsKey(g))
                {
                    var l = gues[g];
                   
                    for (int i =0;i<l.Count;i++)
                    {
                       
                        if (sect[g].Contains(l[i]))
                        {
                            //Console.WriteLine(gues[g].Count);
                            if (gues[g].Count > 1)
                            {
                                gues[g].Remove(l[i]);
                                sect[g].Remove(l[i]);
                            }
                            else
                            {
                               // Console.WriteLine(g);
                                gues.Remove(g);
                                sect.Remove(g);
                               
                            }

                            numOfBulls++;
                        }
                    }
                }
            }

        /*   foreach (var g in gues)
            {
               Console.WriteLine(g.Key);
                var l = g.Value;
                for (int i = 0; i < l.Count; i++)
                    Console.WriteLine(l[i]);


            }*/
          /*  foreach (var s in sect)
            {
                Console.WriteLine(s.Key);
                var l = s.Value;
                for (int i = 0; i < l.Count; i++)
                    Console.WriteLine(l[i]);


            }*/

            //Second pass for cows


            return new string(numOfBulls+"A"+numOfCows+"B");
        }
    }
}
