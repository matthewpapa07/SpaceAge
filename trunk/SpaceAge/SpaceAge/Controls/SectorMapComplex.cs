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
        GraphicsCache SpaceShipGc = GraphicsCache.GraphicsCacheSpaceShip();

        public int TempRefreshRate = 28;  //ms
        public int TempViewRadius = 400;
        public int ImageViewMultiplier = 1;

        // For Threads
        public Thread MapRefreshThread;
        public EventToInvoke PlayerShipInTransit;

        public SectorMapComplex()
        { 
            PlayerShipInTransit = new EventToInvoke(ShipMoverDelegate);
            //KeyboardCheck = new EventToInvoke(TakeUserInput);
            MapRefreshThread = new Thread(new ThreadStart(RefreshScreen));
            
            //KeyboardCheckThread = new Thread(new ThreadStart(RefreshKeystrokes));
            this.DoubleBuffered = true;

            //
            // Assume height == width when determining points per pixel
            //
            InitializeComponent();

        }

        protected override void OnPaint(PaintEventArgs e)
        {
            try
            {
                drawSector(e.Graphics);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void UiSectorMap_Load(object sender, EventArgs e)
        {

        }

        public void drawSector(Graphics GraphicsToUse)
        {
            Sector currentSector = UserState.getCurrentSector();
            if (currentSector == null)
            {
                return;
            }
            
            Bitmap SsImage;
            int SsAngle;

            Point ShipControlCoordinates = new Point(0, 0);
            //Bitmap RotatedImage;
            Rectangle RectToUse = this.ClientRectangle;

            Point RectStart = new Point(0, 0);
            Point RectDimensions = new Point(RectToUse.Width, RectToUse.Height);
            Point GridStart = new Point((int)(UserState.PlayerShip.SectorFineGridLocation.X - TempViewRadius * ImageViewMultiplier), (int)(UserState.PlayerShip.SectorFineGridLocation.Y - TempViewRadius * ImageViewMultiplier));
            Point GridDimensions = new Point(TempViewRadius * ImageViewMultiplier * 2, TempViewRadius * ImageViewMultiplier * 2);
            //DrawSectorGraphicsEx(Graphics GraphicsToUse, Rectangle RectToUse, Point RectStart, Point RectDimensions, Point GridStart, Point GridDimensions)
            currentSector.DrawSectorGraphicsEx(
                GraphicsToUse, 
                RectToUse, 
                RectStart, 
                RectDimensions,
                GridStart,
                GridDimensions,
                ImageViewMultiplier
                );
            //currentSector.DrawSectorGraphicsEx(GraphicsToUse, RectToUse, RectStart, RectDimensions, Sector.SETOR_START_P, Sector.SETOR_END_P);
            //currentSector.DrawSectorGraphics(GraphicsToUse, RectToUse, 0, 0, RectToUse.Width, RectToUse.Height );

            PointEx Actual;
            SpaceShip[] SectSpaceShips = currentSector.PresentSpaceShips.ToArray();
            foreach (SpaceShip ss in SectSpaceShips)
            {
                Actual = GraphicsLib.GetPointInRelativeGrid(ss.SectorFineGridLocation.ToPoint(), GridStart, GridDimensions);

                if (Actual != null)
                {
                    // Try image cache for image, if it doesnt exist make a new one
                    SsAngle = ss.DirectionVector.GetAngle();
                    SsImage = SpaceShipGc.GetImage(ss, SsAngle);
                    if (SsImage == null)
                    {
                        SsImage = ss.GetSpaceShipImage(SsAngle);
                        if (SsImage == null)
                        {
                            throw new Exception();
                        }
                        SpaceShipGc.SetImage(ss, SsImage, SsAngle);
                    }

                    ShipControlCoordinates.X = (
                        staticGraphics.ScaleCoordinate(
                        GridDimensions.X,
                        Actual.X,
                        RectToUse.Width
                        ));
                    ShipControlCoordinates.Y = (
                        staticGraphics.ScaleCoordinate(
                        GridDimensions.Y,
                        Actual.Y, 
                        RectToUse.Height
                        ));
                    GraphicsToUse.DrawImage(
                        SsImage,
                        ShipControlCoordinates.X /* - SsImage.Height / 2 */,
                        ShipControlCoordinates.Y /* - SsImage.Height / 2 */,
                        35 / ImageViewMultiplier, 35 / ImageViewMultiplier
                        );
                }
            }

            // Draw green dot representign local waypoint into the window
            if (UserState.PlayerShip.SpaceShipMovementState == SpaceShip.SpaceShipMovementEnum.LocalWaypoint || UserState.PlayerShip.SpaceShipMovementState == SpaceShip.SpaceShipMovementEnum.RemoteWaypoint)
            {
                Actual = GraphicsLib.GetPointInRelativeGrid(UserState.PlayerShip.GetDestinationPoint().ToPoint(), GridStart, GridDimensions);

                if (Actual != null)
                {
                    Rectangle waypointRect = new Rectangle(
                        staticGraphics.ScaleCoordinate(
                            GridDimensions.X,
                            Actual.X, 
                            RectToUse.Width
                            ),
                        staticGraphics.ScaleCoordinate(
                            GridDimensions.Y,
                            Actual.Y,
                            RectToUse.Height
                            ),
                        5,
                        5
                       );
                    GraphicsToUse.FillEllipse(staticGraphics.greenBrush, waypointRect);
                }
            }
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
            Point ClickPoint = e.Location;

            Rectangle RectToUse = this.ClientRectangle;
            Point GridStart = new Point((int)(UserState.PlayerShip.SectorFineGridLocation.X - TempViewRadius * ImageViewMultiplier), (int)(UserState.PlayerShip.SectorFineGridLocation.Y - TempViewRadius * ImageViewMultiplier));

            // Convert graphics point to sector coordinate. loss of precision is expected of course
            PointD DestinationPoint = new PointD (
                staticGraphics.ScaleCoordinate(ClientRectangle.Width, ClickPoint.X, TempViewRadius * ImageViewMultiplier * 2),
                staticGraphics.ScaleCoordinate(ClientRectangle.Height, ClickPoint.Y, TempViewRadius * ImageViewMultiplier * 2)
                );
            DestinationPoint.X += GridStart.X;
            DestinationPoint.Y += GridStart.Y;

            UserState.PlayerShip.SetLocalDestinationPoint(DestinationPoint);

            // Check to see if click selected a certain object
            UserState.getCurrentSector().ClickForObject(DestinationPoint);

            //Console.WriteLine("Double click at X:" + ClickPoint.X + " Y:" + ClickPoint.Y + " Angle:" + DirectionVector.GetAngle());

        }
    }
}
