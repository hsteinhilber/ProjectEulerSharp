using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectEulerSharp.Sequences;
using System;
using System.Linq;

namespace ProjectEulerSharp.Page01
{
    /******************************************************************************
     * URL: http://projecteuler.net/problem=035
     * Title: Circular primes
     * The number, 197, is called a circular prime because all rotations of the digits: 197, 971, and 719, are themselves prime.
     * 
     * There are thirteen such primes below 100: 2, 3, 5, 7, 11, 13, 17, 31, 37, 71, 73, 79, and 97.
     * 
     * How many circular primes are there below one million?
     ******************************************************************************/
    [TestClass]
    public class Problem035 : ProblemBase
    {
        // protected override long ExpectedAnswer => 0;

        protected override long SolutionImplementation()
        {
            return PrimeNumberSequence.All.TakeWhile(n => n < 1000000).Where(n => n.IsCircularPrime()).Count();
        }
    }
}

