using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.ComponentModel.Design;
using System.Security.Cryptography;
using ProjectEulerSharp.Sequences;
using System.Collections.Generic;

namespace ProjectEulerSharp.Page01
{
    /******************************************************************************
     * URL: http://projecteuler.net/problem=043
     * Title: Sub-string Divisibility
     * The number, 1406357289, is a 0 to 9 pandigital number because it is made up 
     * of each of the digits 0 to 9 in some order, but it also has a rather 
     * interesting sub-string divisibility property.
     * 
     * Let d1 be the 1st digit, d2 be the 2nd digit, and so on. In this way, we 
     * note the following:
     * 
     *     d(2)d(3)d(4)=406 is divisible by 2
     *     d(3)d(4)d(5)=063 is divisible by 3
     *     d(4)d(5)d(6)=635 is divisible by 5
     *     d(5)d(6)d(7)=357 is divisible by 7
     *     d(6)d(7)d(8)=572 is divisible by 11
     *     d(7)d(8)d(9)=728 is divisible by 13
     *     d(8)d(9)d(10)=289 is divisible by 17
     * 
     * Find the sum of all 0 to 9 pandigital numbers with this property.
     ******************************************************************************/
    [TestClass]
    public class Problem043 : ProblemBase
    {
        protected override long SolutionImplementation()
        {
            Assert.Inconclusive("Test is not yet implemented.");
            return -1;
        }
    }
}