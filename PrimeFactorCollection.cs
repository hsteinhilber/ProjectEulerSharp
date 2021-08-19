using System.Collections.Generic;
using System.Linq;
using System.Collections;
using System.Text;

namespace ProjectEulerSharp
{
    public sealed class PrimeFactorCollection : ICollection<PrimeFactor>
    {
        private readonly Dictionary<long, PrimeFactor> _factors = new Dictionary<long, PrimeFactor>();

        public long ComputeValue()
        {
            return _factors.Values.Select(f => f.ComputeValue()).Product();
        }

        public int Count => _factors.Count;

        bool ICollection<PrimeFactor>.IsReadOnly => false;

        public void Add(IEnumerable<PrimeFactor> collection)
        {
            foreach (var factor in collection)
                this.Add(factor);
        }

        public void Add(PrimeFactor item)
        {
            if (_factors.ContainsKey(item.Prime))
            {
                if (_factors[item.Prime].Count < item.Count)
                    _factors[item.Prime] = item;
            }
            else
            {
                _factors.Add(item.Prime, item);
            }
        }

        public void Clear()
        {
            _factors.Clear();
        }

        bool ICollection<PrimeFactor>.Contains(PrimeFactor item)
        {
            return _factors.ContainsValue(item);
        }

        void ICollection<PrimeFactor>.CopyTo(PrimeFactor[] array, int arrayIndex)
        {
            _factors.Values.CopyTo(array, arrayIndex);
        }

        public IEnumerator<PrimeFactor> GetEnumerator()
        {
            return _factors.Values.GetEnumerator();
        }

        public bool Remove(PrimeFactor item)
        {
            return _factors.Remove(item.Prime);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.AppendFormat("[{0}]", this.ComputeValue());
            result.Append(" { ");
            foreach (var pf in this)
                result.AppendFormat("{0}^{1}, ", pf.Prime, pf.Count);
            if (this.Count > 0)
                result.Remove(result.Length - 2, 2);
            result.Append(" }");
            return result.ToString();
        }
    }
}
