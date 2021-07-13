using System;
using System.Collections.Generic;

namespace MeetingRooms
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] intervals = { { 1, 10 }, { 2, 7 }, { 3, 19 }, { 8, 12 }, { 10, 20 }, { 11, 30 } };
            //{ { 0, 30 }, { 5, 10 }, { 15, 20 } }
            Console.WriteLine(MinMeetingRooms(intervals));

        }

        public static int MinMeetingRooms(int[,] intervals)
        {
           int [] startTimes = new int[intervals.GetLength(0)];
           int[] endTimes = new int[intervals.GetLength(0)];
            for (int i=0;i<intervals.GetLength(0);i++)  {
                startTimes[i] = intervals[i,0];
                endTimes[i] = intervals[i, 1];
            }

            Array.Sort(startTimes);
            Array.Sort(endTimes);
            
            if (startTimes.Length == 0)
                return 0;
            int numofRooms = 0;
            int ePointer = 0;
            int sPointer = 0;
            
            while(sPointer< startTimes.Length) {
                if (startTimes[sPointer] >= endTimes[ePointer])
                {
                    ePointer++;
                }
                else
                    numofRooms++;
                sPointer++;
            }

            return numofRooms;
        }
    }
}
