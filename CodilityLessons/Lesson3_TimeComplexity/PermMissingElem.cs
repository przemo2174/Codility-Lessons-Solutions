using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodilityLessons.Lesson3_TimeComplexity
{
    
    public static class PermMissingElem
    {
        //100% score
        public static int Solution(int[] A)
        {
            if (A.Length == 0)
            {
                return 1;
            }

            long n = A.Length + 1;
            //Need to operate on long because int overflows
            long sum = A.Sum(x => (long)x);

            long missing = (n * (n + 1)) / 2 - sum;
            return (int)missing;
        }
    }
}
