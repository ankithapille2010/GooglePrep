using System;
using System.Collections.Generic;

namespace CourseSchedule2
{
    class Program
    {
        static void Main(string[] args)
        {
            int numCourses = 3;
            int[][] prerequisites = { new int[] { 1, 0 }, new int[] { 1, 2 }, new int[] { 0,1 } };
            int [] result = (FindOrder(numCourses, prerequisites));
            foreach (int i in result)
                Console.WriteLine(i);
        }

        public static int[] FindOrder(int numCourses, int[][] prerequisites)
        {
            IDictionary<int, List<int>> adj = new Dictionary<int, List<int>>();
            for(int i= 0;i < prerequisites.GetLength(0); i++)
            {
                if (adj.ContainsKey(prerequisites[i][0]))
                {
                    adj[prerequisites[i][0]].Add(prerequisites[i][1]);
                }
                else
                    adj.Add(prerequisites[i][0],new List<int> { prerequisites[i][1] });
            }
            for(int i = 0; i < numCourses; i++)
            {
                if (!adj.ContainsKey(i))
                    adj.Add(i, new List<int> { });
            }

            List<int>result = TopologiocalSort(adj);
            return result.Count==numCourses?result.ToArray():new int[] { };

        }

        public static List<int> TopologiocalSort(IDictionary<int, List<int>> adj)
        {
            List<int> topologicalOrder = new List<int>();
            Queue<int> order = new Queue<int>();
            bool[] visited = new bool[adj.Count];
            for (int i = 0; i < adj.Count; i++) {
                visited[i] = false;
            }
            foreach (KeyValuePair<int, List<int>> k in adj)
            {
                
                if (k.Value.Count==0)
                {
                    order.Enqueue(k.Key);
                    visited[k.Key] = true;
                }
            }

            while(order.Count != 0)
            {
                int currNode = order.Dequeue();
                topologicalOrder.Add(currNode);
                foreach(KeyValuePair<int,List<int>> a in adj)
                {
                    if (a.Value.Contains(currNode)&& visited[a.Key]== false)
                    {
                        a.Value.Remove(currNode);
                        if (a.Value.Count == 0)
                        {
                            order.Enqueue(a.Key);
                            visited[a.Key] = true;
                        }
                    }
                }
            }
            return topologicalOrder;

        }

        private static IList<int> DFS(int Node, IDictionary<int, List<int>> adj, List<int>visited)
        {

            /* if (!adj.ContainsKey(Node) || adj[Node].Count == 0)
             {
                 if(!visited.Contains(Node))
                     visited.Add(Node);
             }

             else
             {
                 foreach (int adjnode in adj[Node])
                 {
                     DFS(adjnode, adj, visited);
                 }
             }
            */
            Queue<int> order = new Queue<int>();
            order.Enqueue(Node);
            while (order.Count != 0)
            {
                int n = order.Dequeue();
               // Console.WriteLine(n);
                if (!adj.ContainsKey(n) || adj[n].Count == 0)
                {
                    if (!visited.Contains(n))
                        visited.Add(n);
                }
                else
                {
                    foreach (int adjnode in adj[n])
                    {               
                        order.Enqueue(adjnode);
                    }
                }
               
            }
            return visited;
            
        }
    }
}
