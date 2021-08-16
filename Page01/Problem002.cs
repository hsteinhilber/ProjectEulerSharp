﻿using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using ProjectEulerSharp.Sequences;

namespace ProjectEulerSharp.Page01
{
    /**************************************************************************
     * URL: https://projecteuler.net/problem=2
     * Title: Even Fibonacci numbers
     * Each new term in the Fibonacci sequence is generated by adding the 
     * previous two terms. By starting with 1 and 2, the first 10 terms will be:
     * 
     * 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, ...
     * 
     * By considering the terms in the Fibonacci sequence whose values do not 
     * exceed four million, find the sum of the even-valued terms.
     **************************************************************************/
    [TestClass]
    public class Problem002 : ProblemBase 
    {
        protected override long ExpectedAnswer => 4613732;

        protected override long SolutionImplementation()
        {
            var fib = FibonacciSequence.Start();
            return (long)fib.TakeWhile(x => x < 4000000).Where(x => x % 2 == 0).Sum();
        }

    }
}
