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
        int MovementVelocity;
        VectorD DirectionVector = new VectorD(0.0, 0.0);
        Point ShipControlCoordinates = new Point(0, 0);
        //Point TempCoordiantes = new Point(0, 0);
        
        // For ship waypoints
        Point ClickPoint = new Point(0, 0);
        bool ClickEnabled = false;

        public int TempShipSpeed = 15;
        public int TempRefreshRate = 20;  //ms

        // For Threads
        public Thread MapRefreshThread;
        public Thread ShipVelocityThread;
        public Thread KeyboardCheckThread;
        public delegate void EventToInvoke();
        public EventToInvoke PlayerShipInTransit;
        public EventToInvoke KeyboardCheck;

        // For graphics
        public Bitmap OriginalImage;

        public SectorMapComplex()
        {
            currentSector = UserState.getCurrentSector();
            SpaceShipImage = staticGraphics.GetSpaceShip();
            PlayerShipInTransit = new EventToInvoke(ShipMoverDelegate);
            KeyboardCheck = new EventToInvoke(TakeUserInput);
            MapRefreshThread = new Thread(new ThreadStart(RefreshScreen));
            ShipVelocityThread = new Thread(new ThreadStart(UpdateMovingShipsPosition));
            KeyboardCheckThread = new Thread(new ThreadStart(RefreshKeystrokes));
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
            //Bitmap RotatedImage;
            Rectangle RectToUse = this.ClientRectangle;
            if(currentSector != null)
                currentSector.DrawSectorGraphics(GraphicsToUse, RectToUse, 0, 0, RectToUse.Width, RectToUse.Height);

            using (Bitmap RotatedImage = GraphicsLib.RotateBitmap(OriginalImage, ((DirectionVector.GetAngle())) ))
            {
                //Console.WriteLine("Rotation angle " + MovementVector.GetAngle());
                ShipControlCoordinates.Y = (staticGraphics.ScaleCoordinate(Sector.MAX_DISTANCE_FROM_AXIS, (int)UserState.SectorFineGridLocation.Y - SpaceShipImage.Width, RectToUse.Width));
                ShipControlCoordinates.X = (staticGraphics.ScaleCoordinate(Sector.MAX_DISTANCE_FROM_AXIS, (int)UserState.SectorFineGridLocation.X - SpaceShipImage.Height, RectToUse.Height));
                GraphicsToUse.DrawImage(RotatedImage,
                    ShipControlCoordinates.Y,
                    ShipControlCoordinates.X,
                    35, 35);
            }

            if (ClickEnabled)
            {
                Rectangle waypointRect = new Rectangle(ClickPoint.X, ClickPoint.Y, 5, 5);
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

        public void RefreshKeystrokes()
        {
            while (!this.IsDisposed)
            {
                if (PlayerShipInTransit != null && this.IsHandleCreated == true)
                {
                    try
                    {
                        this.Invoke(KeyboardCheck);
                    }
                    catch { }
                }
                Thread.Sleep(20);
            }
        }

        public void UpdateMovingShipsPosition()
        {
            double WaitAmount = (1/(double)TempShipSpeed)*1000;
            while (!this.IsDisposed && this.IsHandleCreated == true)
            {
                UserState.SectorFineGridLocation.Y += DirectionVector.Y * (MovementVelocity) * TempShipSpeed;
                UserState.SectorFineGridLocation.X += DirectionVector.X * (MovementVelocity) * TempShipSpeed;
                Thread.Sleep((int)WaitAmount);
            }
            // TODO: Keep track of sector boundry
        }

        public void AlterMovement(int delta)
        {
            //MovementVector.X = dX + MovementVector.X;
            //MovementVector.Y = dY + MovementVector.Y;
            //if (MovementVector.X != 0)
            //    Console.WriteLine("Speed of x " + MovementVector.X);
            //if (MovementVector.Y != 0)
            //    Console.WriteLine("Speed of y " + MovementVector.Y);
            //// TODO: Incorporate ship agility/inertia
            //if (MovementVector.X <= 2 && dX > 0)
            //    MovementVector.X += dX;
            //if (MovementVector.X >= -2 && dX < 0)
            //    MovementVector.X += dX;

            //if (MovementVector.Y <= 2 && dY > 0)
            //    MovementVector.Y += dY;
            //if (MovementVector.Y >= -2 && dY < 0)
            //    MovementVector.Y += dY;

            MovementVelocity += delta;
            if (MovementVelocity < 0)
                MovementVelocity = 0;
            if (MovementVelocity > 1)
                MovementVelocity = 1;

        }

        public void TakeUserInput()
        {
            //if (UserInput.CheckKey('w'))
            //{
            //    AlterMovement(1, 0);
            //}
            //if (UserInput.CheckKey('s'))
            //{
            //    AlterMovement(-1, 0);
            //}
            //if (UserInput.CheckKey('a'))
            //{
            //    AlterMovement(0, 1);
            //}
            //if (UserInput.CheckKey('d'))
            //{
            //    AlterMovement(0, -1);
            //}
            //if (UserInput.CheckKey(' '))
            //{
            //    MovementVector.X = 0.0;
            //    MovementVector.Y = 0.0;
            //}
            //DirectionVector.X = this.PointToScreen(ShipControlCoordinates).X - Cursor.Position.X;
            //DirectionVector.Y = this.PointToScreen(ShipControlCoordinates).Y - Cursor.Position.Y;
            //DirectionVector.Normalize();
        }

        private void SectorMapComplex_KeyPress(object sender, KeyPressEventArgs e)
        {
            int Key = e.KeyChar;
            switch (Key)
            {
                case 'w':       // Up
                    AlterMovement(1);
                    break;
                case 's':       // Down
                    AlterMovement(-1);
                    break;
                //case 'a':       // Left
                //    AlterMovement(0, -1);
                //    break;
                //case 'd':       // Right
                //    AlterMovement(0, 1);
                //    break;
                case ' ':       // Stop
                    MovementVelocity = 0;
                    break;
                default:
                    break;
            }
        }

        private void SectorMapComplex_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ClickPoint = e.Location;
            ClickEnabled = true;

        }
    }
}
