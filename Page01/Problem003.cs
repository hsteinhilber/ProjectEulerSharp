using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Collections.Generic;

namespace ProjectEulerSharp.Page01
{
    /**************************************************************************
     * URL: https://projecteuler.net/problem=3
     * The prime factors of 13195 are 5, 7, 13 and 29.
     * 
     * What is the largest prime factor of the number 600851475143?
     **************************************************************************/
    [TestClass]
    public class Problem003 : ProblemBase
    {
        public const long ANSWER = 6857;

        [TestMethod]
        public void Solve()
        {
            const long NUMBER = 600851475143;
            long root = (long)Math.Ceiling(Math.Sqrt(NUMBER));
            var primes = new Primes();

            long result = primes.TakeWhile(x => x <= root).Where(x => NUMBER % x == 0).Max();
            LogResult(result);
            Assert.AreEqual(ANSWER, result);
        }
    }
}
