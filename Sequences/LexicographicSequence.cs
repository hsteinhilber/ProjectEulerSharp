using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerSharp.Sequences
{
    /// <summary>
    /// Represents a sequence of lexicographic permutations of a given list of elements. The
    /// given elements must be:
    ///    1) sortable - implementing <see cref="IComparable{T}"/>
    ///    2) unique - no duplicate elements may exist
    ///    
    /// URL: https://en.wikipedia.org/wiki/Lexicographic_order
    /// </summary>
    /// <typeparam name="T">Any comparable (implements <see cref="IComparable{T}"/></typeparam>
    class LexicographicSequence<T> : IEnumerable<IList<T>> where T: IComparable<T>
    {
        private List<T> current;

        public LexicographicSequence(IEnumerable<T> initial)
        {
            current = new List<T>(initial);
        }

        IEnumerator<IList<T>> IEnumerable<IList<T>>.GetEnumerator()
        {
            current.Sort();
            var last = new List<T>(current); last.Reverse();

            while (!current.SequenceEqual(last))
            {
                yield return current;
                ComputeNextPermutation(current);
            }
            yield return last; 
        }

        private void ComputeNextPermutation(List<T> current)
        {
            // Workiing right to left, find the first element that is smaller than the one to its right (leftElement)
            int index = current.Count - 2;
            while (index >= 0 && current[index].CompareTo(current[index + 1]) >= 0) index--;
            var leftElement = index;

            // Find the smallest element to the right of leftElement that is also larger than leftElement (rightElement)
            var rightElement = leftElement + 1;
            for (index = rightElement; index < current.Count; index++)
                if (current[index].CompareTo(current[leftElement]) > 0 && current[index].CompareTo(current[rightElement]) <= 0)
                    rightElement = index;

            // Swap leftElement and rightElement
            var temp = current[leftElement];
            current[leftElement] = current[rightElement];
            current[rightElement] = temp;

            // Sort everything to the right of leftElement from smallest to largest
            current.Sort(leftElement + 1, current.Count - leftElement - 1, null);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<IList<T>>)this).GetEnumerator();
        }
    }
}
