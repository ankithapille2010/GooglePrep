using System;
using System.Collections;
using System.Collections.Generic;

namespace GooglePrep
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 0, 1, 3, 50, 75 };
            int lower =0;
            int upper = 99;
            var result = FindMissingRanges(nums, lower, upper);
            foreach(string s in result)
            {
                Console.WriteLine(s);
            }
        }
        public static IList<string> FindMissingRanges(int[] nums, int lower, int upper)
        {
            IList<string> resultList = new List<string>();
            int lowerIndex = lower;
            if (nums.Length == 0)
            {
                if (lower != upper)
                    Console.WriteLine(lower + "->" + upper);
                else
                    Console.WriteLine(lower);
            }
            else if (nums[nums.Length - 1] < lower || nums[0] > upper)
            {
                if (lower != upper)
                    Console.WriteLine(lower + "->" + upper);
                else
                    Console.WriteLine(lower);
            }

            else
            {
                for (int i = 0; i < nums.Length - 1; i++)
                {
                    if (nums[i] < lower)
                        continue;
                    if (nums[i] == lower)
                        lowerIndex = lower + 1;
                    Console.WriteLine(lowerIndex+" "+ nums[i]);
                    if (nums[i + 1] - lowerIndex == 2)
                    {
                        Console.WriteLine(lowerIndex);
                    }

                    if (nums[i + 1] - lowerIndex > 2)
                        Console.WriteLine(lowerIndex + "->" + (nums[i + 1] - 1).ToString());
                    lowerIndex = nums[i]+1;

                }
                if (nums[nums.Length - 1] < upper)
                    Console.WriteLine(lowerIndex + "->" + upper);
                //Console.WriteLine(lowerIndex);
            }
            return resultList; 

        }
    }
}
