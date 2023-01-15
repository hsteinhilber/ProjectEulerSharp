using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerSharp.Sequences
{
    /// <summary>
    /// Represents a sequence of pandigital numbers from 2 digits to 9.
    /// </summary>
    class PandigitalSequence : IEnumerable<long>
    {
        private IList<LexicographicSequence<char>> _pandigitals = new List<LexicographicSequence<char>>(10);

        public PandigitalSequence()
        {
            for (int i = 2; i <= 9; i++)
                _pandigitals.Add(new LexicographicSequence<char>(Enumerable.Range(1, i).Select(c => (char)(c + '0'))));
        }

        IEnumerator<long> IEnumerable<long>.GetEnumerator()
        {
            foreach (var lexiconograph in _pandigitals)
                foreach (var array in lexiconograph)
                {
                    long.TryParse(new String(array.ToArray()), out var value);
                    yield return value;
                }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<long>)this).GetEnumerator();
        }
    }
}
