using System;
using System.Collections.Generic;

namespace TrappingRainWater
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] height = { 4, 2, 0, 3, 2, 5 };
            Console.WriteLine(Trap(height));
        }
        public static int Trap(int[] height)
        {
            int waterUnits = 0;
            if (height.Length == 0)
                return waterUnits;
            int[] left_max = new int[height.Length];
            int[] right_max = new int[height.Length];

            int leftM = height[0];
            left_max[0]=(height[0]);
            for (int i = 1; i < height.Length; i++)
            {
                //leftM = ;
                left_max[i]=(Math.Max(left_max[i - 1], height[i]));
            }
            int rightM = height[height.Length - 1];
            right_max[height.Length-1]=height[height.Length - 1];
            for (int i = height.Length - 2; i >= 0; i--)
            {
                //rightM =;
                right_max[i]=(Math.Max(right_max[i + 1], height[i]));
            }

            for (int i = 1; i < left_max.Length - 1; i++)
            {
                waterUnits = waterUnits + Math.Min(right_max[i], left_max[i]) - height[i];
            }
            return waterUnits;

        }
    }
}
