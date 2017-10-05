using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerSharp.Sequences
{
    public class Fibonacci : IEnumerable<int>
    {
        int first, second;

        private Fibonacci(int first, int second)
        {
            this.first = first;
            this.second = second;
        }

        public static Fibonacci Start(int first = 1, int second = 2)
        {
            return new Fibonacci(first, second);
        }

        IEnumerator<int> IEnumerable<int>.GetEnumerator()
        {
            yield return first;
            while (true)
            {
                yield return second;
                second = first + second;
                first = second - first;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<int>)this).GetEnumerator();
        }
    }
}
