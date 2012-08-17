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
        public int MerchantMoney = 50000; // For now start out merchants with 50k

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
            // Make sure there are stores here, if not leave this state
            if (CurrentSector.RegisteredItemStores.Count == 0)
            {
                ShipState = MerchantShipState.Idle;
                return;
            }
            // Get commodities available to sell first to make cargo room. If a good price is offered go ahead and sell
            Commodity.CommodityEnum [] onboardCommodities = this.SpaceShipCargo.getCommoditiesPresent();
            if (onboardCommodities.Length >= 1)
            {
                List<ResourceVector> BestSellPrices = new List<ResourceVector>(3);
                foreach (Commodity.CommodityEnum curCom in onboardCommodities)
                {
                    BestSellPrices.Add(ResourceVector.GetBestSellPriceForCommodity(curCom, CurrentSector));
                }
                foreach (ResourceVector rv in BestSellPrices)
                {
                    if (rv.DecideIfGoodSellPrice())
                    {
                        int HowManyCanISell = rv.HowManyCanSell();
                        int HowManyDoIHave = SpaceShipCargo.CommoditiesAvailable(rv.TypeOfCommodity);

                        if (HowManyCanISell >= HowManyDoIHave)
                        {
                            // Case 1 sell everything that the merchant can unload
                            rv.WhichStore.UserSellCommodity(rv.TypeOfCommodity, HowManyDoIHave);
                            SpaceShipCargo.RemoveCommodity(rv.TypeOfCommodity, HowManyDoIHave);
                            MerchantMoney += HowManyDoIHave * rv.Price;
                        }
                        else
                        {
                            // Case 2 the itemstore has limited space for the merchants items
                            rv.WhichStore.UserSellCommodity(rv.TypeOfCommodity, HowManyCanISell);
                            SpaceShipCargo.RemoveCommodity(rv.TypeOfCommodity, HowManyCanISell);
                            MerchantMoney += HowManyCanISell * rv.Price;
                        }
                    }
                }
            }

            if (SpaceShipCargo.GetFreeVolumeSpace() == 0)
            {
                ShipState = MerchantShipState.Idle;
                return;
            }

            //For efficiency purposes check for just 3 random commodities to buy right now. Its fine if they are the same
            List<Commodity.CommodityEnum> TryToBuyCommodities = new List<Commodity.CommodityEnum>(3);
            TryToBuyCommodities.Add(Commodity.GetRandomCommodity());
            TryToBuyCommodities.Add(Commodity.GetRandomCommodity());
            TryToBuyCommodities.Add(Commodity.GetRandomCommodity());

            List<ResourceVector> BestBuyPrices = new List<ResourceVector>(3);
            foreach (Commodity.CommodityEnum curCom in TryToBuyCommodities)
            {
                BestBuyPrices.Add(ResourceVector.GetBestBuyPriceForCommodity(curCom, CurrentSector));
            }
            foreach (ResourceVector rv in BestBuyPrices)
            {
                if (rv.DecideIfGoodBuyPrice())
                {
                    int HowManyCanIBuy = rv.HowManyCanBuy();
                    int HowManyCanIFit = SpaceShipCargo.GetFreeVolumeSpace() / Commodity.getCommodityFromEnum(rv.TypeOfCommodity).UnitVolume;

                    if (HowManyCanIBuy >= HowManyCanIFit)
                    {
                        rv.WhichStore.UserBuyCommodity(rv.TypeOfCommodity, HowManyCanIFit);
                        SpaceShipCargo.AddCommodity(rv.TypeOfCommodity, HowManyCanIFit);
                        MerchantMoney -= HowManyCanIFit * rv.Price;
                    }
                    else
                    {
                        rv.WhichStore.UserBuyCommodity(rv.TypeOfCommodity, HowManyCanIBuy);
                        SpaceShipCargo.AddCommodity(rv.TypeOfCommodity, HowManyCanIBuy);
                        MerchantMoney -= HowManyCanIBuy * rv.Price;
                    }
                }
            }

            // Commerce Complete, set idle state so that a destination can be set next turn
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
