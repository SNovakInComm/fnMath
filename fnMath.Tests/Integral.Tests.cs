using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using fnMath;

namespace fnMath.Tests
{
    [TestFixture]
    public class IntegralTests
    {

        [Test]
        public void TestSimpsonIterative()
        {
            CONSTANT f = new CONSTANT();
            EXP g = new EXP();
            LINE h = new LINE();
            double ans = Integral.IntegrateSimpson(f, 0, 1);
            double err = Math.Abs(ans - 1.0);
            Assert.That(err < Globals.absErr,
                "Trapezoidal Integral Failed On Constant Function");

            ans = Integral.IntegrateSimpson(g, 0, 1);
            err = Math.Abs(ans - (Math.E - 1.0));
            Assert.That( err < Globals.relErr,
                "Trapezoidal Integral Failed On Exponential Function - \nActual: " + ans + "\nExpected: " + (Math.E - 1.0) + "\nErr: " + Math.Abs(ans - (Math.E - 1.0)));
        }


        [Test]
        public void TestRhomberg()
        {

            CONSTANT f = new CONSTANT();
            EXP g = new EXP();
            LINE h = new LINE();
            double ans = Integral.IntegrateRhomberg(f, 0, 1);
            double err = Math.Abs(ans - 1.0);
            Assert.That(err < Globals.absErr,
                "Rhomberg Integral Failed On Constant Function");

            ans = Integral.IntegrateRhomberg(g, 0, 1);
            err = Math.Abs(ans - (Math.E - 1.0));
            Assert.That(err < Globals.relErr,
                "Rhomberg Integral Failed On Exponential Function - \nActual: " + ans + "\nExpected: " + (Math.E - 1.0) + "\nErr: " + Math.Abs(ans - (Math.E - 1.0)));
        }

    }

    public class EXP : Function
    {
        public double Evaluate(double x)
        {
            return Math.Exp(x);
        }

        public double Evaluate(Vector<double> x)
        {
            return Evaluate(x[0]);
        }
    }

    public class CONSTANT : Function
    {
        public double Evaluate(double x)
        {
            return 1.0;
        }

        public double Evaluate(Vector<double> x)
        {
            return 1.0;
        }
    }

    public class LINE : Function
    {
        double a = 1;
        double b = 5;

        public double Evaluate(double x)
        {
            return x * a + b;
        }

        public double Evaluate(Vector<double> x)
        {
            return Evaluate(x[0]);
        }
    }
}
