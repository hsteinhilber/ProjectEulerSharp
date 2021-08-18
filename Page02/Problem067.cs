using System;
using System.Collections.Generic;
using System.Numerics;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace ProjectEulerSharp.Page02
{
    /******************************************************************************
     * URL: http://projecteuler.net/problem=67
     * Title: Maximum path sum II
     * By starting at the top of the triangle below and moving to adjacent numbers on the row below, 
     * the maximum total from top to bottom is 23.
     * 
     *      3
     *     7 4
     *    2 4 6
     *   8 5 9 3
     * 
     * That is, 3 + 7 + 4 + 9 = 23.
     * 
     * Find the maximum total from top to bottom in triangle.txt (right click and 'Save Link/Target 
     * As...'), a 15K text file containing a triangle with one-hundred rows.
     * 
     * NOTE: This is a much more difficult version of Problem 18. It is not possible to try every 
     * route to solve this problem, as there are 2^99 altogether! If you could check one trillion 
     * (10^12) routes every second it would take over twenty billion years to check them all. There 
     * is an efficient algorithm to solve it. ;o)
     ******************************************************************************/
    [TestClass]
    [TestCategory("Fast")]
    [TestCategory("Difficulty-05")]
    public class Problem067 : ProblemBase
    {
        protected override long ExpectedAnswer => 7273;

        protected override long SolutionImplementation()
        {
            NODES = ReadNodesFromFile(@"Data\p067_triangle.txt");
            return ComputeLargestPathSum(NODES);
        }

        private int[][] ReadNodesFromFile(string filename)
        {
            List<int[]> rows = new List<int[]>();
            using (var reader = new StreamReader(filename))
            {
                while (!reader.EndOfStream)
                {
                    rows.Add(reader.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray());
                }
            }

            return rows.ToArray();
        }

        private int[][] NODES;

        private int ComputeLargestPathSum(int[][] nodes)
        {
            for (int row = nodes.Length - 2; row >= 0; row--)
            {
                for (int index = 0; index < nodes[row].Length; index++)
                {
                    nodes[row][index] = nodes[row][index] + Math.Max(nodes[row + 1][index], nodes[row + 1][index + 1]);
                }
            }

            return nodes[0][0];
        }
    }
}
