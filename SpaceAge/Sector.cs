using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace SpaceAge
{
    class Sector
    {
        public const int MAX_SYSTEMS_PER_SECTOR = 5;
        public const int MAX_DISTANCE_FROM_AXIS = 5000;      //Number must be significantly larger than UiSectorMap Height/Width
        public const int STARTING_SPACESHIP_SPACES = 12;     // This list initializer is demand based. Sectors with higher traffic will end up
                                                             // being allocated more space while ones who dont will only need 25 slots max

        public StarSystem [] StarSystemsList;
        public Point SectorGridLocation;
        public List<MerchantSpaceShip> PresentSpaceShips = new List<MerchantSpaceShip>(STARTING_SPACESHIP_SPACES);
        public List<ItemStore> RegisteredItemStores = new List<ItemStore>(20); //Register ItemStores here to avoid tight nested loop in the AI

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

            //
            // Tune this to change the density of systems generated
            //
            if (!n.LinearPmfResult(8, 25))
            {
                StarSystemsList = new StarSystem[0];
                return;
            }
            systemsToPopulate = n.GetRandNumberInRange(0, MAX_SYSTEMS_PER_SECTOR);
            StarSystemsList = new StarSystem[systemsToPopulate];

            for (int i = 0; i < systemsToPopulate; i++)
            {
                coord1 = n.GetRandNumberInRange(0, MAX_DISTANCE_FROM_AXIS);
                coord2 = n.GetRandNumberInRange(0, MAX_DISTANCE_FROM_AXIS);

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

        public void DrawSectorGraphics(Graphics GraphicsToUse, Rectangle RectToUse)
        {
            int dimension = RectToUse.Width;
            GraphicsToUse.DrawImage(staticGraphics.emptySpace, RectToUse);
            int DrawX;
            int DrawY;

            foreach (StarSystem StarSys in StarSystemsList)
            {
                //
                // For now assume one star per system, and at least one star per system
                //
                DrawX = ScaleCoordinate(MAX_DISTANCE_FROM_AXIS, StarSys.StarSystemLocation.X, RectToUse.Width);
                DrawX += RectToUse.X;
                DrawY = ScaleCoordinate(MAX_DISTANCE_FROM_AXIS, StarSys.StarSystemLocation.Y, RectToUse.Height);
                DrawY += RectToUse.Y;
                StarSys.stars[0].DrawStarGraphics(GraphicsToUse, DrawX, DrawY);
            }
        }

        //
        // TODO: Refactor this out so we can use it everywhere
        //
        public int ScaleCoordinate(int maxOriginCoor, int actualOriginCoor, int maxDestCoor)
        {
            //
            // Cast everything to double for the greatest accuracy and rounding
            //
            double MaxOriginCoorD = maxOriginCoor;
            double ActualOriginCoorD = actualOriginCoor;
            double MaxDestCoorD = maxDestCoor;

            double result = (ActualOriginCoorD / MaxOriginCoorD) * MaxDestCoorD;

            return (int)result;
        }

        //public void setParent(Universe u)
        //{
        //    parent = u;
        //}
        
    }
}
