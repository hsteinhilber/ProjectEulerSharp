﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.ComponentModel.Design;
using System.Security.Cryptography;
using ProjectEulerSharp.Sequences;
using System.Collections.Generic;

namespace ProjectEulerSharp.Page01
{
    /******************************************************************************
     * URL: http://projecteuler.net/problem=045
     * Title: Triangular, pentagonal, and hexagonal
     * Triangle, pentagonal, and hexagonal numbers are generated by the following formulae:
     * 
     * Triangle	 	    T(n)=n(n+1)/2	 	    1, 3, 6, 10, 15, ...
     * Pentagonal	 	P(n)=n(3n−1)/2	 	    1, 5, 12, 22, 35, ...
     * Hexagonal	 	H(n)=n(2n−1)	 	    1, 6, 15, 28, 45, ...
     * It can be verified that T(285) = P(165) = H(143) = 40755.
     * 
     * Find the next triangle number that is also pentagonal and hexagonal.
     ******************************************************************************/
    [TestClass]
    public class Problem045 : ProblemBase
    {
        protected override long SolutionImplementation()
        {
            Assert.Inconclusive("Test is not yet implemented.");
            return -1;
        }
    }
}