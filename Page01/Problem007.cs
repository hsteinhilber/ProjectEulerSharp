using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectEulerSharp.Sequences;
using System.Linq;

namespace ProjectEulerSharp.Page01
{
    /**************************************************************************
     * URL: https://projecteuler.net/problem=7
     * By listing the first six prime numbers: 2, 3, 5, 7, 11, and 13, we can 
     * see that the 6th prime is 13.
     *
     * What is the 10,001st prime number?
     **************************************************************************/
    [TestClass]
    public class Problem007 : ProblemBase
    {
        protected override long ExpectedAnswer => 104743;

        protected override long SolutionImplementation()
        {
            return Primes.All.Skip(10000).First();
        }
    }
}
