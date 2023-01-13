using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.ComponentModel.Design;
using System.Security.Cryptography;
using ProjectEulerSharp.Sequences;

namespace ProjectEulerSharp.Page01
{
    /******************************************************************************
     * URL: http://projecteuler.net/problem=038
     * Title: Pandigital Multiples
     * Take the number 192 and multiply it by each of 1, 2, and 3:
     * 
     * 192 × 1 = 192
     * 192 × 2 = 384
     * 192 × 3 = 576
     * By concatenating each product we get the 1 to 9 pandigital, 192384576. We will call 
     * 192384576 the concatenated product of 192 and (1,2,3)
     * 
     * The same can be achieved by starting with 9 and multiplying by 1, 2, 3, 4, and 5, 
     * giving the pandigital, 918273645, which is the concatenated product of 9 and (1,2,3,4,5).
     * 
     * What is the largest 1 to 9 pandigital 9-digit number that can be formed as the 
     * concatenated product of an integer with (1,2, ... , n) where n > 1?
     ******************************************************************************/
    [TestClass]
    public class Problem038 : ProblemBase
    {
        protected override long ExpectedAnswer => 932718654;

        protected override long SolutionImplementation()
        {
            long result = 0;
            for (long i = 1; i <= 9999; i++)
                for (int n = 2; n <= 9; n++)
                {
                    var product = i.ConcatenatedProduct(n);
                    if (product > result && product.IsPandigital())
                        result = product;
                }
            return result;
        }
    }
}
