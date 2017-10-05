using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting.Logging;

namespace ProjectEulerSharp
{
    public class ProblemBase
    {

        public ProblemBase()
        {
        }

        protected virtual void LogResult<T>(T result)
        {
            Logger.LogMessage("Test Result: {0}", result);
        }
    }
}
