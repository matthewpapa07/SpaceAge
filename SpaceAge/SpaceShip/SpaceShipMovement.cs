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

        public PointD DestinationPoint = new PointD(Sector.MAX_DISTANCE_FROM_AXIS / 2, Sector.MAX_DISTANCE_FROM_AXIS/2);
        public VectorD DirectionVector = new VectorD(0.0, 1.0);

        // For ship waypoints. Eventually make a new structure for a destination vector
        public long LastUpdateTimeTick = 0;
        
        public void ExecuteMoveSector(Sector.GateDirections GateDir)
        {
            switch (GateDir)
            {
                case Sector.GateDirections.North:
                    DestinationPoint.Y = 0;
                    DestinationPoint.X = SectorFineGridLocation.X;
                    break;
                case Sector.GateDirections.South:
                    DestinationPoint.Y = Sector.MAX_DISTANCE_FROM_AXIS;
                    DestinationPoint.X = SectorFineGridLocation.X;
                    break;
                case Sector.GateDirections.East:
                    DestinationPoint.X = Sector.MAX_DISTANCE_FROM_AXIS;
                    DestinationPoint.Y = SectorFineGridLocation.Y;
                    break;
                case Sector.GateDirections.West:
                    DestinationPoint.X = 0;
                    DestinationPoint.Y = SectorFineGridLocation.Y;
                    break;
                default:
                    break;
            } 

            DirectionVector.X = SectorFineGridLocation.X - DestinationPoint.X;
            DirectionVector.Y = SectorFineGridLocation.Y - DestinationPoint.Y;

            DirectionVector.Normalize();
        }

        public void UpdateMovingShipsPosition()
        {
            long LastUpdateDelta;
            // Only refresh position as fast as the ship's rate of speed
            //double WaitAmount = (1 / (double)EffectiveWarpSpeed) * 1000;
            {
                LastUpdateDelta = DateTime.Now.Ticks - LastUpdateTimeTick;
                LastUpdateTimeTick = DateTime.Now.Ticks;

                if (!DestinationPoint.Equals(SectorFineGridLocation))
                {
                    DirectionVector.X = SectorFineGridLocation.X - DestinationPoint.X;
                    DirectionVector.Y = SectorFineGridLocation.Y - DestinationPoint.Y;

                    DirectionVector.Normalize();

                    double dx = DirectionVector.X * EffectiveWarpSpeed * (-1);
                    double dy = DirectionVector.Y * EffectiveWarpSpeed * (-1);
                    double distanceActual = DestinationPoint.Distance(SectorFineGridLocation);

                    // Since the frame only refreshes the period of the velocity, our distance will always be 1.

                    if (distanceActual <= 30.0)
                    {
                        SectorFineGridLocation.X = DestinationPoint.X;
                        SectorFineGridLocation.Y = DestinationPoint.Y;
                    }
                    if (!DestinationPoint.Equals(SectorFineGridLocation))
                    {
                        SectorFineGridLocation.X += dx;
                        SectorFineGridLocation.Y += dy;
                    }
                }
                else
                {

                }

                CheckSectorBoundary();
            }
        }

        public void CheckSectorBoundary()
        {
            if (CurrentShipSector == null)
                return;
            Sector TransitionSector = null;
            Sector OriginalSector = CurrentShipSector;
            int currentX = CurrentShipSector.SectorGridLocation.X;
            int currentY = CurrentShipSector.SectorGridLocation.Y;

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
                CurrentShipSector = TransitionSector;
            }

            if (SectorFineGridLocation.X == 0)
            {
                SectorFineGridLocation.X = Sector.MAX_DISTANCE_FROM_AXIS - 20;
                ResetDestinationPoint();
            }
            if (SectorFineGridLocation.X == Sector.MAX_DISTANCE_FROM_AXIS)
            {
                SectorFineGridLocation.X = 20;
                ResetDestinationPoint();
            }
            if (SectorFineGridLocation.Y == 0)
            {
                SectorFineGridLocation.Y = Sector.MAX_DISTANCE_FROM_AXIS - 20;
                ResetDestinationPoint();
            }
            if (SectorFineGridLocation.Y == Sector.MAX_DISTANCE_FROM_AXIS)
            {
                SectorFineGridLocation.Y = 20;
                ResetDestinationPoint();
            }
        }

        public void ResetDestinationPoint()
        {
            //DestinationPoint.X = SectorFineGridLocation.X;
            //DestinationPoint.Y = SectorFineGridLocation.Y;
            DestinationPoint.X = Sector.MAX_DISTANCE_FROM_AXIS / 2;
            DestinationPoint.Y = Sector.MAX_DISTANCE_FROM_AXIS / 2;
        }

    }

}
