using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SpaceAge.Controls
{
    partial class UiSectorMap : UserControl
    {
        Sector          currentSector;
        StaticGraphics  staticGraphics = StaticGraphics.getStaticGraphics();
        int             stepsPerCoordinate = 0;

        public UiSectorMap(Sector s)
        {
            currentSector = s;
            //
            // Assume height == width when determining points per pixel
            //
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            drawSector();
        }

        private void UiSectorMap_Load(object sender, EventArgs e)
        {

        }

        public void drawSector()
        {
            int listLength;
            stepsPerCoordinate = Sector.MAX_DISTANCE_FROM_AXIS / Height;

            using (Graphics g = this.CreateGraphics())
            {
                g.FillRectangle(staticGraphics.blackBrush, this.DisplayRectangle);

                if (currentSector == null)
                    return;

                listLength = currentSector.StarSystemsList.Length;
                //using (Pen p = new Pen(StaticGraphics.getStaticGraphics().greenBrush))
                //{
                //    g.DrawLine(p, 0, Sector.MAX_DISTANCE_FROM_AXIS / 2, Sector.MAX_DISTANCE_FROM_AXIS / 2, 0);
                //}

                if(listLength == 0)
                    return;

                //Star[] theStars = new Star[listLength];
                for (int i = 0; i < listLength; i++)
                {
                    Star currentStar = currentSector.StarSystemsList[i].stars[0];
                    Point currentPoint = currentSector.StarSystemsList[i].StarSystemLocation;

                    currentStar.DrawStarGraphics(g, currentPoint.X / stepsPerCoordinate, currentPoint.Y / stepsPerCoordinate);

                }
            }
        }
    }
}
