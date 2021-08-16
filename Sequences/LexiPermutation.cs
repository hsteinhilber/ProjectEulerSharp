using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerSharp.Sequences
{
    class LexiPermutation<T> : IEnumerable<IList<T>> where T: IComparable<T>
    {
        private List<T> current;

        public LexiPermutation(IEnumerable<T> initial)
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
                UpdatePermutation(current);
            }
            yield return last;
            //Let us consider the string “ABCDEF”. Let previously printed permutation be “DCFEBA”. The next permutation in sorted order should be “DEABCF”. Let us understand
            //above steps to find next permutation.The ‘first character’ will be ‘C’. The ‘second character’ will be ‘E’. After swapping these two, we get “DEFCBA”. The final
            //step is to sort the substring after the character original index of ‘first character’. Finally, we get “DEABCF”. 
        }

        private void UpdatePermutation(List<T> current)
        {
            int index = current.Count - 2;
            while (index >= 0 && current[index].CompareTo(current[index + 1]) >= 0) index--;
            var first = index;

            var second = first + 1;
            for (index = first + 1; index < current.Count; index++)
                if (current[index].CompareTo(current[first]) > 0 && current[index].CompareTo(current[second]) <= 0)
                    second = index;

            var temp = current[first];
            current[first] = current[second];
            current[second] = temp;

            current.Sort(first + 1, current.Count - first - 1, null);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<IList<T>>)this).GetEnumerator();
        }
    }
}
