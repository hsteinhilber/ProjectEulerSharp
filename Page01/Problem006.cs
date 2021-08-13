using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace ProjectEulerSharp.Page01
{
    /**************************************************************************
     * URL: https://projecteuler.net/problem=6
     * Title: Sum square difference
     * The sum of the squares of the first ten natural numbers is,
     *     1^2 + 2^2 + ... + 10^2 = 385
     *
     * The square of the sum of the first ten natural numbers is,
     *     (1 + 2 + ... + 10)^2 = 55^2 = 3025
     *
     * Hence the difference between the sum of the squares of the first ten 
     * natural numbers and the square of the sum is 3025 − 385 = 2640.
     * 
     * Find the difference between the sum of the squares of the first one 
     * hundred natural numbers and the square of the sum.
     **************************************************************************/
    [TestClass]
    public class Problem006 : ProblemBase
    {
        protected override long ExpectedAnswer => 25164150;

        protected override long SolutionImplementation()
        {
            var sumOfSquares = Enumerable.Range(1, 100).Select(x => x * x).Sum();
            var sum = Enumerable.Range(1, 100).Sum();
            var squareOfSum = sum * sum;
            return squareOfSum - sumOfSquares;
        }
    }
}
