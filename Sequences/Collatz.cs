using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerSharp.Sequences
{
    internal class Collatz : IEnumerable<long>
    {
        private long _current;

        private Collatz(long first) => _current = first;

        public static Collatz Start(long first)
        {
            return new Collatz(first);
        }

        public IEnumerator<long> GetEnumerator()
        {
            yield return _current;
            while (_current > 1)
            {
                if (_current % 2 == 0)
                    _current /= 2;
                else
                    _current = 3 * _current + 1;
                yield return _current;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<long>)this).GetEnumerator();
        }
    }
}
