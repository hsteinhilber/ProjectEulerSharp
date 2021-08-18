using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProjectEulerSharp.Page01
{
    /******************************************************************************
     * URL: http://projecteuler.net/problem=20
     * Title: Factorial digit sum
     * n! means n × (n − 1) × ... × 3 × 2 × 1
     * 
     * For example, 10! = 10 × 9 × ... × 3 × 2 × 1 = 3628800,
     * and the sum of the digits in the number 10! is 3 + 6 + 2 + 8 + 8 + 0 + 0 = 27.
     * 
     * Find the sum of the digits in the number 100!
     ******************************************************************************/
    [TestClass]
    [TestCategory("Fast")]
    [TestCategory("Difficulty-05")]
    public class Problem020 : ProblemBase
    {
        protected override long ExpectedAnswer => 648;

        protected override long SolutionImplementation()
        {
            return 100L.Factorial().ToString().ToCharArray().Sum(c => c - '0'); 
        }
    }
}
