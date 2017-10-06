﻿using ProjectEulerSharp.Sequences;
using System.Collections.Generic;
using System.Linq;

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
    }
}