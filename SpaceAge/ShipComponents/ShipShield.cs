using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceAge.ShipComponents
{
    class ShipShield : ShipDefense
    {
        private static int BASE_VOL = 5;
        private static int BASE_WEIGHT = 5;
        private static int BASE_PRICE = 500;

        private static int BASE_MIN_DEFENSE = 1;
        private static int BASE_MAX_DEFENSE = 5;
        private static int BASE_RECHARGE_CE = 1;

        private static string itemName = "Ship Shield";

        private ShipShield()
            : base()
        {
            ItemSize = ObjectCharactaristics.ItemSize.ExtraSmall;
            ItemBaseVolume = BASE_VOL;
            ItemBaseWeight = BASE_WEIGHT;
            ItemBasePrice = BASE_PRICE;
        }

        public static ShipShield GenerateRandom(ObjectCharactaristics.ItemSize size)
        {
            ShipShield retVal = new ShipShield();

            retVal.ItemSize = size;
            retVal.BaseDefenseValue = (int)NumberGenerator.getInstance().GetItemStatAtLevel(BASE_MIN_DEFENSE, BASE_MAX_DEFENSE) * ObjectCharactaristics.ItemSizeStatMultiplier[(int)size];
            retVal.RechargeCoefficient = BASE_RECHARGE_CE * ObjectCharactaristics.ItemSizeStatMultiplier[(int)size];

            return retVal;
        }

        public static ShipShield GetBasic(ObjectCharactaristics.ItemSize size)
        {
            ShipShield prototype = new ShipShield();

            prototype.ItemSize = size;
            prototype.BaseDefenseValue = BASE_MIN_DEFENSE * ObjectCharactaristics.ItemSizeStatMultiplier[(int)size];
            prototype.RechargeCoefficient = BASE_RECHARGE_CE * ObjectCharactaristics.ItemSizeStatMultiplier[(int)size];

            return prototype;
        }

        public override string ToString()
        {
            if (this.IsGenericItem)
                return itemName;
            else
                return "Exceptional " + itemName;
        }
    }
}
