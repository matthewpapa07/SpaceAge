using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using SpaceAge.Properties;

namespace SpaceAge
{
    class MerchantSpaceShip : SpaceShip
    {
        public static long MoneyChangedHands = 0;
        public static int START_SYSTEM_DISTANCE_AWAY = 5;
        // Data for what will hopefully become the state machine dictating AI action
        public bool IsAlive = true;
        //public ItemStore[] ChosenItemStores;
        //public int ChosenItemStoresIndex = 0;

        public static int GlobalMerchantId = 0;
        public int MerchantId = -1;
        public static List<MerchantSpaceShip> AllMerchants = new List<MerchantSpaceShip>(1000);

        static Bitmap SpaceShipImage2 = new Bitmap(Resources.SpaceShip2);

        ResourceVector currVect; // Temporary variable used in price acquisition

        public enum MerchantSpaceShipState { MovingSectors, MovingWithinSector, Holding, Arrived, Idle };
        public MerchantSpaceShipState ShipState = MerchantSpaceShipState.Idle;

        public MerchantSpaceShip(int inWeaponMounts, int inDefensiveMounts, int inEngineMounts, int inSpecialMounts):
            base(inWeaponMounts, inDefensiveMounts, inEngineMounts, inSpecialMounts)
        {
            MerchantId = GlobalMerchantId++;

            SectorFineGridLocation.X = NumberGenerator.getInstance().GetRandDoubleInRange(400, Sector.MAX_DISTANCE_FROM_AXIS - 400);
            SectorFineGridLocation.Y = NumberGenerator.getInstance().GetRandDoubleInRange(400, Sector.MAX_DISTANCE_FROM_AXIS - 400);
            SpaceShipName = "Merch: " + MerchantId;

            AllMerchants.Add(this);
        }

        public void Live()
        {
            //if (MerchantId == 120)
            //    Console.WriteLine("Tracking ship 120");
            switch (ShipState)
            {
                case MerchantSpaceShipState.Holding:
                    VerifyHold();
                    break;
                case MerchantSpaceShipState.MovingSectors:
                    CheckSectorArrival();
                    break;
                case MerchantSpaceShipState.MovingWithinSector:
                    GotoLocalWpts();
                    break;
                case MerchantSpaceShipState.Idle:
                    StartNewTask();
                    break;
                case MerchantSpaceShipState.Arrived:
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
            int i = START_SYSTEM_DISTANCE_AWAY + 1;

            SystemsToVisit = DriverLibrary.NavigationLib.GetStarSystemsInDistance(CurrentShipSector, START_SYSTEM_DISTANCE_AWAY);
            while (SystemsToVisit.Length == 0)
            {
                SystemsToVisit = DriverLibrary.NavigationLib.GetStarSystemsInDistance(CurrentShipSector, i++);
            }

            CurrentWaypoint = SystemsToVisit[NumberGenerator.getInstance().GetRandNumberInRange(0, SystemsToVisit.Length - 1)].parent;
            ShipState = MerchantSpaceShipState.MovingSectors;
            ExecuteWaypoints();

            CheckSectorArrival();
        }

        private void CheckSectorArrival()
        {
            if (SpaceShipMovementState == SpaceShipMovementEnum.None)
            {
                StarSystem[] tempStarSystems = CurrentShipSector.StarSystemsList.ToArray();
                if (tempStarSystems.Length == 0)
                {
                    ShipState = MerchantSpaceShipState.Idle;
                    return;
                }
                
                SetLocalDestinationPoint(new PointD(tempStarSystems[NumberGenerator.getInstance().GetRandNumberInRange(0, tempStarSystems.Length - 1)].StarSystemLocation));

                ShipState = MerchantSpaceShipState.MovingWithinSector;
            }
        }

        private void GotoLocalWpts()
        {
            if (SpaceShipMovementState == SpaceShipMovementEnum.None)
            {
                ShipState = MerchantSpaceShipState.Idle;
            }
            
        }

        private void ConductCommerce()
        {
            bool Status = false;
            // Make sure there are stores here, if not leave this state
            if (CurrentShipSector.RegisteredItemStores.Count == 0)
            {
                ShipState = MerchantSpaceShipState.Idle;
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
                ShipState = MerchantSpaceShipState.Idle;
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
            ShipState = MerchantSpaceShipState.Idle;
        }

        private void VerifyHold()
        {
            if (NumberGenerator.getInstance().LinearPmfResult(0.90))
            {
                ShipState = MerchantSpaceShipState.Idle;
            }
        }

        public void PerformCommerceOnSector()
        {

        }

        public override Bitmap GetSpaceShipImage()
        {
            Bitmap RotatedImage = GraphicsLib.RotateBitmap(SpaceShipImage2, DirectionVector.GetAngle());
            return RotatedImage;
        }

    }
}
