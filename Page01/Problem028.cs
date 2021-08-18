using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProjectEulerSharp.Page01
{
    /******************************************************************************
     * URL: http://projecteuler.net/problem=028
     * Title: Number spiral diagonals
     * Starting with the number 1 and moving to the right in a clockwise direction a 5 by 5 spiral is formed as follows:
     * 
     *      [21]  22   23   24  [25]
     *       20  [ 7]   8  [ 9]  10
     *       19    6  [ 1]   2   11
     *       18  [ 5]   4  [ 3]  12
     *      [17]  16   15   14  [13]
     * 
     * It can be verified that the sum of the numbers on the diagonals is 101.
     * 
     * What is the sum of the numbers on the diagonals in a 1001 by 1001 spiral formed in the same way?
     ******************************************************************************/
    [TestClass]
    public class Problem028 : ProblemBase
    {
        // protected override long ExpectedAnswer => 0;

        protected override long SolutionImplementation()
        {
            int x = GRID_SIZE / 2, y = GRID_SIZE / 2;
            int dx = 0, dy = -1;
            long sum = 0;

            for (int n = 1; n <= GRID_SIZE * GRID_SIZE; n++)
            {
                if (x == y || x + y == GRID_SIZE - 1)
                    sum += n;

                if (x == y || (x < GRID_SIZE / 2 && x + y == GRID_SIZE - 1) || (x > GRID_SIZE / 2 && x + y == GRID_SIZE))
                {
                    var tmp = dx;
                    dx = -dy;
                    dy = tmp;
                }

                x += dx;
                y += dy;
            }

            return sum;
        }

        private const int GRID_SIZE = 1001;
    }
}

