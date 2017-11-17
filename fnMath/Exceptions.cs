using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fnMath
{
    #region Vector / Matrix Exceptions

    #region General Exceptions

    public class FunctionNotImplementedException : System.Exception
    {
        public FunctionNotImplementedException() 
            : base("The Function Throwing This Exception Has Not Yet Been Implemented!\nThis is A Placeholder and Should Not Be Called\nSorry for the inconvenience ") { }
    }

    #endregion


    public class DimensionMismatchException : System.Exception
    {
        public DimensionMismatchException() 
            : base("Inner Dimensions Must Agree For Liner Algebra Operator!!") { }
    }

    public class ColumnTransposeException : System.Exception
    {
        public ColumnTransposeException()
            : base("Row found when a column was expected!!") { }
    }

    public class RowTransposeException : System.Exception
    {
        public RowTransposeException()
            : base("Column found when a row was expected!!") { }
    }

    #endregion


}
