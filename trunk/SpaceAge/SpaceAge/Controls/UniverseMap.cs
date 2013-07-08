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
        const int colRadius = Constants.MAP_SECTORS_COLUMNS / 2;    //truncate here if odd
        const int rowRadius = Constants.MAP_SECTORS_ROWS / 2;      //truncate here if odd
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

            int startingRow = Constants.UNIVERSE_ROWS / 2;
            int startingColumn = Constants.UNIVERSE_COLUMNS / 2;
            theGrid = new Sector[Constants.MAP_SECTORS_ROWS, Constants.MAP_SECTORS_COLUMNS];
            UniverseMapCenter = Universe.getSector(startingRow, startingColumn);

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
            UserState.UserStateMachine = UserState.UState.UniverseMap;

            height = this.Height;
            width = this.Width;

            sectorHeight= height / Constants.MAP_SECTORS_COLUMNS;
            sectorWidth = width / Constants.MAP_SECTORS_ROWS;

            double tempx;
            double tempy;
            double tempWidth;
            double tempHeight;

            //using (Graphics g = this.CreateGraphics())
            {
                //g.FillRectangle(staticGraphics.spaceBrush, this.ClientRectangle);
                g.DrawRectangle(staticGraphics.greenPen, this.ClientRectangle);

                for (int CurrentRow = 0; CurrentRow < Constants.MAP_SECTORS_ROWS; CurrentRow++)
                {
                    for (int CurrentCol = 0; CurrentCol < Constants.MAP_SECTORS_COLUMNS; CurrentCol++)
                    {
                        tempx = CurrentCol * sectorWidth;
                        tempy = CurrentRow * sectorHeight;
                        tempWidth = sectorWidth;
                        tempHeight = sectorHeight ;

                        Sector ThisSector = theGrid[CurrentRow, CurrentCol];
                        if (ThisSector != null)
                        {
                            ThisSector.DrawSectorGraphics(g, this.ClientRectangle, (int)tempx, (int)tempy, (int)Math.Ceiling(tempWidth), (int)Math.Ceiling(tempHeight));

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
                                using (Image im = staticGraphics.GetSpaceShip())
                                {
                                    tempx = (CurrentCol) * sectorWidth;
                                    tempy = (CurrentRow) * sectorHeight;
                                    tempWidth = sectorWidth;
                                    tempHeight = sectorHeight;

                                    g.DrawImage(im, (int)tempx, (int)tempy, (int)Math.Ceiling(tempWidth), (int)Math.Ceiling(tempHeight));
                                }
                            }
                        }
                    }
                }

                //tempx = (Constants.MAP_SECTORS_COLUMNS / 2) * sectorWidth;
                //tempy = (Constants.MAP_SECTORS_ROWS / 2) * sectorHeight;
                //tempWidth = sectorWidth;
                //tempHeight = sectorHeight;

                //g.DrawRectangle(staticGraphics.whitePen, (int)tempx, (int)tempy, (int)Math.Ceiling(tempWidth), (int)Math.Ceiling(tempHeight));

                ////
                //// Draw the ship in the middle
                ////
                //using(Image im = staticGraphics.GetSpaceShip())
                //{
                //    switch (UserState.progState)
                //    {
                //        case (int)UserState.ShipOrientationState.Down:
                //            im.RotateFlip(RotateFlipType.Rotate270FlipNone);
                //            break;
                //        case (int)UserState.ShipOrientationState.Up:
                //            im.RotateFlip(RotateFlipType.Rotate90FlipNone);
                //            break;
                //        case (int)UserState.ShipOrientationState.Left:
                //            im.RotateFlip(RotateFlipType.RotateNoneFlipNone);
                //            break;
                //        case (int)UserState.ShipOrientationState.Right:
                //            im.RotateFlip(RotateFlipType.Rotate180FlipNone);
                //            break;
                //        default:
                //            break;
                //    }

                //    tempx = (Constants.MAP_SECTORS_COLUMNS / 2) * sectorWidth + spaceWidth * ((Constants.MAP_SECTORS_COLUMNS / 2) + 1);
                //    tempy = (Constants.MAP_SECTORS_ROWS / 2) * sectorHeight + spaceHeight * ((Constants.MAP_SECTORS_ROWS / 2) + 1);
                //    tempWidth = sectorWidth - spaceWidth;
                //    tempHeight = sectorHeight - spaceHeight;

                //    g.DrawImage(im, (int)tempx, (int)tempy, (int)Math.Ceiling(tempWidth), (int)Math.Ceiling(tempHeight));
                //}
            }
        }


        public void updateGrid()
        {

            if (UniverseMapCenter == null)
                return;
            int currentCol = UniverseMapCenter.SectorGridLocation.Y;
            int currentRow = UniverseMapCenter.SectorGridLocation.X;

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

        public void UserKeyPress(int Key)
        {
            if (UniverseMapCenter == null)
                return;
            Sector newSector = null;

            switch (Key)
            {
                case 'w':       // Up
                    newSector = Universe.getSector(UniverseMapCenter.SectorGridLocation.X - 1, UniverseMapCenter.SectorGridLocation.Y);
                    break;
                case 's':       // Down
                    newSector = Universe.getSector(UniverseMapCenter.SectorGridLocation.X + 1, UniverseMapCenter.SectorGridLocation.Y);
                    break;
                case 'a':       // Left
                    newSector = Universe.getSector(UniverseMapCenter.SectorGridLocation.X, UniverseMapCenter.SectorGridLocation.Y - 1);
                    break;
                case 'd':       // Right
                    newSector = Universe.getSector(UniverseMapCenter.SectorGridLocation.X, UniverseMapCenter.SectorGridLocation.Y + 1);
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
            int rowClicked, colClicked;

            height = this.Height;
            width = this.Width;

            sectorHeight = height / Constants.MAP_SECTORS_COLUMNS;
            sectorWidth = width / Constants.MAP_SECTORS_ROWS;

            rowClicked = ClickPoint.Y / sectorHeight;
            colClicked = ClickPoint.X / sectorWidth;

            tempClickedSector = theGrid[rowClicked, colClicked];
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
