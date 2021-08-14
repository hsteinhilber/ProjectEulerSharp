using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerSharp.Sequences
{
    class Primes : IEnumerable<long>
    {
        private Primes()
        {

        }

        public static Primes All => new Primes();

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
