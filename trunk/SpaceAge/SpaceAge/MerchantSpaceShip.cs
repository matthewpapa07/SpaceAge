using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace SpaceAge
{
    class MerchantSpaceShip : SpaceShip
    {
        public static long MoneyChangedHands = 0;
        public static int START_SYSTEM_DISTANCE_AWAY = 5;
        // Data for what will hopefully become the state machine dictating AI action
        public enum MerchantShipState { Moving, Holding, Arrived, Idle };
        public MerchantShipState ShipState = MerchantShipState.Idle;
        public ItemStore DestinationItemStore = null;   // TODO: Implement this
        public bool IsAlive = true;

        public static int GlobalMerchantId = 0;
        public int MerchantId = -1;

        ResourceVector currVect; // Temporary variable used in price acquisition

        public MerchantSpaceShip(int inWeaponMounts, int inDefensiveMounts, int inEngineMounts, int inSpecialMounts):
            base(inWeaponMounts, inDefensiveMounts, inEngineMounts, inSpecialMounts)
        {
            MerchantId = GlobalMerchantId++;

            SpaceShipName = "Merch: " + MerchantId;

        }

        public void Live()
        {
            //if (MerchantId == 120)
            //    Console.WriteLine("Tracking ship 120");
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
                    //if (MerchantId == 120)
                    //    Console.WriteLine("Ship 120 arrived at " + CurrentSector.SectorGridLocation.ToString());
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

            SystemsToVisit = DriverLibrary.NavigationLib.GetStarSystemsInDistance(CurrentShipSector, START_SYSTEM_DISTANCE_AWAY);
            while (SystemsToVisit.Length == 0)
            {
                SystemsToVisit = DriverLibrary.NavigationLib.GetStarSystemsInDistance(CurrentShipSector, i++);
            }

            TargetSystem = SystemsToVisit[NumberGenerator.getInstance().GetRandNumberInRange(0, SystemsToVisit.Length - 1)];
            CurrentWaypoint = TargetSystem.parent;
            ShipState = MerchantShipState.Moving;
            ContinueOnJourney();
        }

        private void ContinueOnJourney()
        {
            DriverLibrary.NavigationLib.Directions Direction = DriverLibrary.NavigationLib.NextDirection(CurrentShipSector, CurrentWaypoint);
            Sector NextSector = DriverLibrary.NavigationLib.GetSectorInDirection(CurrentShipSector, Direction);
            if (NextSector == null)
            {
                throw new Exception();
            }
            if (NextSector.Equals(CurrentWaypoint))
            {
                ShipState = MerchantShipState.Arrived;
            }
            CurrentShipSector.ShipMoveOut(this);
            CurrentShipSector = NextSector;
            CurrentShipSector.ShipMoveIn(this);
        }

        private void ConductCommerce()
        {
            bool Status = false;
            // Make sure there are stores here, if not leave this state
            if (CurrentShipSector.RegisteredItemStores.Count == 0)
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
                    currVect = ResourceVector.GetBestSellPriceForCommodity(curCom, CurrentShipSector);
                    if(currVect != null)
                        BestSellPrices.Add(currVect);
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
                            Status = rv.WhichStore.UserSellCommodity(rv.TypeOfCommodity, HowManyDoIHave);
                            if (!Status)
                            {
                                Console.WriteLine("Debug: There was a problem selling");
                            }
                            SpaceShipCargo.RemoveCommodity(rv.TypeOfCommodity, HowManyDoIHave);
                            SpaceShipFunds += HowManyDoIHave * rv.Price;
                            //MoneyChangedHands += HowManyDoIHave * rv.Price;     // Diagnostic field
                        }
                        else
                        {
                            // Case 2 the itemstore has limited space for the merchants items
                            rv.WhichStore.UserSellCommodity(rv.TypeOfCommodity, HowManyCanISell);
                            SpaceShipCargo.RemoveCommodity(rv.TypeOfCommodity, HowManyCanISell);
                            SpaceShipFunds += HowManyCanISell * rv.Price;
                            //MoneyChangedHands += HowManyCanISell * rv.Price;    // Diagnostic field
                        }
                    }
                }
            }

            // Shortcut this if no cargo space, try and go sell elsewhere
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
                currVect = ResourceVector.GetBestBuyPriceForCommodity(curCom, CurrentShipSector);
                if(currVect != null)
                    BestBuyPrices.Add(currVect);
            }
            foreach (ResourceVector rv in BestBuyPrices)
            {
                if (rv.DecideIfGoodBuyPrice())
                {
                    int HowManyCanIBuy = rv.HowManyCanBuy();
                    int HowManyCanIFit = SpaceShipCargo.GetFreeVolumeSpace() / Commodity.getCommodityFromEnum(rv.TypeOfCommodity).UnitVolume;

                    if (HowManyCanIBuy >= HowManyCanIFit)
                    {
                        Status = rv.WhichStore.UserBuyCommodity(rv.TypeOfCommodity, HowManyCanIFit);
                        if (!Status)
                        {
                            Console.WriteLine("Debug: There was a problem buying");
                        }
                        SpaceShipCargo.AddCommodity(rv.TypeOfCommodity, HowManyCanIFit);
                        SpaceShipFunds -= HowManyCanIFit * rv.Price;
                        MoneyChangedHands += HowManyCanIFit * rv.Price;         // Diagnostic Field
                    }
                    else
                    {
                        rv.WhichStore.UserBuyCommodity(rv.TypeOfCommodity, HowManyCanIBuy);
                        SpaceShipCargo.AddCommodity(rv.TypeOfCommodity, HowManyCanIBuy);
                        SpaceShipFunds -= HowManyCanIBuy * rv.Price;
                        MoneyChangedHands += HowManyCanIBuy * rv.Price;       // Diagnostic field
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
