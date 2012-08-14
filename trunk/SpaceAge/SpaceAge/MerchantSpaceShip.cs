using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace SpaceAge
{
    class MerchantSpaceShip : SpaceShip
    {
        // Data for what will hopefully become the state machine dictating AI action
        public enum MerchantShipState { Moving, Holding, Arrived, Idle };
        public MerchantShipState ShipState = MerchantShipState.Holding;
        public Sector DestinationSector = null; // Prepetuated by AI
        public Sector CurrentSector = null; // Initialized when placed in sector, prepetuated by AI
        public ItemStore DestinationItemStore = null;   // TODO: Implement this
        public bool IsAlive = true;

        public static int GlobalMerchantId = 0;
        public int MerchantId = -1;

        public MerchantSpaceShip(int inWeaponMounts, int inDefensiveMounts, int inEngineMounts, int inSpecialMounts):
            base(inWeaponMounts, inDefensiveMounts, inEngineMounts, inSpecialMounts)
        {
            MerchantId = GlobalMerchantId++;
        }

        public void Live()
        {
            switch (ShipState)
            {
                case MerchantShipState.Holding:
                    VerifyHold();
                    break;
                case MerchantShipState.Moving:
                    ContinueOnJourney();
                    break;
                case MerchantShipState.Idle:
                    StartNewTask();
                    break;
                case MerchantShipState.Arrived:
                    ConductCommerce();
                    break;
                default:
                    VerifyHold();
                    break;
            }
        }

        private void StartNewTask()
        {

        }

        private void ContinueOnJourney()
        {
            DriverLibrary.NavigationLib.Directions Direction = DriverLibrary.NavigationLib.NextDirection(CurrentSector, DestinationSector);
            Sector NewDestinationSector = DriverLibrary.NavigationLib.GetSectorInDirection(CurrentSector, Direction);
            if (NewDestinationSector == null)
            {
                throw new Exception();
            }
            if (NewDestinationSector.Equals(DestinationSector))
            {
                ShipState = MerchantShipState.Arrived;
                return;
            }
            CurrentSector.ShipMoveOut(this);
            //Next
            
        }

        private void ConductCommerce()
        {

        }

        private void VerifyHold()
        {

        }



    }
}
