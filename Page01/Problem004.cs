﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace ProjectEulerSharp.Page01
{
    /**************************************************************************
     * URL: https://projecteuler.net/problem=4
     * Title: Largest paliindrome product
     * A palindromic number reads the same both ways. The largest palindrome 
     * made from the product of two 2-digit numbers is 9009 = 91 × 99.
     * 
     * Find the largest palindrome made from the product of two 3-digit numbers.
     **************************************************************************/
    [TestClass]
    [TestCategory("Fast")]
    [TestCategory("Difficulty-05")]
    public class Problem004 : ProblemBase
    {
        protected override long ExpectedAnswer => 906609;

        protected override long SolutionImplementation()
        {
            long largest = 0;
            foreach (var i in Enumerable.Range(100, 900))
                foreach (var j in Enumerable.Range(i, 1000 - i))
                    if ((i * j).IsPalindrome() && i * j > largest)
                        largest = i * j;
            return largest;
        }

        
    }
}
