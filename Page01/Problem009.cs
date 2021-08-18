using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProjectEulerSharp.Page01
{
    /**************************************************************************
     * URL: https://projecteuler.net/problem=9
     * Title: Special Pythagorean triplet
     * A Pythagorean triplet is a set of three natural numbers, a < b < c, for which,
     * 
     * a^2 + b^2 = c^2
     * For example, 3^2 + 4^2 = 9 + 16 = 25 = 5^2.
     * 
     * There exists exactly one Pythagorean triplet for which a + b + c = 1000.
     * Find the product abc.
     **************************************************************************/
    [TestClass]
    [TestCategory("Fast")]
    [TestCategory("Difficulty-05")]
    public class Problem009 : ProblemBase
    {
        protected override long ExpectedAnswer => 31875000;

        private const int SUM = 1000;

        protected override long SolutionImplementation()
        {
            for (var a = 1; a <= (SUM - 3) / 3; ++a)
            {
                for (var b = a + 1; b <= (SUM - a) / 2; ++b)
                {
                    var c = SUM - (a + b);

                    if (IsPythagoreanTriple(a, b, c))
                        return a * b * c;
                }
            }
            return 0;
        }

        bool IsPythagoreanTriple(int a, int b, int c)
        {
            if (a >= b) return false;
            if (b >= c) return false;

            return a * a + b * b == c * c;
        }
    }
}
