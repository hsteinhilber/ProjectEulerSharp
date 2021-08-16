using System;
using System.Linq;

namespace ProjectEulerSharp
{
    /// <summary>
    /// Represents a prime number and the number of times the prime is a factor of another number. 
    /// </summary>
    /// <remarks>
    /// A number can have a prime number be a factor multiple times. For instance, the number 12 has 
    /// three prime factors: 2, 2, and 3. So in this case it would have 2^2 and 3^1 as its prime factors. 
    /// In this case, there would be two <see cref="PrimeFactor"/>: {Prime: 2, Count: 2} and {Prime: 3, Count: 1}
    /// </remarks>
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

        /// <summary>
        /// Computes the overall value of the prime factor by return (Prime)^(Count).
        /// </summary>
        /// <returns>Computes the product of Prime multiplied Count times</returns>
        public long ComputeValue()
        {
            return Enumerable.Repeat(Prime, Count).Product();
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

        public static PrimeFactor operator ++(PrimeFactor value)
        {
            return new PrimeFactor(value.Prime, value.Count + 1);
        }

        public static PrimeFactor operator --(PrimeFactor value)
        {
            if (value.Count == 0)
                throw new InvalidOperationException("Cannot reduce exponent to less than 0");

            return new PrimeFactor(value.Prime, value.Count - 1);
        }

        public static bool operator <(PrimeFactor lhs, PrimeFactor rhs)
        {
            return lhs.CompareTo(rhs) < 0;
        }

        public static bool operator >(PrimeFactor lhs, PrimeFactor rhs)
        {
            return lhs.CompareTo(rhs) > 0;
        }

        public static bool operator <=(PrimeFactor lhs, PrimeFactor rhs)
        {
            return lhs.CompareTo(rhs) <= 0;
        }

        public static bool operator >=(PrimeFactor lhs, PrimeFactor rhs)
        {
            return lhs.CompareTo(rhs) >= 0;
        }

        public static bool operator ==(PrimeFactor lhs, PrimeFactor rhs)
        {
            return lhs.Equals(rhs);
        }

        public static bool operator !=(PrimeFactor lhs, PrimeFactor rhs)
        {
            return !lhs.Equals(rhs);
        }

        public static implicit operator PrimeFactor(long prime)
        {
            return new PrimeFactor(prime, 0);
        }
    }
}
