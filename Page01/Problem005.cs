﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using ProjectEulerSharp.Sequences;
using System.Linq;
using System.Collections.ObjectModel;

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
            var resultFactors = new PrimeFactorCollection();

            foreach (var num in Enumerable.Range(1, 20))
                resultFactors.Add(GetPrimeFactors(num));
            return resultFactors.ComputeValue();
        }

        private IEnumerable<PrimeFactor> GetPrimeFactors(long value)
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
    }
}
