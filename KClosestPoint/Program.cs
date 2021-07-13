using System;
using System.Collections.Generic;

namespace KClosestPoint
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] input = { new int[] { 1, 3 }, new int[] { -2, 2 }};
            int[][] result = KClosest(input, 1);
            for (int i = 0; i < result.GetLength(0); i++)
            {
             //   Console.WriteLine(result[i][0]);
               // Console.WriteLine(result[i][1]);

            }
        }

            public static int[][] KClosest(int[][] points, int k)
        {
            int[][] result = new int [k][];
            SortedList<double, int> res = new SortedList<double, int>();
            for (int i = 0; i < points.GetLength(0); i++)
            {
                res.Add(Math.Sqrt(Math.Pow(points[i][0],2)+ Math.Pow(points[i][1], 2)),i);
            }
            foreach(KeyValuePair<double,int> key in res)
            {
                Console.WriteLine(key.Key + " "+ key.Value);
            }
            for(int i=0;i<k;i++)
            {
                
                result[i] = new int[] { points[i][0], points[i][1]};
            }
            return result;
        }
    }
}
