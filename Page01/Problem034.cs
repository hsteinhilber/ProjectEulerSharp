using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace ProjectEulerSharp.Page01
{
    /******************************************************************************
     * URL: http://projecteuler.net/problem=034
     * Title: Digit factorials
     * 145 is a curious number, as 1! + 4! + 5! = 1 + 24 + 120 = 145.
     * 
     * Find the sum of all numbers which are equal to the sum of the factorial of their digits.
     * 
     * Note: As 1! = 1 and 2! = 2 are not sums they are not included.
     ******************************************************************************/
    [TestClass]
    [TestCategory("Fast")]
    [TestCategory("Difficulty-05")]
    public class Problem034 : ProblemBase
    {
        protected override long ExpectedAnswer => 40730;

        protected override long SolutionImplementation()
        {
            long sum = 0;
            for (int number = 10; number < 50000; number++)
            {
                var factorials = number.ToString().ToCharArray().Select(n => ((long)(n - '0')).Factorial()).Sum();
                if (number == factorials)
                    sum += number;
            }
            return sum;
        }
    }
}

