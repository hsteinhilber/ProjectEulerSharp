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
        public static IEnumerable<PrimeFactor> GetPrimeFactors(this int value)
        {
            return GetPrimeFactors((long)value);
        }

        public static IEnumerable<PrimeFactor> GetPrimeFactors(this long value)
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

        public static bool IsPalindrome(this int value)
        {
            return IsPalindrome((long)value);
        }

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

        public static long Product(this IEnumerable<int> collection)
        {
            return collection.Aggregate(1L, (p, v) => p * v);
        }

        public static long Product(this IEnumerable<long> collection)
        {
            return collection.Aggregate(1L, (p, v) => p * v);
        }

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

        public static BigInteger Factorial(this long number)
        {
            if (number <= 1) return number;

            return number * Factorial(number - 1);
        }

        public static long Combination(this long number, long r)
        {
            // n >= r >= 0
            if (number < 0) throw new ArgumentOutOfRangeException("number must be non-negative", nameof(number));
            if (r < 0) throw new ArgumentOutOfRangeException("number must be non-negative", nameof(r));

            if (number < r) return 0;

            // nPr = n! / r!*(n-r)!
            return (long)(number.Factorial() / (r.Factorial() * (number - r).Factorial()));
        }

        public static long Permutation(this long number, long r)
        {
            // n >= r >= 0
            if (number < 0) throw new ArgumentOutOfRangeException("number must be non-negative", nameof(number));
            if (r < 0) throw new ArgumentOutOfRangeException("number must be non-negative", nameof(r));

            if (number < r) return 0;

            // nPr = n! / (n-r)!
            return (long)(number.Factorial() / (number - r).Factorial());
        }

        public static bool IsPrime(this long num)
        {
            if (num < 2 || num % 2 == 0)
                return false;

            for (long i = 3; i <= num / i; i += 2)
                if (num % i == 0) return false;

            return true;
        }

        public static long GetSumOfDivisors(this long number)
        {
            var result = 1L;
            var right = number;

            for (var left = 2L; left < right; ++left)
            {
                if (number % left == 0)
                {
                    right = number / left;
                    result += left;
                    if (left != right)
                        result += right;
                }
            }
            
            return result;
        }

        public static bool IsAbundant(this long number)
        {
            return number < number.GetSumOfDivisors();
        }

        public static bool IsPerfect(this long number)
        {
            return number == number.GetSumOfDivisors();
        }

        public static bool IsDeficient(this long number)
        {
            return number > number.GetSumOfDivisors();
        }
    }
}
