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
     * URL: http://projecteuler.net/problem=039
     * Title: Integer Right Triangles
     * If p is the perimeter of a right angle triangle with integral length sides, 
     * {a,b,c}, there are exactly three solutions for p = 120.
     * 
     * {20,48,52}, {24,45,51}, {30,40,50}
     * 
     * For which value of p ≤ 1000, is the number of solutions maximised?
     ******************************************************************************/
    [TestClass]
    public class Problem039 : ProblemBase
    {
        protected override long SolutionImplementation()
        {
            var counters = new Dictionary<int, int>();
            for (int p = 12; p <= 1000; p++)
            {
                counters[p] = 0;
                for (int a = 3; a <= (p / 3) - 1; a++)
                {
                    for (int b = (p / 2) - a; b <= (p - a) / 2; b++)
                    {
                        var c = p - a - b;
                        if (a * a + b * b == c * c)
                        { counters[p]++; }
                    }
                }
            }

            var maxSolutions = counters.Max(c => c.Value);
            return (from c in counters where c.Value == maxSolutions select c.Key).First();
        }
    }
}
