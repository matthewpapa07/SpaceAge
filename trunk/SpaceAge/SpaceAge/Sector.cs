using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace SpaceAge
{
    class Sector
    {
        public const int STARS_PER_SECTOR_CHANCE = 35;
        public const int MAX_DISTANCE_FROM_AXIS = 5000;      //Number must be significantly larger than UiSectorMap Height/Width
        public const int SECTOR_EDGE_PADDING = 500;
        public const int STARTING_SPACESHIP_SPACES = 12;     // This list initializer is demand based. Sectors with higher traffic will end up
                                                             // being allocated more space while ones who dont will only need 25 slots max

        public StarSystem [] StarSystemsList;
        public Point SectorGridLocation;
        public List<SpaceShip> PresentSpaceShips = new List<SpaceShip>(STARTING_SPACESHIP_SPACES);
        public List<ItemStore> RegisteredItemStores = new List<ItemStore>(20); //Register ItemStores here to avoid tight nested loop in the AI
        public Point[] RandomBackgroundStars;
        public static StarSystem HighlightSystem;

        public static StaticGraphics staticGraphics = StaticGraphics.getStaticGraphics();
        public enum GateDirections { North, South, East, West, None, Unknown };

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
            //if (!n.LinearPmfResult(8, 25)) Changed for greater density of systems in universe
            if (!n.LinearPmfResult(12, 25))
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
            mss.CurrentShipSector = this;
            return true;
        }

        public static void SetSectorObjectListViewItemsMini(ListView ui_SectorList)
        {
            ui_SectorList.Columns.Clear();
            //
            // Add columns
            //
            double BoxLength = ui_SectorList.Width;
            ui_SectorList.Columns.Add("Name", (int) (BoxLength*.35));
            ui_SectorList.Columns.Add("Stars", (int) (BoxLength*.18));
            ui_SectorList.Columns.Add("Planets", (int) (BoxLength*.20));
            ui_SectorList.Columns.Add("Soverignty", (int)(BoxLength* .25));
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

            if (HighlightSystem != null && StarSystemsList.Contains(HighlightSystem))
            {
                GraphicsToUse.DrawRectangle(staticGraphics.greenPen, HighlightSystem.stars[0].StarRectangle);
            }
        }

        public void DrawSectorGraphicsEx(Graphics GraphicsToUse, Rectangle RectToUse, Point RectStart, Point RectDimensions, Point GridStart, Point GridDimensions)
        {
            PointEx Actual;
            PointEx Draw = new PointEx(0, 0) ;

            //
            // Draw the random stars in the background
            //
            foreach (Point p in RandomBackgroundStars)
            {
                Actual = GraphicsLib.GetPointInRelativeGrid(p, GridStart, GridDimensions);
                if (Actual != null)
                {
                    Draw.X = staticGraphics.ScaleCoordinate(GridDimensions.X, Actual.X, RectDimensions.X);
                    Draw.X += RectStart.X;
                    Draw.Y = staticGraphics.ScaleCoordinate(GridDimensions.Y, Actual.Y, RectDimensions.Y);
                    Draw.Y += RectStart.Y;
                    if (Draw.X < 0 || Draw.Y < 0)
                        continue;

                    GraphicsToUse.DrawRectangle(staticGraphics.whitePen, new Rectangle(Draw.X, Draw.Y, 1, 1));
                }
            }

            foreach (StarSystem StarSys in StarSystemsList)
            {
                Actual = GraphicsLib.GetPointInRelativeGrid(StarSys.StarSystemLocation, GridStart, GridDimensions);

                if (Actual != null)
                {
                    Draw.X = staticGraphics.ScaleCoordinate(GridDimensions.X, Actual.X, RectDimensions.X);
                    Draw.X += RectStart.X;
                    Draw.Y = staticGraphics.ScaleCoordinate(GridDimensions.Y, Actual.Y, RectDimensions.Y);
                    Draw.Y += RectStart.Y;
                    if (Draw.X < 0 || Draw.Y < 0)
                        continue;
                    StarSys.stars[0].DrawStarGraphics(GraphicsToUse, Draw.X, Draw.Y);
                }
            }

            // Broken. Need to look at this
            //if (HighlightSystem != null && StarSystemsList.Contains(HighlightSystem))
            //{
            //    GraphicsToUse.DrawRectangle(staticGraphics.greenPen, HighlightSystem.stars[0].StarRectangle);
            //}
        }

        /// <summary>
        /// Function called to see if the user clicked on anything drawn in the sector
        /// </summary>
        /// <param name="ClickCoordinates"></param>
        /// <returns></returns>
        public StarSystem ClickForObject(PointD ClickCoordinates)
        {
            PointD TempPointD = new PointD(0.0,0.0);
            double PointDistance;

            foreach (StarSystem StarSys in StarSystemsList)
            {
                PointDistance = TempPointD.Distance(ClickCoordinates);
                if (PointDistance <= 200 /* StarSys.stars[0].StarRectangle.Height */)
                {
                    HighlightSystem = StarSys;
                    return StarSys;
                }
            }

            HighlightSystem = null;
            return null;
        }

        public override bool Equals(object obj)
        {
            if (obj is Sector)
            {
                Point p1 = this.SectorGridLocation;
                Point p2 = ((Sector)obj).SectorGridLocation;
                if (p1.X == p2.X && p1.Y == p2.Y)
                    return true;
                else
                    return false;
            }
            return false;
            //return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public int Distance(Sector inSec)
        {
            // Wait until diagonals are added
            //return (int)Math.Sqrt(
            //    Math.Pow((SectorGridLocation.X - inSec.SectorGridLocation.X), 2) + Math.Pow((SectorGridLocation.Y - inSec.SectorGridLocation.Y), 2)
            //    );
            return Math.Abs((SectorGridLocation.X - inSec.SectorGridLocation.X)) + Math.Abs((SectorGridLocation.Y - inSec.SectorGridLocation.Y));
        }

        //public void setParent(Universe u)
        //{
        //    parent = u;
        //}

        // Later enhance algorithm to use diagonals
        public Sector[] GetSectorPath(Sector Destination)
        {
            int DistanceToGo = Distance(Destination);
            Sector[] Options = new Sector[4];
            int[] OptionsDistance = new int[4];
            Sector[] SectorPath = new Sector[DistanceToGo];
            int SelectedSectorDistance;
            int SelectedSector;

            Options[0] = Universe.getSector(SectorGridLocation.X + 1, SectorGridLocation.Y);
            Options[1] = Universe.getSector(SectorGridLocation.X, SectorGridLocation.Y + 1);
            Options[2] = Universe.getSector(SectorGridLocation.X - 1, SectorGridLocation.Y);
            Options[3] = Universe.getSector(SectorGridLocation.X, SectorGridLocation.Y - 1);

            if (Equals(Destination))
            {
                return null;
            }

            for (int j = 0; j < DistanceToGo; j++)
            {
                for (int i = 0; i <= 3; i++)
                {
                    OptionsDistance[i] = 0;

                    if (Options[i] != null)
                    {
                        OptionsDistance[i] = Options[i].Distance(Destination);
                    }
                }
                SelectedSectorDistance = 999999;
                SelectedSector = 0;
                for (int k = 0; k <= 3; k++)
                {
                    if (OptionsDistance[k] < SelectedSectorDistance)
                    {
                        SelectedSector = k;
                        SelectedSectorDistance = OptionsDistance[k];
                    }
                }

                SectorPath[j] = Options[SelectedSector];

                Options[0] = Universe.getSector(SectorPath[j].SectorGridLocation.X + 1, SectorPath[j].SectorGridLocation.Y);
                Options[1] = Universe.getSector(SectorPath[j].SectorGridLocation.X, SectorPath[j].SectorGridLocation.Y + 1);
                Options[2] = Universe.getSector(SectorPath[j].SectorGridLocation.X - 1, SectorPath[j].SectorGridLocation.Y);
                Options[3] = Universe.getSector(SectorPath[j].SectorGridLocation.X, SectorPath[j].SectorGridLocation.Y - 1);
            }

            return SectorPath;
        }

        public Sector GetNextSectorToWaypoint(Sector Destination)
        {
            Sector[] Options = new Sector[4];
            int[] OptionsDistance = new int[4];

            Options[0] = Universe.getSector(SectorGridLocation.X + 1, SectorGridLocation.Y);
            Options[1] = Universe.getSector(SectorGridLocation.X, SectorGridLocation.Y + 1);
            Options[2] = Universe.getSector(SectorGridLocation.X - 1, SectorGridLocation.Y);
            Options[3] = Universe.getSector(SectorGridLocation.X, SectorGridLocation.Y - 1);

            for (int i = 0; i <= 3; i++)
            {
                OptionsDistance[i] = 999999999;
            }

            for (int i = 0; i <= 3; i++)
            {
                if (Options[i] != null)
                {
                    OptionsDistance[i] = Options[i].Distance(Destination);
                }
            }

            int SelectedSectorDistance;
            int SelectedSector;
            SelectedSectorDistance = 999999999;
            SelectedSector = 0;
            for (int k = 0; k <= 3; k++)
            {
                if (OptionsDistance[k] < SelectedSectorDistance)
                {
                    SelectedSector = k;
                    SelectedSectorDistance = OptionsDistance[k];
                }
            }

            return Options[SelectedSector];
        }


        public GateDirections GetNextSectorDirection(Sector Destination)
        {
            Sector[] Options = new Sector[4];

            Options[0] = Universe.getSector(SectorGridLocation.X + 1, SectorGridLocation.Y);
            Options[1] = Universe.getSector(SectorGridLocation.X, SectorGridLocation.Y + 1);
            Options[2] = Universe.getSector(SectorGridLocation.X - 1, SectorGridLocation.Y);
            Options[3] = Universe.getSector(SectorGridLocation.X, SectorGridLocation.Y - 1);

            Sector NextSec = GetNextSectorToWaypoint(Destination);

            if (Options[0] != null && NextSec.Equals(Options[0]))
            {
                return GateDirections.East;
            }
            if (Options[1] != null && NextSec.Equals(Options[1]))
            {
                return GateDirections.South;
            }
            if (Options[2] != null && NextSec.Equals(Options[2]))
            {
                return GateDirections.West;
            }
            if (Options[3] != null && NextSec.Equals(Options[3]))
            {
                return GateDirections.North;
            }

            throw new Exception();

        }
        //public Point GetSectorOffset(Sector AdjacentSector)
        //{

        //}
        
    }
}
