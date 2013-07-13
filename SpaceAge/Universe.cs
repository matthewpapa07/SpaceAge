using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceAge
{
    static class Universe
    {
        public static Sector[,] map;
        public static int uniWidth;
        public static int uniHeight;

        // ATTN: Row = x and Column = y

        //public Universe(int rows, int columns)
        //{
        //    GenerateUniverse(rows,columns);
        //}

        public static void GenerateUniverse(int Width, int Height)
        {
            map = new Sector[Width, Height];

            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    map[i, j] = new Sector(i, j);
                }
            }

            uniHeight = Height;
            uniWidth = Width;
        }

        /// <summary>
        /// Initialize factions, stations etc with relevant values
        /// </summary>
        public static void RunSupplementalGeneration()
        {

        }

        public static Sector getSector(int xCoor, int yCoor)
        {
            if ((xCoor < Constants.UNIVERSE_WIDTH) && (yCoor < Constants.UNIVERSE_HEIGHT))
            {
                if ((xCoor >= 0) && (yCoor >= 0))
                {
                    try
                    {
                        return map[xCoor, yCoor];
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
