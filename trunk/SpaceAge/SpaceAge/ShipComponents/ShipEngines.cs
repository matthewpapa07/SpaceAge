using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceAge.ShipComponents
{
    class ShipEngines : Item
    {
        private static int BASE_VOL = 5;
        private static int BASE_WEIGHT = 5;
        private static int BASE_PRICE = 500;

        private static int BASE_MAX_DRIVE_STRENGTH = 100;
        private static int BASE_MIN_DRIVE_STRENGTH = 1;
        private static int BASE_WARP_POWER = 1;

        private static NumberGenerator numGen = NumberGenerator.getInstance();

        private static string itemName = "Ship Engines";
        public int DrivePower = 1;
        public int WarpPower = 1;

        private ShipEngines()
            : base()
        {
            ItemSize = ObjectCharactaristics.ItemSize.ExtraSmall;
            ItemBaseVolume = BASE_VOL;
            ItemBaseWeight = BASE_WEIGHT;
            ItemBasePrice = BASE_PRICE;  
        }

        public static ShipEngines GenerateRandom(ObjectCharactaristics.ItemSize size)
        {
            ShipEngines retVal = new ShipEngines();

            retVal.ItemSize = size;
            retVal.DrivePower = (int)numGen.GetItemStatAtLevel(BASE_MIN_DRIVE_STRENGTH, BASE_MAX_DRIVE_STRENGTH) * ObjectCharactaristics.ItemSizeStatMultiplier[(int)size];
            retVal.WarpPower = BASE_WARP_POWER * ObjectCharactaristics.ItemSizeStatMultiplier[(int)size];

            return retVal;
        }

        public static ShipEngines GetBasic(ObjectCharactaristics.ItemSize size)
        {
            ShipEngines prototype = new ShipEngines();

            prototype.ItemSize = size;
            prototype.DrivePower = BASE_MIN_DRIVE_STRENGTH * ObjectCharactaristics.ItemSizeStatMultiplier[(int)size];
            prototype.WarpPower = BASE_WARP_POWER * ObjectCharactaristics.ItemSizeStatMultiplier[(int)size];

            return prototype;
        }

        public override string SpecialStat()
        {
            return "Drive Power: "+ DrivePower.ToString();
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
