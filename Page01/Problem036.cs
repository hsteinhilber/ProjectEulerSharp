using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ProjectEulerSharp.Page01
{
    /******************************************************************************
     * URL: http://projecteuler.net/problem=036
     * Title: Double-base palindromes
     * The decimal number, 585 = 10010010012 (binary), is palindromic in both bases.
     * 
     * Find the sum of all numbers, less than one million, which are palindromic in base 10 and base 2.
     * 
     * (Please note that the palindromic number, in either base, may not include leading zeros.)
     ******************************************************************************/
    [TestClass]
    public class Problem036 : ProblemBase
    {
        protected override long ExpectedAnswer => 872187;

        protected override long SolutionImplementation()
        {
            var sum = 0;
            for (int number = 1; number < 1000000; number += 2)
            {
                var binary = Convert.ToString(number, 2);
                if (number.IsPalindrome() && binary.IsPalindrome())
                    sum += number;
            }
            return sum;
        }
    }
}

