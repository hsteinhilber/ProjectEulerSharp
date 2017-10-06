using System.Collections.Generic;
using System.Linq;
using System.Collections;

namespace ProjectEulerSharp
{
    public class PrimeFactorCollection : ICollection<PrimeFactor>
    {
        private Dictionary<long, PrimeFactor> factors = new Dictionary<long, PrimeFactor>();

        public long ComputeValue()
        {
            return factors.Values.Aggregate(1L, (a, v) => a * v.ComputeValue());
        }

        public int Count => factors.Count;

        bool ICollection<PrimeFactor>.IsReadOnly => false;

        public void Add(IEnumerable<PrimeFactor> collection)
        {
            foreach (var factor in collection)
                this.Add(factor);
        }

        public void Add(PrimeFactor item)
        {
            if (factors.ContainsKey(item.Prime))
            {
                if (factors[item.Prime].Count < item.Count)
                    factors[item.Prime] = item;
            }
            else
            {
                factors.Add(item.Prime, item);
            }
        }

        public void Clear()
        {
            factors.Clear();
        }

        bool ICollection<PrimeFactor>.Contains(PrimeFactor item)
        {
            return factors.ContainsValue(item);
        }

        void ICollection<PrimeFactor>.CopyTo(PrimeFactor[] array, int arrayIndex)
        {
            factors.Values.CopyTo(array, arrayIndex);
        }

        public IEnumerator<PrimeFactor> GetEnumerator()
        {
            return factors.Values.GetEnumerator();
        }

        public bool Remove(PrimeFactor item)
        {
            return factors.Remove(item.Prime);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
