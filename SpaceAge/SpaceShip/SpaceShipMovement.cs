using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace SpaceAge
{
    partial class SpaceShip
    {
        public Sector CurrentShipSector = null;
        public Sector CurrentWaypoint = null;

        public PointD SectorFineGridLocation;

        public PointD DestinationPoint = new PointD(0.0, 0.0);
        public VectorD DirectionVector = new VectorD(0.0, 1.0);

        public Thread ShipVelocityThread;

        // For ship waypoints. Eventually make a new structure for a destination vector
        public bool InTransit = false;

        public void ExecuteMoveSector(Sector.GateDirections GateDir)
        {
            switch (GateDir)
            {
                case Sector.GateDirections.North:
                    UserState.PlayerShip.DestinationPoint.Y = 0;
                    UserState.PlayerShip.DestinationPoint.X = UserState.PlayerShip.SectorFineGridLocation.X;
                    break;
                case Sector.GateDirections.South:
                    UserState.PlayerShip.DestinationPoint.Y = Sector.MAX_DISTANCE_FROM_AXIS;
                    UserState.PlayerShip.DestinationPoint.X = UserState.PlayerShip.SectorFineGridLocation.X;
                    break;
                case Sector.GateDirections.East:
                    UserState.PlayerShip.DestinationPoint.X = Sector.MAX_DISTANCE_FROM_AXIS;
                    UserState.PlayerShip.DestinationPoint.Y = UserState.PlayerShip.SectorFineGridLocation.Y;
                    break;
                case Sector.GateDirections.West:
                    UserState.PlayerShip.DestinationPoint.X = 0;
                    UserState.PlayerShip.DestinationPoint.Y = UserState.PlayerShip.SectorFineGridLocation.Y;
                    break;
                default:
                    break;
            }

            UserState.PlayerShip.DirectionVector.X = UserState.PlayerShip.SectorFineGridLocation.X - UserState.PlayerShip.DestinationPoint.X;
            UserState.PlayerShip.DirectionVector.Y = UserState.PlayerShip.SectorFineGridLocation.Y - UserState.PlayerShip.DestinationPoint.Y;

            UserState.PlayerShip.DirectionVector.Normalize();;
            UserState.PlayerShip.InTransit = true;
        }

        public void CheckSectorBoundary()
        {
            if (UserState.getCurrentSector() == null)
                return;
            Sector TransitionSector = null;
            int currentX = UserState.getCurrentSector().SectorGridLocation.X;
            int currentY = UserState.getCurrentSector().SectorGridLocation.Y;

            if (SectorFineGridLocation.X == 0)
            {
                TransitionSector = Universe.getSector(currentX - 1, currentY);
            }
            if (SectorFineGridLocation.X == Sector.MAX_DISTANCE_FROM_AXIS)
            {
                TransitionSector = Universe.getSector(currentX + 1, currentY);
            }
            if (SectorFineGridLocation.Y == 0)
            {
                TransitionSector = Universe.getSector(currentX, currentY - 1);
            }
            if (SectorFineGridLocation.Y == Sector.MAX_DISTANCE_FROM_AXIS)
            {
                TransitionSector = Universe.getSector(currentX, currentY + 1);
            }

            if (TransitionSector != null)
            {
                UserState.setCurrentSector(TransitionSector);
            }

            if (SectorFineGridLocation.X == 0)
            {
                SectorFineGridLocation.X = Sector.MAX_DISTANCE_FROM_AXIS - 20;
            }
            if (SectorFineGridLocation.X == Sector.MAX_DISTANCE_FROM_AXIS)
            {
                SectorFineGridLocation.X = 20;
            }
            if (SectorFineGridLocation.Y == 0)
            {
                SectorFineGridLocation.Y = Sector.MAX_DISTANCE_FROM_AXIS - 20;
            }
            if (SectorFineGridLocation.Y == Sector.MAX_DISTANCE_FROM_AXIS)
            {
                SectorFineGridLocation.Y = 20;
            }
        }

        public void UpdateMovingShipsPosition()
        {
            // Only refresh position as fast as the ship's rate of speed
            double WaitAmount = (1 / (double)EffectiveWarpSpeed) * 1000;
            while (ShipVelocityThread.IsAlive && UserState.ThreadsRunning)
            {

                if (!DestinationPoint.Equals(SectorFineGridLocation) && InTransit)
                {
                    DirectionVector.X = SectorFineGridLocation.X - DestinationPoint.X;
                    DirectionVector.Y = SectorFineGridLocation.Y - DestinationPoint.Y;

                    DirectionVector.Normalize();

                    double dx = DirectionVector.X * EffectiveWarpSpeed * (-1);
                    double dy = DirectionVector.Y * EffectiveWarpSpeed * (-1);
                    double distanceActual = DestinationPoint.Distance(SectorFineGridLocation);

                    // Since the frame only refreshes the period of the velocity, our distance will always be 1.0
                    if (distanceActual <= 30.0)
                    {
                        SectorFineGridLocation.X = DestinationPoint.X;
                        SectorFineGridLocation.Y = DestinationPoint.Y;
                        InTransit = false;
                    }
                    else
                    {
                        SectorFineGridLocation.X += dx;
                        SectorFineGridLocation.Y += dy;
                    }
                }

                CheckSectorBoundary();
                Thread.Sleep((int)WaitAmount);
            }
        }

    }

}
