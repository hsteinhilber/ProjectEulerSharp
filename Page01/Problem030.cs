using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace ProjectEulerSharp.Page01
{
    /******************************************************************************
     * URL: http://projecteuler.net/problem=030
     * Title: Digit fifth powers
     * Surprisingly there are only three numbers that can be written as the sum of fourth powers of their digits:
     * 
     * 1634 = 1^4 + 6^4 + 3^4 + 4^4
     * 8208 = 8^4 + 2^4 + 0^4 + 8^4
     * 9474 = 9^4 + 4^4 + 7^4 + 4^4
     * As 1 = 1^4 is not a sum it is not included.
     * 
     * The sum of these numbers is 1634 + 8208 + 9474 = 19316.
     * 
     * Find the sum of all the numbers that can be written as the sum of fifth powers of their digits.
     ******************************************************************************/
    [TestClass]
    public class Problem030 : ProblemBase
    {
        protected override long ExpectedAnswer => 443839;

        protected override long SolutionImplementation()
        {
            long sum = 0;
            for (int n = 10; n < UPPER_LIMIT; n++)
                if (n == ComputeSumOfFifthPowerOfDigits(n))
                    sum += n;
            return sum;
        }

        private const long UPPER_LIMIT = 250000;

        private long ComputeSumOfFifthPowerOfDigits(long n)
        {
            return (from c in n.ToString() select ToTheFifth((long)(c - '0'))).Sum();
        }

        private long ToTheFifth(long n) => n * n * n * n * n;
    }
}

