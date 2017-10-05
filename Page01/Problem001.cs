using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Collections.Generic;

namespace ProjectEulerSharp.Page01
{
    /**************************************************************************
     * URL: https://projecteuler.net/problem=1
     * If we list all the natural numbers below 10 that are multiples of 3 or 5, 
     * we get 3, 5, 6 and 9. The sum of these multiples is 23.
     * 
     * Find the sum of all the multiples of 3 or 5 below 1000.
     **************************************************************************/
    [TestClass]
    public class Problem001 : ProblemBase
    {
        [TestMethod]
        public void Solve()
        {
            int result = Enumerable.Range(1, 999).Where(x => ((x % 3 == 0) || (x % 5 == 0))).Sum();

            LogResult(result);
        }


    }
}
