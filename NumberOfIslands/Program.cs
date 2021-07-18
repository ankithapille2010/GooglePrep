using System;

namespace NumberOfIslands
{
    class Program
    {
        static void Main(string[] args)
        {
            char[][] grid = { new char[] { '1', '1', '1', '1', '0' },
                new char[] { '1', '1', '1', '1', '0' },
                new char[] { '1', '1', '0', '0', '0' },
                new char[] { '0', '0', '0', '0', '0' } };
            Console.WriteLine(NumIslands(grid));
        }
        public static int NumIslands(char[][] grid)
        {
            if (grid == null || grid.Length == 0)
                return 0;
            int noOfIslands = 0;
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid[i].GetLength(0); j++)
                {
                     if (grid[i][j]=='1')
                        noOfIslands += dsf(i, j, grid);
                }
            }
            return noOfIslands;
        }

        private static int dsf(int i, int j, char[][] grid)
        {
            //Console.WriteLine(i + " " + j);
            if (i < 0 || i >=grid.GetLength(0) || j<0 || j>=grid[i].GetLength(0)|| grid[i][j] == '0')
                return 0;
            grid[i][j] = '0';
            dsf(i, j + 1, grid);
            dsf(i + 1, j, grid);
            dsf(i - 1, j, grid);
            dsf(i, j - 1, grid);

            return 1;
        }

        
    }
}
