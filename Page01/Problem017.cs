using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProjectEulerSharp.Page01
{
    /******************************************************************************
     * URL: http://projecteuler.net/problem=17
     * Title: Number letter counts
     * If the numbers 1 to 5 are written out in words: one, two, three, four, five, then there are 
     * 3 + 3 + 5 + 4 + 4 = 19 letters used in total.
     * 
     * If all the numbers from 1 to 1000 (one thousand) inclusive were written out in words, how 
     * many letters would be used?
     * 
     * 
     * NOTE: Do not count spaces or hyphens. For example, 342 (three hundred and forty-two) 
     * contains 23 letters and 115 (one hundred and fifteen) contains 20 letters. The use of "and" 
     * when writing out numbers is in compliance with British usage.
     ******************************************************************************/
    [TestClass]
    [TestCategory("Fast")]
    [TestCategory("Difficulty-05")]
    public class Problem017 : ProblemBase
    {
        protected override long ExpectedAnswer => 21124;

        private readonly IList<char> LETTERS = 
            new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
        private readonly IList<string> DIGITS =
            new string[] { "", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", 
                "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
        private readonly IList<string> TENS =
            new string[] { "", "", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };

        protected override long SolutionImplementation()
        {
            return Enumerable.Range(1, 1000).Sum(i => CountLetters(i));
        }

        private int CountLetters(int i)
        {
            return NumberToText(i).Replace("-", "").Replace(" ", "").Length;
        }

        // TODO: This method is limited to numbers <= 999,999 and >= 1
        private string NumberToText(int i)
        {
            var thousands = i / 1000;
            var hundreds = (i % 1000) / 100;
            var remainder = i % 100;
            var result = new StringBuilder();
            
            if (thousands > 0)
            {
                result.Append(NumberToText(thousands));
                result.Append(" thousand ");
            }

            if (hundreds > 0)
            {
                result.Append(DIGITS[hundreds]);
                result.Append(" hundred ");
            }

            if ((thousands > 0 || hundreds > 0) && remainder > 0)
                result.Append("and ");

            if (remainder < 20)
            {
                result.Append(DIGITS[remainder]);
            }
            else
            {
                result.Append(TENS[remainder / 10]);
                if (remainder % 10 > 0)
                {
                    result.Append("-");
                    result.Append(DIGITS[remainder % 10]);
                }
            }
            return result.ToString();
        }
    }
}
