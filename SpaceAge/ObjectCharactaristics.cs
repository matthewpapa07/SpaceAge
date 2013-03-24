using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace SpaceAge
{

    static class ObjectCharactaristics
    {
        /// <summary>
        /// Stuff to have happen on first class usage
        /// </summary>
        static ObjectCharactaristics()
        {
            StaticGraphics staticGraphics = StaticGraphics.getStaticGraphics();

        }



        public static string[] StarSizeString = { "Dwarf", "Micro", "Normal", "Medium", "Giant", "Ultra Giant" };
        public enum StarSize { Dwarf, Micro, Normal, Medium, Giant, UltraGiant};
//        public static int [] StarSizeValues = {1000,2000,23432};  //TODO: Size Values

        //
        // Charactaristics Associated with Planets
        //
        public static string[] PlanetSizeString = { "Asteroid", "Very Small", "Small", "Medium", "Large", "Super" };
        public enum PlanetSize { Asteroid, VerySmall, Small, Medium, Large, Super };    // Size of the planet
//        public static int[] SizeValues = { 1000, 2000, 23432 };  //TODO: Size Values

        public static string[] PositionString = { "Inner", "Middle", "Outer", "Rogue" };
        public enum Position { Inner, Middle, Outer, Rogue };                     // Position of planet from star

        ////
        //// Common resources on planet.
        ////  ALSO UPDATE THE COMMODITY ENTRY WHEN UPDATING
        ////
        //public static string[] CommonAtmosphereString = { "Oxygen", "Hydrogen", "Methane", "SulphuricAcid", "CarbonDioxide", "Nitrogen", "Chlorine", "Helium"};
        //public enum CommonAtmosphere { Oxygen = 0, Hydrogen, Methane, SulphuricAcid, CarbonDioxide, Nitrogen, Chlorine, Helium };
        //public static Commodity.CommodityEnum CommonAtmosphereToC(CommonAtmosphere ca)
        //{
        //    return Commodity.CommodityEnum.Oxygen + (int)ca;
        //}

        //public static string[] RareAtmosphereString = { "Boron", "Neon", "Xenon", "Krypton" };
        //public enum RareAtmosphere { Boron = 0, Neon, Xenon, Krypton };
        //public static Commodity.CommodityEnum RareAtmosphereToC(RareAtmosphere ra)
        //{
        //    return Commodity.CommodityEnum.Boron + (int)ra;
        //}

        //public static string[] CommonElementsString = { "Silicon", "Iron", "Carbon", "Copper", "Magnesium", "Sodium", "Sulfur", "Lead", "Nickel", "Amuninum" };
        //public enum CommonElements { Silicon = 0, Iron, Carbon, Copper, Magnesium, Sodium, Sulfur, Lead, Nickel, Amuninum };
        //public static Commodity.CommodityEnum CommonElementToC(CommonElements ce)
        //{
        //    return Commodity.CommodityEnum.Silicon + (int)ce;
        //}

        //public static string[] RareElementsString = { "Titanium", "Neodymium", "Germanium", "Gallium", "Arsenic", "Strontium", "Gold", "Silver", "Platinum" };
        //public enum RareElements { Titanium = 0, Neodymium, Germanium, Gallium, Arsenic, Strontium, Gold, Silver, Platinum };
        //public static Commodity.CommodityEnum RareElementToC(RareElements re)
        //{
        //    return Commodity.CommodityEnum.Titanium + (int)re;
        //}

        //public static string[] ResourcesStaticString = { "Hydrocarbons", "Cellulose", "Acid", "Biomass", "Mud", "Water", "Minerals" };
        //public enum ResourcesStatic  { Hydrocarbons = 0, Cellulose, Acid, Biomass, Mud, Water, Minerals };
        //public static Commodity.CommodityEnum ResourcesStaticToC(ResourcesStatic rs)
        //{
        //    return Commodity.CommodityEnum.Hydrocarbons + (int)rs;
        //}

        // Finally an enum to give the right offset for each enum
        public enum ResourceCommodityType { CommonAtmosphere = 0, RareAtmosphere, CommonElement, RareElement, ResourceStatic };

        //
        // Charactaristics assocaited with items
        //
        public static string[] ItemSizeStaticString = { "Extra Small", "Small", "Medium", "Large", "Extra Large", "N/A" };
        public enum ItemSize { ExtraSmall, Small, Medium, Large, ExraLarge, NoSize };
        public static int [] ItemSizeStatMultiplier = { 1, 3, 10, 25, 50, 1 };
        public static int[] ItemSizeStatDivider = { 5, 4, 3, 2, 1, 1 };

    }

}
