using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.ComponentModel.Design;
using System.Security.Cryptography;
using ProjectEulerSharp.Sequences;
using System.Collections.Generic;

namespace ProjectEulerSharp.Page01
{
    /******************************************************************************
     * URL: http://projecteuler.net/problem=050
     * Title: Consecutive prime sum
     * The prime 41, can be written as the sum of six consecutive primes:
     * 
     * 41 = 2 + 3 + 5 + 7 + 11 + 13
     * This is the longest sum of consecutive primes that adds to a prime below 
     * one-hundred.
     * 
     * The longest sum of consecutive primes below one-thousand that adds to a prime, 
     * contains 21 terms, and is equal to 953.
     * 
     * Which prime, below one-million, can be written as the sum of the most 
     * consecutive primes?
     ******************************************************************************/
    [TestClass]
    public class Problem050 : ProblemBase
    {
        protected override long SolutionImplementation()
        {
            Assert.Inconclusive("Test is not yet implemented.");
            return -1;
        }
    }
}