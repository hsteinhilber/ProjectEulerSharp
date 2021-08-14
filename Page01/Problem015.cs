using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProjectEulerSharp.Page01
{
    /******************************************************************************
     * URL: http://projecteuler.net/problem=15
     * Title: Lattice paths
     * Starting in the top left corner of a 2×2 grid, and only being able to move to 
     * the right and down, there are exactly 6 routes to the bottom right corner.
     *
     *     *RR*RR*      *RR*--*      *RR*--*    
     *     |  |  D      |  D  |      |  D  |
     *     *--*--*      *--*RR*      *--*--*
     *     |  |  D      |  |  D      |  D  |
     *     *--*--*      *--*--*      *--*RR*
     *
     *     *--*--*      *--*--*      *--*--*
     *     D  |  |      D  |  |      D  |  |
     *     *RR*RR*      *RR*--*      *--*--*
     *     |  |  D      |  D  |      D  |  |
     *     *--*--*      *--*RR*      *RR*RR*
     *
     * How many such routes are there through a 20×20 grid?
     ******************************************************************************/
    [TestClass]
    public class Problem015 : ProblemBase
    {
        protected override long ExpectedAnswer => 137846528820;
        
        const long SOUTH_STEPS = 20;
        const long EAST_STEPS = 20;

        protected override long SolutionImplementation()
        {
            // The number of steps in a NE latice (or SE in this case) is equal to the
            // binomial coefficient (n + e / n) or (n+e)Cn
            return (SOUTH_STEPS + EAST_STEPS).Combination(SOUTH_STEPS);
        }
    }
}
