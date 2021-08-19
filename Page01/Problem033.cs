using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace ProjectEulerSharp.Page01
{
    /******************************************************************************
     * URL: http://projecteuler.net/problem=033
     * Title: Digit cancelling fractions
     * The fraction 49/98 is a curious fraction, as an inexperienced mathematician in 
     * attempting to simplify it may incorrectly believe that 49/98 = 4/8, which is 
     * correct, is obtained by cancelling the 9s.
     * 
     * We shall consider fractions like, 30/50 = 3/5, to be trivial examples.
     * 
     * There are exactly four non-trivial examples of this type of fraction, less than 
     * one in value, and containing two digits in the numerator and denominator.
     * 
     * If the product of these four fractions is given in its lowest common terms, 
     * find the value of the denominator.
     ******************************************************************************/
    [TestClass]
    [TestCategory("Difficulty-05")]
    public class Problem033 : ProblemBase
    {
        // protected override long ExpectedAnswer => 0;

        protected override long SolutionImplementation()
        {

            Fraction product = new Fraction(1, 1);
            foreach (var f in FindDigitCancellingFractions())
            {
                LogValue(f);
                product *= f;
                LogValue(product);
            }

            product = product.Simplify();
            LogValue(product);

            return product.Denominator;
        }

        private IEnumerable<Fraction> FindDigitCancellingFractions()
        {
            for (int n = 1; n <= 9; n++)
            {
                for (int d = 1; d <= 9; d++)
                {
                    for (int c = 1; c <= 9; c++)
                    {
                        Fraction simplified = new Fraction(n, d);

                        var tmp = new Fraction(10 * n + c, 10 * c + d);
                        if ((tmp.Numerator < tmp.Denominator) && (tmp == simplified))
                            yield return tmp;

                        tmp = new Fraction(10 * n + c, 10 * d + c);
                        if ((tmp.Numerator < tmp.Denominator) && (tmp == simplified))
                            yield return tmp;

                        tmp = new Fraction(10 * c + n, 10 * c + d);
                        if ((tmp.Numerator < tmp.Denominator) && (tmp == simplified))
                            yield return tmp;

                        tmp = new Fraction(10 * c + n, 10 * d + c);
                        if ((tmp.Numerator < tmp.Denominator) && (tmp == simplified))
                            yield return tmp;
                    }
                }
            }
        }
    }
}

