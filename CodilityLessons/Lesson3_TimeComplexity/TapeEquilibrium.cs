using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CodilityLessons.Lesson3_TimeComplexity
{
    public static class TapeEquilibrium
    {
        //100% correctness. 0% performance O(N^N)
        public static int Solution1(int[] A)
        {
            int N = A.Length;
            long minDifference = int.MaxValue;

            for (int P = 1; P < N; P++)
            {
                long leftSideSum = A.Take(P).Sum(x => (long)x);
                long rightSideSum = A.Skip(P).Sum(x => (long)x);

                long difference = Math.Abs(leftSideSum - rightSideSum);

                minDifference = Math.Min(difference, minDifference);
            }

            return (int)minDifference;
        }

        //100% correctness. 0% performance.
        //It turned out that Skip() method doesn't leverage indexes of array to move to specified index in O(1) time. 
        //Skip() iterates from the start of the array, element by element until it skipped specified number of elements. This is O(m) time complexity where m is number of elements to skip.
        public static int Solution2(int [] A)
        {
            int N = A.Length;
            long minDifference = int.MaxValue;
            long leftSideSumAggregate = 0;
            long rightSideSumAggregate = 0;

            for (int P = 1; P < N; P++)
            {
                leftSideSumAggregate += A.Skip(P - 1).Take(1).Single();
                if (P == 1)
                {
                    rightSideSumAggregate = A.Skip(P).Sum(x => (long)x);
                }
                else
                {
                    rightSideSumAggregate -= A.Skip(P - 1).Take(1).Single();
                }

                long difference = Math.Abs(leftSideSumAggregate - rightSideSumAggregate);

                minDifference = Math.Min(difference, minDifference);
            }

            return (int)minDifference;
        }

        //100% correctness. 100% performance.
        //This solution overcomes the Skip() problem presented in Solution2 by using array indexing.
        public static int SolutionBest(int[] A)
        {
            int N = A.Length;
            long minDifference = int.MaxValue;
            long leftSideSumAggregate = 0;
            long rightSideSumAggregate = 0;

            for (int P = 1; P < N; P++)
            {
                leftSideSumAggregate += A[P - 1];
                if (P == 1)
                {
                    rightSideSumAggregate = A.Skip(P).Sum(x => (long)x);
                }
                else
                {
                    rightSideSumAggregate -= A[P - 1];
                }

                long difference = Math.Abs(leftSideSumAggregate - rightSideSumAggregate);

                minDifference = Math.Min(difference, minDifference);
            }

            return (int)minDifference;
        }
    }
}
