using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using ProjectEulerSharp.Sequences;
using System.Linq;

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
            var resultFactors = new Dictionary<long, int>();

            foreach (var num in Enumerable.Range(1, 20))
            {
                var factors = GetPrimeFactors(num);
                foreach (var prime in factors.Keys)
                {
                    if (!resultFactors.ContainsKey(prime))
                        resultFactors[prime] = 0;
                    resultFactors[prime] = Math.Max(resultFactors[prime], factors[prime]);
                }
            }
            return (long)resultFactors.Aggregate(1.0d, (current, factor) => current * Math.Pow(factor.Key, factor.Value));
        }

        private IDictionary<long, int> GetPrimeFactors(long value)
        {
            var factors = new Dictionary<long, int>();
            var current = value;

            foreach (var prime in Primes.All.TakeWhile(x => x <= value))
            {
                factors[prime] = 0;
                while (current % prime == 0)
                {
                    factors[prime]++;
                    current = current / prime;
                }
                if (current == 1)
                    return factors;
            }
            return factors;
        }
    }
}
