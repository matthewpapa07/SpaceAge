
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace SpaceAge.DriverLibrary
{
    static class NavigationLib
    {
        public enum Directions { Up, Down, Left, Right, Hold };
        public static int GetSectorTaxiDistance(Sector s1, Sector s2)
        {
            return Math.Abs(s1.SectorGridLocation.X - s2.SectorGridLocation.X) + Math.Abs(s1.SectorGridLocation.Y - s2.SectorGridLocation.Y);
        }

        public static int GetTaxiDistance(int x1, int x2, int y1, int y2)
        {
            return Math.Abs(x1 - x2) + Math.Abs(y1 - y2);
        }

        public static Directions NextDirection(Sector CurrentSector, Sector DestinationSector)
        {
            Point origin = CurrentSector.SectorGridLocation;
            Point destination = DestinationSector.SectorGridLocation;

            int distanceToTravel = 0;
            int newDistance = 0;

            // Stay if nowhere to go
            distanceToTravel = GetTaxiDistance(origin.X, destination.X, origin.Y, destination.Y);
            if (distanceToTravel == 0)
                return Directions.Hold;

            //Up
            newDistance = GetTaxiDistance(origin.X, destination.X, origin.Y - 1, destination.Y);
            if (newDistance < distanceToTravel)
                return Directions.Up;

            //Down
            newDistance = GetTaxiDistance(origin.X, destination.X, origin.Y + 1, destination.Y);
            if (newDistance < distanceToTravel)
                return Directions.Down;

            //Left
            newDistance = GetTaxiDistance(origin.X - 1, destination.X, origin.Y, destination.Y);
            if (newDistance < distanceToTravel)
                return Directions.Left;

            //Right
            newDistance = GetTaxiDistance(origin.X + 1, destination.X, origin.Y, destination.Y);
            if (newDistance < distanceToTravel)
                return Directions.Right;

            //default needed?
            return Directions.Hold;
        }

        public static StarSystem[] GetStarSystemsInDistance(Sector s, int radius)
        {
            if (s == null)
                throw new Exception();

            List<StarSystem> SSList = new List<StarSystem>(20);

            for (int i = 1; i <= radius; i++)
            {
                Sector[] Square = GetRingAtRadius(s, i);
                foreach (Sector sec in Square)
                {
                    foreach (StarSystem ss in sec.StarSystemsList)
                    {
                        SSList.Add(ss);
                    }
                }
            }

            return SSList.ToArray();
        }

        public static StarSystem[] GetStarSystemsAtDistance(Sector s, int radius)
        {
            if (s == null)
                throw new Exception();

            Sector[] Square = GetRingAtRadius(s, radius);
            List<StarSystem> SSList = new List<StarSystem>(20);

            foreach (Sector sec in Square)
            {
                foreach (StarSystem ss in sec.StarSystemsList)
                {
                    SSList.Add(ss);
                }
            }

            return SSList.ToArray();
        }

        // Get ring of sectors at a range. NOTE: This function was not refactored when I fixed 
        // The universe coordinate system. I dont think it is necessary to do this. So remember that
        // Up/Down is Rigth/Left and vise versa
        public static Sector[] GetRingAtRadius(Sector s, int radius)
        {
            if(radius == 0)
                return null;

            int searchLength = radius * 2 + 1;
            List<Sector> SecList = new List<Sector>(radius*4 - 4);
            Sector tempSec;
            Point p = s.SectorGridLocation;
            
            // Get the bottom left corner
            tempSec = Universe.getSector(p.X - radius, p.Y - radius);
            if (tempSec != null)
                SecList.Add(tempSec);

            // Now head towards the top and right one square at a time
            Point searchLocLeft = new Point(p.X - radius, p.Y - radius);
            for (int i = 1; i < searchLength; i++)
            {
                tempSec = Universe.getSector(searchLocLeft.X, searchLocLeft.Y + i);
                if(tempSec != null)
                    SecList.Add(tempSec);
                tempSec = Universe.getSector(searchLocLeft.X + i, searchLocLeft.Y);
                if(tempSec != null)
                    SecList.Add(tempSec);
            }

            // Get the top right corner
            tempSec = Universe.getSector(p.X + radius, p.Y + radius);
            if (tempSec != null)
                SecList.Add(tempSec);

            // Now head towards the botton and left one square at time
            Point searchLocRight = new Point(p.X + radius, p.Y + radius);
            for (int i = 1; i < (searchLength-1); i++)
            {
                tempSec = Universe.getSector(searchLocRight.X, searchLocRight.Y - i);
                if (tempSec != null)
                    SecList.Add(tempSec);
                tempSec = Universe.getSector(searchLocRight.X - i, searchLocRight.Y);
                if (tempSec != null)
                    SecList.Add(tempSec);
            }

            return SecList.ToArray();
        }

        public static Sector GetSectorInDirection(Sector CurrentSector, Directions WhichDirection)
        {
            switch (WhichDirection)
            {
                case Directions.Down:
                    return Universe.getSector(CurrentSector.SectorGridLocation.X, CurrentSector.SectorGridLocation.Y + 1);
                case Directions.Up:
                    return Universe.getSector(CurrentSector.SectorGridLocation.X, CurrentSector.SectorGridLocation.Y - 1);
                case Directions.Right:
                    return Universe.getSector(CurrentSector.SectorGridLocation.X + 1, CurrentSector.SectorGridLocation.Y);
                case Directions.Left:
                    return Universe.getSector(CurrentSector.SectorGridLocation.X - 1, CurrentSector.SectorGridLocation.Y);
                case Directions.Hold:
                    return CurrentSector;
                default:
                    return CurrentSector;
            }

        }
    }
}
