using System.Collections;
using System.Collections.Generic;

namespace ProjectEulerSharp.Sequences
{
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
