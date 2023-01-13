using ProjectEulerSharp.Sequences;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Numerics;

namespace ProjectEulerSharp
{
    public static class Extensions
    {
        /// <summary>
        /// Memoized results for <see cref="IsAbundant(long)"/> function.
        /// </summary>
        private static readonly Dictionary<long, bool> _verifiedAbundance = new Dictionary<long, bool>();

        /// <summary>
        /// Numbers verified as prime by the <see cref="IsPrime"/> function, seeded with the first 10 primes.
        /// </summary>
        private static readonly HashSet<long> _verifiedPrimes = new HashSet<long>() { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29 };

        /// <summary>
        /// Computes all of the prime factors of a given number and returns them as a collection.
        /// </summary>
        /// <param name="value">An <see cref="int"/> value to compute the prime factors of</param>
        /// <returns>A collection of <see cref="PrimeFactor"/></returns>
        public static IEnumerable<PrimeFactor> GetPrimeFactors(this int value) => GetPrimeFactors((long)value);

        /// <summary>
        /// Computes all of the prime factors of a given number and returns them as a collection.
        /// </summary>
        /// <param name="value">A <see cref="long"/> value to compute the prime factors of</param>
        /// <returns>A collection of <see cref="PrimeFactor"/></returns>
        public static IEnumerable<PrimeFactor> GetPrimeFactors(this long value)
        {
            var factors = new PrimeFactorCollection();
            var current = value;

            foreach (var prime in PrimeNumberSequence.All.TakeWhile(x => x <= value))
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

        /// <summary>
        /// Verifies if a number is within a specified range.
        /// </summary>
        /// <param name="number">The number to test</param>
        /// <param name="min">The lower bound of the range, inclusive</param>
        /// <param name="max">The upper bound of the range, inclusive</param>
        /// <returns></returns>
        public static bool InRange(this long number, long min, long max) => (min <= number) && (number <= max);

        /// <summary>
        /// Verifies if a number is a palindrome number (the same backwards and forwards)
        /// </summary>
        /// <param name="value">A value to verify</param>
        /// <returns><code>true</code> if the value is a palindrome, otherwise <code>false</code></returns>
        public static bool IsPalindrome<T>(this T value) where T : struct => IsPalindrome(value.ToString());

        /// <summary>
        /// Verifies if a number is a palindrome number (the same backwards and forwards)
        /// </summary>
        /// <param name="value">A <see cref="string"/> value to verify</param>
        /// <returns><code>true</code> if the string is a palindrome, otherwise <code>false</code></returns>
        public static bool IsPalindrome(this string value)
        {
            var characters = value.ToCharArray();
            var length = characters.Length;
            var midpoint = length / 2;
            for (int i = 0; i <= midpoint; ++i)
                if (characters[i] != characters[length - i - 1])
                    return false;
            return true;
        }

        /// <summary>
        /// Multiplies together all of the elements of a collection.
        /// </summary>
        /// <param name="collection">A collection of <see cref="int"/> values to multiply together</param>
        /// <returns>The total product after multiplying all of the elements of the collection</returns>
        public static long Product(this IEnumerable<int> collection) => collection.Aggregate(1L, (p, v) => p * v);

        /// <summary>
        /// Multiplies together all of the elements of a collection.
        /// </summary>
        /// <param name="collection">A collection of <see cref="long"/> values to multiply together</param>
        /// <returns>The total product after multiplying all of the elements of the collection</returns>
        public static long Product(this IEnumerable<long> collection) => collection.Aggregate(1L, (p, v) => p * v);

        /// <summary>
        /// Multiplies together all of the fractions in a collection.
        /// </summary>
        /// <param name="collection">A collection of <see cref="Fraction"/> values to multiply together</param>
        /// <returns>The total product after multiplying all of the elements of the collection</returns>
        public static Fraction Product(this IEnumerable<Fraction> collection) 
            => collection.Aggregate(new Fraction(1, 1), (p, v) => p * v);

        /// <summary>
        /// Computes the sum of all <see cref="BigInteger"/> in a collection
        /// </summary>
        /// <param name="collection">The collection to aggregate</param>
        /// <returns>The sum of all elements</returns>
        public static BigInteger Sum(this IEnumerable<BigInteger> collection) => collection.Aggregate((p, v) => p + v);

        /// <summary>
        /// Computes the greatest common divisor (GCD) between two numbers
        /// </summary>
        /// <param name="left">The first number</param>
        /// <param name="right">The second number</param>
        /// <returns>The greatest common divisor that divides evenly into both numbers</returns>
        public static long GetGreatestCommonDivisor(this long left, long right)
        {
            return (from lpf in left.GetPrimeFactors()
                    join rpf in right.GetPrimeFactors() on lpf.Prime equals rpf.Prime
                    select lpf.Prime.Pow(lpf.Count < rpf.Count ? lpf.Count : rpf.Count)).Product();
        }

        /// <summary>
        /// Computes the smalles common multiple of two numbers
        /// </summary>
        /// <param name="left">The first number</param>
        /// <param name="right">The second number</param>
        /// <returns>The smallest number that both <paramref name="left"/> and <paramref name="right"/> divide into evenly</returns>
        public static long GetLeastCommonMultiple(this long left, long right)
        {
            return (from pf in left.GetPrimeFactors().Union(right.GetPrimeFactors())
                    group pf by pf.Prime into factor
                    select factor.Key.Pow(factor.Max(pf => pf.Count))).Product();
        }

        /// <summary>
        /// Computes an exponent as <see cref="Math.Pow(double, double)"/>, but using <see cref="long"/>
        /// </summary>
        /// <param name="number">The base number</param>
        /// <param name="exponent">The exponent to raise number to</param>
        /// <returns>The result of multiplying <paramref name="number"/> by itself <paramref name="exponent"/> times</returns>
        public static long Pow(this long number, int exponent) => Enumerable.Repeat(number, exponent).Product();

        /// <summary>
        /// Computes all of the divisors (numbers that will evenly divide into) a given value.
        /// </summary>
        /// <param name="number">A <see cref="long"/> value to compute the divisors of</param>
        /// <returns></returns>
        public static IEnumerable<long> GetDivisors(this long number)
        {
            var divisors = new List<long>() { 1 };
            var right = number;

            for (var left = 2L; left < right; ++left)
            {
                if (number % left == 0)
                {
                    right = number / left;
                    divisors.Add(left);
                    if (left != right)
                        divisors.Add(right);
                }
            }
            if (number > 1) divisors.Add(number);

            return divisors;
        }

        /// <summary>
        /// Computes the factorial of a given number (the product of all numbers in the sequence 1..n).
        /// </summary>
        /// <param name="number">The number to compute the factorial of</param>
        /// <returns>A <see cref="BigInteger"/> representing the factorial of the given number</returns>
        public static BigInteger Factorial(this long number)
        {
            if (number == 0 || number == 1) return 1;
            if (number < 0) return number;

            return number * Factorial(number - 1);
        }

        /// <summary>
        /// Computes the possible number of combinations (unordered selections) of <paramref name="number"/> items taking <paramref name="r"/> items at a time.
        /// </summary>
        /// <param name="number">The total number of items in the set</param>
        /// <param name="r">The number of items being selected at a time</param>
        /// <returns>The total number of possible combinations</returns>
        public static long Combination(this long number, long r)
        {
            // n >= r >= 0
            if (number < 0) throw new ArgumentOutOfRangeException("number must be non-negative", nameof(number));
            if (r < 0) throw new ArgumentOutOfRangeException("number must be non-negative", nameof(r));

            if (number < r) return 0;

            // nPr = n! / r!*(n-r)!
            return (long)(number.Factorial() / (r.Factorial() * (number - r).Factorial()));
        }

        /// <summary>
        /// Computes the number of permutations (ordered selections) of <paramref name="number"/> items taking <paramref name="r"/> items at a time.
        /// </summary>
        /// <param name="number">The total number of items in the set</param>
        /// <param name="r">The number of items being taken at a time</param>
        /// <returns>The total number of possible permutations</returns>
        public static long Permutation(this long number, long r)
        {
            // n >= r >= 0
            if (number < 0) throw new ArgumentOutOfRangeException("number must be non-negative", nameof(number));
            if (r < 0) throw new ArgumentOutOfRangeException("number must be non-negative", nameof(r));

            if (number < r) return 0;

            // nPr = n! / (n-r)!
            return (long)(number.Factorial() / (number - r).Factorial());
        }

        /// <summary>
        /// Verifies if a number is prime (can only be evenly divided by one and itself).
        /// </summary>
        /// <param name="num">The number to test</param>
        /// <returns><code>true</code> if the number is prime, otherwise <code>false</code></returns>
        public static bool IsPrime(this long num)
        {
            if (_verifiedPrimes.Contains(num)) return true;
            if (num < 2 || num % 2 == 0)
                return false;

            for (long i = 3; i * i <= num; i += 2)
                if (num % i == 0) return false;

            _verifiedPrimes.Add(num);
            return true;
        }

        /// <summary>
        /// Verifies if a number is a circular prime (a prime that all rotations of its digits are also prime).
        /// </summary>
        /// <param name="num">The number to test</param>
        /// <returns><code>true</code> if the number is a circular prime, otherwise <code>false</code></returns>
        public static bool IsCircularPrime(this long num)
        {
            if (!num.IsPrime()) return false;

            int digits = num.ToString().Length;
            long nextDigit = (long)Math.Pow(10, digits);
            for (int rotations = 1; rotations < digits; rotations++)
            {
                var tmp = num * 10;
                num = (tmp % nextDigit) + (tmp / nextDigit);
                if (!num.IsPrime()) return false;
            }

            return true;
        }

        /// <summary>
        /// Computes the sum of all the proper divisors of <paramref name="number"/>. Proper divisors are ones
        /// that are less than <paramref name="number"/>.
        /// </summary>
        /// <param name="number">The number to compute the sum for</param>
        /// <returns>The sum of all proper divisors</returns>
        public static long GetSumOfDivisors(this long number)
        {
            long result = 1;
            for (long divisor = 2; divisor * divisor <= number; divisor++)
            {
                if (number % divisor == 0)
                {
                    result += divisor;
                    if (divisor * divisor != number)
                        result += number / divisor;
                }
            }
            return result;
        }

        /// <summary>
        /// Verifies if a number is considered an abundant number. An abundant number is one that is less than the sum of its proper divisors.
        /// </summary>
        /// <param name="number">The number to verify</param>
        /// <returns><code>true</code> if the number is abundant, otherwise <code>false</code></returns>
        public static bool IsAbundant(this long number)
        {
            if (_verifiedAbundance.ContainsKey(number)) return _verifiedAbundance[number];
            return _verifiedAbundance[number] = (number < number.GetSumOfDivisors());
        }

        /// <summary>
        /// Verifies if a number is considered a perfect number. A perfect number is one that is equal to the sum of its proper divisors.
        /// </summary>
        /// <param name="number">The number to verify</param>
        /// <returns><code>true</code> if the number is perfect, otherwise <code>false</code></returns>
        public static bool IsPerfect(this long number) => number == number.GetSumOfDivisors();

        /// <summary>
        /// Verifies if a number is considered a deficient number. A deficient number is one that is greater than the sum of its proper divisors.
        /// </summary>
        /// <param name="number">The number to verify</param>
        /// <returns><code>true</code> if the number is deficient, otherwise <code>false</code></returns>
        public static bool IsDeficient(this long number) => number > number.GetSumOfDivisors();

        /// <summary>
        /// Verifies if a prime number is left truncatable (stays prime as the left-hand digits are removed). (2,3,5 & 7 are not truncatable)
        /// </summary>
        /// <param name="number">The number to verify (must be prime)</param>
        /// <returns><code>true</code> if the number is left truncatable</returns>
        public static bool IsLeftTruncatable(this long number)
        {
            if (number < 10) return false;
            var modulus = (long)Math.Pow(10, Math.Floor(Math.Log10(number)));
            while (modulus > 1)
            {
                if (!number.IsPrime()) return false;
                number %= modulus;
                modulus /= 10;
            }
            return number.IsPrime();
        }

        /// <summary>
        /// Verifies if a prime number is right truncatable (stays prime as the right-hand digits are removed).  (2,3,5 & 7 are not truncatable)
        /// </summary>
        /// <param name="number">The number to verify (must be prime)</param>
        /// <returns><code>true</code> if the number is right truncatable</returns>
        public static bool IsRightTruncatable(this long number)
        {
            if (number < 10) return false;
            while (number > 0)
            {
                if (!number.IsPrime()) return false;
                number /= 10;
            }
            return true;
        }
    }
}
