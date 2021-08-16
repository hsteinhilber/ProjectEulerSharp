using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectEulerSharp.Sequences;
using System.Linq;

namespace ProjectEulerSharp.Page01
{
    /******************************************************************************
     * URL: http://projecteuler.net/problem=25
     * Title: 1000-digit Fibonacci number
     * The Fibonacci sequence is defined by the recurrence relation:
     * 
     * Fn = Fn−1 + Fn−2, where F1 = 1 and F2 = 1.
     * Hence the first 12 terms will be:
     * 
     * F1 = 1
     * F2 = 1
     * F3 = 2
     * F4 = 3
     * F5 = 5
     * F6 = 8
     * F7 = 13
     * F8 = 21
     * F9 = 34
     * F10 = 55
     * F11 = 89
     * F12 = 144
     * The 12th term, F12, is the first term to contain three digits.
     * 
     * What is the index of the first term in the Fibonacci sequence to contain 1000 digits?
     ******************************************************************************/
    [TestClass]
    public class Problem025 : ProblemBase
    {
        protected override long ExpectedAnswer => 4782;

        protected override long SolutionImplementation()
        {
            return FibonacciSequence.Start(1, 1).TakeWhile(v => v.ToString().Length < 1000).Count() + 1;
        }
    }
}

