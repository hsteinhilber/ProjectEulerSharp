using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProjectEulerSharp.Page01
{
    /**************************************************************************
     * URL: https://projecteuler.net/problem=9
     * A Pythagorean triplet is a set of three natural numbers, a < b < c, for which,
     * 
     * a^2 + b^2 = c^2
     * For example, 3^2 + 4^2 = 9 + 16 = 25 = 5^2.
     * 
     * There exists exactly one Pythagorean triplet for which a + b + c = 1000.
     * Find the product abc.
     **************************************************************************/
    [TestClass]
    public class Problem009 : ProblemBase
    {
        protected override long ExpectedAnswer => 31875000;

        protected override long SolutionImplementation()
        {
            for (var a = 1; a <= 332; ++a)
            {
                for (var b = a + 1; b <= 498; ++b)
                {
                    var c = 1000 - (a + b);
                    if (c <= b) break;

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
