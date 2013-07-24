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

        private PointD DestinationPoint = new PointD(Sector.MAX_DISTANCE_FROM_AXIS / 2, Sector.MAX_DISTANCE_FROM_AXIS/2);
        public VectorD DirectionVector = new VectorD(0.0, 1.0);

        public enum SpaceShipMovementEnum { LocalWaypoint, RemoteWaypoint, JustArrived, None };
        public SpaceShipMovementEnum SpaceShipMovementState = SpaceShipMovementEnum.None;
        public bool FollowToWaypoint = false;

        // For ship waypoints. Eventually make a new structure for a destination vector
        public long LastUpdateTimeTick = DateTime.Now.Ticks;
        
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
        }

        private void UpdateMovingShipsPosition()
        {
            long lastUpdateInMs;

            lastUpdateInMs = (DateTime.Now.Ticks - LastUpdateTimeTick) / TimeSpan.TicksPerMillisecond;
            LastUpdateTimeTick = DateTime.Now.Ticks;

            double DistanceSinceThen = lastUpdateInMs*EffectiveWarpSpeed;
            DistanceSinceThen /= 10;

            if (!DestinationPoint.Equals(SectorFineGridLocation))
            {
                // Reset so we can get dx and dy
                ResetDirectionVector();

                double dx = DirectionVector.X * DistanceSinceThen * (-1);
                double dy = DirectionVector.Y * DistanceSinceThen * (-1);
                double distanceActual = DestinationPoint.Distance(SectorFineGridLocation);

                // Since the frame only refreshes the period of the velocity, our distance will always be 1.

                if (distanceActual <= DistanceSinceThen)
                {
                    SectorFineGridLocation.X = DestinationPoint.X;
                    SectorFineGridLocation.Y = DestinationPoint.Y;
                }
                if (!DestinationPoint.Equals(SectorFineGridLocation))
                {
                    SectorFineGridLocation.X += dx;
                    SectorFineGridLocation.Y += dy;
                }

                //we have arrived at the local waypoint, what to do now
                if (DestinationPoint.Equals(SectorFineGridLocation))
                {
                    // If user has engaged the "follow to remote waypoint"
                    if (FollowToWaypoint)
                    {
                        // Action has been cancelled by user or waypoint removed, disengage and do nothing
                        if (CurrentWaypoint == null)
                        {
                            SpaceShipMovementState = SpaceShipMovementEnum.None;
                            FollowToWaypoint = false;
                        }
                        else
                        {
                            int WptDistance = CurrentWaypoint.Distance(CurrentShipSector);

                            // Has arrived, discard flag and disengage
                            if (WptDistance == 0)
                            {
                                SpaceShipMovementState = SpaceShipMovementEnum.None;
                                FollowToWaypoint = false;
                                CurrentWaypoint = null;
                            }
                            if (WptDistance > 0)
                            {
                                ExecuteMoveSector(CurrentShipSector.GetNextSectorDirection(CurrentWaypoint));
                            }
                        }
                    }
                    else // Arrived at the next sector at manual user request, just close out the state machine
                    {
                        SpaceShipMovementState = SpaceShipMovementEnum.None;
                    }
               
                }

                CheckSectorBoundary();
            }
        }

        private void CheckSectorBoundary()
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
                CurrentShipSector.PresentSpaceShips.Remove(this);
                TransitionSector.PresentSpaceShips.Add(this);
                CurrentShipSector = TransitionSector;
            }

            if (SectorFineGridLocation.X == 0)
            {
                SectorFineGridLocation.X = Sector.MAX_DISTANCE_FROM_AXIS - 1;
                DestinationPoint.X = Sector.MAX_DISTANCE_FROM_AXIS - (Sector.MAX_DISTANCE_FROM_AXIS / 6);
                DestinationPoint.Y = SectorFineGridLocation.Y; 
                SpaceShipMovementState = SpaceShipMovementEnum.JustArrived;
            }
            if (SectorFineGridLocation.X == Sector.MAX_DISTANCE_FROM_AXIS)
            {
                SectorFineGridLocation.X = 1;
                DestinationPoint.X = Sector.MAX_DISTANCE_FROM_AXIS / 6;
                DestinationPoint.Y = SectorFineGridLocation.Y;
                SpaceShipMovementState = SpaceShipMovementEnum.JustArrived;
            }
            if (SectorFineGridLocation.Y == 0)
            {
                SectorFineGridLocation.Y = Sector.MAX_DISTANCE_FROM_AXIS - 1;
                DestinationPoint.X = SectorFineGridLocation.X;
                DestinationPoint.Y = Sector.MAX_DISTANCE_FROM_AXIS - (Sector.MAX_DISTANCE_FROM_AXIS / 6);
                SpaceShipMovementState = SpaceShipMovementEnum.JustArrived;
            }
            if (SectorFineGridLocation.Y == Sector.MAX_DISTANCE_FROM_AXIS)
            {
                SectorFineGridLocation.Y = 1;
                DestinationPoint.X = SectorFineGridLocation.X;
                DestinationPoint.Y = Sector.MAX_DISTANCE_FROM_AXIS / 6;
                SpaceShipMovementState = SpaceShipMovementEnum.JustArrived;
            }
        }

        // Reset internal destination vector
        private void ResetDirectionVector()
        {
            DirectionVector.X = SectorFineGridLocation.X - DestinationPoint.X;
            DirectionVector.Y = SectorFineGridLocation.Y - DestinationPoint.Y;

            DirectionVector.Normalize();
        }

        public void ExecuteWaypoints()
        {
            if (CurrentWaypoint != null)
            {
                SpaceShipMovementState = SpaceShip.SpaceShipMovementEnum.RemoteWaypoint;
                FollowToWaypoint = true;
                ExecuteMoveSector(CurrentShipSector.GetNextSectorDirection(CurrentWaypoint));
            }
        }

        public PointD GetDestinationPoint()
        {
            return DestinationPoint;
        }

        public void SetLocalDestinationPoint(PointD InPoint)
        {
            // abort following any waypoints
            FollowToWaypoint = false;
            DestinationPoint.X = InPoint.X;
            DestinationPoint.Y = InPoint.Y;
            SpaceShipMovementState = SpaceShipMovementEnum.LocalWaypoint;
            ResetDirectionVector();
        }
    }

}
