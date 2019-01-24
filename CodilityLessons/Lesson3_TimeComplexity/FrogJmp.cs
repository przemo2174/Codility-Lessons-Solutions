using System;
using System.Collections.Generic;
using System.Text;

namespace CodilityLessons.Lesson3_TimeComplexity
{
    public static class FrogJmp
    {
        //100% score. O(1) time complexity
        public static int Solution(int X, int Y, int D)
        {
            int distance = Y - X;
            int jumps = (int)Math.Ceiling((double)distance / D);
            return jumps;
        }
    }
}
