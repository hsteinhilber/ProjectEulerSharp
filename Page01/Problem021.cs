using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProjectEulerSharp.Page01
{
    /******************************************************************************
     * URL: http://projecteuler.net/problem=21
     * Title: Factorial digit sum
     * Let d(n) be defined as the sum of proper divisors of n (numbers less than n which divide evenly into n).
     * If d(a) = b and d(b) = a, where a ≠ b, then a and b are an amicable pair and each of a and b are called amicable numbers.
     * 
     * For example, the proper divisors of 220 are 1, 2, 4, 5, 10, 11, 20, 22, 44, 55 and 110; therefore d(220) = 284. The proper 
     * divisors of 284 are 1, 2, 4, 71 and 142; so d(284) = 220.
     * 
     * Evaluate the sum of all the amicable numbers under 10000.
     ******************************************************************************/
    [TestClass]
    public class Problem021 : ProblemBase
    {
        // protected override long ExpectedAnswer => 0;

        protected override long SolutionImplementation()
        {
            var values = new List<long>();

            for (long a = 2; a < 10000; a++)
            {
                if (!values.Contains(a))
                {
                    long b = a.GetDivisors().Sum() - a;
                    if (a != b)
                    {
                        if (b.GetDivisors().Sum() - b == a)
                        {
                            values.Add(a);
                            values.Add(b);
                        }
                    }
                }
            }
            return values.Sum();
        }
    }
}
