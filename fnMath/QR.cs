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
    public class QR<T>
        where T : struct,
        IComparable<T>,
        IConvertible,
        IEquatable<T>
    {

        // --------------------------------------------------
        // ------------------------- Members
        #region 

        Matrix<T> _Q;
        Matrix<T> _R;

        #endregion

        // --------------------------------------------------
        // ------------------------- Constructors
        #region Constructors

        public QR(Matrix<T> A)
        {
            DecomposeGrahmSchmidt(A);
        }

        #endregion


        // --------------------------------------------------
        // ------------------------- Accessors
        #region Accessors

        public Matrix<T> Q { get { return _Q; } }

        public Matrix<T> R { get { return _R; } }

        #endregion

        // --------------------------------------------------
        // ------------------------- Public Methods
        #region Public Methods

        void DecomposeGrahmSchmidt(Matrix<T> A)
        {
            _Q = new Matrix<T>(A.rows, A.columns);
            _R = new Matrix<T>(A.columns, A.columns);

            dynamic sum;
            dynamic norm;
            int rows = _Q.rows;
            int columns = _Q.columns;
    
            for(int i=0; i<rows; i++)   // Normalize
            {
                for(int j=0; j<columns; j++)    // Initialaize ever other value of Q to A
                    _Q[i][j] = A[i][j];
            }
    
            for(int j=0; j<columns; j++)
            {
                for(int k=j; k >0; k--)
                {
                    sum = 0;

                    for (int i = 0; i < rows; i++)
                    {
                        dynamic q = _Q[i][k - 1];
                        sum += q * A[i][j]; // project V onto U
                    }

                    _R[k - 1][j] = sum;
                    for(int i=0; i<rows; i++)
                        _Q[i][j] -= sum * _Q[i][k - 1]; // Subtract
                }
                norm = 0;
                for (int i = 0; i < rows; i++)
                {
                    dynamic q = _Q[i][j];
                    norm += q * q;
                }
                norm = Math.Sqrt(norm);

                _R[j][j] = norm;
        
                for(int i=0; i<rows; i++)
                    _Q[i][j] /= norm;
            }
        }

        #endregion


        // --------------------------------------------------
        // ------------------------- Private Methods
        #region 



        #endregion

        // --------------------------------------------------
        // ------------------------- Utility Functions
        #region Utility Functions

        public void Print()
        {
            System.Console.Write("--------Q\n");
            for (int i = 0; i < Q.rows; i++)
            {
                for (int j = 0; j < Q.columns; j++)
                    System.Console.Write(_Q[i][j] + "\t");
                System.Console.Write("\n");
            }
            System.Console.Write("--------R\n");
            for (int i = 0; i < R.rows; i++)
            {
                for (int j = 0; j < R.columns; j++)
                    System.Console.Write(R[i][j] + "\t");
                System.Console.Write("\n");

            }
            System.Console.Write("--------Q * R\n");
            (Q * R).Print();
        }

        #endregion

    }
}
