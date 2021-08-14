using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectEulerSharp.Sequences;

namespace ProjectEulerSharp.Page01
{
    /**************************************************************************
     * URL: https://projecteuler.net/problem=14
     * Title: Longest Collatz sequence
     * The following iterative sequence is defined for the set of positive integers:
     *
     *     n → n/2 (n is even)
     *     n → 3n + 1 (n is odd)
     *
     * Using the rule above and starting with 13, we generate the following sequence:
     *
     *    13 → 40 → 20 → 10 → 5 → 16 → 8 → 4 → 2 → 1
     * 
     * It can be seen that this sequence (starting at 13 and finishing at 1) contains 
     * 10 terms. Although it has not been proved yet (Collatz Problem), it is thought 
     * that all starting numbers finish at 1.
     * 
     * Which starting number, under one million, produces the longest chain?
     * 
     * NOTE: Once the chain starts the terms are allowed to go above one million.
     **************************************************************************/

    [TestClass]
    public class Problem014 : ProblemBase
    {
        protected override long ExpectedAnswer => 837799;

        private readonly Dictionary<long, int> _chainLengths = new Dictionary<long, int>();

        protected override long SolutionImplementation()
        {
            long result = -1;
            int longestChain = -1;

            foreach (long chainStart in Enumerable.Range(3, 1000000))
            {
                var length = GetChainLength(chainStart);
                if (length > longestChain)
                {
                    result = chainStart;
                    longestChain = length;
                }
            }

            return result;
        }

        private int GetChainLength(long chainStart)
        {
            // return Collatz.Start(chainStart).Count();
            if (chainStart == 1)
                return 1;

            if (_chainLengths.ContainsKey(chainStart))
                return _chainLengths[chainStart];

            if (chainStart % 2 == 0)
                return _chainLengths[chainStart] = (1 + GetChainLength(chainStart / 2));
            else
                return _chainLengths[chainStart] = (1 + GetChainLength(3 * chainStart + 1));
        }

    }
}
