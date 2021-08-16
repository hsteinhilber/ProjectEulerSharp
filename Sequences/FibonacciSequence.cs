using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerSharp.Sequences
{
    /// <summary>
    /// Represents a sequence of Fibonacci numbers. Beginning with the two given numbers, each new number
    /// in the sequence is equal to the two numbers preceeding it.
    /// 
    /// URL: https://en.wikipedia.org/wiki/Fibonacci_number
    /// </summary>
    public sealed class FibonacciSequence : IEnumerable<int>
    {
        int _first, _second;

        private FibonacciSequence(int first, int second)
        {
            _first = first;
            _second = second;
        }

        public static FibonacciSequence Start(int first = 1, int second = 2)
        {
            return new FibonacciSequence(first, second);
        }

        IEnumerator<int> IEnumerable<int>.GetEnumerator()
        {
            yield return _first;
            while (true)
            {
                yield return _second;
                _second = _first + _second;
                _first = _second - _first;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<int>)this).GetEnumerator();
        }
    }
}
