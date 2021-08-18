using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectEulerSharp.Sequences;
using System;
using System.Linq;

namespace ProjectEulerSharp.Page01
{
    /******************************************************************************
     * URL: http://projecteuler.net/problem=24
     * Title: Lexicographic permutations
     * A permutation is an ordered arrangement of objects. For example, 3124 is one possible permutation 
     * of the digits 1, 2, 3 and 4. If all of the permutations are listed numerically or alphabetically, 
     * we call it lexicographic order. The lexicographic permutations of 0, 1 and 2 are:
     * 
     *      012   021   102   120   201   210
     * 
     * What is the millionth lexicographic permutation of the digits 0, 1, 2, 3, 4, 5, 6, 7, 8 and 9?
     ******************************************************************************/
    [TestClass]
    [TestCategory("Fast")]
    [TestCategory("Difficulty-05")]
    public class Problem024 : ProblemBase
    {
        protected override long ExpectedAnswer => 2783915460;

        protected override long SolutionImplementation()
        {
            return long.Parse(new String(new LexicographicSequence<char>("0123456789").Take(1000000).Last().ToArray()));
        }
    }
}

