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
     * URL: http://projecteuler.net/problem=049
     * Title: Prime Permutations
     * The arithmetic sequence, 1487, 4817, 8147, in which each of the terms 
     * increases by 3330, is unusual in two ways: (i) each of the three terms are 
     * prime, and, (ii) each of the 4-digit numbers are permutations of one another.
     * 
     * There are no arithmetic sequences made up of three 1-, 2-, or 3-digit primes, 
     * exhibiting this property, but there is one other 4-digit increasing sequence.
     * 
     * What 12-digit number do you form by concatenating the three terms in this 
     * sequence?
     ******************************************************************************/
    [TestClass]
    public class Problem049 : ProblemBase
    {
        protected override long SolutionImplementation()
        {
            Assert.Inconclusive("Test is not yet implemented.");
            return -1;
        }
    }
}