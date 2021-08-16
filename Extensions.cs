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
        /// Computes all of the prime factors of a given number and returns them as a collection.
        /// </summary>
        /// <param name="value">An <see cref="int"/> value to compute the prime factors of</param>
        /// <returns>A collection of <see cref="PrimeFactor"/></returns>
        public static IEnumerable<PrimeFactor> GetPrimeFactors(this int value)
        {
            return GetPrimeFactors((long)value);
        }

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
        /// Verifies if a number is a palindrome number (the same backwards and forwards)
        /// </summary>
        /// <param name="value">An <see cref="int"/> value to verify</param>
        /// <returns><code>true</code> if the number is a palindrome, otherwise <code>false</code></returns>
        public static bool IsPalindrome(this int value)
        {
            return IsPalindrome((long)value);
        }

        /// <summary>
        /// Verifies if a number is a palindrome number (the same backwards and forwards)
        /// </summary>
        /// <param name="value">A <see cref="long"/> value to verify</param>
        /// <returns><code>true</code> if the number is a palindrome, otherwise <code>false</code></returns>
        public static bool IsPalindrome(this long value)
        {
            var digits = value.ToString().ToCharArray();
            var length = digits.Length;
            var midpoint = length / 2;
            for (int i = 0; i <= midpoint; ++i)
                if (digits[i] != digits[length - i - 1])
                    return false;
            return true;
        }

        /// <summary>
        /// Multiplies together all of the elements of a collection.
        /// </summary>
        /// <param name="collection">A collection of <see cref="int"/> values to multiply together</param>
        /// <returns>The total product after multiplying all of the elements of the collection</returns>
        public static long Product(this IEnumerable<int> collection)
        {
            return collection.Aggregate(1L, (p, v) => p * v);
        }

        /// <summary>
        /// Multiplies together all of the elements of a collection.
        /// </summary>
        /// <param name="collection">A collection of <see cref="long"/> values to multiply together</param>
        /// <returns>The total product after multiplying all of the elements of the collection</returns>
        public static long Product(this IEnumerable<long> collection)
        {
            return collection.Aggregate(1L, (p, v) => p * v);
        }

        public static BigInteger Sum(this IEnumerable<BigInteger> collection)
        {
            return collection.Aggregate((p, v) => p + v);
        }

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
            if (number <= 1) return number;

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
            if (num < 2 || num % 2 == 0)
                return false;

            for (long i = 3; i * i <= num; i += 2)
                if (num % i == 0) return false;

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
            return number < number.GetSumOfDivisors();
        }

        /// <summary>
        /// Verifies if a number is considered a perfect number. A perfect number is one that is equal to the sum of its proper divisors.
        /// </summary>
        /// <param name="number">The number to verify</param>
        /// <returns><code>true</code> if the number is perfect, otherwise <code>false</code></returns>
        public static bool IsPerfect(this long number)
        {
            return number == number.GetSumOfDivisors();
        }

        /// <summary>
        /// Verifies if a number is considered a deficient number. A deficient number is one that is greater than the sum of its proper divisors.
        /// </summary>
        /// <param name="number">The number to verify</param>
        /// <returns><code>true</code> if the number is deficient, otherwise <code>false</code></returns>
        public static bool IsDeficient(this long number)
        {
            return number > number.GetSumOfDivisors();
        }
    }
}
