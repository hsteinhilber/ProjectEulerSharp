using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerSharp.Sequences
{
    public sealed class Fibonacci : IEnumerable<int>
    {
        int _first, _second;

        private Fibonacci(int first, int second)
        {
            _first = first;
            _second = second;
        }

        public static Fibonacci Start(int first = 1, int second = 2)
        {
            return new Fibonacci(first, second);
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
