using System;
using System.Collections.Generic;

namespace NextClosedTime
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(NextClosestTime("00:00"));
        }
         public static string NextClosestTime(string time)
         {
            string resultTime="";
            
            Dictionary<int, int> digits = new Dictionary<int, int>();
            foreach( char c in time)
            {
                if(!digits.ContainsKey(c))
                    digits.Add(c,1);
            }
            int min = Convert.ToInt32(time.Split(':')[1]);
            int hour = Convert.ToInt32(time.Split(':')[0]);

            while(true)
            {

                if (hour == 23 && min == 59)
                {
                    hour = 0;
                    min = 0;
                }
                else if (min == 59)
                {
                    hour = hour + 1;
                    min = 0;
                }
                else
                    min = min + 1;

                string HourStr = hour.ToString().Length == 1 ? "0" + hour : hour.ToString();
                string MinStr = min.ToString().Length == 1 ? "0" + min : min.ToString();
                string res= HourStr + ":" + MinStr;
                bool CorrectTime = true;
                foreach(char c in res)
                {
                    if (!digits.ContainsKey(c))
                    {
                        CorrectTime = false;
                    }
                }
                if (CorrectTime)
                    return res;
            }
            return resultTime;
        }
        
    }
}
