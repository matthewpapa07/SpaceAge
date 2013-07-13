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
        public static int USER_STARTING_FUNDS = 50000;
        public static int USER_FUEL_USED_PER_SECTOR = 5;    //TODO: Scale with ship later

        public enum ShipOrientationState { Up = 1, Down = 2, Left = 3, Right = 4 };

        public static SpaceShip PlayerShip = Preconstructs.ConstructedShips.StarterShip();
        public static int PlayerLevel;

        // Event list to execute when user state changes
        public static List<EventToInvoke> OnSectorChange = new List<EventToInvoke>();
        public static List<EventToInvoke> OnWaypointChange = new List<EventToInvoke>();

        // Boolean flags set indicating user desires
        public static bool ExecuteWaypoint = false;

        static UserState()
        {
            int startingRow = Constants.UNIVERSE_WIDTH / 2;
            int startingColumn = Constants.UNIVERSE_HEIGHT / 2;

            PlayerShip.CurrentShipSector = Universe.getSector(startingRow, startingColumn);
            
            //progState = (int)ShipOrientationState.Up;
            //progStateLast = (int)ShipOrientationState.Up;

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
            return PlayerShip.CurrentShipSector;
        }

        public static void setCurrentSector(Sector sector)
        {
            PlayerShip.CurrentShipSector = sector;

            // Events that key off of a sector change. Fire them all off
            foreach (EventToInvoke evtoinv in OnSectorChange)
            {
                evtoinv.Invoke();
            }
        }

        public static Sector getCurrentWaypoint()
        {
            return PlayerShip.CurrentWaypoint;
        }

        public static void setCurrentWaypoint(Sector sector)
        {
            PlayerShip.CurrentWaypoint = sector;
            // Broadcast to everyone who would be interested
            foreach (EventToInvoke evtoinv in OnWaypointChange)
            {
                evtoinv.Invoke();
            }
        }

        public static int reduceFuel(int reduceAmount)
        {
            int tempReduce = PlayerShip.fuelLevel;

            tempReduce -= reduceAmount;

            if (tempReduce <= 0)
            {
                return Constants.FAILURE;
            }
            else
            {
                PlayerShip.fuelLevel -= reduceAmount;
                return Constants.SUCCESS;
            }
        }

        public static int getFuelLevel()
        {
            return PlayerShip.fuelLevel;
        }

        public static int getPlayerFunds()
        {
            return PlayerShip.SpaceShipFunds;
        }

        public static int changePlayerFunds(int offset)
        {
            int tempFunds = PlayerShip.SpaceShipFunds;

            PlayerShip.SpaceShipFunds += offset;

            if (tempFunds >= 0)
            {
                PlayerShip.SpaceShipFunds += offset;
                return Constants.SUCCESS;
            }
            else
            {
                return Constants.FAILURE;
            }
        }
    }
}
