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

namespace fnMath 
{
    public class LU<T> : Matrix<T>
    where T : struct,
    IComparable<T>,
    IConvertible,
    IEquatable<T>
    {
        // stupid change
        // --------------------------------------------------
        // ------------------------- Members

        #region Members



        #endregion

        // --------------------------------------------------
        // ------------------------- Constructors
        #region Constructors

        public LU(Matrix<T> A) : base(A)
        {
            dynamic d = 1;
            for (int i=0; i<_rows; i++)
                for(int j=0; j<columns; j++)
                    _data[i][j] = d;

            Decompose(A);
        }

        #endregion


        // --------------------------------------------------
        // ------------------------- Accessors
        #region Accessors

        #endregion

        // --------------------------------------------------
        // ------------------------- Public Methods
        #region Public Methods

        public Matrix<T> Upper()
        {
            Matrix<T> C = new Matrix<T>(_rows, _columns);

            for (int j = 0; j < _columns; j++)
                for (int i = 0; i <= j; i++)
                    if (i == j)
                    {
                        dynamic c = 1;
                        C[i][j] = c;
                    }
                    else
                        C[i][j] = _data[i][j];
            return C;
        }


        public Matrix<T> Lower()
        {
            Matrix<T> C = new Matrix<T>(_rows, _columns);

            for (int j = 0; j < _columns; j++)
                for (int i = j; i < _rows; i++)
                    C[i][j] = _data[i][j];

            return C;
        }

        public Vector<T> Solve(Vector<T> b)
        {
            if(b.length !=  _rows)
                throw new DimensionMismatchException();

            Vector<T> y = new Vector<T>(b.length);
            dynamic y_prime;
            for (int i=0; i< _rows; i++)
            {
                y[i] = b[i];

                for (int j=0; j<i; j++)
                {
                    y_prime = y[j];
                    y[i] -= y_prime * _data[i][j];
                }
                y_prime = y[i];
                y[i] = y_prime / _data[i][i];
            }
    
            for(int i=_rows - 1; i>=0; i--)
            {
                for (int j = _columns - 1; j > i; j--)
                {
                    y_prime = y[j];
                    y[i] -= y_prime * _data[i][j];
                }
            }    
            return y;
        }


        public T Determinate()
        {
            dynamic det = _data[0][0];
            for(int i=1; i<_rows; i++)
                det *= _data[i][i];
            return det;
        }

    #endregion


    // --------------------------------------------------
    // ------------------------- Private Methods
    #region Private Methods


    private void Decompose(Matrix<T> A)
        {
            if(_rows != _columns)
                throw new DimensionMismatchException();

            /*
            for(int i=0; i<_rows; i++)
                _data.resize(_columns);
            */

            dynamic tempSum;
            dynamic d;

            for(int j=0; j<_rows; j++)
            {
                for(int i=j; i<_columns; i++)
                {
                    tempSum = 0;
                    for(int k=0; k<j; k++)
                    {
                        d = _data[k][j];
                        tempSum = tempSum + _data[i][k] * d;
                    }
                _data[i][j] = A[i][j] - tempSum;
            }
        
            for(int i=j; i<_columns; i++)
            {
                tempSum = 0;
                for(int k=0; k<j; k++)
                {
                    d = _data[k][i];
                    tempSum = tempSum + _data[i][k] * d;
                }
            
                if(i != j)
                    _data[j][i] = (A[j][i] - tempSum) / _data[j][j];
                }
            }
        }

        private Vector<T> BackwardSub(Vector<T> b)
        {
            if (b.length != _rows)
                throw new DimensionMismatchException();
        
            Vector<T> y = new Vector<T>(b.length);

            for (int i = _rows - 1; i >= 0; i--)
            {
                y[i] = b[i];
                dynamic y_prime = y[i];
                for (int j = _columns - 1; j > i; j--)
                {
                    y[i] -= y_prime * _data[i][j];
                }
            }

            return y;
        }

        
        private Vector<T> ForwardSub(Vector<T> b)
        {
            if (b.length != _rows)
                throw new DimensionMismatchException();
        
            Vector<T> y = new Vector<T>(b.length);

            for (int i = 0; i < _rows; i++)
            {
                y[i] = b[i];
                dynamic y_prime = y[i];
                for (int j = 0; j < i; j++)
                {                    
                    y[i] -= y_prime * _data[i][j];
                }
                y_prime = y[i];
                y[i] = y_prime / _data[i][i];
            }

            return y;
        }

        #endregion


    }
}
