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
     * URL: http://projecteuler.net/problem=046
     * Title: Goldbach's other conjecture
     * It was proposed by Christian Goldbach that every odd composite number can be 
     * written as the sum of a prime and twice a square.
     * 
     * 9 = 7 + 2×1^2
     * 15 = 7 + 2×2^2
     * 21 = 3 + 2×3^2
     * 25 = 7 + 2×3^2
     * 27 = 19 + 2×2^2
     * 33 = 31 + 2×1^2
     * 
     * It turns out that the conjecture was false.
     * 
     * What is the smallest odd composite that cannot be written as the sum of a 
     * prime and twice a square?
     ******************************************************************************/
    [TestClass]
    public class Problem046 : ProblemBase
    {
        protected override long SolutionImplementation()
        {
            Assert.Inconclusive("Test is not yet implemented.");
            return -1;
        }
    }
}