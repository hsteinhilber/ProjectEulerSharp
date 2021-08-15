using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectEulerSharp.Sequences;

namespace ProjectEulerSharp.Page01
{
    /******************************************************************************
     * URL: http://projecteuler.net/problem=23
     * Title: Non-abundant sums
     * A perfect number is a number for which the sum of its proper divisors is exactly equal to 
     * the number. For example, the sum of the proper divisors of 28 would be 1 + 2 + 4 + 7 + 14 = 28, 
     * which means that 28 is a perfect number.
     * 
     * A number n is called deficient if the sum of its proper divisors is less than n and it is 
     * called abundant if this sum exceeds n.
     * 
     * As 12 is the smallest abundant number, 1 + 2 + 3 + 4 + 6 = 16, the smallest number that 
     * can be written as the sum of two abundant numbers is 24. By mathematical analysis, it can 
     * be shown that all integers greater than 28123 can be written as the sum of two abundant 
     * numbers. However, this upper limit cannot be reduced any further by analysis even though 
     * it is known that the greatest number that cannot be expressed as the sum of two abundant 
     * numbers is less than this limit.
     * 
     * Find the sum of all the positive integers which cannot be written as the sum of two 
     * abundant numbers.
     ******************************************************************************/
    [TestClass]
    public class Problem023 : ProblemBase
    {
        protected override long ExpectedAnswer => 4179871;

        protected override long SolutionImplementation()
        {
            var values = new List<int>(Enumerable.Range(1, LARGEST_CANDIDATE));
            var abundants = new List<long>(AbundantNumbers.All.TakeWhile(i => i < LARGEST_CANDIDATE));

            for (int i = 0; i < abundants.Count; i++)
                for (int j = i; j < abundants.Count; j++)
                {
                    int sum = (int)(abundants[i] + abundants[j]);
                    if (values.Contains(sum))
                       values.Remove(sum);
                }

            return values.Sum();
        }

        const int LARGEST_CANDIDATE = 28123;
    }
}
