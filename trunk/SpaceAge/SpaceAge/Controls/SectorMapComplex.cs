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
        VectorD DirectionVector = new VectorD(0.0, 1.0);
        PointD DestinationPoint = new PointD(0.0, 0.0);
        //Point TempCoordiantes = new Point(0, 0);
        
        // For ship waypoints
        bool ClickEnabled = false;

        public int TempShipSpeed = 15;
        public int TempRefreshRate = 20;  //ms

        // For Threads
        public Thread MapRefreshThread;
        public Thread ShipVelocityThread;
        //public Thread KeyboardCheckThread;
        public delegate void EventToInvoke();
        public EventToInvoke PlayerShipInTransit;
        //public EventToInvoke KeyboardCheck;

        // For graphics
        public Bitmap OriginalImage;

        public SectorMapComplex()
        {
            currentSector = UserState.getCurrentSector();
            SpaceShipImage = staticGraphics.GetSpaceShip();
            PlayerShipInTransit = new EventToInvoke(ShipMoverDelegate);
            //KeyboardCheck = new EventToInvoke(TakeUserInput);
            MapRefreshThread = new Thread(new ThreadStart(RefreshScreen));
            ShipVelocityThread = new Thread(new ThreadStart(UpdateMovingShipsPosition));
            //KeyboardCheckThread = new Thread(new ThreadStart(RefreshKeystrokes));
            this.DoubleBuffered = true;
            OriginalImage = new Bitmap(staticGraphics.GetSpaceShip());

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
            Point ShipControlCoordinates = new Point(0, 0);
            //Bitmap RotatedImage;
            Rectangle RectToUse = this.ClientRectangle;
            if(currentSector != null)
                currentSector.DrawSectorGraphics(GraphicsToUse, RectToUse, 0, 0, RectToUse.Width, RectToUse.Height);

            using (Bitmap RotatedImage = GraphicsLib.RotateBitmap(OriginalImage, ((DirectionVector.GetAngle())) ))
            {
                //Console.WriteLine("Rotation angle " + MovementVector.GetAngle());
                ShipControlCoordinates.Y = (
                    staticGraphics.ScaleCoordinate(
                    Sector.MAX_DISTANCE_FROM_AXIS, 
                    (int)UserState.SectorFineGridLocation.Y  - SpaceShipImage.Width/2, RectToUse.Width
                    ));
                ShipControlCoordinates.X = (
                    staticGraphics.ScaleCoordinate(
                    Sector.MAX_DISTANCE_FROM_AXIS, 
                    (int)UserState.SectorFineGridLocation.X - SpaceShipImage.Height/2, RectToUse.Height
                    ));
                GraphicsToUse.DrawImage(RotatedImage,
                    ShipControlCoordinates.Y,
                    ShipControlCoordinates.X,
                    35, 35);
            }

            if (ClickEnabled)
            {
                Rectangle waypointRect = new Rectangle(staticGraphics.ScaleCoordinate(
                    Sector.MAX_DISTANCE_FROM_AXIS, 
                    (int)DestinationPoint.X, RectToUse.Height),
                    staticGraphics.ScaleCoordinate(
                        Sector.MAX_DISTANCE_FROM_AXIS, 
                        (int)DestinationPoint.Y, 
                        RectToUse.Width), 
                    5, 
                    5
                    );
                GraphicsToUse.FillEllipse(staticGraphics.greenBrush, waypointRect);
                
            }
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

        //public void RefreshKeystrokes()
        //{
        //    while (!this.IsDisposed)
        //    {
        //        if (PlayerShipInTransit != null && this.IsHandleCreated == true)
        //        {
        //            try
        //            {
        //                this.Invoke(KeyboardCheck);
        //            }
        //            catch { }
        //        }
        //        Thread.Sleep(20);
        //    }
        //}

        public void UpdateMovingShipsPosition()
        {
            // Only refresh position as fast as the ship's rate of speed
            double WaitAmount = (1/(double)TempShipSpeed)*1000;
            while (!this.IsDisposed && this.IsHandleCreated == true)
            {

                if (!DestinationPoint.Equals(UserState.SectorFineGridLocation) && ClickEnabled)
                {
                    DirectionVector.X = UserState.SectorFineGridLocation.X - DestinationPoint.X;
                    DirectionVector.Y = UserState.SectorFineGridLocation.Y - DestinationPoint.Y;
                    DirectionVector.Normalize();
      
                    double dx = DirectionVector.X * TempShipSpeed;
                    double dy = DirectionVector.Y * TempShipSpeed;
                    double distanceActual = DestinationPoint.Distance(UserState.SectorFineGridLocation);
                    
                    // Since the frame only refreshes the period of the velocity, our distance will always be 1.0
                    if (distanceActual <= 1.0)
                    {
                        UserState.SectorFineGridLocation.X = DestinationPoint.X;
                        UserState.SectorFineGridLocation.Y = DestinationPoint.Y;
                        ClickEnabled = false;
                    }
                    else
                    {
                        PointD TestPoint = new PointD(0.0, 0.0);
                        TestPoint.X = UserState.SectorFineGridLocation.X + dx;
                        if (distanceActual > TestPoint.Distance(DestinationPoint))
                        {
                            UserState.SectorFineGridLocation.X += dx;
                        }
                        else
                        {
                            UserState.SectorFineGridLocation.X -= dx;
                        }
                        distanceActual = DestinationPoint.Distance(UserState.SectorFineGridLocation);
                        TestPoint.Y = UserState.SectorFineGridLocation.Y + dy;
                        if (distanceActual > TestPoint.Distance(DestinationPoint))
                        {
                            UserState.SectorFineGridLocation.Y += dy;
                        }
                        else
                        {
                            UserState.SectorFineGridLocation.Y -= dy;
                        }


                        //TestPoint.Y = UserState.SectorFineGridLocation.Y + dy;
                        //UserState.SectorFineGridLocation.X += dx;
                        //UserState.SectorFineGridLocation.Y += dy;
                        //double absLocation = UserState.SectorFineGridLocation.X + dx;
                        //if (absLocation > UserState.SectorFineGridLocation.X)
                        //    UserState.SectorFineGridLocation.X -= dx;
                        //else
                        //    UserState.SectorFineGridLocation.X += dx;

                        //absLocation = UserState.SectorFineGridLocation.Y + dy;
                        //if (absLocation > UserState.SectorFineGridLocation.Y)
                        //    UserState.SectorFineGridLocation.Y -= dy;
                        //else
                        //    UserState.SectorFineGridLocation.Y += dy;


                    }

                }

                Thread.Sleep((int)WaitAmount);
            }
            // TODO: Keep track of sector boundry
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
            DestinationPoint.X = staticGraphics.ScaleCoordinate(ClientRectangle.Height, ClickPoint.X, Sector.MAX_DISTANCE_FROM_AXIS);
            DestinationPoint.Y = staticGraphics.ScaleCoordinate(ClientRectangle.Width, ClickPoint.Y, Sector.MAX_DISTANCE_FROM_AXIS);

            DirectionVector.X = UserState.SectorFineGridLocation.X - DestinationPoint.X;
            DirectionVector.Y = UserState.SectorFineGridLocation.Y - DestinationPoint.Y;

            ClickEnabled = true;

            Console.WriteLine("Double click at X:" + ClickPoint.X + " Y:" + ClickPoint.Y + " Angle:" + DirectionVector.GetAngle());

        }
    }
}
