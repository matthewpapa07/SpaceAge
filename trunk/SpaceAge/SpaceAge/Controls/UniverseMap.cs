using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;


namespace SpaceAge
{
    partial class UniverseMap : UserControl, HumanInterfaceObj
    {
        const int yRadius = Constants.MAP_SECTORS_HEIGHT / 2;    //truncate here if odd
        const int xRadius = Constants.MAP_SECTORS_WIDTH / 2;      //truncate here if odd
        public Sector UniverseMapCenter;
        public Sector ClickedSquare;
        public static Sector[,] theGrid;

        StaticGraphics staticGraphics = StaticGraphics.getStaticGraphics();

        public EventToInvoke RefreshParentUi;

        int height;
        int width;
        int sectorWidth;
        int sectorHeight;

        public UniverseMap()
        {
            InitializeComponent();
            DoubleBuffered = true;

            int startingX = Constants.UNIVERSE_WIDTH / 2;
            int startingY = Constants.UNIVERSE_HEIGHT / 2;
            theGrid = new Sector[Constants.MAP_SECTORS_WIDTH, Constants.MAP_SECTORS_HEIGHT];
            UniverseMapCenter = Universe.getSector(startingX, startingY);

            updateGrid();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            drawMap(e.Graphics);
        }


        private void UniverseMap_Load(object sender, EventArgs e)
        {

        }


        public void drawMap(Graphics g)
        {
            updateGrid();

            height = this.Height;
            width = this.Width;

            sectorHeight= height / Constants.MAP_SECTORS_HEIGHT;
            sectorWidth = width / Constants.MAP_SECTORS_WIDTH;

            double tempx;
            double tempy;
            double tempWidth;
            double tempHeight;

            //using (Graphics g = this.CreateGraphics())
            {
                //g.FillRectangle(staticGraphics.spaceBrush, this.ClientRectangle);
                g.DrawRectangle(staticGraphics.greenPen, this.ClientRectangle);

                for (int CurrentY = 0; CurrentY < Constants.MAP_SECTORS_HEIGHT; CurrentY++)
                {
                    for (int CurrentX = 0; CurrentX < Constants.MAP_SECTORS_WIDTH; CurrentX++)
                    {
                        tempx = CurrentX * sectorWidth;
                        tempy = CurrentY * sectorHeight;
                        tempWidth = sectorWidth;
                        tempHeight = sectorHeight ;

                        Sector ThisSector = theGrid[CurrentX, CurrentY];
                        if (ThisSector != null)
                        {
                            ThisSector.DrawSectorGraphics(g, this.ClientRectangle, (int)tempx, (int)tempy, (int)Math.Ceiling(tempWidth), (int)Math.Ceiling(tempHeight), 10);

                            // Check for clicked sector
                            if (ClickedSquare != null && ClickedSquare.Equals(ThisSector))
                            {
                                g.DrawRectangle(staticGraphics.greenPen, (int)tempx, (int)tempy, (int)Math.Ceiling(tempWidth), (int)Math.Ceiling(tempHeight));
                            }
                        }
                        else
                            g.FillRectangle(staticGraphics.UniverseBorderBrush, (int)tempx, (int)tempy, (int)Math.Ceiling(tempWidth), (int)Math.Ceiling(tempHeight));

                        if (ThisSector != null)
                        {
                            if (ThisSector.Equals(UserState.getCurrentSector()))
                            {
                                using (Image im = UserState.PlayerShip.GetSpaceShipImage())
                                {
                                    tempx = (CurrentX) * sectorWidth;
                                    tempy = (CurrentY) * sectorHeight;
                                    tempWidth = sectorWidth;
                                    tempHeight = sectorHeight;

                                    g.DrawImage(im, (int)tempx, (int)tempy, (int)Math.Ceiling(tempWidth), (int)Math.Ceiling(tempHeight));
                                }
                            }
                        }
                    }
                }
            }
        }


        public void updateGrid()
        {

            if (UniverseMapCenter == null)
                return;
            int currentY = UniverseMapCenter.SectorGridLocation.Y;
            int currentX = UniverseMapCenter.SectorGridLocation.X;

            for (int xOffset = (-1) * xRadius; xOffset <= xRadius; xOffset++)
            {
                for (int yOffset = (-1) * yRadius; yOffset <= yRadius; yOffset++)
                {
                    int gridX = xOffset + xRadius;
                    int gridY = yOffset + yRadius;

                    if (validatePoint(currentX + xOffset, currentY + yOffset))
                    {
                        theGrid[gridX, gridY] =
                            Universe.getSector(currentX + xOffset, currentY + yOffset);
                    }
                    else
                    {
                        // 
                        // Null is sentinel for now for off map. Need to change that at some point.
                        //
                        theGrid[gridX, gridY] = null;
                    }
                }
            }
        }

        private static bool validatePoint(int inx, int iny)
        {
            if ((inx < Constants.UNIVERSE_WIDTH) && (inx >= 0))
            {
                if ((iny < Constants.UNIVERSE_HEIGHT) && (iny >= 0))
                {
                    return true;
                }
            }
            return false;
        }

        public void UserKeyPress(int Key)
        {
            if (UniverseMapCenter == null)
                return;
            Sector newSector = null;

            switch (Key)
            {
                case 'w':       // Up
                    newSector = Universe.getSector(UniverseMapCenter.SectorGridLocation.X, UniverseMapCenter.SectorGridLocation.Y - 1);
                    break;
                case 's':       // Down
                    newSector = Universe.getSector(UniverseMapCenter.SectorGridLocation.X, UniverseMapCenter.SectorGridLocation.Y + 1);
                    break;
                case 'a':       // Left
                    newSector = Universe.getSector(UniverseMapCenter.SectorGridLocation.X - 1, UniverseMapCenter.SectorGridLocation.Y);
                    break;
                case 'd':       // Right
                    newSector = Universe.getSector(UniverseMapCenter.SectorGridLocation.X + 1, UniverseMapCenter.SectorGridLocation.Y);
                    break;
                default:
                    return;
            }

            if (newSector != null)
            {
                UniverseMapCenter = newSector;
                this.Refresh();
            }
        }

        private void UniverseMap_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void UniverseMap_MouseClick(object sender, MouseEventArgs e)
        {
            Point ClickPoint = e.Location;
            Sector tempClickedSector;
            int yClicked, xClicked;

            sectorHeight = Height / Constants.MAP_SECTORS_HEIGHT;
            sectorWidth = Width / Constants.MAP_SECTORS_WIDTH;

            // Divide click by height/width, discard remainder and you get sector
            yClicked = ClickPoint.Y / sectorHeight;
            xClicked = ClickPoint.X / sectorWidth;

            if (Constants.MAP_SECTORS_HEIGHT <= yClicked || Constants.MAP_SECTORS_WIDTH <= xClicked)
                return;

            tempClickedSector = theGrid[xClicked, yClicked];
            if (ClickedSquare != null)
            {
                // Unselect if clicked twice
                if (ClickedSquare.Equals(tempClickedSector))
                {
                    ClickedSquare = null;
                    this.Refresh();
                    if (RefreshParentUi != null)
                        RefreshParentUi.Invoke();
                    return;
                }
            }

            ClickedSquare = tempClickedSector;
            this.Refresh();

            if(RefreshParentUi != null)
                RefreshParentUi.Invoke();
        }
    }
}
