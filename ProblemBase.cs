using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting.Logging;

namespace ProjectEulerSharp
{
    public abstract class ProblemBase
    {
        public ProblemBase()
        {
        }

        protected virtual long ExpectedAnswer
        {
            get {
                Assert.Inconclusive("Results for this problem have not been verified yet.");
                return -1;
            }
        }

        [TestMethod]
        public void Solve()
        {
            long result = SolutionImplementation();
            LogResult(result);
            Assert.AreEqual(ExpectedAnswer, result);
        }

        protected abstract long SolutionImplementation();

        protected virtual void LogValue<T>(T value)
        {
            Logger.LogMessage("Value: {0}", value);
        }

        protected virtual void LogValue<T, U>(T values) where T: IEnumerable<U>
        {
            var text = new StringBuilder("[");
            foreach (U value in values)
                text.AppendFormat("{0}, ", value);
            if (values.Any())
                text.Remove(text.Length - 2, 2);
            text.Append("]");
            Logger.LogMessage("Collection: {0}", text);
        }

        protected virtual void LogResult<T>(T result)
        {
            Logger.LogMessage("Test Result: {0}", result);
        }
    }
}
