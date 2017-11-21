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
    public static class Factorial
    {
        // --------------------------------------------------
        // ------------------------- Members

        #region Members

        static int maxN = 0;
        static double[] values;

        #endregion

        // --------------------------------------------------
        // ------------------------- Constructor

        #region Public Methods

        static Factorial()
        {
            values = new double[256];
        }

        #endregion

        // --------------------------------------------------
        // ------------------------- Public Methods

        #region Public Methods

        public static double ComputeLn(int n)
        {
            if (n <= maxN)
                return values[n];

            for (int i = maxN + 1; i <= n; i++)
            {
                values[i] = values[i - 1] + Math.Log(i);
            }

            return values[n];
        }

        public static double Compute(int n)
        {
            return Math.Exp(ComputeLn(n));
        }

        #endregion
    }
}
