﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.ComponentModel.Design;
using System.Security.Cryptography;

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
    [TestCategory("Fast")]
    [TestCategory("Difficulty-05")]
    public class Problem036 : ProblemBase
    {
        protected override long ExpectedAnswer => 872187;

        protected override long SolutionImplementation()
        {
            return (from number in Enumerable.Range(1, 1000000).Where(i => i % 2 != 0)
                    where number.IsPalindrome() && Convert.ToString(number, 2).IsPalindrome()
                    select number).Sum();

        }
    }
}

