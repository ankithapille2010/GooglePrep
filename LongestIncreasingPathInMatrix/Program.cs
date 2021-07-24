using System;
using System.Collections.Generic;

namespace LongestIncreasingPathInMatrix
{
    class Program
    {
        public static int[][] Directions = {new int[] { 1, 0 }, new int[] { -1, 0 }, new int[] { 0, 1 }, new int[] { 0, -1 }};
        static void Main(string[] args)
        {
            int[][] matrix = { new int[] { 3, 4, 5 }, new int[] { 3, 2, 6 }, new int[] { 2, 2, 1 } };
            Console.WriteLine(LongestIncreasingPath(matrix));
        }
        public static int LongestIncreasingPath(int[][] matrix)
        {
            int n = matrix.GetLength(0);
            int m = matrix[0].GetLength(0);
            //int[][] pathlength = new int[n][];
            int[][] cache = new int[n][];
            for(int i = 0; i < n; i++)
            {
                cache[i] = new int[m];

            }
            int max = 0;
            for (int i = 0; i < matrix.GetLength(0);i++ ){
                for (int j = 0; j < matrix[i].GetLength(0); j++)
                {
                    int length = path(matrix, cache, i, j, n, m);
                    max = Math.Max(max, length);
                }
            }
            return max;
        }

        private static int path(int [][]matrix, int[][] cache , int i, int j , int n, int m)
        {
            if (cache[i][j] > 0) return cache[i][j];
            int max = 0;
            int length = 0;

            for (int d1 = 0; d1 < Directions.GetLength(0); d1++)
            {
                int x = Directions[d1][0]+i, y = Directions[d1][1]+j;
                if(x>-1 && y>-1 && x<n && y<m && matrix[x][y]> matrix[i][j])
                    length = path(matrix, cache, x, y, n, m);
                max = Math.Max(max, length);

            }
            cache[i][j] = max + 1;
            return cache[i][j];

          
        }
    }
}
