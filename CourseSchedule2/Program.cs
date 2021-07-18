using System;
using System.Collections.Generic;

namespace CourseSchedule2
{
    class Program
    {
        static void Main(string[] args)
        {
            int numCourses = 4;
            int[][] prerequisites = { new int[] { 1, 0 }, new int[] { 2, 0 }, new int[] { 3, 1 }, new int[] { 3, 2 } };
            Console.WriteLine(FindOrder(numCourses, prerequisites));
        }

        public static int[] FindOrder(int numCourses, int[][] prerequisites)
        {
            List<int> result = new List<int>();
            IDictionary<int, List<int>> adj = new Dictionary<int, List<int>>();
            for(int i= 0;i < prerequisites.GetLength(0); i++)
            {
                if (adj.ContainsKey(prerequisites[i][0]))
                {
                    adj[i].Add(prerequisites[i][1]);
                }
                else
                    adj.Add(prerequisites[i][0],new List<int> { prerequisites[i][1] });
            }

            //foreach(KeyValuePair<int, List<int>> k in adj)
            //{
            //    Console.Write("\n" + k.Key+ ":");
            //        foreach (int v in k.Value)
            //        {
            //        Console.WriteLine(v + ",");
            //        }
            //}
            TopologiocalSort(adj);
            return result.ToArray();

        }

        public static List<int> TopologiocalSort(IDictionary<int, List<int>> adj)
        {
            List<int> topologicalOrder = new List<int>();

         //   foreach()
            return topologicalOrder;

        }
    }
}
