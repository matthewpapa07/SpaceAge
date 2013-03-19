using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace SpaceAge
{
    static class UserState
    {
        public static int USER_MAX_FUEL_AMOUNT = 1500;
        public static int USER_STARTING_FUNDS = 20000;
        public static int USER_FUEL_USED_PER_SECTOR = 5;    //TODO: Scale with ship later

        public static Sector[,] theGrid;
        public static Point playerLocation;
        private static Sector currentSector;

        public enum ShipOrientationState { Up = 1, Down = 2, Left = 3, Right = 4 };
        public static int progState;
        public static int progStateLast;

        //
        // User variables
        //
        private static int fuelLevel = USER_MAX_FUEL_AMOUNT;
        private static int playerFunds = USER_STARTING_FUNDS;

        public static SpaceShip PlayerShip = Preconstructs.ConstructedShips.StarterShip();
        public static int PlayerLevel;

        static UserState()
        {
            int startingRow = Constants.UNIVERSE_ROWS / 2;
            int startingColumn = Constants.UNIVERSE_COLUMNS / 2;

            theGrid = new Sector[Constants.MAP_SECTORS_ROWS, Constants.MAP_SECTORS_COLUMNS];
            playerLocation = new Point(startingRow, startingColumn);
            currentSector = Universe.getSector(startingRow, startingColumn);
            
            progState = (int)ShipOrientationState.Up;
            progStateLast = (int)ShipOrientationState.Up;

            PlayerLevel = 1;

            updateGrid();
        }

        public static int moveRight()
        {
            int currentX = playerLocation.X;
            int currentY = playerLocation.Y;
            Sector currentSector;

            if (onEachTravel() == Constants.FAILURE)
                return Constants.FAILURE;

            progStateLast = progState;
            progState = (int)ShipOrientationState.Right;

            currentSector = Universe.getSector(currentX + 1, currentY);
            if (currentSector != null)
            {
                playerLocation.X = currentX + 1;
                updateGrid();
                return Constants.SUCCESS;
            }
            else
            {
                return Constants.NULLREF;
            }
        }

        public static int moveLeft()
        {
            int currentX = playerLocation.X;
            int currentY = playerLocation.Y;
            Sector currentSector;

            if (onEachTravel() == Constants.FAILURE)
                return Constants.FAILURE;

            progStateLast = progState;
            progState = (int)ShipOrientationState.Left;

            currentSector = Universe.getSector(currentX - 1, currentY);
            if (currentSector != null)
            {
                playerLocation.X = currentX - 1;
                updateGrid();
                return Constants.SUCCESS;
            }
            else
            {
                return Constants.NULLREF;
            }
        }

        public static int moveDown()
        {
            int currentX = playerLocation.X;
            int currentY = playerLocation.Y;
            Sector currentSector;

            if (onEachTravel() == Constants.FAILURE)
                return Constants.FAILURE;

            progStateLast = progState;
            progState = (int)ShipOrientationState.Down;

            currentSector = Universe.getSector(currentX, currentY + 1);
            if (currentSector != null)
            {
                playerLocation.Y = currentY + 1;
                updateGrid();
                return Constants.SUCCESS;
            }
            else
            {
                return Constants.NULLREF;
            }
        }

        public static int moveUp()
        {
            int currentX = playerLocation.X;
            int currentY = playerLocation.Y;
            Sector currentSector;

            if (onEachTravel() == Constants.FAILURE)
                return Constants.FAILURE;

            progStateLast = progState;
            progState = (int)ShipOrientationState.Up;

            currentSector = Universe.getSector(currentX, currentY - 1);
            if (currentSector != null)
            {
                playerLocation.Y = currentY - 1;
                updateGrid();
                return Constants.SUCCESS;
            }
            else
            {
                return Constants.NULLREF;
            }
        }

        public static void updateGrid()
        {     
            const int colRadius = Constants.MAP_SECTORS_COLUMNS /2;    //truncate here if odd
            const int rowRadius = Constants.MAP_SECTORS_ROWS / 2;      //truncate here if odd
            int currentCol = playerLocation.X;
            int currentRow = playerLocation.Y;

            for (int rowOffset = (-1) * rowRadius; rowOffset <= rowRadius; rowOffset++)
            {
                for (int colOffset = (-1) * colRadius; colOffset <= colRadius; colOffset++)
                {
                    int gridRow = rowOffset + rowRadius;
                    int gridCol = colOffset + colRadius;

                    if (validatePoint(currentRow + rowOffset, currentCol + colOffset))
                    {
                        theGrid[gridRow, gridCol] = 
                            Universe.getSector(currentRow + rowOffset, currentCol + colOffset);
                    }
                    else
                    {
                        // 
                        // Null is sentinel for now for off map. Need to change that at some point.
                        //
                        theGrid[gridRow, gridCol] = null;
                    }
                }
            }
        }

        public static int onEachTravel()
        {
            // Pass one day for now
            GameDriver.PassTurn(1);
            // And then reduce the fuel accordingly
            return reduceFuel(USER_FUEL_USED_PER_SECTOR);

        }

        private static bool validatePoint(int row, int col)
        {
            if ((row < Constants.UNIVERSE_ROWS) && (row >= 0))
            {
                if ((col < Constants.UNIVERSE_COLUMNS) && (col >= 0))
                {
                    return true;
                }
            }
            return false;
        }

        public static Sector getCurrentSector()
        {
            return theGrid[Constants.MAP_SECTORS_ROWS / 2, Constants.MAP_SECTORS_COLUMNS / 2];
        }

        public static int reduceFuel(int reduceAmount)
        {
            int tempReduce = fuelLevel;

            tempReduce -= reduceAmount;

            if (tempReduce <= 0)
            {
                return Constants.FAILURE;
            }
            else
            {
                fuelLevel -= reduceAmount;
                return Constants.SUCCESS;
            }
        }

        public static int getFuelLevel()
        {
            return fuelLevel;
        }

        public static int getPlayerFunds()
        {
            return playerFunds;
        }

        public static int changePlayerFunds(int offset)
        {
            int tempFunds = playerFunds;

            playerFunds += offset;

            if (tempFunds >= 0)
            {
                playerFunds += offset;
                return Constants.SUCCESS;
            }
            else
            {
                return Constants.FAILURE;
            }
        }
        
        //public static updateShip()
        //{
        //}
    }
}
