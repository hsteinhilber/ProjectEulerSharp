using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Collections.Generic;
using ProjectEulerSharp.Sequences;

namespace ProjectEulerSharp.Page01
{
    /**************************************************************************
     * URL: https://projecteuler.net/problem=3
     * Title: Largest prime factor
     * The prime factors of 13195 are 5, 7, 13 and 29.
     * 
     * What is the largest prime factor of the number 600851475143?
     **************************************************************************/
    [TestClass]
    public class Problem003 : ProblemBase
    {
        protected override long ExpectedAnswer => 6857;

        protected override long SolutionImplementation()
        {
            const long NUMBER = 600851475143;
            long root = (long)Math.Ceiling(Math.Sqrt(NUMBER));
            return PrimeNumberSequence.All.TakeWhile(x => x <= root).Where(x => NUMBER % x == 0).Max();
        }
    }
}
