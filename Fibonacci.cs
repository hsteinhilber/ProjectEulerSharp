using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerSharp
{
    public class Fibonacci : IEnumerable<int>
    {
        int first, second;

        public Fibonacci(int first = 1, int second = 2)
        {
            this.first = first;
            this.second = second;
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
