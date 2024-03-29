﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.ComponentModel.Design;
using System.Security.Cryptography;
using ProjectEulerSharp.Sequences;

namespace ProjectEulerSharp.Page01
{
    /******************************************************************************
     * URL: http://projecteuler.net/problem=037
     * Title: Truncatable Primes
     * The number 3797 has an interesting property. Being prime itself, it is possible to continuously 
     * remove digits from left to right, and remain prime at each stage: 3797, 797, 97, and 7.Similarly 
     * we can work from right to left: 3797, 379, 37, and 3.
     * 
     * Find the sum of the only eleven primes that are both truncatable from left to right and right 
     * to left.
     * 
     * NOTE: 2, 3, 5, and 7 are not considered to be truncatable primes.
     ******************************************************************************/
    [TestClass]
    [TestCategory("Fast")]
    [TestCategory("Difficulty-05")]
    public class Problem037 : ProblemBase
    {
        protected override long ExpectedAnswer => 748317;

        protected override long SolutionImplementation()
        {
            return (from prime in PrimeNumberSequence.All
                    where prime.IsRightTruncatable() && prime.IsLeftTruncatable()
                    select prime).Take(11).Sum();
        }
    }
}



