using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEulerSharp.Page01
{
    /******************************************************************************
     * URL: http://projecteuler.net/problem=032
     * Title: Pandigital products
     * We shall say that an n-digit number is pandigital if it makes use of all the digits 
     * 1 to n exactly once; for example, the 5-digit number, 15234, is 1 through 5 pandigital.
     * 
     * The product 7254 is unusual, as the identity, 39 × 186 = 7254, containing multiplicand, 
     * multiplier, and product is 1 through 9 pandigital.
     * 
     * Find the sum of all products whose multiplicand/multiplier/product identity can be 
     * written as a 1 through 9 pandigital.
     * 
     * HINT: Some products can be obtained in more than one way so be sure to only include it 
     * once in your sum.
     ******************************************************************************/
    [TestClass]
    public class Problem032 : ProblemBase
    {
        // protected override long ExpectedAnswer => 0;

        protected override long SolutionImplementation()
        {
            return GetPandigitalProducts().Distinct().Sum();
        }

        private IEnumerable<long> GetPandigitalProducts()
        {
            for (long a = 1; a <= 9; a++)
            {
                for (long b = 1234; b <= 9876; b++)
                {
                    long product = a * b;
                    if (product.InRange(1234, 9876) && IsPandigital(string.Format("{0}{1}{2}", a, b, product)))
                        yield return product;
                }
            }

            for (long a = 12; a <= 98; a++)
            {
                for (long b = 123; b <= 987; b++)
                {
                    long product = a * b;
                    if (product.InRange(1234, 9876) && IsPandigital(string.Format("{0}{1}{2}", a, b, product)))
                        yield return product;
                }
            }
        }

        private bool IsPandigital(string number)
        {
            List<char> digits = number.ToCharArray().ToList();
            digits.Sort();
            return (new string(digits.ToArray()) == "123456789");
        }
    }
}

