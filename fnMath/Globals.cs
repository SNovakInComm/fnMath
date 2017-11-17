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
        }

        #endregion



    }
}
