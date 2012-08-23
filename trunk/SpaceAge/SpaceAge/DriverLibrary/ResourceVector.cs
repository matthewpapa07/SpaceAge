using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceAge
{
    class ResourceVector
    {
        public static double BUY_BASE_PRICE_MAX_PERCENT = 1.75;
        public static double SELL_BASE_PRICE_MAX_PERCENT = 2.15;
        public enum VectorTypeEnum { BuyVector, SellVector };
        public VectorTypeEnum VectorType;
        public Commodity.CommodityEnum TypeOfCommodity;
        public ItemStore WhichStore;

        public int Quantity;
        public int Price;

        private ResourceVector(Commodity.CommodityEnum inTypeOfCommodity, ItemStore inWhichStore, VectorTypeEnum inVectorType)
        {
            TypeOfCommodity = inTypeOfCommodity;
            WhichStore = inWhichStore;
            Quantity = WhichStore.CommoditiesAvailable(TypeOfCommodity);
            VectorType = inVectorType;
            if(VectorType == VectorTypeEnum.BuyVector)
                Price = WhichStore.QueryCommodityUserBuyPrice(inTypeOfCommodity);
            if(VectorType == VectorTypeEnum.SellVector)
                Price = WhichStore.QueryCommodityUserSellPrice(inTypeOfCommodity);
        }

        public static ResourceVector GetBestBuyPriceForCommodity(Commodity.CommodityEnum CommodityType, Sector InSector)
        {
            ItemStore TargetStore = null;
            int RunningPrice = 0;

            if (InSector.RegisteredItemStores.Count == 0)
            {
                return null;
            }

            TargetStore = InSector.RegisteredItemStores[0];
            RunningPrice = InSector.RegisteredItemStores[0].QueryCommodityUserBuyPrice(CommodityType);

            for (int i = 1; i < InSector.RegisteredItemStores.Count; i++)
            {
                if (InSector.RegisteredItemStores[i].QueryCommodityUserBuyPrice(CommodityType) < RunningPrice)
                {
                    TargetStore = InSector.RegisteredItemStores[i];
                    RunningPrice = InSector.RegisteredItemStores[i].QueryCommodityUserBuyPrice(CommodityType);
                }
            }

            return new ResourceVector(CommodityType, TargetStore, VectorTypeEnum.BuyVector);
        }

        public static ResourceVector GetBestSellPriceForCommodity(Commodity.CommodityEnum CommodityType, Sector InSector)
        {
            ItemStore TargetStore = null;
            int RunningPrice = 0;

            if (InSector.RegisteredItemStores.Count == 0)
            {
                return null;
            }

            RunningPrice = 0;
            TargetStore = InSector.RegisteredItemStores[0]; // Return the only one for now....

            for (int i = 0; i < InSector.RegisteredItemStores.Count; i++)
            {
                if ((InSector.RegisteredItemStores[i].CanUserSellCommodity(CommodityType)) && (InSector.RegisteredItemStores[i].QueryCommodityUserBuyPrice(CommodityType) > RunningPrice))
                {
                    TargetStore = InSector.RegisteredItemStores[i];
                    RunningPrice = InSector.RegisteredItemStores[i].QueryCommodityUserSellPrice(CommodityType);
                }
            }

            return new ResourceVector(CommodityType, TargetStore, VectorTypeEnum.SellVector);
        }

        public int HowManyCanBuy()
        {
            if (VectorType == VectorTypeEnum.SellVector)
                throw new Exception();

            return WhichStore.CommoditiesAvailable(TypeOfCommodity);
        }

        public int HowManyCanSell()
        {
            if (VectorType == VectorTypeEnum.BuyVector)
                throw new Exception();

            return Commodity.getCommodityFromEnum(TypeOfCommodity).MaxQuantity - WhichStore.CommoditiesAvailable(TypeOfCommodity);
        }

        public bool DecideIfGoodSellPrice()
        {
            double TempPrice = Commodity.getCommodityFromEnum(TypeOfCommodity).BaseValue * SELL_BASE_PRICE_MAX_PERCENT;
            if (VectorType == VectorTypeEnum.BuyVector)
                throw new Exception();

            if (Price >= TempPrice)
            {
                return true;
            }
            else
                return false;
        }

        public bool DecideIfGoodBuyPrice()
        {
            double TempPrice = Commodity.getCommodityFromEnum(TypeOfCommodity).BaseValue * BUY_BASE_PRICE_MAX_PERCENT;
            if (VectorType == VectorTypeEnum.SellVector)
                throw new Exception();

            if (Price <= TempPrice)
            {
                return true;
            }
            else
                return false;
        }
    }
}
