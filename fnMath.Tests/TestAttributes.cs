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
        public static bool lastTestPassed = false;
        public static int passedTests = 0;
        public static int failedTests = 0;

        public static int totalPassedTests = 0;
        public static int totalFailedTests = 0;

        #region Bookkeeping

        public static void NewTestFixture()
        {
            passedTests = 0;
            failedTests = 0;
        }

        #endregion

        #region Thats 

        public static int That(bool test)
        {
            if (test)
            {
                testPassed();
                return 0;
            }
            else
            {
                testFailed();
                return -1;
            }
        }

        public static int That(bool test, string failureMessage)
        {
            if (test)
            {
                testPassed();
                return 0;
            }
            else
            {
                testFailed();
                Console.Write(failureMessage + "\n");
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
                testFailed();
                Console.Write("No Exception Thrown\n");
                return -1;
            }
            catch (Exception e)
            {
                if (e is TException)
                {
                    testPassed();
                    return 0;
                }
                else
                {
                    testFailed();
                    Console.WriteLine("Exception: " + e.ToString() + " is not expected type!\n");
                    return -1;
                }
            }
        }

        public static int Throws<TException>(Action function, string message)
        {
            try
            {
                function();
                testFailed();
                Console.Write("No Exception Thrown: " + message + "\n");
                return -1;
            }
            catch (Exception e)
            {
                if (e is TException)
                {
                    testPassed();
                    return 0;
                }
                else
                {
                    testFailed();
                    Console.WriteLine("Exception: " + e.ToString() + " is not expected type! " + message + "\n");
                    return -1;
                }
            }
        }

        #endregion

        #region Private Methods

        private static void testPassed()
        {
            //lastTestPassed = true;
            totalPassedTests++;
            passedTests++;
        }

        private static void testFailed()
        {
            lastTestPassed = false;
            totalFailedTests++;
            failedTests++;
        }

        #endregion

    }
}
