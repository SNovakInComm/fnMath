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
            V.print();          // Should print vertically

            Globals.PrintLine("Print out a row vector:");
            Globals.PrintLine("----------------------------------");
            V.isColumn = false;
            V.print();          // Should print horizontally


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
            sum.print();
            Globals.PrintLine("rowVector - columnVector = ");
            diff.print();



        }

        #endregion  
    }
}
