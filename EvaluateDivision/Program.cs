using System;
using System.Collections;
using System.Collections.Generic;

namespace EvaluateDivision
{
    class Program
    {
        static void Main(string[] args)
        {
            IList<IList<string>> equations = new List<IList<string>>();
            List<string> e1 = new List<string>();
            e1.Add("x1");
            e1.Add("x2");
            equations.Add(e1);
            List<string> e2 = new List<string>();
            e2.Add("x2");
            e2.Add("x3");
            equations.Add(e2);
            List<string> e3 = new List<string>();
            e3.Add("x3");
            e3.Add("x4");
            equations.Add(e3);
            List<string> e4 = new List<string>();
            e4.Add("x4");
            e4.Add("x5");
            equations.Add(e4);

            double[] values = { 3.0, 4.0, 5.0, 6.0 };

            IList<IList<string>> queries = new List<IList<string>>();
            List<string> q1 = new List<string>();
            q1.Add("x1");
            q1.Add("x5");
            queries.Add(q1);
            List<string> q2 = new List<string>();
            q2.Add("x5");
            q2.Add("x2");
            queries.Add(q2);

            List<string> q3 = new List<string>();
            q3.Add("x2");
            q3.Add("x4");
            queries.Add(q3);

            List<string> q4 = new List<string>();
            q4.Add("x2");
            q4.Add("x2");
            queries.Add(q4);


            List<string> q5 = new List<string>();
            q5.Add("x2");
            q5.Add("x9");
            queries.Add(q5);
            CalcEquation(equations, values, queries);

        }

        public static double[] CalcEquation(IList<IList<string>> equations, double[] values, IList<IList<string>> queries)
        {
            double[] result = new double[queries.Count];
            int counter = 0;
            IDictionary<string, Dictionary<string, double>> eqs = new Dictionary<string, Dictionary<string, double>>();
            foreach (List<string> eq in equations)
            {
                // Console.WriteLine(eq[0]); 
                if (!eqs.ContainsKey(eq[0])) {
                    Dictionary<string, double> v = new Dictionary<string, double>();
                    v.Add(eq[1], values[counter]);
                    eqs.Add(eq[0], v);
                }
                else
                {
                    var v = eqs[eq[0]];
                    v.Add(eq[1], values[counter]);
                }
                if (!eqs.ContainsKey(eq[1]))
                {
                    Dictionary<string, double> v = new Dictionary<string, double>();
                    v.Add(eq[0], 1 / values[counter]);
                    eqs.Add(eq[1], v);
                }
                else
                {
                    var v = eqs[eq[1]];
                    v.Add(eq[0], 1 / values[counter]);
                }
                counter++;
            }



            //print dic

            foreach (KeyValuePair<string, Dictionary<string, double>> kv in eqs)
            {
                Console.Write(kv.Key + ":");
                foreach (KeyValuePair<string, double> kv1 in kv.Value)
                {
                    Console.Write(kv1.Key + "->" + kv1.Value + ",");
                }
                Console.Write("\n");

            }
            counter = 0;
            foreach (List<string> qr in queries)
            {
                if (!eqs.ContainsKey(qr[0]) || !eqs.ContainsKey(qr[1]))
                {
                    result[counter] = (-1);
                }
                else if (qr[0] == qr[1])
                    result[counter] = 1;
                else
                {
                    List<string> visited = new List<string>();
                    result[counter] = dfs(eqs, qr[0], qr[1], 1, visited);
                   
                }
                counter++;
            }

            for (int i = 0; i < result.Length; i++)
                Console.WriteLine(result[i]);
            return result;
        }

        private static double dfs(IDictionary<string, Dictionary<string, double>> eqs, string v1, string v2, double prod, List<string>visited)
        {
             double answer = -1;
             Dictionary<string,double> neighbors = eqs[v1];
             visited.Add(v1);
            if (neighbors.ContainsKey(v2))
            {
                
                answer = prod * neighbors[v2];
            }
            else
            {
                foreach(KeyValuePair<string, double> n in neighbors)
                {
                    //Console.WriteLine(prod);
                    if (!visited.Contains(n.Key))
                    answer = dfs(eqs,n.Key,v2,prod*n.Value,visited);
                    if (answer != -1)
                        break;
                }
            }
                           
            return answer;
        }

       
    }
}
