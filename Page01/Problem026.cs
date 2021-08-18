using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;
using System.Text.RegularExpressions;

namespace ProjectEulerSharp.Page01
{
    /******************************************************************************
     * URL: http://projecteuler.net/problem=026
     * Title: Reciprocal cycles
     * A unit fraction contains 1 in the numerator. The decimal representation of the unit fractions with denominators 2 to 10 are given:
     * 
     * 1/2	= 	0.5
     * 1/3	= 	0.(3)
     * 1/4	= 	0.25
     * 1/5	= 	0.2
     * 1/6	= 	0.1(6)
     * 1/7	= 	0.(142857)
     * 1/8	= 	0.125
     * 1/9	= 	0.(1)
     * 1/10	= 	0.1
     * Where 0.1(6) means 0.166666..., and has a 1-digit recurring cycle. It can be seen that 1/7 has a 6-digit recurring cycle.
     * 
     * Find the value of d < 1000 for which 1/d contains the longest recurring cycle in its decimal fraction part.
     ******************************************************************************/
    [TestClass]
    public class Problem026 : ProblemBase
    {
        // protected override long ExpectedAnswer => 0;

        protected override long SolutionImplementation()
        {
            long result = 0;
            var recurring = "";
            for (int d = 2; d < 1000; d++)
            {
                var value = UnitFractionToDecimalAsString(d);
                var match = Regex.Match(value.ToString(), @"0\.\d*?(?<recurring>\d+?)\k<recurring>{2,}");
                if (match.Groups["recurring"].Length > recurring.Length)
                {
                    recurring = match.Groups["recurring"].Value;
                    result = d;
                }
            }
            return result;
        }

        private string UnitFractionToDecimalAsString(int denominator)
        {
            var result = new StringBuilder("0.");

            var numerator = 10;
            do
            {
                result.Append(numerator / denominator);
                numerator = (numerator % denominator) * 10;
            } while (result.Length < 10000 && numerator > 0);

            return result.ToString();
        }
    }
}

