using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerSharp.Sequences
{
    /// <summary>
    /// Represents the sequence of prime numbers: natural numbers that are greater than one and
    /// cannot be represented as the product of two smaller natural numbers.
    /// 
    /// URL: https://en.wikipedia.org/wiki/Prime_number
    /// </summary>
    class PrimeNumberSequence : IEnumerable<long>
    {
        private PrimeNumberSequence()
        {

        }

        public static PrimeNumberSequence All => new PrimeNumberSequence();

        IEnumerator<long> IEnumerable<long>.GetEnumerator()
        {
            yield return 2;

            long n = 3;
            while (true)
            {
                yield return n;
                do n += 2; while (!n.IsPrime());
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<long>)this).GetEnumerator();
        }
    }
}
