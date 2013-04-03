using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace SpaceAge
{
    class Sector
    {
        public const int STARS_PER_SECTOR_CHANCE = 20;
        public const int MAX_DISTANCE_FROM_AXIS = 5000;      //Number must be significantly larger than UiSectorMap Height/Width
        public const int SECTOR_EDGE_PADDING = 500;
        public const int STARTING_SPACESHIP_SPACES = 12;     // This list initializer is demand based. Sectors with higher traffic will end up
                                                             // being allocated more space while ones who dont will only need 25 slots max

        public StarSystem [] StarSystemsList;
        public Point SectorGridLocation;
        public List<MerchantSpaceShip> PresentSpaceShips = new List<MerchantSpaceShip>(STARTING_SPACESHIP_SPACES);
        public List<ItemStore> RegisteredItemStores = new List<ItemStore>(20); //Register ItemStores here to avoid tight nested loop in the AI
        public Point[] RandomBackgroundStars;

        public static StaticGraphics staticGraphics = StaticGraphics.getStaticGraphics();

        public Sector(int x, int y)
        {
            //setParent(u);
            SectorGridLocation = new Point(x, y);
            generateSector();
            
        }

        public void generateSector()
        {
            NumberGenerator n;
            int systemsToPopulate;
            int coord1, coord2;

            n = NumberGenerator.getInstance();

            int BackgStarsCount = n.GetRandNumberInRange(Constants.BACKGROUND_STARS_MIN, Constants.BACKGROUND_STARS_MAX);
            RandomBackgroundStars = new Point[BackgStarsCount];
            for (int i = 0; i < BackgStarsCount; i++)
            {
                RandomBackgroundStars[i] = new Point(n.GetRandNumberInRange(0, MAX_DISTANCE_FROM_AXIS), n.GetRandNumberInRange(0, MAX_DISTANCE_FROM_AXIS));
            }

            //
            // Tune this to change the density of sectors that are populated with stars
            //
            if (!n.LinearPmfResult(8, 25))
            {
                StarSystemsList = new StarSystem[0]; // Empty Array
                return;
            }
            systemsToPopulate = n.CompoundPmfResult(STARS_PER_SECTOR_CHANCE, 100);
            StarSystemsList = new StarSystem[systemsToPopulate];

            for (int i = 0; i < systemsToPopulate; i++)
            {
                coord1 = n.GetRandNumberInRange(SECTOR_EDGE_PADDING, MAX_DISTANCE_FROM_AXIS - SECTOR_EDGE_PADDING);
                coord2 = n.GetRandNumberInRange(SECTOR_EDGE_PADDING, MAX_DISTANCE_FROM_AXIS - SECTOR_EDGE_PADDING);

                StarSystemsList[i] = (new StarSystem(this, new Point(coord1, coord2)));
            }
            coord1 = 0;

        }

        public int getNumOfSystems()
        {
            return StarSystemsList.Length;
        }

        public string getPrintOut()
        {
            return "Planet : " + " Systems : " + "";
        }

        public bool ShipMoveOut(MerchantSpaceShip mss)
        {
            return PresentSpaceShips.Remove(mss);
        }

        public bool ShipMoveIn(MerchantSpaceShip mss)
        {
            PresentSpaceShips.Add(mss);
            mss.CurrentSector = this;
            return true;
        }

        public void DrawSectorGraphics(Graphics GraphicsToUse, Rectangle RectToUse, int StartX, int StartY, int SegWidth, int SegHeight)
        {
            int DrawX;
            int DrawY;

            //
            // Draw the random stars in the background
            //
            foreach (Point p in RandomBackgroundStars)
            {
                DrawX = staticGraphics.ScaleCoordinate(MAX_DISTANCE_FROM_AXIS, p.X, SegWidth);
                DrawX += StartX;
                DrawY = staticGraphics.ScaleCoordinate(MAX_DISTANCE_FROM_AXIS, p.Y, SegHeight);
                DrawY += StartY;
                if (DrawX < 0 || DrawY < 0)
                    continue;

                GraphicsToUse.DrawRectangle(staticGraphics.whitePen, new Rectangle(DrawX, DrawY, 1, 1));
            }

            foreach (StarSystem StarSys in StarSystemsList)
            {
                //
                // For now assume one star per system, and at least one star per system
                //
                DrawX = staticGraphics.ScaleCoordinate(MAX_DISTANCE_FROM_AXIS, StarSys.StarSystemLocation.X, SegWidth);
                DrawX += StartX;
                DrawY = staticGraphics.ScaleCoordinate(MAX_DISTANCE_FROM_AXIS, StarSys.StarSystemLocation.Y, SegHeight);
                DrawY += StartY;
                if (DrawX < 0 || DrawY < 0)
                    continue;
                StarSys.stars[0].DrawStarGraphics(GraphicsToUse, DrawX, DrawY);
            }
        }

        //public void setParent(Universe u)
        //{
        //    parent = u;
        //}
        
    }
}
