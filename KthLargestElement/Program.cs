using System;
using System.Collections.Generic;

namespace KthLargestElement
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 3, 1, 2, 5, 6, 4};
            Console.WriteLine(FindKthLargest(nums,2));
        }
        public static int FindKthLargest(int[] nums, int k)
        {
            int KthLargest = 0;
            SortedList<int, int> list = new SortedList<int, int>();
            for(int i =0;i<nums.Length;i++)
            {
                if (list.ContainsKey(nums[i]))
                    list[nums[i]]++;
                else
                    list.Add(nums[i], 1);
            }
            
            if (list.Count != 0)
            {
                //Console.WriteLine(list.Keys[list.Count - 1]);
                for(int i = 0; i < k-1; i++)
                {
                    if(list[list.Keys[list.Count - 1]]>1)
                        list[list.Keys[list.Count - 1]]--;
                    else 
                        list.Remove(list.Keys[list.Count - 1]);
                }
                KthLargest=(list.Keys[list.Count - 1]);
            }
                //KthLargest = list.Keys[list.Count - k];
            return KthLargest;
        }

    }
}
