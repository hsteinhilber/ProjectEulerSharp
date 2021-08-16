using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerSharp.Sequences
{
    /// <summary>
    /// Represents a Collatz sequence that start with any positive integer n. Then each term is obtained from the previous term as follows: 
    ///   1) if the previous term is even, the next term is one half of the previous term
    ///   2) if the previous term is odd, the next term is 3 times the previous term plus 1. 
    ///   
    /// URL: https://en.wikipedia.org/wiki/Collatz_conjecture
    /// </summary>
    internal class CollatzSequence : IEnumerable<long>
    {
        private long _current;

        private CollatzSequence(long first) => _current = first;

        public static CollatzSequence Start(long first)
        {
            return new CollatzSequence(first);
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
