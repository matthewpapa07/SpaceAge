﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceAge
{
    partial class SpaceShip
    {
        public string SpaceShipName = "TODO:Name";
        SpaceShipConstant.SpaceShipClass SpaceShipClass = SpaceShipConstant.SpaceShipClass.Generic;
        SpaceShipConstant.SpaceShipSize SpaceShipSize = SpaceShipConstant.SpaceShipSize.Medium;

    }

    static class SpaceShipConstant
    {
        //
        // Commonly Associated with SpaceShip
        //
        public enum SpaceShipClass { Generic, Merchant };
        public static string[] SpaceShipClassString = { "Generic", "Merchant" };

        public static string[] SpaceShipSizeString = { "XS", "S", "M", "L", "XL", "N/A" };
        public enum SpaceShipSize { ExtraSmall, Small, Medium, Large, ExraLarge, NoSize };
        //public static int[] ItemSizeStatMultiplier = { 1, 3, 10, 25, 50, 1 };
        //public static int[] ItemSizeStatDivider = { 5, 4, 3, 2, 1, 1 };
    }
}