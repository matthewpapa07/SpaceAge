using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceAge
{
    static class Universe
    {
        public static Sector[,] map;
        public static int uniRows;
        public static int uniCols;

        //public Universe(int rows, int columns)
        //{
        //    GenerateUniverse(rows,columns);
        //}

        public static void GenerateUniverse(int rows, int columns)
        {
            map = new Sector[rows, columns];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    map[i, j] = new Sector(i, j);
                }
            }

            uniCols = columns;
            uniRows = rows;
        }

        /// <summary>
        /// Initialize factions, stations etc with relevant values
        /// </summary>
        public static void RunSupplementalGeneration()
        {

        }

        public static Sector getSector(int row, int column)
        {
            if ((row < Constants.UNIVERSE_ROWS) && (column < Constants.UNIVERSE_COLUMNS))
            {
                if ((row >= 0) && (column >= 0))
                {
                    try
                    {
                        return map[row, column];
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Exception : " + e.Message);
                        return null;
                    }
                }
            }
            return null;
        }
    }
}
