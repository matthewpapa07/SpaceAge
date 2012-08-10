using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceAge
{
    class Constants
    {
        /// <summary>
        /// Return Values of functions
        /// </summary>
        public const int SUCCESS = 0;
        public const int NULLREF = 1;
        public const int FAILURE = -1;
        public const int ABORTED = -2;
        public const int EXCEPTION = -3;

        /// <summary>
        /// Universe rows and columns
        /// </summary>
        public const int UNIVERSE_ROWS = 100;
        public const int UNIVERSE_COLUMNS = 100;

        /// <summary>
        /// These numbers MUST be odd for now
        /// </summary>
        public const int MAP_SECTORS_ROWS = 7;
        public const int MAP_SECTORS_COLUMNS = 7;

        public const int MAP_PADDING_PERCENT = 3;

        public static string intToHex(int n)
        {
            return n.ToString("x");
        }


    }
}
