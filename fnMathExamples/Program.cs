using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using fnMath;

namespace fnMathExamples
{
    class Program
    {
        // --------------------------------------------------
        // ------------------------- Main
        static void Main(string[] args)
        {
            Working_With_Vectors();

            SolvingLinearSystemsOfEquations();

            return;
        }

        // --------------------------------------------------
        // ------------------------- Examples

        #region Vector Examples

        private static void Working_With_Vectors()
        {
            // ------------------------- Setup Global Environment (Optional)
            Globals.setOutputToConsole();                   // All output will print to the console  

            Globals.PrintLine("Working With Vectors Test");
            Globals.PrintLine("----------------------------------");

            // ------------------------- Construct a Vector object of type double
            Vector<double> V = new Vector<double>(3);       // Constructs a vector of length 3

            // ------------------------- Assign Values
            V[0] = 10.0;
            V[1] = -20.5;
            V[2] = 0.0;

            // ------------------------- Output the values
            Globals.PrintLine("Print out a column vector:");
            Globals.PrintLine("----------------------------------");
            V.isColumn = true;
            V.Print();          // Should print vertically

            Globals.PrintLine("Print out a row vector:");
            Globals.PrintLine("----------------------------------");
            V.isColumn = false;
            V.Print();          // Should print horizontally


            // ------------------------- Now make a new vector from the existing one
            Vector<double> rowVector = new Vector<double>(V);
            Vector<double> columnVector = new Vector<double>(V);    // Passing a vector into the constructor will copy the vector's members
            columnVector.isColumn = true;       // Even copy's the fact it's a row....

            // ------------------------- Add / subtract two vectors
            Globals.PrintLine("Add two vectors:");
            Globals.PrintLine("----------------------------------");

            Vector<double> sum =  rowVector + columnVector;         // Arimatic operators are overloaded 
            Vector<double> diff = rowVector - columnVector;

            Globals.PrintLine("rowVector + columnVector = ");
            sum.Print();
            Globals.PrintLine("rowVector - columnVector = ");
            diff.Print();



        }

        #endregion

        #region Solving Linear Systems Of Equations
        private static void SolvingLinearSystemsOfEquations()
        {
            Globals.setOutputToConsole();
            Matrix<double> A = new Matrix<double>(2, 2);
            LU<double> B;

            A[0][0] = 3.0;
            A[1][0] = 4.0;

            A[0][1] = 1.0;
            A[1][1] = 2.0;

            B = new LU<double>(A);

            A.Print();
            B.Print();
            B.Upper().Print();
            B.Lower().Print();
        }

        #endregion
    }
}
