using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fnMath
{
    public class Vector<T>
         where T : struct,
         IComparable<T>,
         IConvertible,
         IEquatable<T>
   
    {
        // --------------------------------------------------
        // ------------------------- Members

        #region Members

        private T[] _data;          // Actual Data Contained in Matrix
        bool _isColumn;             // Flag for column or row vector

        #endregion

        // --------------------------------------------------
        // ------------------------- Constructors

        #region Constructors

        private void commonSetup()
        {
            _data = null;
            _isColumn = true;
        }

        public Vector()
        {
            commonSetup();
        }

        public Vector(int length)
        {
            commonSetup();
            _data = new T[length];
        }

        public Vector(int length, T value)
        {
            commonSetup();
            _data = new T[length];

            for(int i=0; i<_data.Length; i++)
                _data[i] = value;
        }

        public Vector(Vector<T> A)
        {
            commonSetup();
            _data = new T[A.length];

            for (int i = 0; i < A.length; i++)
                _data[i] = A[i];

            _isColumn = A.isColumn;
        }

        public Vector(T[] A)
        {
            _data = new T[A.Length];
            for(int i=0; i<A.Length; i++)
            {
                _data[i] = A[i];
            }
        }

        #endregion

        // --------------------------------------------------
        // ------------------------- Accessors

        #region Accessors
        public int length { get { return _data.Length; }}

        public bool isColumn { get { return _isColumn; } set { _isColumn = value; } }

        public bool isRow { get { return !_isColumn; } set { _isColumn = !value; } }


        #endregion

        // --------------------------------------------------
        // ------------------------- Operator Overloads

        #region Operator Overloads

        public T this[int index]
        { get { return _data[index]; } set { _data[index] = value; } }

        public static Vector<T> operator +(Vector<T> A, Vector<T> B)
        {
            Vector<T> C;

            if (A.length != B.length) // Should we throw an exception here?
                return null;

            if (A.isColumn == B._isColumn)   // Check if 
            {
                C = new Vector<T>(A);
                for (int i = 0; i < A.length; i++)
                {
                    dynamic a = A[i];
                    dynamic b = B[i];
                    C[i] = a + b;
                }  
            }
            else
            {
                C = new Vector<T>(1);
                for (int i = 0; i < A.length; i++)
                {
                    dynamic a = A[i];
                    dynamic b = B[i];
                    dynamic c = C[0];
                    C[0] = c + a + b;
                }
            }
           
            return C;
        }

        public static Vector<T> operator +(Vector<T> A, T b)
        {
            Vector<T> C;

            C = new Vector<T>(A);
            for (int i = 0; i < A.length; i++)
            {
                dynamic a = A[i];
                dynamic b_prime = b;
                C[i] = a + b;
            }  

            return C;
        }

        public static Vector<T> operator -(Vector<T> A, Vector<T> B)
        {
            Vector<T> C;

            if (A.length != B.length) // Should we throw an exception here?
                return null;

            if (A.isColumn == B._isColumn)   // Check if 
            {
                C = new Vector<T>(A);
                for (int i = 0; i < A.length; i++)
                {
                    dynamic a = A[i];
                    dynamic b = B[i];
                    C[i] = a - b;
                }
            }
            else
            {
                C = new Vector<T>(1);
                for (int i = 0; i < A.length; i++)
                {
                    dynamic a = A[i];
                    dynamic b = B[i];
                    dynamic c = C[0];
                    C[0] = c + a - b;
                }
            }

            return C;
        }
   
        public static Vector<T> operator -(Vector<T> A, T b)
        {
            Vector<T> C;

            C = new Vector<T>(A);
            for (int i = 0; i < A.length; i++)
            {
                dynamic a = A[i];
                dynamic b_prime = b;
                C[i] = a - b;
            }

            return C;
        }

        public static Vector<T> operator *(Vector<T> A, T b)
        {
            Vector<T> C;

            C = new Vector<T>(A);
            for (int i = 0; i < A.length; i++)
            {
                dynamic a = A[i];
                dynamic b_prime = b;
                C[i] = a * b;
            }

            return C;
        }

        #endregion

        // --------------------------------------------------
        // ------------------------- Public Methods

        #region Public Methods

        public T Dot (Vector<T> B)
        {
            if (this.length != B.length)
                throw new DimensionMismatchException();

            dynamic a = _data[0];
            dynamic b = B[0];
            dynamic c = a * b;
            for (int i=1; i<this.length; i++)
            {
                a = _data[i];
                b = B[i];
                c = c + a * b;
            }

            return c;
        }

        public Matrix<T> Cross(Vector<T> B)
        {
            Matrix<T> C = new Matrix<T>();

            throw (new FunctionNotImplementedException());

            return C;
        }

        #endregion

        // --------------------------------------------------
        // ------------------------- Private Methods

        #region Private Methods

        #endregion


        // --------------------------------------------------
        // ------------------------- Utility Methods

        #region Utility Methods

        public void print()
        {

            for (int i = 0; i < _data.Length; i++)
                if(isColumn)
                    Globals.PrintLine(_data[i].ToString());
                else
                    Globals.Print(_data[i].ToString() + "\t");

                Globals.Print("\n");
        }

        #endregion
    }
}
