using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProjectEulerSharp.Page01
{
    /******************************************************************************
     * URL: http://projecteuler.net/problem=027
     * Title: Quadratic primes
     * Euler discovered the remarkable quadratic formula:
     * 
     *          n^2 + n + 41
     * 
     * It turns out that the formula will produce 40 primes for the consecutive integer values 0 <= n <= 39. 
     * However, when n=40, 40^2 +40 + 41 = 40*(40 + 1) + 41 is divisible by 41, and certainly when 
     * n = 41, 41^2 + 41 + 41 is clearly divisible by 41.
     * 
     * The incredible formula n^2 - 79*n + 1601 was discovered, which produces 80 primes for the consecutive 
     * values 0 <= n <= 79. The product of the coefficients, −79 and 1601, is −126479.
     * 
     * Considering quadratics of the form:
     * 
     *          n^2 + a*n + b, where |a| < 1000 and |b| <= 1000
     *          
     *          where |n| is the modulus/absolute value of n
     *          e.g. |11| = 11 and |-4| = 4
     *          
     * Find the product of the coefficients, a and b, for the quadratic expression that produces the maximum 
     * number of primes for consecutive values of n, starting with n=0.
     ******************************************************************************/
    [TestClass]
    public class Problem027 : ProblemBase
    {
        protected override long ExpectedAnswer => -59231;

        protected override long SolutionImplementation()
        {
            long maxPrimes = 0;
            long product = 0;

            for (long a = -999; a <= 999; a++)
                for (long b = -1000; b <= 1000; b++)
                {
                    var primes = CountGeneratedPrimes(a, b);
                    if (primes > maxPrimes)
                    {
                        maxPrimes = primes;
                        product = a * b;
                    }
                }

            return product;
        }

        public long CountGeneratedPrimes(long a, long b)
        {
            long n = 0;
            while ((n * n + a * n + b).IsPrime())
                n++;
            return n;
        }
    }
}

