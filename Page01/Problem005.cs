using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

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
        protected override long SolutionImplementation()
        {
            var resultFactors = new Dictionary<long, int>();

            // For each number i => 1..20
            //   Get the prime factors of i
            //   For each prime factor
            //   if result factors contains prime
            //      if count(prime) in prime factors of i > count(prime) in factors of result
            //         set count(prime) in factors of result = count(prime) in prime factors of i
            //   else
            //      add count(prime) in prime factors of i to factors of result
            // result = sum(prime * count(prime)) for each factor of result

            return 0;
        }

        private IDictionary<long, int> GetPrimeFactors(long value)
        {
            var factors = new Dictionary<long, int>();

            return factors;
        }
    }
}
