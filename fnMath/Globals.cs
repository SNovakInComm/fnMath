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
using System.IO;

namespace fnMath
{
    
    /// <summary>
    /// Static Globals Class
    /// 
    /// Handles and controls variable and streams shared between 
    /// various fnMath Modules
    /// 
    /// </summary>
    public static class Globals
    {
        // --------------------------------------------------
        // ------------------------- Members

        #region Members

        public const string GLOBAL_VERSION = "0.0.0.1";

        static StreamWriter _outputStream;      // Used for data output
        static StreamReader _inputStream;       // Used for data input
        static uint _MAXITER;                   // Maximum Iterations
        static double _absErr;                  // Absolute Error limit
        static double _relErr;                  // Relative Error limit
        static double _lastErr;                 // Relative Error limit
        static int _iterations;                 // Relative Error limit

        #endregion


        // --------------------------------------------------
        // ------------------------- Constructor

        #region Constructor

        /// <summary>
        /// Static Constructor
        /// </summary>
        static Globals()
        {
            _outputStream = null;
            _inputStream = null;
            _MAXITER = 20;
            _absErr = 1e-5;
            _relErr = 1e-10;
            _lastErr = 0.0;
        }

        #endregion

        // --------------------------------------------------
        // ------------------------- Accessors

        #region Accessors

        /// <summary>
        /// Sets the output stream to write to the console
        /// </summary>
        public static void setOutputToConsole()
        {
            _outputStream = new StreamWriter(Console.OpenStandardOutput());
            _outputStream.AutoFlush = true;
            System.Console.SetOut(_outputStream);
        }

        /// <summary>
        /// Sets the output stream to write to a file
        /// </summary>
        /// <param name="fileName"></param>
        public static void setOutputToFile(string fileName)
        {
            _outputStream = new StreamWriter(fileName);
        }

        public static uint MAXITER { get { return _MAXITER; } set { _MAXITER = value; } }

        public static double absErr { get { return _absErr; } set { _absErr = value; } }

        public static double relErr { get { return _relErr; } set { _relErr = value; } }

        public static double lastErr { get { return _lastErr; } set { _relErr = _lastErr; } }

        public static int iterations { get { return _iterations; } set { _iterations = value; } }

        #endregion

        // --------------------------------------------------
        // -------------------------  Public Methods

        #region Public Methods

        /// <summary>
        /// Writes a string to the currently set output stream
        /// </summary>
        /// <param name="line">String to write out</param>
        public static void Print(string line)
        {
            _outputStream.Write(line);
        }

        /// <summary>
        /// Writes a string with newline to the currently set output stream
        /// </summary>
        /// <param name="line">String to write</param>
        public static void PrintLine(string line)
        {
            _outputStream.WriteLine(line);
        }

        /// <summary>
        /// Opens a CSV file for reading 
        /// </summary>
        /// <param name="fileName">Name of the file to open</param>
        public static void OpenCSVFile(string fileName)
        {
            if (_inputStream != null)
                _inputStream.Close();
            _inputStream = new StreamReader(fileName);
        }

        #endregion

        // --------------------------------------------------
        // -------------------------  Private Methods

        #region Private Methods



        #endregion

    }
}
