using System;
using System.Collections;
using System.Collections.Generic;

namespace GooglePrep
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = {-1};
            int lower =-1;
            int upper = -1;
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
                    resultList.Add(lower + "->" + upper);
                else
                    resultList.Add(lower.ToString());
            }
          
            else
            {
                if(nums[0]>lower)
                    if(lower == nums[0]-1)
                        resultList.Add(lower.ToString());
                    else
                    resultList.Add((lower) + "->" +( nums[0]-1));
                for (int i = 0; i < nums.Length - 1; i++)
                {
                    if(nums[i+1]-nums[i]==2 && nums[i]+1>= lower && nums[i]+1<=upper)
                        resultList.Add((nums[i]+1).ToString());

                    if (nums[i + 1] - nums[i] > 2)
                    {            
                        resultList.Add((nums[i] + 1) + "->" + (nums[i + 1] - 1));     
                    }
                }
                if (nums[nums.Length - 1] < upper)
                    if (nums[nums.Length - 1] + 1 == upper)
                        resultList.Add(upper.ToString());
                    else
                        resultList.Add(nums[nums.Length - 1]+1 + "->" + upper);
            }
            return resultList; 

        }
    }
}
