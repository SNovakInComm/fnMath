using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using fnMath;

namespace fnMath.Tests
{
    [TestFixture]
    class LU
    {

        #region Setup Tests

        

        #endregion


        #region Tests

        [Test]
        public void ConstructorTest_Dobule()
        {
            Globals.setOutputToConsole();
            Matrix<double> A = new Matrix<double>(2, 2);
            LU<double> B;

            double err = 1e-5;

            A[0][0] = 123.0;
            A[1][0] = 433.3450;

            A[0][1] = 121.045;
            A[1][1] = -202.0;

            B = new LU<double>(A);

            Matrix<double> C = B.Lower() * B.Upper();

            for(int i=0; i<C.rows; i++)
                for(int j=0; j<C.columns; j++)
                    Assert.That(Math.Abs(C[0][0] - A[0][0]) < err, 
                        "Too much error in LUDecomposition");

        }

        [Test]
        public void SolveLinearSystemTest()
        {
            Globals.setOutputToConsole();
            Matrix<double> A = new Matrix<double>(2, 2);
            LU<double> B;

            A[0][0] = 1.0;
            A[1][0] = -10.0;

            A[0][1] = 5.0;
            A[1][1] = 13;

            B = new LU<double>(A);

            Vector<double> b = new Vector<double>(3);

            Assert.Throws<DimensionMismatchException>(() => B.Solve(b),
                "Exception not thrown when dimensions are mismatched");

            b = new Vector<double>(2);
            b[0] = 12.0;
            b[1] = 6.0;

            Vector<double> y = B.Solve(b);

            Assert.That(y[0] == 2.0,
                "Error Solving Linear System Of Equations");

            Assert.That(y[1] == 2.0,
                "Error Solving Linear System Of Equations");

            b[0] = -30.5;
            b[1] = 179.0;
            y = B.Solve(b);
            Assert.That(y[0] == -20.5,
                "Error Solving Linear System Of Equations");

            Assert.That(y[1] == -2.0,
                "Error Solving Linear System Of Equations");
        }

        [Test]
        public void TestDeterminate_Double()
        {
            Matrix<double> A = new Matrix<double>(2, 2);
            LU<double> B;

            A[0][0] = 3.0;
            A[1][0] = 4.0;
            
            A[0][1] = 8.0;
            A[1][1] = 6.0;

            B = new LU<double>(A);

            dynamic det = B.Determinate();

            Assert.That(Math.Abs(det - -14.0) < 1e-5,
                "Error Calculating Determinate");
            /*
            A = new Matrix<double>(3, );
            
            A[0][0] = 1.0;
            A[1][0] = 3.0;
            A[2][0] = 8.0;

            A[0][1] = 2.0;
            A[1][1] = 0.0;
            A[2][1] = 4.0;

            A[0][2] = 1.0;
            A[1][2] = 4.0;
            A[2][2] = 10.0;

            B = new LU<double>(A);
            det = B.Determinate();
            
            Assert.That(Math.Abs(det - -306.0) < 1e-5,
                "Error Calculating Determinate");
            */
        }

        #endregion

    }
}
