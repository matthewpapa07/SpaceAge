using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceAge.ShipComponents
{
    class ShipMissileLauncher : ShipWeapon
    {
        private static int BASE_VOL = 5;
        private static int BASE_WEIGHT = 5;
        private static int BASE_PRICE = 500;

        private static int BASE_RATE_OF_FIRE = 1;
        private static int BASE_MIN_DAMAGE = 1;
        private static int BASE_MAX_DAMAGE = 10;

        private static string itemName = "Missile Launcher";

        private ShipMissileLauncher()
            : base()
        {
            ItemSize = ObjectCharactaristics.ItemSize.ExtraSmall;
            ItemBaseVolume = BASE_VOL;
            ItemBaseWeight = BASE_WEIGHT;
            ItemBasePrice = BASE_PRICE;
        }

        public static ShipMissileLauncher GenerateRandom(ObjectCharactaristics.ItemSize size)
        {
            ShipMissileLauncher retVal = new ShipMissileLauncher();

            retVal.ItemSize = size;
            retVal.BaseDamage = (int)NumberGenerator.getInstance().GetItemStatAtLevel(BASE_MIN_DAMAGE, BASE_MAX_DAMAGE) * ObjectCharactaristics.ItemSizeStatMultiplier[(int)size];
            retVal.BaseRateOfFire = BASE_RATE_OF_FIRE * ObjectCharactaristics.ItemSizeStatDivider[(int)size];

            return retVal;
        }

        public static ShipMissileLauncher GetBasic(ObjectCharactaristics.ItemSize size)
        {
            ShipMissileLauncher prototype = new ShipMissileLauncher();

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
