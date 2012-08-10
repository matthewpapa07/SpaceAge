using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceAge.ShipComponents
{
    class ShipScanner : Item
    {
        private static int BASE_VOL = 5;
        private static int BASE_WEIGHT = 5;
        private static int BASE_PRICE = 500;

        private static int MAX_SCAN_STRENGTH = 30;
        private static int MIN_SCAN_STRENGTH = 1;

        private static NumberGenerator numGen = NumberGenerator.getInstance();

        private static string itemName = "Ship Scanner";
        public int ScannerStrength = 10;

        private ShipScanner()
            : base()
        {
            ItemSize = ObjectCharactaristics.ItemSize.ExtraSmall;
            ItemBaseVolume = BASE_VOL;
            ItemBaseWeight = BASE_WEIGHT;
            ItemBasePrice = BASE_PRICE;
        }

        public static ShipScanner GenerateShipScanner(ObjectCharactaristics.ItemSize size)
        {
            ShipScanner retVal = new ShipScanner();

            retVal.ItemSize = size;
            retVal.ScannerStrength = (int)numGen.GetItemStatAtLevel(MIN_SCAN_STRENGTH, MAX_SCAN_STRENGTH) * ObjectCharactaristics.ItemSizeStatMultiplier[(int)size];

            return retVal;
        }

        public static ShipScanner GetBasic(ObjectCharactaristics.ItemSize size)
        {
            ShipScanner prototype = new ShipScanner();

            prototype.ItemSize = size;
            prototype.ScannerStrength = MIN_SCAN_STRENGTH * ObjectCharactaristics.ItemSizeStatMultiplier[(int)size];

            return prototype;
        }

        public override string SpecialStat()
        {
            return "Pulse Width: " + ScannerStrength.ToString();
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
