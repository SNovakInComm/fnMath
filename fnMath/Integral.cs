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
    public static class Integral
    {
        // --------------------------------------------------
        // ------------------------- Members

        #region Members

        #endregion

        // --------------------------------------------------
        // ------------------------- Public Methods

        #region Public Methods

        public static double IntegrateSimpson(Function F, double start, double end, int steps)
        {
            double x = start;
            double h = (end - start) / steps;
            double sum = (F.Evaluate(end) + F.Evaluate(start)) / 2;


            for (int i = 1; i < steps; i++)
            {
                x += h;
                sum += F.Evaluate(x);
            }

            return sum * h;
        }

        public static double IntegrateSimpson(Function F, double start, double end)
        {
            double steps = 1;
            double sum = 0.0;
            double lastSum = Double.MaxValue;
            int i=0;

            for (i = 0; i < Globals.MAXITER; i++)
            {
                steps *= 2;
                double x = start;
                double h = (end - start) / steps;
                sum = (F.Evaluate(end) + F.Evaluate(start)) / 2;

                for (int j = 1; j < steps; j++)
                {
                    x += h;
                    sum += F.Evaluate(x);
                }
                sum *= h;
                double err = Math.Abs(lastSum - sum);
                if (err < Globals.relErr)
                {
                    Globals.iterations = (int)i;
                    return sum;
                }
                lastSum = sum;
            }

            return sum;
        }

        public static double IntegrateRhomberg(Function F, double start, double end)
        {
            double x = start;
            double h = (end - start);
            double sum = (F.Evaluate(end) + F.Evaluate(start)) / 2;
            int arraySize = 1 << ((int)Globals.MAXITER) + 1;
            Vector<double> evaluations = new Vector<double>((int)arraySize);
            Vector<double> thisEvaluation = new Vector<double>((int)Globals.MAXITER + 1);
            Vector<double> lastEvaluation = new Vector<double>((int)Globals.MAXITER + 1);
            double error;
            int maxIndex = 1;
            int steps = 1;
            int k;
            int factor;

            evaluations[0] = end;
            evaluations[1] = start;

            lastEvaluation[0] = sum * h;

            for (int iterations = 1; iterations <= Globals.MAXITER; iterations++)
            {
                h /= 2;
                for (int i = 1; i <= maxIndex; i++)
                {
                    evaluations[i + steps] = evaluations[i] + h;
                    sum += F.Evaluate(evaluations[i + steps]);
                }
                maxIndex += steps;
                steps *= 2;

                thisEvaluation[0] = sum * h;

                factor = 2;
                for (k = 1; k <= iterations; k++)
                {
                    thisEvaluation[k] = (factor * thisEvaluation[k - 1] - lastEvaluation[k - 1]) / (factor - 1);
                    factor = factor << 1;
                }

                error = thisEvaluation[iterations] / lastEvaluation[iterations - 1] - 1;
                if (error < 0)
                    error *= -1;

                if (error <= Globals.relErr)
                {
                    x = thisEvaluation[iterations];
                    return x;
                }

                Vector<double> temp = thisEvaluation;
                thisEvaluation = lastEvaluation;
                lastEvaluation = temp;
                temp = null;

            }
            x = lastEvaluation[(int)Globals.MAXITER];

            // Do I need this????
            thisEvaluation = null;
            lastEvaluation = null;

            return x;
        }

        #endregion

        // --------------------------------------------------
        // ------------------------- Accessors

        #region Accessors

        #endregion

        // --------------------------------------------------
        // ------------------------- Private Methods

        #region Private Methods

        #endregion
    }
}
