using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceAge.ShipComponents
{
    class ShipMassDriver : ShipWeapon
    {
        private static int BASE_VOL = 5;
        private static int BASE_WEIGHT = 5;
        private static int BASE_PRICE = 500;

        private static int BASE_RATE_OF_FIRE = 10;
        private static int BASE_MIN_DAMAGE = 1;
        private static int BASE_MAX_DAMAGE = 2;

        private static string itemName = "Mass Driver Cannon";

        private ShipMassDriver()
            : base()
        {
            ItemSize = ObjectCharactaristics.ItemSize.ExtraSmall;
            ItemBaseVolume = BASE_VOL;
            ItemBaseWeight = BASE_WEIGHT;
            ItemBasePrice = BASE_PRICE;
        }

        public static ShipMassDriver GenerateRandom(ObjectCharactaristics.ItemSize size)
        {
            ShipMassDriver retVal = new ShipMassDriver();

            retVal.ItemSize = size;
            retVal.BaseDamage = (int)NumberGenerator.getInstance().GetItemStatAtLevel(BASE_MIN_DAMAGE, BASE_MAX_DAMAGE) * ObjectCharactaristics.ItemSizeStatMultiplier[(int)size];
            retVal.BaseRateOfFire = BASE_RATE_OF_FIRE * ObjectCharactaristics.ItemSizeStatDivider[(int)size];

            return retVal;
        }

        public static ShipMassDriver GetBasic(ObjectCharactaristics.ItemSize size)
        {
            ShipMassDriver prototype = new ShipMassDriver();

            prototype.ItemSize = size;
            prototype.BaseDamage = BASE_MIN_DAMAGE * ObjectCharactaristics.ItemSizeStatMultiplier[(int)size];
            prototype.BaseRateOfFire = BASE_RATE_OF_FIRE * ObjectCharactaristics.ItemSizeStatDivider[(int)size];

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
