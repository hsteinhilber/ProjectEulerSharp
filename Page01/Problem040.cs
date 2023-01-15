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
     * URL: http://projecteuler.net/problem=040
     * Title: Champernowne's constant
     * An irrational decimal fraction is created by concatenating the positive integers:
     * 
     * 0.123456789101112131415161718192021...
     * 
     * It can be seen that the 12th digit of the fractional part is 1.
     * 
     * If d(n) represents the nth digit of the fractional part, find the value of the following expression.
     * 
     * d(1) × d(10) × d(100) × d(1000) × d(10000) × d(100000) × d(1000000)
     ******************************************************************************/
    [TestClass]
    public class Problem040 : ProblemBase
    {
        protected override long SolutionImplementation()
        {
            Assert.Inconclusive("Test is not yet implemented.");
            return -1;
        }
    }
}