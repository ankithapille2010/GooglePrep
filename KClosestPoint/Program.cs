using System;
using System.Collections.Generic;

namespace KClosestPoint
{
    class Point
    {
        public int X;
        public int Y;
        public double DistaceFromZero;
        public Point(int x, int y, double dist)
        {
            X = x;
            Y = y;
            DistaceFromZero=dist;
        }
        public Point()
        {

        }
    }
    class Program: Point
    {
        static void Main(string[] args)
        {
            int[][] input = { new int[] { 1, 0 }, new int[] { 0, 1}};
            int[][] result = KClosest(input, 2);
            for (int i = 0; i < result.GetLength(0); i++)
            {
                Console.WriteLine(result[i][0]);
                Console.WriteLine(result[i][1]);

            }
        }


        public static int[][] KClosest(int[][] points, int k)
        {
            int[][] result = new int[k][];
            SortedList<double, string> pointDist = new SortedList<double, string>();

            for (int i = 0; i < points.GetLength(0); i++) { 
                double currDist = Math.Sqrt(Math.Pow(points[i][0], 2) + Math.Pow(points[i][1], 2));
                 if (pointDist.ContainsKey(currDist))
                {
                    pointDist[currDist] = pointDist[currDist] + "," + i;
                }
                else
                pointDist.Add(currDist,i.ToString());
            }

          
            int counter = 0;
            for(int i =0;i<k;i++){
                 foreach (string s in pointDist.Values[i].Split(','))
                {
                    result[counter]= new int [] { points[Convert.ToInt32(s)][0], points[Convert.ToInt32(s)][1] };
                    counter++;
                }
                if (counter == k)
                {
                    break;
                }
            }
            return result;
        }
    }
}
