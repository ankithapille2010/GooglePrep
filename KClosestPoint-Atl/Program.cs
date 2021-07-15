using System;

namespace KClosestPoint_Atl
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] input = { new int[] { 1, 3 }, new int[] { -2, -2 } };
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
            Array.Sort(points, (a,b)=>DistanceSquared(a).CompareTo(DistanceSquared(b)));
            Array.Copy(points,result,k);
            return result;
        }

        public static double DistanceSquared(int [] point)
        {
            double dist = point[0]*point[0]+ point[1]*point[1];
            return dist;
        }
    }
}
