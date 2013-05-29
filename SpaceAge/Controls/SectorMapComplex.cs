using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace SpaceAge.Controls
{
    partial class SectorMapComplex : UserControl
    {
        Sector currentSector;
        StaticGraphics staticGraphics = StaticGraphics.getStaticGraphics();
        Image SpaceShipImage;

        // For Threads
        Thread BackgroundThread;
        public delegate void ShipInTransit();
        public ShipInTransit PlayerShipInTransit;

        public SectorMapComplex()
        {
            currentSector = UserState.getCurrentSector();
            SpaceShipImage = staticGraphics.GetSpaceShip();
            PlayerShipInTransit = new ShipInTransit(ShipMoverDelegate);
            BackgroundThread = new Thread(new ThreadStart(MoveShips));
            this.DoubleBuffered = true;
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

        public void StartMovement()
        {
            BackgroundThread.Start();
        }

        public void drawSector(Graphics GraphicsToUse)
        {
            Rectangle RectToUse = this.ClientRectangle;
            if(currentSector != null)
                currentSector.DrawSectorGraphics(GraphicsToUse, RectToUse, 0, 0, RectToUse.Width, RectToUse.Height);

            //GraphicsToUse.DrawImage(SpaceShipImage,
            //    (staticGraphics.ScaleCoordinate(Sector.MAX_DISTANCE_FROM_AXIS, UserState.FineGridLocation.Y-SpaceShipImage.Width, RectToUse.Width)),
            //    (staticGraphics.ScaleCoordinate(Sector.MAX_DISTANCE_FROM_AXIS, UserState.FineGridLocation.X - SpaceShipImage.Height, RectToUse.Height))
            //    );
            GraphicsToUse.DrawImage(SpaceShipImage,
                (staticGraphics.ScaleCoordinate(Sector.MAX_DISTANCE_FROM_AXIS, UserState.FineGridLocation.Y - SpaceShipImage.Width, RectToUse.Width)),
                (staticGraphics.ScaleCoordinate(Sector.MAX_DISTANCE_FROM_AXIS, UserState.FineGridLocation.X - SpaceShipImage.Height, RectToUse.Height))
                ,35,35);
        }

        public void ShipMoverDelegate()
        {
            // TODO: Eventually make this based off the ship stat
            // TODO: Bounds checking
            UserState.FineGridLocation.Y += 10;
            UserState.FineGridLocation.X += 10;
            this.Refresh();
        }

        public void MoveShips()
        {
            for (int i = 0; i < 200; i++)
            {
                this.Invoke(PlayerShipInTransit);
                Thread.Sleep(100);
            }
        }
    }
}
