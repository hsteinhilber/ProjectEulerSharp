using System.Collections;
using System.Collections.Generic;

namespace ProjectEulerSharp.Sequences
{
    /// <summary>
    /// Represents a sequence of numbers that are abundant. An abundant number is one that
    /// is less than the sum of its proper divisors.
    /// 
    /// URL: https://en.wikipedia.org/wiki/Abundant_number
    /// </summary>
    class AbundantNumbers : IEnumerable<long>
    {
        private AbundantNumbers()
        {

        }

        public static AbundantNumbers All => new AbundantNumbers();

        IEnumerator<long> IEnumerable<long>.GetEnumerator()
        {
            long n = 12;
            while (true)
            {
                yield return n;
                do n++; while (!n.IsAbundant());
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<long>)this).GetEnumerator();
        }
    }
}
