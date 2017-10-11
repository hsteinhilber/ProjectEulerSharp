using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectEulerSharp
{
    /**************************************************************************
     * LargeNumber - Stores an arbitrary length unsigned integer
     * 
     **************************************************************************/
    public class LargeNumber : IComparable<LargeNumber>, IComparable, IEquatable<LargeNumber>
    {
        private const long CARRY_SIZE = 1000000000000000000L;

        private readonly long[] values;

        public static readonly LargeNumber Zero = new LargeNumber();

        #region Constructors

        public LargeNumber()
        {
            this.values = new long[] { 0 };
        }

        public LargeNumber(long value)
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(value), nameof(LargeNumber) + " is unsigned and cannot be negative");

            if (value < CARRY_SIZE)
                this.values = new long[] { value };
            else
                this.values = new long[] { value % CARRY_SIZE, value / CARRY_SIZE };
        }

        public LargeNumber(LargeNumber value)
        {
            if (value == null) throw new ArgumentNullException(nameof(value));

            this.values = new long[value.values.Length];
            value.values.CopyTo(this.values, 0);
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

            if (this.values.Length < other.values.Length) return -1;
            if (this.values.Length > other.values.Length) return 1;

            for (int index = this.values.Length - 1; index >= 0; index--)
            {
                long diff = this.values[index] - other.values[index];
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
            for (int index = this.values.Length - 1; index >= 0; index--)
                result.Append(this.values[index]);
            return result.ToString();
        }

        public override bool Equals(object obj)
        {
            return this.Equals((LargeNumber)obj);
        }

        public override int GetHashCode()
        {
            return 1649527923 + EqualityComparer<long[]>.Default.GetHashCode(this.values);
        }

        #endregion

        #region Static methods

        public LargeNumber FromString(string value)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Operator overloads

        public static LargeNumber operator +(LargeNumber lhs, LargeNumber rhs)
        {
            if (lhs == null) throw new ArgumentNullException(nameof(lhs));
            if (rhs == null) throw new ArgumentNullException(nameof(rhs));

            throw new NotImplementedException();
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
            if (number.values.Length == 1) return number.values[0];

            return number.values[0] + ((number.values[1] * CARRY_SIZE) & 0x7FFFFFFFFFFFFFFF);
        }

        public static implicit operator LargeNumber(long number)
        {
            return new LargeNumber(number);
        }

        #endregion
    }
}

