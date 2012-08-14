using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceAge
{
    class MerchantSpaceShip : SpaceShip
    {
        // Data for what will hopefully become the state machine dictating AI action
        public enum MerchantShipState { Moving, Holding, Arrived, Idle };
        public MerchantShipState ShipState = MerchantShipState.Holding;
        public Sector DestinationSector = null;
        public ItemStore DestinationItemStore = null;
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

        }

        private void ConductCommerce()
        {

        }

        private void VerifyHold()
        {

        }



    }
}
