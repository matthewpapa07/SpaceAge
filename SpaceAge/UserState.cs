using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace SpaceAge
{
    static class UserState
    {
        public static volatile bool ThreadsRunning = true;
        public static int USER_MAX_FUEL_AMOUNT = 1500;
        public static int USER_STARTING_FUNDS = 20000;
        public static int USER_FUEL_USED_PER_SECTOR = 5;    //TODO: Scale with ship later

        public static PointD SectorFineGridLocation;
        private static Sector CurrentSectorUser = null;
        private static Sector CurrentWaypoint = null;

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

        public enum UState { UniverseMap, SectorMap, Other };
        public static UState UserStateMachine = UState.Other;

        // Event list to execute when user state changes
        public static List<EventToInvoke> OnSectorChange = new List<EventToInvoke>();
        public static List<EventToInvoke> OnWaypointChange = new List<EventToInvoke>();

        static UserState()
        {
            int startingRow = Constants.UNIVERSE_ROWS / 2;
            int startingColumn = Constants.UNIVERSE_COLUMNS / 2;

            SectorFineGridLocation = new PointD(Sector.MAX_DISTANCE_FROM_AXIS / 2, Sector.MAX_DISTANCE_FROM_AXIS / 2);
            CurrentSectorUser = Universe.getSector(startingRow, startingColumn);
            
            progState = (int)ShipOrientationState.Up;
            progStateLast = (int)ShipOrientationState.Up;

            PlayerLevel = 1;
        }

        public static int onEachTravel()
        {
            GameDriver.PassTurn(1);
            // And then reduce the fuel accordingly
            return reduceFuel(USER_FUEL_USED_PER_SECTOR);

        }

        public static Sector getCurrentSector()
        {
            return CurrentSectorUser;
        }

        public static void setCurrentSector(Sector sector)
        {
            CurrentSectorUser = sector;

            // Events that key off of a sector change. Fire them all off
            foreach (EventToInvoke evtoinv in OnSectorChange)
            {
                evtoinv.Invoke();
            }
        }

        public static Sector getCurrentWaypoint()
        {
            return CurrentWaypoint;
        }

        public static void setCurrentWaypoint(Sector sector)
        {
            CurrentWaypoint = sector;
            // Broadcast to everyone who would be interested
            foreach (EventToInvoke evtoinv in OnWaypointChange)
            {
                evtoinv.Invoke();
            }
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
    }
}
