using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using SpaceAge.Properties;

namespace SpaceAge
{
    class PatrolSpaceShip : SpaceShip
    {
        public static long MoneyChangedHands = 0;
        public static int START_SYSTEM_DISTANCE_AWAY = 5;
        // Data for what will hopefully become the state machine dictating AI action
        public bool IsAlive = true;
        //public ItemStore[] ChosenItemStores;
        //public int ChosenItemStoresIndex = 0;

        public static int GlobalPatrolId = 0;
        public int PatrolId = -1;
        public static List<PatrolSpaceShip> AllPatrols = new List<PatrolSpaceShip>(1000);
        public int ImageAssignmentIndex = 0;

        static Bitmap [] PatrolShipImages = {
                                                new Bitmap(Resources.XS_Ship001),
                                                new Bitmap(Resources.XS_Ship002),
                                                new Bitmap(Resources.XS_Ship003),
                                                new Bitmap(Resources.XS_Ship004),
                                                new Bitmap(Resources.XS_Ship005)
                                            };


        public enum PatrolSpaceShipState { MovingWithinSector, Arrived, FindingTarget, Attacking};
        public PatrolSpaceShipState ShipState = PatrolSpaceShipState.Arrived;

        public PatrolSpaceShip(int inWeaponMounts, int inDefensiveMounts, int inEngineMounts, int inSpecialMounts):
            base(inWeaponMounts, inDefensiveMounts, inEngineMounts, inSpecialMounts)
        {
            PatrolId = GlobalPatrolId++;

            SectorFineGridLocation.X = NumberGenerator.getInstance().GetRandDoubleInRange(400, Sector.MAX_DISTANCE_FROM_AXIS - 400);
            SectorFineGridLocation.Y = NumberGenerator.getInstance().GetRandDoubleInRange(400, Sector.MAX_DISTANCE_FROM_AXIS - 400);
            SpaceShipName = "Patrol: " + PatrolId;
            ImageAssignmentIndex = NumberGenerator.getInstance().GetRandNumberInRange(0, PatrolShipImages.Length - 1);

            AllPatrols.Add(this);
        }

        public override void Live()
        {
            switch (ShipState)
            {
                case PatrolSpaceShipState.MovingWithinSector:
                    CheckOnTransit();
                    break;
                case PatrolSpaceShipState.Arrived:
                    DetermineWhereToGoNext();
                    break;
                case PatrolSpaceShipState.FindingTarget:
                    //TODO : Not armed, for now!
                    break;
                case PatrolSpaceShipState.Attacking:
                    //TODO : Not Armed, for now!
                    break;
                default:
                    DetermineWhereToGoNext();
                    break;
            }
        }

        private void DetermineWhereToGoNext()
        {
            SetLocalDestinationPoint(CurrentShipSector.RandomClearPointInSector());
            ShipState = PatrolSpaceShipState.MovingWithinSector;
        }

        private void CheckOnTransit()
        {
            if (SpaceShipMovementState == SpaceShipMovementEnum.None)
            {
                ShipState = PatrolSpaceShipState.Arrived;
            }
            else
            {
                // Still moving
            }
            
        }

        public override Bitmap GetSpaceShipImage()
        {
            Bitmap RotatedImage = GraphicsLib.RotateBitmap(PatrolShipImages[ImageAssignmentIndex], DirectionVector.GetAngle());
            return RotatedImage;
        }

        // Better for atomic operations
        public override Bitmap GetSpaceShipImage(int Angle)
        {
            Bitmap RotatedImage = GraphicsLib.RotateBitmap(PatrolShipImages[ImageAssignmentIndex], Angle);
            return RotatedImage;
        }

    }
}
