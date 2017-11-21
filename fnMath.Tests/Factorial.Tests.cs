using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using fnMath;

namespace fnMath.Tests
{
    [TestFixture]
    class FactorialTester
    {

        [Test]
        public void TestFactorial()
        {
            const double err = 1e-8;
            double fact = 1.0;

            for(int i=1; i<10; i++)
            {
                fact *= i;
                Assert.That(Math.Abs(fact - Factorial.Compute(i)) < err,
                    "Factorial Values Calculated Incorrectly");
                Assert.That(Math.Abs(Math.Log(fact) - Factorial.ComputeLn(i)) < err,
                    "Factorial Values Calculated Incorrectly");
            }
        }

    }
}
