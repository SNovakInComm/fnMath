using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fnMath.Tests
{
    [System.AttributeUsage(System.AttributeTargets.Method |
                       System.AttributeTargets.Struct)
]
    public class Test : System.Attribute
    {

    }

    public class TestFixture : System.Attribute
    {

    }

    public static class Assert
    {
        #region Thats 

        public static int That(bool test)
        {
            if (test)
                return 0;
            else
                return -1;
        }

        public static int That(bool test, string failureMessage)
        {
            if (test)
                return 0;
            else
            {
                Console.Write(failureMessage);
                return -1;
            }
        }

        #endregion

        #region Throws
        public static int Throws<TException>(Action function)
        {
            try
            {
                function();
                Console.Write("No Exception Thrown");
                return -1;
            }
            catch (Exception e)
            {
                if (e is TException)
                    return 0;
                else
                {
                    Console.WriteLine("Exception: " + e.ToString() + " is not expected type!");
                    return -1;
                }
            }
        }

        public static int Throws<TException>(Action function, string message)
        {
            try
            {
                function();
                Console.Write("No Exception Thrown: " + message);
                return -1;
            }
            catch (Exception e)
            {
                if (e is TException)
                    return 0;
                else
                {
                    Console.WriteLine("Exception: " + e.ToString() + " is not expected type! " + message);
                    return -1;
                }
            }
        }

        #endregion
    }
}
