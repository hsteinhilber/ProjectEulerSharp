using System;
using System.Collections.Generic;

namespace ProjectEulerSharp.Sequences
{
    public static class TriangleNumbers
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
