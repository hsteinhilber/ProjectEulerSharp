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
    [TestCategory("Fast")]
    [TestCategory("Difficulty-05")]
    public class Problem038 : ProblemBase
    {
        protected override long ExpectedAnswer => 932718654;

        protected override long SolutionImplementation()
        {
            long result = 0;

            // * For every number, the first iteration is guaranteed to produce an iteration with the same
            //   number of digits as the value itself.
            // * Every subsequent iteration will produce a number with the same number of digits or one more.
            // * Numbers greater than 9999 will not be able to produce a 9-digit concatenated product as the smallest
            //   concatenated product they can produce would contain 10-digits.


            // Numbers 1-9 require n=5..9 to produce a 9-digit concatenated product.
            // The initial 1-digit iteration & four 2-digit iterations can reach a 9-digit result. (n=5)
            // The initial 1-digit iteration & eight 1-digit iterations can reach a 9-digit result. (n=9)
            for (long i = 1; i <= 9; i++)
                for (int n = 5; n <= 9; n++)
                {
                    var product = i.ConcatenatedProduct(n);
                    if (product > result && product.IsPandigital())
                        result = product;
                }

            // Numbers 10-99 require n=4 to produce a 9-digit concatenated product.
            // Three 2-digit and one 3-digit iterations are required to reach a 9-digit result.
            for (long i = 10; i <= 99; i++)
            {
                var product = i.ConcatenatedProduct(4);
                if (product > result && product.IsPandigital())
                    result = product;
            }

            // Numbers 100-999 require n=3 to produce a 9-digit concatenated product.
            // Three 3-digit iterations are required to reach a 9-digit result.
            for (long i = 100; i <= 999; i++)
            {
                var product = i.ConcatenatedProduct(3);
                if (product > result && product.IsPandigital())
                    result = product;
            }

            // Numbers 1000-9999 require n=2 to produce a 9-digit concatenated product.
            // A 4-digit iteration and a 5-digit iteration are required to reach a 9-digit result.
            for (long i = 1000; i <= 9999; i++)
            {
                var product = i.ConcatenatedProduct(2);
                if (product > result && product.IsPandigital())
                    result = product;
            }

            return result;
        }
    }
}
