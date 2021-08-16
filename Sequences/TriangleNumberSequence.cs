using System;
using System.Collections.Generic;

namespace ProjectEulerSharp.Sequences
{
    /// <summary>
    /// Represents a sequence of triangular numbers. The nth triangular number is equal to the sum of the n natural numbers from 1 to n. 
    /// 
    /// URL: https://en.wikipedia.org/wiki/Triangular_number
    /// </summary>
    public static class TriangleNumberSequence
    {
        public static IEnumerable<long> Start()
        {
            long current = 0, next = 1;
            while (true)
            {
                current += next++;
                yield return current;
            }
        }
    }
}
