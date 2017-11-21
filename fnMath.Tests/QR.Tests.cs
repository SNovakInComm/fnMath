using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fnMath.Tests
{
    [TestFixture]
    class QR
    {

        [Test]
        public void TestQRDecommpositionGrahamSchmidt()
        {
            Matrix<double> A = new Matrix<double>(3, 3);
            QR<double> B;
            double err = 1e-8;

            A[0][0] = 1.0;
            A[1][0] = 3.0;
            A[2][0] = 8.0;

            A[0][1] = 2.0;
            A[1][1] = 0.0;
            A[2][1] = 4.0;

            A[0][2] = 1.0;
            A[1][2] = 4.0;
            A[2][2] = 10.0;

            B = new QR<double>(A);

            Matrix<double> C = B.Q * B.R;

            for (int i = 0; i < C.rows; i++)
                for (int j = 0; j < C.columns; j++)
                    Assert.That(Math.Abs(C[0][0] - A[0][0]) < err,
                        "Too much error in QR Decomposition");
        }

    }
}
