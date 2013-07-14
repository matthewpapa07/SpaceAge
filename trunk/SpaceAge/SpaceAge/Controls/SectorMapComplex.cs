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
        StaticGraphics staticGraphics = StaticGraphics.getStaticGraphics();
        Image SpaceShipImage;
        Bitmap RotatedImage;

        public int TempShipSpeed = 20;
        public int TempRefreshRate = 28;  //ms

        // For Threads
        public Thread MapRefreshThread;
        public EventToInvoke PlayerShipInTransit;

        // For graphics
        public Bitmap OriginalImage;

        public SectorMapComplex()
        {
            SpaceShipImage = staticGraphics.GetSpaceShip();
            PlayerShipInTransit = new EventToInvoke(ShipMoverDelegate);
            //KeyboardCheck = new EventToInvoke(TakeUserInput);
            MapRefreshThread = new Thread(new ThreadStart(RefreshScreen));
            
            //KeyboardCheckThread = new Thread(new ThreadStart(RefreshKeystrokes));
            this.DoubleBuffered = true;
            OriginalImage = new Bitmap(staticGraphics.GetSpaceShip());
            RotatedImage = GraphicsLib.RotateBitmap(OriginalImage, ((UserState.PlayerShip.DirectionVector.GetAngle())));

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
            Sector currentSector = UserState.getCurrentSector();

            Point ShipControlCoordinates = new Point(0, 0);
            //Bitmap RotatedImage;
            Rectangle RectToUse = this.ClientRectangle;
            if (currentSector != null)
                currentSector.DrawSectorGraphics(GraphicsToUse, RectToUse, 0, 0, RectToUse.Width, RectToUse.Height);

            {
                //Console.WriteLine("Rotation angle " + MovementVector.GetAngle());
                ShipControlCoordinates.Y = (
                    staticGraphics.ScaleCoordinate(
                    Sector.MAX_DISTANCE_FROM_AXIS, 
                    (int)UserState.PlayerShip.SectorFineGridLocation.Y  - SpaceShipImage.Height/2, RectToUse.Height
                    ));
                ShipControlCoordinates.X = (
                    staticGraphics.ScaleCoordinate(
                    Sector.MAX_DISTANCE_FROM_AXIS,
                    (int)UserState.PlayerShip.SectorFineGridLocation.X - SpaceShipImage.Width / 2, RectToUse.Width
                    ));
                GraphicsToUse.DrawImage(
                    RotatedImage,
                    ShipControlCoordinates.X,
                    ShipControlCoordinates.Y,
                    35, 35);
            }

            if (UserState.PlayerShip.ShipState == SpaceShip.SpaceShipState.MovingSectors || UserState.PlayerShip.ShipState == SpaceShip.SpaceShipState.MovingWithinSector)
            {
                Rectangle waypointRect = new Rectangle(
                    staticGraphics.ScaleCoordinate(
                    Sector.MAX_DISTANCE_FROM_AXIS,
                    (int)UserState.PlayerShip.DestinationPoint.X, RectToUse.Width),
                    staticGraphics.ScaleCoordinate(
                        Sector.MAX_DISTANCE_FROM_AXIS,
                        (int)UserState.PlayerShip.DestinationPoint.Y,
                        RectToUse.Height),
                    5,
                    5
                    );
                GraphicsToUse.FillEllipse(staticGraphics.greenBrush, waypointRect);

            }

            GraphicsToUse.DrawRectangle(staticGraphics.redPen, this.ClientRectangle);
        }

        public void ShipMoverDelegate()
        {
            this.Refresh();
        }

        public void RefreshScreen()
        {
            while (MapRefreshThread.IsAlive && UserState.ThreadsRunning)
            {
                if (PlayerShipInTransit != null && this.IsHandleCreated == true)
                {
                    try
                    {
                        this.Invoke(PlayerShipInTransit);
                    }
                    catch { }
                }
                Thread.Sleep(TempRefreshRate);
            }
        }

        private void SectorMapComplex_KeyPress(object sender, KeyPressEventArgs e)
        {
            //int Key = e.KeyChar;
            //switch (Key)
            //{
            //    //case 'w':       // Up
            //    //    break;
            //    //case 's':       // Down
            //    //    break;
            //    //case 'a':       // Left
            //    //    break;
            //    //case 'd':       // Right
            //    //    break;
            //    //case ' ':       // Stop
            //    //    break;
            //    //default:
            //    //    break;
            //}
        }

        private void SectorMapComplex_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Point ClickPoint;

            // Convert graphics point to sector coordinate. loss of precision is expected of course
            ClickPoint = e.Location;
            UserState.PlayerShip.DestinationPoint.X = staticGraphics.ScaleCoordinate(ClientRectangle.Width, ClickPoint.X, Sector.MAX_DISTANCE_FROM_AXIS);
            UserState.PlayerShip.DestinationPoint.Y = staticGraphics.ScaleCoordinate(ClientRectangle.Height, ClickPoint.Y, Sector.MAX_DISTANCE_FROM_AXIS);


            UserState.PlayerShip.DirectionVector.X = UserState.PlayerShip.SectorFineGridLocation.X - UserState.PlayerShip.DestinationPoint.X;
            UserState.PlayerShip.DirectionVector.Y = UserState.PlayerShip.SectorFineGridLocation.Y - UserState.PlayerShip.DestinationPoint.Y;

            UserState.getCurrentSector().ClickForObject(UserState.PlayerShip.DestinationPoint);
            UserState.PlayerShip.DirectionVector.Normalize();
            RefreshImages();

            UserState.PlayerShip.ShipState = SpaceShip.SpaceShipState.MovingWithinSector;

            //Console.WriteLine("Double click at X:" + ClickPoint.X + " Y:" + ClickPoint.Y + " Angle:" + DirectionVector.GetAngle());

        }

        public void RefreshImages()
        {
            if (RotatedImage != null)
            {
                RotatedImage.Dispose();
            }
            RotatedImage = GraphicsLib.RotateBitmap(OriginalImage, ((UserState.PlayerShip.DirectionVector.GetAngle())));
        }
    }
}
