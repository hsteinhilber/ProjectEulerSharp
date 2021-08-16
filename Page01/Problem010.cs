using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectEulerSharp.Sequences;
using System.Linq;

namespace ProjectEulerSharp.Page01
{
    /**************************************************************************
     * URL: https://projecteuler.net/problem=10
     * Title: Summation of primes
     * The sum of the primes below 10 is 2 + 3 + 5 + 7 = 17.
     * 
     * Find the sum of all the primes below two million.
     **************************************************************************/
    [TestClass]
    public class Problem010 : ProblemBase
    {
        protected override long ExpectedAnswer => 142913828922;

        protected override long SolutionImplementation()
        {
            return PrimeNumberSequence.All.TakeWhile(x => x < 2000000).Sum();
        }
    }
}
