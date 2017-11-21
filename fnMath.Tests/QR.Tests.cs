// --------------------------------------------------
// Created by Steven Novak 
// 
// 11 / 21 / 2017
// --------------------------------------------------
//
//

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
            Matrix<double> A = new Matrix<double>(5, 3);
            QR<double> B;
            double err = 1e-8;

            A[0][0] = 1.0;
            A[1][0] = 3.0;
            A[2][0] = 8.0;
            A[3][0] = 28.20;
            A[4][0] = 8.0;

            A[0][1] = 2.0;
            A[1][1] = 0.0;
            A[2][1] = 4.0;
            A[3][1] = 43.64;
            A[4][1] = 1.670;


            A[0][2] = 1.0;
            A[1][2] = 4.0;
            A[2][2] = 10.0;
            A[3][2] = 30.0;
            A[4][2] = 2.56;


            B = new QR<double>(A);

            Matrix<double> C = B.Q * B.R;

            // ----- Check that A = Q * R
            for (int i = 0; i < C.rows; i++)
                for (int j = 0; j < C.columns; j++)
                    Assert.That(Math.Abs(C[0][0] - A[0][0]) < err,
                        "Too much error in QR Decomposition");


            // ----- Check that Q is orthogonal
            C = ~B.Q * B.Q;
            A.Identity();
            for (int i = 0; i < C.rows; i++)
                for (int j = 0; j < C.columns; j++)
                    Assert.That(Math.Abs(C[0][0] - A[0][0]) < err,
                        "QR Decomposition resulted in non-orthogonal Q!!");

        }

    }
}
