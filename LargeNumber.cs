using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEulerSharp
{
    /**************************************************************************
     * LargeNumber - Stores an arbitrary length unsigned integer
     * 
     **************************************************************************/
    public class LargeNumber : IComparable<LargeNumber>, IComparable, IEquatable<LargeNumber>
    {
        private const long CarrySize = 1000000000000000000L;
        private const int DigitsPerSegment = 18;
        private const int DigitsPerTuple = 3;
        private const int TuplesPerSegment = DigitsPerSegment / DigitsPerTuple;

        private long[] _values;

        private long[] Values
        {
            get => this._values ?? (this._values = new long[] { 0 });
            set => this._values = value;
        }

        public static readonly LargeNumber Zero = new LargeNumber();

        #region Constructors

        public LargeNumber()
        {
            this.Values = new long[] { 0 };
        }

        public LargeNumber(long value)
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(value), nameof(LargeNumber) + " is unsigned and cannot be negative");

            if (value < CarrySize)
                this.Values = new long[] { value };
            else
                this.Values = new long[] { value % CarrySize, value / CarrySize };
        }

        public LargeNumber(LargeNumber value)
        {
            if (value == null) throw new ArgumentNullException(nameof(value));

            this.Values = new long[value.Values.Length];
            value.Values.CopyTo(this.Values, 0);
        }

        /// <summary>
        /// Create a new instance of <c>LargeNumber</c> from a list of values.
        /// </summary>
        /// <param name="values">A list of <see cref="System.UInt32"/> in order from highest significance to lowest</param>
        /// <example>
        /// <code>var value = new LargeNumber(18,000,000,000,025,000);</code>
        /// Creates a new LargeNumber with a value of 18 quadrillion 25 thousand. 
        /// </example>
        /// <remarks>
        /// Each <see cref="System.UInt32"/> should be in the range of 0-999. It is recommended that numbers less than
        /// 100 are padded with preceeding '0' (i.e., 3 => 003) for all but the first (most significant) value. This 
        /// makes the number format to look much like the actual value that will be represented by the <c>LargeNumber</c>.
        /// </remarks>
        public LargeNumber(params uint[] values)
        {
            if (values == null) throw new ArgumentNullException(nameof(values));
            if (!values.All(v => v < 1000)) throw new ArgumentOutOfRangeException(nameof(values), "All values of constructor must be less than 1000");

            var length = values.Length;
            var remainder = length % TuplesPerSegment;
            var max = length / TuplesPerSegment;
            this.Values = new long[max + (remainder > 0 ? 1 : 0)];

            for (int m = 0; m < max; m++)
            {
                var i = length - TuplesPerSegment * (m + 1);
                this.Values[m] = (from n in Enumerable.Range(i, TuplesPerSegment)
                                  select (long)(values[n] * Math.Pow(10, DigitsPerTuple * (i - n + TuplesPerSegment - 1)))).Sum();
            }

            if (remainder > 0)
            {
                this.Values[max] = (from n in Enumerable.Range(0, remainder)
                                    select (long)(values[n] * Math.Pow(10, DigitsPerTuple * (remainder - n - 1)))).Sum();
            }
        }

        private LargeNumber(long[] values)
        {
            this.Values = values ?? throw new ArgumentNullException(nameof(values));
        }

        #endregion

        #region Interface implementations

        int IComparable.CompareTo(object obj)
        {
            return this.CompareTo((LargeNumber)obj);
        }

        public int CompareTo(LargeNumber other)
        {
            if (other == null) throw new ArgumentNullException(nameof(other));

            if (this.Values.Length < other.Values.Length) return -1;
            if (this.Values.Length > other.Values.Length) return 1;

            for (int index = this.Values.Length - 1; index >= 0; index--)
            {
                long diff = this.Values[index] - other.Values[index];
                if (diff != 0) return (int)diff;
            }

            return 0;
        }

        public bool Equals(LargeNumber other)
        {
            return this.CompareTo(other) == 0;
        }

        #endregion

        #region Base overrides

        public override string ToString()
        {
            var result = new StringBuilder();
            for (int index = this.Values.Length - 1; index >= 0; index--)
                result.AppendFormat("{0,18}", this.Values[index]);
            result.Replace(" ", "0");
            return result.ToString();
        }

        public override bool Equals(object obj)
        {
            return this.Equals((LargeNumber)obj);
        }

        public override int GetHashCode()
        {
            return 1649527923 + EqualityComparer<long[]>.Default.GetHashCode(this.Values);
        }

        #endregion

        #region Static methods

        public LargeNumber Parse(string value)
        {
            if (value == null) throw new ArgumentNullException(nameof(value));

            var result = new long[value.Length / DigitsPerSegment + (value.Length % DigitsPerSegment > 0 ? 1 : 0)];

            int resultIndex = 0, valueIndex = value.Length - DigitsPerSegment;
            while (valueIndex > 0)
            {
                result[resultIndex++] = long.Parse(value.Substring(valueIndex, DigitsPerSegment));
                valueIndex -= DigitsPerSegment;
            }

            var length = DigitsPerSegment + valueIndex;
            result[resultIndex] = long.Parse(value.Substring(0, length));

            return new LargeNumber(result);
        }

        #endregion

        #region Operator overloads

        public static LargeNumber operator +(LargeNumber lhs, LargeNumber rhs)
        {
            if (lhs == null) throw new ArgumentNullException(nameof(lhs));
            if (rhs == null) throw new ArgumentNullException(nameof(rhs));

            if (lhs < rhs) return (rhs + lhs);

            var resultLength = lhs.Values.Length;
            var carry = 0L;
            var result = new long[resultLength];

            Array.Copy(rhs.Values, result, rhs.Values.Length);
            for (var index = 0; index < resultLength; index++)
            {
                result[index] += lhs.Values[index] + carry;
                carry = result[index] / CarrySize;

                if (carry > 0)
                {
                    result[index] %= CarrySize;

                    if (index == resultLength - 1)
                    {
                        Array.Resize(ref result, resultLength + 1);
                        result[index + 1] = carry;
                    }
                }
            }

            return new LargeNumber(result);
        }

        public static LargeNumber operator -(LargeNumber lhs, LargeNumber rhs)
        {
            if (lhs == null) throw new ArgumentNullException(nameof(lhs));
            if (rhs == null) throw new ArgumentNullException(nameof(rhs));
            if (lhs < rhs) throw new OverflowException("Operation would result in negative value in unsigned type");
            if (lhs == rhs) return LargeNumber.Zero;

            throw new NotImplementedException();
        }

        public static bool operator <(LargeNumber lhs, LargeNumber rhs)
        {
            if (lhs == null) throw new ArgumentNullException(nameof(lhs));
            if (rhs == null) throw new ArgumentNullException(nameof(rhs));

            return lhs.CompareTo(rhs) < 0;
        }

        public static bool operator <=(LargeNumber lhs, LargeNumber rhs)
        {
            if (lhs == null) throw new ArgumentNullException(nameof(lhs));
            if (rhs == null) throw new ArgumentNullException(nameof(rhs));

            return lhs.CompareTo(rhs) <= 0;
        }

        public static bool operator >(LargeNumber lhs, LargeNumber rhs)
        {
            if (lhs == null) throw new ArgumentNullException(nameof(lhs));
            if (rhs == null) throw new ArgumentNullException(nameof(rhs));

            return lhs.CompareTo(rhs) > 0;
        }

        public static bool operator >=(LargeNumber lhs, LargeNumber rhs)
        {
            if (lhs == null) throw new ArgumentNullException(nameof(lhs));
            if (rhs == null) throw new ArgumentNullException(nameof(rhs));

            return lhs.CompareTo(rhs) >= 0;
        }

        public static bool operator ==(LargeNumber lhs, LargeNumber rhs)
        {
            if (lhs == null) return rhs == null;
            if (rhs == null) return false;

            return lhs.Equals(rhs);
        }

        public static bool operator !=(LargeNumber lhs, LargeNumber rhs)
        {
            if (lhs == null) return !(rhs == null);
            if (rhs == null) return true;

            return !lhs.Equals(rhs);
        }

        #endregion

        #region Casting overloads

        public static explicit operator long(LargeNumber number)
        {
            if (number.Values.Length == 1) return number.Values[0];

            return number.Values[0] + ((number.Values[1] * CarrySize) & 0x7FFFFFFFFFFFFFFF);
        }

        public static implicit operator LargeNumber(long number)
        {
            return new LargeNumber(number);
        }

        #endregion
    }
}

