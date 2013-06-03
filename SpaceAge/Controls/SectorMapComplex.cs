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
    partial class SectorMapComplex : UserControl, HumanInterfaceObj
    {
        Sector currentSector;
        StaticGraphics staticGraphics = StaticGraphics.getStaticGraphics();
        Image SpaceShipImage;
        static VectorD MovementVector = new VectorD(0.0, 0.0);

        public int TempShipSpeed = 20;
        public int TempRefreshRate = 20;  //ms

        // For Threads
        public Thread MapRefreshThread;
        public Thread ShipVelocityThread;
        public delegate void ShipInTransit();
        public ShipInTransit PlayerShipInTransit;

        public SectorMapComplex()
        {
            currentSector = UserState.getCurrentSector();
            SpaceShipImage = staticGraphics.GetSpaceShip();
            PlayerShipInTransit = new ShipInTransit(ShipMoverDelegate);
            MapRefreshThread = new Thread(new ThreadStart(RefreshScreen));
            ShipVelocityThread = new Thread(new ThreadStart(UpdateMovingShipsPosition));
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
                (staticGraphics.ScaleCoordinate(Sector.MAX_DISTANCE_FROM_AXIS, (int)UserState.SectorFineGridLocation.Y - SpaceShipImage.Width, RectToUse.Width)),
                (staticGraphics.ScaleCoordinate(Sector.MAX_DISTANCE_FROM_AXIS, (int)UserState.SectorFineGridLocation.X - SpaceShipImage.Height, RectToUse.Height))
                ,35,35);
        }

        public void ShipMoverDelegate()
        {
            this.Refresh();
        }

        public void RefreshScreen()
        {
            while (!this.IsDisposed)
            {
                if (PlayerShipInTransit != null && this.IsHandleCreated == true)
                    try
                    {
                        this.Invoke(PlayerShipInTransit);
                    }
                    catch{}
                }
            Thread.Sleep(TempRefreshRate);
        }

        public void UpdateMovingShipsPosition()
        {
            double WaitAmount = (1/(double)TempShipSpeed)*1000;
            while (!this.IsDisposed && this.IsHandleCreated == true)
            {
                UserState.SectorFineGridLocation.X += MovementVector.X * TempShipSpeed;
                UserState.SectorFineGridLocation.Y += MovementVector.Y * TempShipSpeed;
                Thread.Sleep((int)WaitAmount);
            }
            // TODO: Keep track of sector boundry
        }

        public void UserKeyPress(int Key)
        {

        }

        private void SectorMapComplex_KeyPress(object sender, KeyPressEventArgs e)
        {
            int Key = e.KeyChar;
            switch (Key)
            {
                case 'w':       // Up
                    MovementVector.X += -1.0;
                    MovementVector.Normalize();
                    break;
                case 's':       // Down
                    MovementVector.X += 1.0;
                    MovementVector.Normalize();
                    break;
                case 'a':       // Left
                    MovementVector.Y += -1.0;
                    MovementVector.Normalize();
                    break;
                case 'd':       // Right
                    MovementVector.Y += 1.0;
                    MovementVector.Normalize();
                    break;
                case ' ':       // Stop
                    MovementVector.X = 0.0;
                    MovementVector.Y = 0.0;
                    break;
                default:
                    break;
            }
        }

        private void SectorMapComplex_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

    }
}
