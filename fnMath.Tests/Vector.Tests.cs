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

using fnMath;

namespace fnMath.Tests
{
    // --------------------------------------------------
    // ------------------------- Text Fixture

    [TestFixture]
    public class VectorTests
    {
        // --------------------------------------------------
        // ------------------------- Test Setup

        #region Test Setup


        #endregion

        // --------------------------------------------------
        // ------------------------- Constructor Tests

        #region Constructor Tests

        [Test]
        public void LengthConstructorTestWithDouble()
        {
            const int LENGTH = 10;
            Vector<double> V = new Vector<double>(LENGTH);

            Assert.That(V.length == 10);
        }

        [Test]
        public void ValueConstructorTestWithDouble()
        {
            // Construct an object with a value
            const int length = 10;
            double value = 14.3;
            Vector<double> V = new Vector<double>(length, value);


            // Check each value to ensure it is the same as what was passed to the object
            for(int i=0; i<length; i++)
                Assert.That(V[i] == value);
        }

        [Test]
        public void CopyConstructorTestWithDouble()
        {
            const string message = "Vector Copy Constrctor Test Failed: ";

            // ------------------------- Construct an object
            const int length = 10;
            Vector<double> V = new Vector<double>(length);
            Vector<double> V_prime;

            // ------------------------- Init Array
            for (int i=0; i<length; i++)
            {
                V[i] = (double)(i * i) / (Math.E);
            }
            V.isColumn = false;

            V_prime = new Vector<double>(V);

            // ------------------------- Compare Objects
            for (int i = 0; i < length; i++)
                Assert.That(V[i] == V_prime[i],
                    message + "V should equal V_prime");

            Assert.That(V.isColumn == V_prime.isColumn, 
                message + "Column vector flag not preserved in copy operation");

            Assert.That(V.isRow == V_prime.isRow,
                message + "Row vector flag not preserved in copy operation");

            // ------------------------- Change a value in one object
            V[0] = V[length - 1];

            // ------------------------- Check that the values have not 
            // ------------------------- changed in the copy
            Assert.That(V[0] != V_prime[0],
                message + "Values should not be equal after reassignment");
        }

        [Test]
        public void ValueConstructorTestWithInt()
        {
            // Construct an object with a value
            const int length = 10;
            int value = 14;
            Vector<int> V = new Vector<int>(length, value);


            // Check each value to ensure it is the same as what was passed to the object
            for (int i = 0; i < length; i++)
                Assert.That(V[i] == value);
        }

        [Test]
        public void CopyConstructorTestWithInt()
        {
            const string message = "Vector Copy Constrctor Test Failed: ";

            // ------------------------- Construct an object
            const int length = 10;
            Vector<int> V = new Vector<int>(length);
            Vector<int> V_prime;

            // ------------------------- Init Array
            for (int i = 0; i < length; i++)
            {
                V[i] = i * i;
            }
            V.isColumn = false;

            V_prime = new Vector<int>(V);

            // ------------------------- Compare Objects
            for (int i = 0; i < length; i++)
                Assert.That(V[i] == V_prime[i],
                    message + "V should equal V_prime");

            Assert.That(V.isColumn == V_prime.isColumn,
                message + "Column vector flag not preserved in copy operation");

            Assert.That(V.isRow == V_prime.isRow,
                message + "Row vector flag not preserved in copy operation");

            // ------------------------- Change a value in one object
            V[0] = V[length - 1];

            // ------------------------- Check that the values have not 
            // ------------------------- changed in the copy
            Assert.That(V[0] != V_prime[0],
                message + "Values should not be equal after reassignment");

        }

        [Test]
        public void CopyConstructorTestWithDoubleArray()
        {
            const int length = 10;
            double[] A = new double[length];

            for(int i=0; i<length; i++)
            {
                A[i] = Math.PI * (double)i;
            }

            Vector<double> B = new Vector<double>(A);

            Assert.That(A.Length == B.length);

            for(int i=0; i<length; i++)
            {
                Assert.That(A[i] == B[i]);
            }

        }

        #endregion

        // --------------------------------------------------
        // ------------------------- Operator Overload Tests

        #region Operator Overload Tests

        [Test]
        public void OperatorTest_VectorPlusVector_Double()
        {
            const int length = 3;
            double value = 1.5;

            // ------------------------- Init 2 vectors
            Vector<double> A = new Vector<double>(length, value);
            Vector<double> B = new Vector<double>(length);

            for(int i=0; i<length; i++)
                B[i] = (double)i * 1.5;


            // ------------------------- Add them as columns
            Vector<double> C = A + B;

            // ------------------------- Check the results
            Assert.That(C.length == A.length);

            for (int i = 0; i < length; i++)
                Assert.That(C[i] == A[i] + B[i]);

            // ------------------------- Add them as column and row
            A.isRow = true;
            C = A + B;

            Assert.That(C.length == 1);

            double sum = 0;
            for (int i = 0; i < length; i++)
                sum += A[i] + B[i];

            Assert.That(C[0] == sum);
        }

        [Test]
        public void OperatorTest_VectorPlusVector_Int()
        {
            const int length = 3;
            int value = 5;

            // ------------------------- Init 2 vectors
            Vector<int> A = new Vector<int>(length, value);
            Vector<int> B = new Vector<int>(length);

            for (int i = 0; i < length; i++)
                B[i] = (int)i * 10;


            // ------------------------- Add them as columns
            Vector<int> C = A + B;

            // ------------------------- Check the results
            Assert.That(C.length == A.length);

            for (int i = 0; i < length; i++)
                Assert.That(C[i] == A[i] + B[i]);

            // ------------------------- Add them as column and row
            A.isRow = true;
            C = A + B;

            Assert.That(C.length == 1);

            int sum = 0;
            for (int i = 0; i < length; i++)
                sum += A[i] + B[i];

            Assert.That(C[0] == sum);

        }

        [Test]
        public void OperatorTest_VectorMinusVector_Double()
        {
            const int length = 3;
            double value = 1.5;

            // ------------------------- Init 2 vectors
            Vector<double> A = new Vector<double>(length, value);
            Vector<double> B = new Vector<double>(length);

            for (int i = 0; i < length; i++)
                B[i] = (double)i * 1.5;


            // ------------------------- Add them as columns
            Vector<double> C = A - B;

            // ------------------------- Check the results
            Assert.That(C.length == A.length);

            for (int i = 0; i < length; i++)
                Assert.That(C[i] == A[i] - B[i]);

            // ------------------------- Add them as column and row
            A.isRow = true;
            C = A - B;

            Assert.That(C.length == 1);

            double sum = 0;
            for (int i = 0; i < length; i++)
                sum += A[i] - B[i];

            Assert.That(C[0] == sum);
        }

        [Test]
        public void OperatorTest_VectorMinusVector_Int()
        {
            const int length = 3;
            int value = 5;

            // ------------------------- Init 2 vectors
            Vector<int> A = new Vector<int>(length, value);
            Vector<int> B = new Vector<int>(length);

            for (int i = 0; i < length; i++)
                B[i] = (int)i * 10;


            // ------------------------- Add them as columns
            Vector<int> C = A - B;

            // ------------------------- Check the results
            Assert.That(C.length == A.length);

            for (int i = 0; i < length; i++)
                Assert.That(C[i] == A[i] - B[i]);

            // ------------------------- Add them as column and row
            A.isRow = true;
            C = A - B;

            Assert.That(C.length == 1);

            int sum = 0;
            for (int i = 0; i < length; i++)
                sum += A[i] - B[i];

            Assert.That(C[0] == sum);

        }

        [Test]
        public void OperatorTest_VectorPlusScalar_Double()
        {
            const int length = 3;

            // ------------------------- Init 2 vectors
            Vector<double> A = new Vector<double>(length);
            const double b = 6.923;

            for (int i = 0; i < length; i++)
                A[i] = (double)i * 1.5;

            // ------------------------- Add them as columns
            Vector<double> C = A + b;

            // ------------------------- Check the results
            Assert.That(C.length == A.length);

            for (int i = 0; i < length; i++)
                Assert.That(C[i] == A[i] + b);
        }

        [Test]
        public void OperatorTest_VectorPlusScalar_Int()
        {
            const int length = 3;

            // ------------------------- Init 2 vectors
            Vector<int> A = new Vector<int>(length);
            const int b = 105;

            for (int i = 0; i < length; i++)
                A[i] = (int)i * 2;

            // ------------------------- Add them as columns
            Vector<int> C = A + b;

            // ------------------------- Check the results
            Assert.That(C.length == A.length);

            for (int i = 0; i < length; i++)
                Assert.That(C[i] == A[i] + b);
        }

        [Test]
        public void OperatorTest_VectorMinusScalar_Double()
        {
            const int length = 3;

            // ------------------------- Init 2 vectors
            Vector<double> A = new Vector<double>(length);
            const double b = 6.923;

            for (int i = 0; i < length; i++)
                A[i] = (double)i * 1.5;

            // ------------------------- Add them as columns
            Vector<double> C = A - b;

            // ------------------------- Check the results
            Assert.That(C.length == A.length);

            for (int i = 0; i < length; i++)
                Assert.That(C[i] == A[i] - b);
        }

        [Test]
        public void OperatorTest_VectorMinusScalar_Int()
        {
            const int length = 3;

            // ------------------------- Init 2 vectors
            Vector<int> A = new Vector<int>(length);
            const int b = 106;

            for (int i = 0; i < length; i++)
                A[i] = (int)i * 10;

            // ------------------------- Add them as columns
            Vector<int> C = A - b;

            // ------------------------- Check the results
            Assert.That(C.length == A.length);

            for (int i = 0; i < length; i++)
                Assert.That(C[i] == A[i] - b);
        }

        [Test]
        public void OperatorTest_VectorMultiplyScalar_Double()
        {
            const int length = 3;

            // ------------------------- Init 2 vectors
            Vector<double> A = new Vector<double>(length);
            const double b = 6.923;

            for (int i = 0; i < length; i++)
                A[i] = (double)i * 1.5;

            // ------------------------- Add them as columns
            Vector<double> C = A * b;

            // ------------------------- Check the results
            Assert.That(C.length == A.length);

            for (int i = 0; i < length; i++)
                Assert.That(C[i] == A[i] * b);
        }

        [Test]
        public void OperatorTest_VectorMultiplyScalar_Int()
        {
            const int length = 3;

            // ------------------------- Init 2 vectors
            Vector<int> A = new Vector<int>(length);
            const int b = 106;

            for (int i = 0; i < length; i++)
                A[i] = (int)i * 10;

            // ------------------------- Add them as columns
            Vector<int> C = A * b;

            // ------------------------- Check the results
            Assert.That(C.length == A.length);

            for (int i = 0; i < length; i++)
                Assert.That(C[i] == A[i] * b);
        }

        #endregion

        // --------------------------------------------------
        // ------------------------- Public Method Tests

        #region Public Method Tests

        [Test]
        public void DotProductDoubleTest()
        {
            const int length = 3;
            Vector<double> A = new Vector<double>(length);
            Vector<double> A_prime = new Vector<double>(2 * length);
            Vector<double> B = new Vector<double>(length);

            double aDotb, bDota;

            // ------------------------- Init Vectors
            int i = 0;
            A[i] = 1.0;
            B[i++] = 4.0;

            A[i] = 2.0;
            B[i++] = -5.0;

            A[i] = 3.0;
            B[i++] = 6.0;

            // ------------------------- Check Mismatched Indicies
            Assert.Throws<DimensionMismatchException>( () => A.Dot(A_prime));

            // ------------------------- Check A dot B
            aDotb = A.Dot(B);
            Assert.That(aDotb == 12.0);

            // ------------------------- Check B dot A =  A dot B
            bDota = B.Dot(A);
            Assert.That(bDota == aDotb);
        }

        /*
        [Test]
        public void CrossProductDoubleTest()
        {
            const int length = 3;
            Vector<double> A = new Vector<double>(length);
            Vector<double> A_prime = new Vector<double>(2 * length);
            Vector<double> B = new Vector<double>(length);

            Matrix<double> aCrossb, bCrossa;

            // ------------------------- Init Vectors
            int i = 0;
            A[i] = 2.0;
            B[i++] = 5.0;

            A[i] = 3.0;
            B[i++] = 6.0;

            A[i] = 4.0;
            B[i++] = 7.0;

            // **************************************
            // THIS IS A PLACE HOLDER.... FUNCTIONING 
            // TEST IS NEEDED WHEN THIS IS IMPLEMENTED
            // **************************************
            Assert.Throws<FunctionNotImplementedException>(() => A.Cross(A_prime));

        }
        */

        #endregion

    }
}
