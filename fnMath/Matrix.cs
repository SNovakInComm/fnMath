using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fnMath
{
    /// <summary>
    /// Base Matrix Class
    /// </summary>
    /// <typeparam name="T">Numeric Type</typeparam>
    public class Matrix<T>
        where T : struct,
        IComparable<T>,
        IConvertible,
        IEquatable<T>
    {
        // --------------------------------------------------
        // ------------------------- Members

        #region Members

        protected Vector<T>[] _data;         // Actual Data Contained in Matrix
        protected int _rows, _columns;        // Number Of Rows and Columns in The Matrix

        #endregion

        // --------------------------------------------------
        // ------------------------- Constructors

        #region Constructors

        private void commonSetup()
        {
            _data = null;
        }

        public Matrix()
        {
            commonSetup();
        }

        public Matrix(int rows, int columns)
        {
            commonSetup();

            _rows = rows;
            _columns = columns;
            _data = new Vector<T>[rows];
            for (int i=0; i<rows; i++)
            {
                _data[i] = new Vector<T>(columns);
                _data[i].isColumn = false;
            }
        }

        public Matrix(int rows, int columns, T value)
        {
            commonSetup();

            _rows = rows;
            _columns = columns;
            _data = new Vector<T>[rows];
            for (int i = 0; i < rows; i++)
            {
                _data[i] = new Vector<T>(columns, value);
                _data[i].isColumn = false;
            }
        }

        public Matrix(Matrix<T> A)
        {
            commonSetup();

            _rows = A.rows;
            _columns = A.columns;
            _data = new Vector<T>[_rows];
            for (int i=0; i<_rows; i++)
            {
                _data[i] = new Vector<T>(_columns);
                _data[i].isColumn = false;
                for (int j = 0; j < _columns; j++)
                    _data[i][j] = A[i][j];
            }
        }



    #endregion

        // --------------------------------------------------
        // ------------------------- Accessors

        #region Accessors
        public int rows { get { return _rows; } set { _rows = value; } }

        public int columns { get { return _columns; } set { _columns = value; } }

        #endregion

        // --------------------------------------------------
        // ------------------------- Operator Overloads

        #region Operator Overloads

        public Vector<T> this[int row] { get { return _data[row]; } }

        public static Matrix<T> operator *(Matrix<T> A, Matrix<T> B)
        {
            if (A.columns != B.rows)
                throw new DimensionMismatchException();

            Matrix<T> C = new Matrix<T>(A.rows, B.columns);

            for (int i = 0; i < C.rows; i++)
            {
                for (int j = 0; j < C.columns; j++)
                {
                    for (int k = 0; k < A.columns; k++)
                    {
                        dynamic b = B[k][j];
                        dynamic a = A[i][k];
                        C[i][j] += b * a;
                    }
                }
            }
            return C;
        }

        public static Vector<T> operator *(Matrix<T> A, Vector<T> B)
        {
            if (A.columns != B.length)
                throw new DimensionMismatchException();

            if (B.isRow)
                throw new ColumnTransposeException();

            Vector<T> C = new Vector<T>(A.rows);

            for (int i = 0; i < C.length; i++)
            {
                for (int j = 0; j < A.columns; j++)
                {
                    dynamic b = B[j];
                    dynamic a = A[i][j];
                    C[i] += b * a;
                }
            }
            return C;
        }

        public static Matrix<T> operator *(Matrix<T> A, T B)
        {
            Matrix<T> C = new Matrix<T>(A);

            for (int i = 0; i < A.rows; i++)
            {
                for (int j = 0; j < A.columns; j++)
                {
                    dynamic b = B;
                    C[i][j] *= b;
                }
            }
            return C;
        }

        public static Matrix<T> operator ~ (Matrix<T> A)
        {
            Matrix<T> C = new Matrix<T>(A.columns, A.rows);

            for (int i = 0; i < A.rows; i++)
                for (int j = 0; j < A.columns; j++)
                    C[j][i] = A[i][j];
            return C;
        }

        #endregion

        // --------------------------------------------------
        // ------------------------- Public Methods

        public void Identity()
        {
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < columns; j++)
                {
                    dynamic d;
                    if (i == j)
                        d = 1.0;
                    else
                        d = 0.0;
                    _data[i][j] = d;
                }
        }

        public T Max()
        {
            T _max = _data[0][0];

            for(int i=0; i<rows; i++)
                for(int j=0; j<columns; j++)
                {
                    dynamic a = _max;
                    if (_data[i][j] > a)
                        _max = _data[i][j];
                }
            return _max;
        }

        public T Min()
        {
            T _min = _data[0][0];

            for (int i = 0; i < rows; i++)
                for (int j = 0; j < columns; j++)
                {
                    dynamic a = _min;
                    if (_data[i][j] < a)
                        _min = _data[i][j];
                }
            return _min;
        }

        public T AbsMax()
        {
            T _absMax = _data[0][0];

            for (int i = 0; i < rows; i++)
                for (int j = 0; j < columns; j++)
                {
                    dynamic a = _absMax;
                    a = Math.Abs(a);
                    dynamic b = _data[i][j];
                    if (Math.Abs(b) > a)
                        _absMax = _data[i][j];
                }
            return _absMax;
        }

        public T AbsMin()
        {
            T _absMin = _data[0][0];

            for (int i = 0; i < rows; i++)
                for (int j = 0; j < columns; j++)
                {
                    dynamic a = _absMin;
                    a = Math.Abs(a);
                    dynamic b = _data[i][j];
                    if (Math.Abs(b) <
                        a)
                        _absMin = _data[i][j];
                }
            return _absMin;
        }

        // --------------------------------------------------
        // ------------------------- Private Methods

        #region Private Methods



        #endregion
            
        // --------------------------------------------------
        // ------------------------- Utility Methods

        #region Utility Methods

        public void Print()
        {

            for (int i = 0; i < _rows; i++)
            {
                for (int j = 0; j < _columns; j++)
                    Globals.Print(_data[i][j] + " ");
                Globals.Print("\n");
            }
            Globals.Print("\n");
        }

        #endregion
    }
}
