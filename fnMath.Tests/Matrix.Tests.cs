using NUnit.Framework;

namespace fnMath.Tests
{
    class Matrix
    {

        // --------------------------------------------------
        // ------------------------- Test Setup

        #region Test Setup



        #endregion


        // --------------------------------------------------
        // ------------------------- Constructor Tests

        #region Constructor Tests

        [Test] 
        public void TestDimensionConstructorDouble()
        {
            const int rows = 4; ;
            const int columns = 4;

            Matrix<double> A = new Matrix<double>(rows, columns);

            Assert.That(A, Is.Not.Null,
                "Error: New matrix is null");
            Assert.That(A.rows, Is.EqualTo(rows),
                "Error: Dimension is wrong in new matrix");
            Assert.That(A.columns, Is.EqualTo(columns),
                "Error: Dimension is wrong in new matrix");
        }

        [Test]
        public void TestValueConstructorDouble()
        {
            const int rows = 4; ;
            const int columns = 4;
            const double value = 1.5;

            Matrix<double> A = new Matrix<double>(rows, columns, value);

            Assert.That(A, Is.Not.Null,
                "Error: New matrix is null");
            Assert.That(A.rows, Is.EqualTo(rows),
                "Error: Dimension is wrong in new matrix");
            Assert.That(A.columns, Is.EqualTo(columns)
                ,
                "Error: Dimension is wrong in new matrix");

            for(int i=0; i<rows; i++)
            {
                for(int j=0; j<columns; j++)
                {
                    Assert.That(A[i][j], Is.EqualTo(value),
                        "Error: Assigned value is wrong in new matrix");
                }
            }
        }

        [Test]
        public void TestCopyConstructorDouble()
        {
            const int rows = 4; ;
            const int columns = 4;
            const double value = 1.5;

            Matrix<double> A = new Matrix<double>(rows, columns, value);
            Matrix<double> B = new Matrix<double>(A);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Assert.That(A[i][j], Is.EqualTo(value),
                        "Error in Matrix Copy Constructor");
                    Assert.That(B[i][j], Is.EqualTo(A[i][j]),
                        "Error in Matrix Copy Constructor");
                }
            }
        }

        #endregion

        // --------------------------------------------------
        // ------------------------- Operator Tests

        #region Operator Tests

        [Test]
        public void MatrixMultiplyMatrixTest_Double()
        {
            Matrix<double> A = new Matrix<double>(2, 3);
            Matrix<double> B = new Matrix<double>(3, 2);
            Matrix<double> C;

            // ------------------------- Setup Matricies
            A[0][0] = 1.0;
            A[1][0] = 4.0;

            A[0][1] = 2.0;
            A[1][1] = 5.0;

            A[0][2] = 3.0;
            A[1][2] = 6.0;

            B[0][0] = 7.0;
            B[1][0] = 9.0;
            B[2][0] = 11.0;

            B[0][1] = 8.0;
            B[1][1] = 10.0;
            B[2][1] = 12.0;

            // ------------------------- Test Inner Dimesion Error
            Assert.Throws<DimensionMismatchException>(
                delegate { C = A * A; },
                "Error did NOT throw exception in matrix multiplication");

            // ------------------------- Test Multiplication 1
            C = A * B;

            Assert.That(C.columns, Is.EqualTo(C.rows)); // The result from this operation should be symmetric
            Assert.That(C.columns, Is.EqualTo(2),
                "Unexpected Column / row count in matrix multiplication");      // And equal to 2

            Assert.That(C[0][0], Is.EqualTo(58),
                "Arithmatic error in matrix multiplication");       // This check both the values and
            Assert.That(C[0][1], Is.EqualTo(64),
                "Arithmatic error in matrix multiplication");       // the correct indexing
            Assert.That(C[1][0], Is.EqualTo(139),
                "Arithmatic error in matrix multiplication");      // i.e. C[row][column]
            Assert.That(C[1][1], Is.EqualTo(154),
                "Arithmatic error in matrix multiplication");

            // ------------------------- Test Multiplication 2
            C = B * A;

            Assert.That(C.columns, Is.EqualTo(C.rows)); 
            Assert.That(C.columns, Is.EqualTo(3),
                "Unexpected Column / row count in matrix multiplication");      

            Assert.That(C[0][0], Is.EqualTo(39), 
                "Arithmatic error in matrix multiplication");       
            Assert.That(C[0][1], Is.EqualTo(54),
                "Arithmatic error in matrix multiplication");       
            Assert.That(C[0][2], Is.EqualTo(69),
                "Arithmatic error in matrix multiplication");

            Assert.That(C[1][0], Is.EqualTo(49),
                "Arithmatic error in matrix multiplication");
            Assert.That(C[1][1], Is.EqualTo(68),
                "Arithmatic error in matrix multiplication");
            Assert.That(C[1][2], Is.EqualTo(87),
                "Arithmatic error in matrix multiplication");

            Assert.That(C[2][0], Is.EqualTo(59),
                "Arithmatic error in matrix multiplication");
            Assert.That(C[2][1], Is.EqualTo(82),
                "Arithmatic error in matrix multiplication");
            Assert.That(C[2][2], Is.EqualTo(105),
                "Arithmatic error in matrix multiplication");

        }

        [Test]
        public void MatrixMultiplyVectorTest_Double()
        {
            Matrix<double> A = new Matrix<double>(3, 3);
            Vector<double> B = new Vector<double>(3);
            Vector<double> C;

            // ------------------------- Setup Matricies
            A[0][0] = 1.0;
            A[1][0] = 4.0;
            A[2][0] = 7.0;

            A[0][1] = 2.0;
            A[1][1] = 5.0;
            A[2][1] = 8.0;

            A[0][2] = 3.0;
            A[1][2] = 6.0;
            A[2][2] = 9.0;
        
            B[0] = 2.0;
            B[1] = 4.0;
            B[2] = 6.0;

            B.isRow = true;

            // ------------------------- Test Inner Dimesion Error
            Assert.Throws<ColumnTransposeException>(
                delegate { C = A * B; },
                "Error did NOT throw exception in matrix * vector multiplication");

            // ------------------------- Test Multiplication 1
            B.isColumn = true;
            C = A * B;

            Assert.That(C.length, Is.EqualTo(A.columns));   //  Check the size

            Assert.That(C[0], Is.EqualTo(28.0),
                "Arithmatic error in matrix * vector multiplication!");
            Assert.That(C[1], Is.EqualTo(64.0),
                "Arithmatic error in matrix * vector multiplication!");
            Assert.That(C[2], Is.EqualTo(100.0),
                "Arithmatic error in matrix * vector multiplication!");
        }

        [Test]
        public void MatrixTransposeTest_Double()
        {
            Matrix<double> A = new Matrix<double>(3, 2);
            Matrix<double> C;

            // ------------------------- Setup Matricies
            A[0][0] = 1.0;
            A[1][0] = 4.0;
            A[2][0] = 7.0;

            A[0][1] = 2.0;
            A[1][1] = 5.0;
            A[2][1] = 8.0;

            // ------------------------- Take Transpose
            C = ~A;

            // ------------------------- Check success

            Assert.IsTrue(A.rows == C.columns,
                "Dimension Mismatch After Matrix Transpose!!");
            Assert.IsTrue(A.columns == C.rows,
                "Dimension Mismatch After Matrix Transpose!!");

            for (int i = 0; i < A.rows; i++)
                for (int j = 0; j < A.columns; j++)
                    Assert.IsTrue(A[i][j] == C[j][i], 
                        "Error Copying During Matrix Transpose!");
        }

        [Test]
        public void MatrixMultiplyScalarTest_Double()
        {
            Matrix<double> A = new Matrix<double>(3, 2);
            Matrix<double> C;
            const double d = 10.0;

            // ------------------------- Setup Matricies
            A[0][0] = 1.0;
            A[1][0] = 4.0;
            A[2][0] = 7.0;

            A[0][1] = 2.0;
            A[1][1] = 5.0;
            A[2][1] = 8.0;

            // ------------------------- Take Transpose
            C = A * d;

            // ------------------------- Check success

            Assert.IsTrue(A.rows == C.rows,
                "Dimension Mismatch After Matrix * Scalar Operation!!");
            Assert.IsTrue(A.columns == C.columns,
                "Dimension Mismatch After Matrix * Scalar Operation!!");

            for (int i = 0; i < A.rows; i++)
                for (int j = 0; j < A.columns; j++)
                    Assert.IsTrue(A[i][j] * d == C[i][j],
                        "Arithmatic Error In Matrix * Scalar Operation!");
        }

        #endregion


        // --------------------------------------------------
        // ------------------------- Public Method Tests

        #region Public Method Tests


        [Test]
        public void testMatrixIdentity_Double()
        {
            Matrix<double> A = new Matrix<double>(3, 3);

            A[0][0] = -10;
            A[1][1] = 5;
            A.Identity();

            for(int i=0; i<A.rows; i++)
                for(int j=0; j<A.columns; j++)
                    if (i == j)
                        Assert.IsTrue(A[i][j] == 1.0,
                            "Diagonal not unity on matrix identity!!");
                    else
                        Assert.IsTrue(A[i][j] == 0.0,
                            "Off diagonal not zero on matrix identity!!");
        }

        [Test]
        public void testMatrixMax_Double()
        {
            const double maxVal = 20.5;
            double result;
            Matrix<double> A = new Matrix<double>(3, 3);

            A[0][0] = -7.0;
            A[1][0] = 9.0;
            A[2][0] = 11.0;

            A[0][1] = -8.0;
            A[1][1] = maxVal;
            A[2][1] = 12.0;

            A[0][2] = -7.0;
            A[1][2] = 9.0;
            A[2][2] = -11.0;


            // ------------------------- Check

            result = A.Max();

            Assert.That(result, Is.EqualTo(maxVal),
                "Error finding Max val in matrix");
        }

        [Test]
        public void testMatrixMin_Double()
        {
            const double minVal = -20.5;
            double result;
            Matrix<double> A = new Matrix<double>(3, 3);

            A[0][0] = -7.0;
            A[1][0] = 9.0;
            A[2][0] = 11.0;

            A[0][1] = -8.0;
            A[1][1] = minVal;
            A[2][1] = 12.0;

            A[0][2] = -7.0;
            A[1][2] = 9.0;
            A[2][2] = -11.0;


            // ------------------------- Check

            result = A.Min();

            Assert.That(result, Is.EqualTo(minVal),
                "Error finding Min val in matrix");
        }

        [Test]
        public void testMatrixAbsMax_Double()
        {
            const double maxVal = -20.5;
            double result;
            Matrix<double> A = new Matrix<double>(3, 3);

            A[0][0] = -7.0;
            A[1][0] = 9.0;
            A[2][0] = 11.0;

            A[0][1] = -8.0;
            A[1][1] = maxVal;
            A[2][1] = 12.0;

            A[0][2] = -7.0;
            A[1][2] = 9.0;
            A[2][2] = -11.0;


            // ------------------------- Check

            result = A.AbsMax();

            Assert.That(result, Is.EqualTo(maxVal),
                "Error finding AbsMax val in matrix");
            Assert.IsTrue(result < 0.0,
               "Sign error finding AbsMin val in matrix");
        }

        [Test]
        public void testMatrixAbsMin_Double()
        {
            const double minVal = -0.0205;
            double result;
            Matrix<double> A = new Matrix<double>(3, 3);

            A[0][0] = -7.0;
            A[1][0] = 9.0;
            A[2][0] = 11.0;

            A[0][1] = -8.0;
            A[1][1] = minVal;
            A[2][1] = 12.0;

            A[0][2] = -7.0;
            A[1][2] = 9.0;
            A[2][2] = -11.0;


            // ------------------------- Check

            result = A.AbsMin();

            Assert.That(result, Is.EqualTo(minVal),
                "Error finsing AbsMin val in matrix");
            Assert.IsTrue(result < 0.0,
                "Sign error finding AbsMin val in matrix");
        }

        #endregion


    }
}
