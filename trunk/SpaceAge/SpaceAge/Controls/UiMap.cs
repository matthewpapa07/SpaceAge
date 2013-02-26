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
        SolidBrush blackBrush = new SolidBrush(System.Drawing.Color.Black);
        SolidBrush greenBrush = new SolidBrush(System.Drawing.Color.Green);
        SolidBrush redBrush = new SolidBrush(System.Drawing.Color.Red);
        HatchBrush hatchBrush = new HatchBrush(HatchStyle.Cross, System.Drawing.Color.Red, System.Drawing.Color.Blue);

        Rectangle[,] theGrid;
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
            //using (Graphics g = this.CreateGraphics())
            //{
            //    g.FillRectangle(greenBrush, this.DisplayRectangle);
            //}

            //base.OnPaint(e);
            //height = ClientRectangle.Height;
            //width = ClientRectangle.Width;
            height = this.Height;
            width = this.Width;

            sectorHeight= height / Constants.MAP_SECTORS_COLUMNS;
            sectorWidth = width / Constants.MAP_SECTORS_ROWS;

            double tempDoub;
            tempDoub = sectorWidth * ((float)Constants.MAP_PADDING_PERCENT / 100);
            spaceWidth = (int)tempDoub;
            spaceWidth /= 2;
            tempDoub = sectorHeight * ((float)Constants.MAP_PADDING_PERCENT / 100);
            spaceHeight = (int)tempDoub;
            spaceHeight /= 2;

            sectorHeight -= spaceHeight;
            sectorWidth -= spaceWidth;

            int tempx;
            int tempy;
            int tempWidth;
            int tempHeight;

            using (Graphics g = this.CreateGraphics())
            {
                for (int CurrentRow = 0; CurrentRow < Constants.MAP_SECTORS_ROWS; CurrentRow++)
                {
                    for (int CurrentCol = 0; CurrentCol < Constants.MAP_SECTORS_COLUMNS; CurrentCol++)
                    {
                        tempx = CurrentCol * sectorWidth + spaceWidth * (CurrentCol + 1);
                        tempy = CurrentRow * sectorHeight + spaceHeight * (CurrentRow + 1);
                        tempWidth = sectorWidth - spaceWidth;
                        tempHeight = sectorHeight - spaceHeight;

                        theGrid[CurrentRow, CurrentCol].Height = tempHeight;
                        theGrid[CurrentRow, CurrentCol].Width = tempWidth;
                        theGrid[CurrentRow, CurrentCol].X = tempx;
                        theGrid[CurrentRow, CurrentCol].Y = tempy;

                        //using (Graphics g = this.CreateGraphics())
                        {
                            Sector thisSector = UserState.theGrid[CurrentRow, CurrentCol];

                            if (thisSector == null)
                            {
                                g.FillRectangle(hatchBrush, theGrid[CurrentRow, CurrentCol]);
                            }
                            else
                            {
                                /////
                                /////TODO: Make these numbers constants so they can be easily adjusted
                                /////
                                //if (thisSector.getNumOfSystems() == 0)
                                //{
                                //    g.DrawImage(staticGraphics.emptySpace, theGrid[CurrentRow, CurrentCol]);
                                //}
                                //if ((thisSector.getNumOfSystems() >= 1) && (thisSector.getNumOfSystems() <= 3))
                                //{
                                //    g.DrawImage(staticGraphics.fewSystems, theGrid[CurrentRow, CurrentCol]);
                                //}
                                //if (thisSector.getNumOfSystems() > 3)
                                //{
                                //    g.DrawImage(staticGraphics.manySystems, theGrid[CurrentRow, CurrentCol]);
                                //}
                                thisSector.DrawSectorGraphics(g, theGrid[CurrentRow, CurrentCol]);

                                if(CurrentRow == (Constants.MAP_SECTORS_ROWS / 2))
                                    if(CurrentCol == (Constants.MAP_SECTORS_COLUMNS / 2))
                                        g.DrawImage(StaticGraphics.getSpaceShip(), theGrid[CurrentRow, CurrentCol]);
                            }
                        }
                        
                    }
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
