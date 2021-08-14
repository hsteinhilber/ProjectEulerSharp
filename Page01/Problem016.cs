using System;
using System.Collections.Generic;
using System.Numerics;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProjectEulerSharp.Page01
{
    /******************************************************************************
     * URL: http://projecteuler.net/problem=16
     * Title: Power digit sum
     * 2^15 = 32768 and the sum of its digits is 3 + 2 + 7 + 6 + 8 = 26.
     *
     * What is the sum of the digits of the number 2^1000?
     ******************************************************************************/
    [TestClass]
    public class Problem016 : ProblemBase
    {
        protected override long ExpectedAnswer => 1366;

        protected override long SolutionImplementation()
        {
            return BigInteger.Pow(2, 1000).ToString().ToCharArray().Sum(c => c - '0');
        }
    }
}
