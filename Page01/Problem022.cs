using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProjectEulerSharp.Page01
{
    /******************************************************************************
     * URL: http://projecteuler.net/problem=22
     * Title: Names scores
     * Using names.txt (right click and 'Save Link/Target As...'), a 46K text file containing over 
     * five-thousand first names, begin by sorting it into alphabetical order. Then working out the 
     * alphabetical value for each name, multiply this value by its alphabetical position in the 
     * list to obtain a name score.
     * 
     * For example, when the list is sorted into alphabetical order, COLIN, which is worth 
     * 3 + 15 + 12 + 9 + 14 = 53, is the 938th name in the list. So, COLIN would obtain a score of 
     * 938 × 53 = 49714.
     * 
     * What is the total of all the name scores in the file?
     ******************************************************************************/
    [TestClass]
    public class Problem022 : ProblemBase
    {
        // protected override long ExpectedAnswer => 0;

        protected override long SolutionImplementation()
        {
            return 0;
        }
    }
}
