using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerSharp
{
    struct Fraction : IComparable<Fraction>, IComparable, IEquatable<Fraction>
    {
        public long Numerator { get; }
        public long Denominator { get; }

        public Fraction(long numerator, long denominator)
        {
            Numerator = numerator;
            Denominator = denominator;
            if (denominator < 0)
            {
                Numerator = -Numerator;
                Denominator = -Denominator;
            }
        }

        public static Fraction operator *(Fraction left, Fraction right)
        {
            return new Fraction(left.Numerator * right.Numerator, left.Denominator * right.Denominator);
        }

        public static Fraction operator /(Fraction left, Fraction right)
        {
            return new Fraction(left.Numerator * right.Denominator, left.Denominator * right.Numerator);
        }

        public static Fraction operator +(Fraction left, Fraction right)
        {
            if (left.Denominator == right.Denominator)
                return new Fraction(left.Numerator + right.Numerator, left.Denominator);

            var lcm = left.Denominator.GetLeastCommonMultiple(right.Denominator);
            return new Fraction(left.Numerator * lcm / left.Denominator + right.Numerator * lcm / right.Denominator, lcm);
        }


        public static Fraction operator -(Fraction left, Fraction right)
        {
            if (left.Denominator == right.Denominator)
                return new Fraction(left.Numerator - right.Numerator, left.Denominator);

            var lcm = left.Denominator.GetLeastCommonMultiple(right.Denominator);
            return new Fraction(left.Numerator * lcm / left.Denominator + right.Numerator * lcm / right.Denominator, lcm);
        }

        public static Fraction operator -(Fraction fraction)
        {
            return new Fraction(-fraction.Numerator, fraction.Denominator);
        }

        public static bool operator ==(Fraction left, Fraction right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Fraction left, Fraction right)
        {
            return !(left == right);
        }

        public static bool operator <(Fraction left, Fraction right)
        {
            return left.CompareTo(right) < 0; 
        }

        public static bool operator <=(Fraction left, Fraction right)
        {
            return left.CompareTo(right) <= 0;
        }

        public static bool operator >(Fraction left, Fraction right)
        {
            return left.CompareTo(right) > 0;
        }

        public static bool operator >=(Fraction left, Fraction right)
        {
            return left.CompareTo(right) >= 0;
        }

        public decimal AsDecimal()
        {
            return (decimal)Numerator / (decimal)Denominator;
        }

        public Fraction Simplify()
        {
            var gcd = Numerator.GetGreatestCommonDivisor(Denominator);
            return new Fraction(Numerator / gcd, Denominator / gcd);
        }


        int IComparable.CompareTo(object obj)
        {
            if (!(obj is Fraction))
                throw new ArgumentException(nameof(obj), String.Format("{0} argument must be of type {1}", nameof(obj), typeof(Fraction)));

            return ((IComparable<Fraction>)this).CompareTo((Fraction)obj);
        }

        public int CompareTo(Fraction other)
        {
            var lcm = Denominator.GetLeastCommonMultiple(other.Denominator);
            return (Numerator * lcm / Denominator).CompareTo(other.Numerator * lcm / other.Denominator);
        }

        public bool Equals(Fraction other)
        {
            var lcm = Denominator.GetLeastCommonMultiple(other.Denominator);
            return (Numerator * lcm / Denominator).Equals(other.Numerator * lcm / other.Denominator);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Fraction))
                throw new ArgumentException(nameof(obj), String.Format("{0} argument must be of type {1}", nameof(obj), typeof(Fraction)));

            return ((IEquatable<Fraction>)this).Equals((Fraction)obj);
        }

        public override int GetHashCode()
        {
            int hashCode = -1534900553;
            hashCode = hashCode * -1521134295 + Numerator.GetHashCode();
            hashCode = hashCode * -1521134295 + Denominator.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            return String.Format("{0}/{1}", Numerator, Denominator);
        }
    }
}
