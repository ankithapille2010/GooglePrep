using System;
using System.Collections.Generic;

namespace MaxDistToClosest
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] seats = { 0, 1 };
            Console.WriteLine(MaxDistToClosest(seats));
        }

        public static int MaxDistToClosest(int[] seats)
        {
            int maxdist = 0;
            /* Dictionary<int, int> emptyseats = new Dictionary<int, int>();
             Dictionary<int, int> filledseats = new Dictionary<int, int>();
             for (int i=0;i<seats.Length;i++)
             {
                 if (seats[i] == 0)
                     emptyseats.Add(i, seats[i]);
                 else
                     filledseats.Add(i, seats[i]);
             }
            
             foreach(KeyValuePair<int,int> eseats in emptyseats)
             {
                 int closestDist = 0;
                 foreach (KeyValuePair<int, int> fillseats in filledseats)
                 {

                     if (closestDist == 0)
                         closestDist = Math.Abs(eseats.Key - fillseats.Key);
                     else
                         if (Math.Abs(eseats.Key - fillseats.Key) < closestDist)
                         closestDist = Math.Abs(eseats.Key - fillseats.Key);
                 }
                 if (maxdist == 0)
                     maxdist = closestDist;
                 else if (closestDist > maxdist)
                     maxdist = closestDist;

             }*/

            // Alternate Solutions
            for(int i=0)
            return maxdist;
        }
    }
}
