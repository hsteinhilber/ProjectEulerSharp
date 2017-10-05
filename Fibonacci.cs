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
        int first = 1, second = 2;

        IEnumerator<int> IEnumerable<int>.GetEnumerator()
        {
            yield return first;
            yield return second;
            while (true)
            {
                var next = first + second;
                first = second;
                second = next;
                yield return next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<int>)this).GetEnumerator();
        }
    }
}
