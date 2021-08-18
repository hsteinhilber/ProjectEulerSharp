using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProjectEulerSharp.Page01
{
    /******************************************************************************
     * URL: http://projecteuler.net/problem=031
     * Title: Coin sums
     * In the United Kingdom the currency is made up of pound (£) and pence (p). There are eight coins in general circulation:
     * 
     * 1p, 2p, 5p, 10p, 20p, 50p, £1 (100p), and £2 (200p).
     * It is possible to make £2 in the following way:
     * 
     * 1×£1 + 1×50p + 2×20p + 1×5p + 1×2p + 3×1p
     * How many different ways can £2 be made using any number of coins?
     ******************************************************************************/
    [TestClass]
    public class Problem031 : ProblemBase
    {
        protected override long ExpectedAnswer => 73682;

        protected override long SolutionImplementation()
        {
            return CountCombinations(200, new int[] { 200, 100, 50, 20, 10, 5, 2, 1 });
        }

        private long?[,] CACHE;

        private long CountCombinations(long amount, int[] coinValues)
        {
            CACHE = new long?[amount + 1, coinValues.Length];
            return CountCombinations(amount, 0, coinValues);
        }

        private long CountCombinations(long amount, int current_coin, int[] coinValues)
        {
            if (amount == 0) return 1;
            if (amount < 0 || current_coin == coinValues.Length) return 0;

            if (CACHE[amount, current_coin] != null)
                return (long)CACHE[amount, current_coin];

            return (long)(CACHE[amount, current_coin] = CountCombinations(amount - coinValues[current_coin], current_coin, coinValues) +
                                                        CountCombinations(amount, current_coin + 1, coinValues));
        }
    }
}

