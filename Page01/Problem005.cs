using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using ProjectEulerSharp.Sequences;
using System.Linq;
using System.Collections;
using System.Collections.ObjectModel;

namespace ProjectEulerSharp.Page01
{
    /**************************************************************************
     * URL: https://projecteuler.net/problem=5
     * 2520 is the smallest number that can be divided by each of the numbers 
     * from 1 to 10 without any remainder.
     * 
     * What is the smallest positive number that is evenly divisible by all of 
     * the numbers from 1 to 20?
     **************************************************************************/
    [TestClass]
    public class Problem005 : ProblemBase
    {
        protected override long ExpectedAnswer => 232792560;

        protected override long SolutionImplementation()
        {
            var resultFactors = new PrimeFactorCollection();

            foreach (var num in Enumerable.Range(1, 20))
                resultFactors.Add(GetPrimeFactors(num));
            return resultFactors.ComputeValue();
        }

        private IEnumerable<PrimeFactor> GetPrimeFactors(long value)
        {
            var factors = new PrimeFactorCollection();
            var current = value;

            foreach (var prime in Primes.All.TakeWhile(x => x <= value))
            {
                PrimeFactor factor = prime;
                while (current % prime == 0)
                {
                    factor++;
                    current /= prime;
                }
                factors.Add(factor);
                if (current == 1)
                    return factors;
            }
            return factors;
        }

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

        public struct PrimeFactor : IComparable<PrimeFactor>, IComparable, IEquatable<PrimeFactor>
        {
            public long Prime { get; }
            public int Count { get; }

            public PrimeFactor(long prime)
            {
                Prime = prime;
                Count = 0;
            }

            public PrimeFactor(long prime, int count)
            {
                Prime = prime;
                Count = count;
            }

            public long ComputeValue()
            {
                return Enumerable.Repeat(Prime, Count).Aggregate(1L, (a, v) => a * v);
            }

            public override string ToString()
            {
                return String.Format("{0}^{1}", Prime, Count);
            }
            
            public int CompareTo(PrimeFactor other)
            {
                return this.ComputeValue().CompareTo(other.ComputeValue());
            }

            int IComparable.CompareTo(object obj)
            {
                if (!(obj is PrimeFactor))
                    throw new ArgumentException("Invalid type for obj");

                return ((IComparable<PrimeFactor>)this).CompareTo((PrimeFactor)obj);
            }

            bool IEquatable<PrimeFactor>.Equals(PrimeFactor other)
            {
                return Prime == other.Prime &&
                       Count == other.Count;
            }

            public override bool Equals(object obj)
            {
                if (!(obj is PrimeFactor))
                {
                    return false;
                }

                var factor = (PrimeFactor)obj;
                return Prime == factor.Prime &&
                       Count == factor.Count;
            }

            public override int GetHashCode()
            {
                var hashCode = 1579827380;
                hashCode = hashCode * -1521134295 + base.GetHashCode();
                hashCode = hashCode * -1521134295 + Prime.GetHashCode();
                hashCode = hashCode * -1521134295 + Count.GetHashCode();
                return hashCode;
            }

            public static PrimeFactor operator++(PrimeFactor value)
            {
                return new PrimeFactor(value.Prime, value.Count + 1);
            }

            public static PrimeFactor operator--(PrimeFactor value)
            {
                if (value.Count == 0)
                    throw new InvalidOperationException("Cannot reduce exponent to less than 0");

                return new PrimeFactor(value.Prime, value.Count - 1);
            }

            public static bool operator<(PrimeFactor lhs, PrimeFactor rhs)
            {
                return lhs.CompareTo(rhs) < 0;
            }

            public static bool operator>(PrimeFactor lhs, PrimeFactor rhs)
            {
                return lhs.CompareTo(rhs) > 0;
            }

            public static bool operator<=(PrimeFactor lhs, PrimeFactor rhs)
            {
                return lhs.CompareTo(rhs) <= 0;
            }

            public static bool operator>=(PrimeFactor lhs, PrimeFactor rhs)
            {
                return lhs.CompareTo(rhs) >= 0;
            }

            public static bool operator==(PrimeFactor lhs, PrimeFactor rhs)
            {
                return lhs.Equals(rhs);
            }

            public static bool operator!=(PrimeFactor lhs, PrimeFactor rhs)
            {
                return !lhs.Equals(rhs);
            }

            public static implicit operator PrimeFactor(long prime)
            {
                return new PrimeFactor(prime, 0);
            }
        }
    }
}
