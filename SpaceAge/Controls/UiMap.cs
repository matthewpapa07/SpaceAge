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
            DoubleBuffered = true;

        }

        protected override void OnPaint(PaintEventArgs e)
        {
            drawMap(e.Graphics);
        }


        private void UiMap_Load(object sender, EventArgs e)
        {

        }


        public void drawMap(Graphics g)
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

            //using (Graphics g = this.CreateGraphics())
            {
                g.FillRectangle(staticGraphics.blackBrush, this.ClientRectangle);

                //g.FillRectangle(staticGraphics.blackBrush, this.
                for (int CurrentRow = 0; CurrentRow < Constants.MAP_SECTORS_ROWS; CurrentRow++)
                {
                    for (int CurrentCol = 0; CurrentCol < Constants.MAP_SECTORS_COLUMNS; CurrentCol++)
                    {
                        tempx = CurrentCol * sectorWidth + spaceWidth * (CurrentCol + 1);
                        tempy = CurrentRow * sectorHeight + spaceHeight * (CurrentRow + 1);
                        tempWidth = sectorWidth - spaceWidth;
                        tempHeight = sectorHeight - spaceHeight;

                        Sector ThisSector = UserState.theGrid[CurrentRow, CurrentCol];
                        if (ThisSector != null)
                        {
                            // g.FillRectangle(staticGraphics.blackBrush, (int)tempx, (int)tempy, (int)Math.Ceiling(tempWidth), (int)Math.Ceiling(tempHeight));
                            ThisSector.DrawSectorGraphics(g, this.ClientRectangle, (int)tempx, (int)tempy, (int)Math.Ceiling(tempWidth), (int)Math.Ceiling(tempHeight));
                        }
                        else
                            g.FillRectangle(hatchBrush, (int)tempx, (int)tempy, (int)Math.Ceiling(tempWidth), (int)Math.Ceiling(tempHeight));
                        
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

                    tempx = (Constants.MAP_SECTORS_COLUMNS / 2) * sectorWidth + spaceWidth * ((Constants.MAP_SECTORS_COLUMNS / 2) + 1);
                    tempy = (Constants.MAP_SECTORS_ROWS / 2) * sectorHeight + spaceHeight * ((Constants.MAP_SECTORS_ROWS / 2) + 1);
                    tempWidth = sectorWidth - spaceWidth;
                    tempHeight = sectorHeight - spaceHeight;

                    g.DrawImage(im, (int)tempx, (int)tempy, (int)Math.Ceiling(tempWidth), (int)Math.Ceiling(tempHeight));
                }
            }
        }

        private void UiMap_SizeChanged(object sender, EventArgs e)
        {
            using (Graphics g = this.CreateGraphics())
            {
                g.FillRectangle(staticGraphics.blackBrush, this.DisplayRectangle);
                drawMap(g);
            }
            
        }
    }
}
