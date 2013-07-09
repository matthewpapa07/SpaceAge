using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace SpaceAge
{
    partial class SpaceShip
    {
        public Thread ShipVelocityThread;

        public PointD DestinationPoint = new PointD(0.0, 0.0);
        public VectorD DirectionVector = new VectorD(0.0, 1.0);

        // For ship waypoints. Eventually make a new structure for a destination vector
        public bool InTransit = false;

        public void CheckSectorBoundary()
        {
            if (UserState.getCurrentSector() == null)
                return;
            Sector TransitionSector = null;
            int currentX = UserState.getCurrentSector().SectorGridLocation.X;
            int currentY = UserState.getCurrentSector().SectorGridLocation.Y;

            if (UserState.SectorFineGridLocation.X == 0)
            {
                TransitionSector = Universe.getSector(currentX, currentY - 1);
            }
            if (UserState.SectorFineGridLocation.X == Sector.MAX_DISTANCE_FROM_AXIS)
            {
                TransitionSector = Universe.getSector(currentX, currentY + 1);
            }
            if (UserState.SectorFineGridLocation.Y == 0)
            {
                TransitionSector = Universe.getSector(currentX - 1, currentY);
            }
            if (UserState.SectorFineGridLocation.Y == Sector.MAX_DISTANCE_FROM_AXIS)
            {
                TransitionSector = Universe.getSector(currentX + 1, currentY);
            }

            if (TransitionSector != null)
            {
                UserState.setCurrentSector(TransitionSector);
            }

            if (UserState.SectorFineGridLocation.X == 0)
            {
                UserState.SectorFineGridLocation.X = Sector.MAX_DISTANCE_FROM_AXIS - 20;
            }
            if (UserState.SectorFineGridLocation.X == Sector.MAX_DISTANCE_FROM_AXIS)
            {
                UserState.SectorFineGridLocation.X = 20;
            }
            if (UserState.SectorFineGridLocation.Y == 0)
            {
                UserState.SectorFineGridLocation.Y = Sector.MAX_DISTANCE_FROM_AXIS - 20;
            }
            if (UserState.SectorFineGridLocation.Y == Sector.MAX_DISTANCE_FROM_AXIS)
            {
                UserState.SectorFineGridLocation.Y = 20;
            }
        }

        public void UpdateMovingShipsPosition()
        {
            // Only refresh position as fast as the ship's rate of speed
            double WaitAmount = (1 / (double)EffectiveWarpSpeed) * 1000;
            while (ShipVelocityThread.IsAlive && UserState.ThreadsRunning)
            {

                if (!DestinationPoint.Equals(UserState.SectorFineGridLocation) && InTransit)
                {
                    DirectionVector.X = UserState.SectorFineGridLocation.X - DestinationPoint.X;
                    DirectionVector.Y = UserState.SectorFineGridLocation.Y - DestinationPoint.Y;

                    DirectionVector.Normalize();

                    double dx = DirectionVector.X * EffectiveWarpSpeed * (-1);
                    double dy = DirectionVector.Y * EffectiveWarpSpeed * (-1);
                    double distanceActual = DestinationPoint.Distance(UserState.SectorFineGridLocation);

                    // Since the frame only refreshes the period of the velocity, our distance will always be 1.0
                    if (distanceActual <= 30.0)
                    {
                        UserState.SectorFineGridLocation.X = DestinationPoint.X;
                        UserState.SectorFineGridLocation.Y = DestinationPoint.Y;
                        InTransit = false;
                    }
                    else
                    {
                        UserState.SectorFineGridLocation.X += dx;
                        UserState.SectorFineGridLocation.Y += dy;
                    }

                }

                CheckSectorBoundary();
                Thread.Sleep((int)WaitAmount);
            }
        }

    }

}
