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
    partial class SectorMapSimple : UserControl
    {
        Sector          currentSector;
        StaticGraphics  staticGraphics = StaticGraphics.getStaticGraphics();
        int             stepsPerCoordinate = 0;

        public SectorMapSimple(Sector s)
        {
            currentSector = s;
            //
            // Assume height == width when determining points per pixel
            //
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            drawSector(e.Graphics);
        }

        private void UiSectorMap_Load(object sender, EventArgs e)
        {

        }

        public void drawSector(Graphics GraphicsToUse)
        {
            stepsPerCoordinate = Sector.MAX_DISTANCE_FROM_AXIS / Height;
            int DrawX;
            int DrawY;

            GraphicsToUse.FillRectangle(staticGraphics.blackBrush, this.DisplayRectangle);
            //
            // Draw the random stars in the background
            //
            foreach (Point p in currentSector.RandomBackgroundStars)
            {
                DrawX = staticGraphics.ScaleCoordinate(Sector.MAX_DISTANCE_FROM_AXIS, p.X, this.ClientRectangle.Width);
                DrawY = staticGraphics.ScaleCoordinate(Sector.MAX_DISTANCE_FROM_AXIS, p.Y, this.ClientRectangle.Height);
                if (DrawX < 0 || DrawY < 0)
                    continue;

                GraphicsToUse.DrawRectangle(staticGraphics.whitePen, new Rectangle(DrawX, DrawY, 1, 1));
            }

            if (currentSector == null)
                return;

            foreach (ISectorMember ism in currentSector.PresentSectorMembers)
            {
                using (Bitmap ismBitmap = ism.GetImage(5))
                {
                    GraphicsToUse.DrawImage(ismBitmap, ism.SectorFineGridLocation.X / stepsPerCoordinate, ism.SectorFineGridLocation.Y / stepsPerCoordinate);
                }
            }
        }
    }
}
