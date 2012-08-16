using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace SpaceAge
{
    class MerchantSpaceShip : SpaceShip
    {
        public static int START_SYSTEM_DISTANCE_AWAY = 5;
        // Data for what will hopefully become the state machine dictating AI action
        public enum MerchantShipState { Moving, Holding, Arrived, Idle };
        public MerchantShipState ShipState = MerchantShipState.Idle;
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
            if (MerchantId == 120)
                Console.WriteLine("Tracking ship 120");
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
                    if (MerchantId == 120)
                        Console.WriteLine("Ship 120 arrived at " + CurrentSector.SectorGridLocation.ToString());
                    break;
                default:
                    VerifyHold();
                    break;
            }
        }

        private void StartNewTask()
        {
            StarSystem[] SystemsToVisit;
            StarSystem TargetSystem;
            int i = START_SYSTEM_DISTANCE_AWAY + 1;

            SystemsToVisit = DriverLibrary.NavigationLib.GetStarSystemsInDistance(CurrentSector, START_SYSTEM_DISTANCE_AWAY);
            while (SystemsToVisit.Length == 0)
            {
                SystemsToVisit = DriverLibrary.NavigationLib.GetStarSystemsInDistance(CurrentSector, i++);
            }

            TargetSystem = SystemsToVisit[NumberGenerator.getInstance().getNumberRange(0, SystemsToVisit.Length - 1)];
            DestinationSector = TargetSystem.parent;
            ShipState = MerchantShipState.Moving;
            ContinueOnJourney();
        }

        private void ContinueOnJourney()
        {
            DriverLibrary.NavigationLib.Directions Direction = DriverLibrary.NavigationLib.NextDirection(CurrentSector, DestinationSector);
            Sector NextSector = DriverLibrary.NavigationLib.GetSectorInDirection(CurrentSector, Direction);
            if (NextSector == null)
            {
                throw new Exception();
            }
            if (NextSector.Equals(DestinationSector))
            {
                ShipState = MerchantShipState.Arrived;
            }
            CurrentSector.ShipMoveOut(this);
            CurrentSector = NextSector;
            CurrentSector.ShipMoveIn(this);
        }

        private void ConductCommerce()
        {
            Commodity.CommodityEnum [] CommoditiesAvailable = this.SpaceShipCargo.getCommoditiesPresent();

            ShipState = MerchantShipState.Idle;
        }

        private void VerifyHold()
        {
            if (NumberGenerator.getInstance().LinearPmfResult(0.25))
            {
                ShipState = MerchantShipState.Idle;
            }
        }

    }
}
