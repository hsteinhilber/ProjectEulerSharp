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
     * URL: http://projecteuler.net/problem=047
     * Title: Distinct Prime Factors
     * The first two consecutive numbers to have two distinct prime factors are:

     * 14 = 2 × 7
     * 15 = 3 × 5
     * 
     * The first three consecutive numbers to have three distinct prime factors are:
     * 
     * 644 = 2² × 7 × 23
     * 645 = 3 × 5 × 43
     * 646 = 2 × 17 × 19.
     * 
     * Find the first four consecutive integers to have four distinct prime factors 
     * each. What is the first of these numbers?
     ******************************************************************************/
    [TestClass]
    public class Problem047 : ProblemBase
    {
        protected override long SolutionImplementation()
        {
            Assert.Inconclusive("Test is not yet implemented.");
            return -1;
        }
    }
}