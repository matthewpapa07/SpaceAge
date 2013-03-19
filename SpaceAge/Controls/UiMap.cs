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
    public partial class UiMap : UserControl
    {
        HatchBrush hatchBrush = new HatchBrush(HatchStyle.Cross, System.Drawing.Color.Red, System.Drawing.Color.Blue);

        public static Rectangle[,] theGrid;
        StaticGraphics staticGraphics = StaticGraphics.getStaticGraphics();

        int height;
        int width;
        int sectorWidth;
        int sectorHeight;
        int spaceWidth;
        int spaceHeight;

        public UiMap()
        {
            InitializeComponent();
            //DoubleBuffered = true;

        }

        protected override void OnPaint(PaintEventArgs e)
        {
            drawMap();
        }


        private void UiMap_Load(object sender, EventArgs e)
        {
            theGrid = new Rectangle[Constants.MAP_SECTORS_ROWS, Constants.MAP_SECTORS_COLUMNS];

            for (int CurrentRow = 0; CurrentRow < Constants.MAP_SECTORS_ROWS; CurrentRow++)
            {
                for (int CurrentCol = 0; CurrentCol < Constants.MAP_SECTORS_COLUMNS; CurrentCol++)
                {
                    theGrid[CurrentRow, CurrentCol] = new Rectangle();
                }
            }

        }


        public void drawMap()
        {
            height = this.Height;
            width = this.Width;

            sectorHeight= height / Constants.MAP_SECTORS_COLUMNS;
            sectorWidth = width / Constants.MAP_SECTORS_ROWS;

            spaceWidth = 0;
            spaceHeight = 0;

            sectorHeight -= spaceHeight;
            sectorWidth -= spaceWidth;

            double tempx;
            double tempy;
            double tempWidth;
            double tempHeight;

            using (Graphics g = this.CreateGraphics())
            {
                //g.FillRectangle(staticGraphics.blackBrush, this.
                for (int CurrentRow = 0; CurrentRow < Constants.MAP_SECTORS_ROWS; CurrentRow++)
                {
                    for (int CurrentCol = 0; CurrentCol < Constants.MAP_SECTORS_COLUMNS; CurrentCol++)
                    {
                        tempx = CurrentCol * sectorWidth + spaceWidth * (CurrentCol + 1);
                        tempy = CurrentRow * sectorHeight + spaceHeight * (CurrentRow + 1);
                        tempWidth = sectorWidth - spaceWidth;
                        tempHeight = sectorHeight - spaceHeight;

                        //
                        // Snap the sectors to the grid
                        //
                        theGrid[CurrentRow, CurrentCol].Height = (int)Math.Ceiling(tempHeight);
                        theGrid[CurrentRow, CurrentCol].Width = (int)Math.Ceiling(tempWidth);
                        theGrid[CurrentRow, CurrentCol].X = (int)tempx;
                        theGrid[CurrentRow, CurrentCol].Y = (int)tempy;

                        //using (Graphics g = this.CreateGraphics())
                        {
                            Sector thisSector = UserState.theGrid[CurrentRow, CurrentCol];

                            if (thisSector == null)
                            {
                                g.FillRectangle(hatchBrush, theGrid[CurrentRow, CurrentCol]);
                            }
                            else
                            {
                                thisSector.DrawSectorGraphics(g, theGrid[CurrentRow, CurrentCol]);
                            }
                        }
                        
                    }
                }

                //
                // If in middle position draw the ship
                //
                using(Image im = staticGraphics.GetSpaceShip())
                {
                    switch (UserState.progState)
                    {
                        case (int)UserState.ShipOrientationState.Down:
                            im.RotateFlip(RotateFlipType.Rotate180FlipNone);
                            break;
                        case (int)UserState.ShipOrientationState.Up:
                            im.RotateFlip(RotateFlipType.RotateNoneFlipNone);
                            break;
                        case (int)UserState.ShipOrientationState.Left:
                            im.RotateFlip(RotateFlipType.Rotate270FlipNone);
                            break;
                        case (int)UserState.ShipOrientationState.Right:
                            im.RotateFlip(RotateFlipType.Rotate90FlipNone);
                            break;
                        default:
                            break;
                    }

                    g.DrawImage(im, theGrid[Constants.MAP_SECTORS_ROWS / 2, Constants.MAP_SECTORS_COLUMNS / 2]);
                }
            }
        }

        private void UiMap_SizeChanged(object sender, EventArgs e)
        {
            using (Graphics g = this.CreateGraphics())
            {
                g.FillRectangle(staticGraphics.blackBrush, this.DisplayRectangle);
            }
            drawMap();
        }
    }
}
