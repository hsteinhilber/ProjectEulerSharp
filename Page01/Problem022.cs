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
            long result = 0;

            var reader = new StreamReader(@"Data\p022_names.txt");
            var file = reader.ReadToEnd();
            var names = file.Split(new string[] { "\",\"", "\"" }, StringSplitOptions.RemoveEmptyEntries);
            var nameList = new List<string>(names);
            nameList.Sort();

            for (int index = 0; index < nameList.Count; index++)
            {
                result += (index + 1) * NameScore(nameList[index]);
            }

            return result;
        }

        private int NameScore(string name)
        {
            return name.ToCharArray().Sum(c => c - 'A' + 1);
        }
    }
}
